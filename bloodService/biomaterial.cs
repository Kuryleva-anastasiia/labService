using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using PriceCounter;

namespace bloodService
{
    public partial class Biomaterial : Form
    {
        public int id { get; set; }

        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";
        SqlConnection sqlCon;
		

		public Biomaterial()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(conStr);
            string cmdStr1 = "select fullname from UsersEnter where role = 'patient'";
            SqlCommand cmd1 = new SqlCommand(cmdStr1, sqlCon);
            SqlDataReader read;

            string cmdStr2 = "select name from LabServices";
            SqlCommand cmd2 = new SqlCommand(cmdStr2, sqlCon);
            SqlDataReader read2;

            string cmdStr3 = "select IDENT_CURRENT('Orders');";
            SqlCommand cmd3 = new SqlCommand(cmdStr3, sqlCon);

            sqlCon.Open();

            read = cmd1.ExecuteReader();
            //список пользователей
            while (read.Read())
            {
                comboBox1.Items.Add(read[0]);
            }
            read.Close();

            read2 = cmd2.ExecuteReader();
            //список услуг
            while (read2.Read())
            {
                checkedListBox1.Items.Add(read2[0]);
            }
            read2.Close();

            //id следующего заказа
            int id = Convert.ToInt32(cmd3.ExecuteScalar());
            comboBox2.Items.Add(id + 1);

            sqlCon.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdStrUser = "select id from UsersEnter where fullname = '" + comboBox1.Text + "'";
            string cmdStrAllId = "select id from Orders";

            SqlCommand cmdUser = new SqlCommand(cmdStrUser, sqlCon);
            SqlCommand cmdAllId = new SqlCommand(cmdStrAllId, sqlCon);

            sqlCon.Open();
            SqlDataReader reader = cmdAllId.ExecuteReader();
            int orderId = Convert.ToInt32(comboBox2.Text);
            bool flag = false;
            int count = 0;
            try
            {
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader[0]) == orderId)
                    {
                        flag = true;
                        throw new Exception();
                    }
                    count++;
                }
            }
            catch (Exception ex) { MessageBox.Show("Заказ с таким идентификатором уже существует!\n" + ex.Message); }

            reader.Close();

            if (flag == false)
            {
                int id = Convert.ToInt32(cmdUser.ExecuteScalar());
                string cmdStrInsertBio = $"insert into Biomaterials values('{orderId}{DateTime.Today.Day}{DateTime.Today.Month}{DateTime.Today.Year}123456', '{orderId}', '{id}')";
                SqlCommand cmdInsertBio = new SqlCommand(cmdStrInsertBio, sqlCon);
                cmdInsertBio.ExecuteNonQuery();

                string cmdStrInsertOrder = $"insert into Orders values('{DateTime.Now}', '{orderId}', 'InProcess', 'InProcess', '{count}')";
                SqlCommand cmdInsertOrder = new SqlCommand(cmdStrInsertOrder, sqlCon);
                cmdInsertOrder.ExecuteNonQuery();

                var services = new List<string>();
                var prices = new List<double>();
                double totalPrice = 0;

                foreach (string service in checkedListBox1.CheckedItems)
                {
                    string str = "select id from LabServices where name = '" + service + "'";
                    SqlCommand cmdStr = new SqlCommand(str, sqlCon);
                    int serviceId = Convert.ToInt32(cmdStr.ExecuteScalar());

                    string strPrice = "select price from LabServices where id = '" + serviceId + "'";
                    SqlCommand cmdPrice = new SqlCommand(strPrice, sqlCon);
                    double price = Convert.ToDouble(cmdPrice.ExecuteScalar());
                    totalPrice += price;

                    string cmdStrInsertService = $"insert into ListOfServices values('{orderId}', '{serviceId}')";
                    SqlCommand cmdInsertService = new SqlCommand(cmdStrInsertService, sqlCon);
                    cmdInsertService.ExecuteNonQuery();

                    services.Add(service);
                    prices.Add(price);
                }
                MessageBox.Show("Биоматериал успешно добавлен!\nЗаказ был сформирован!");

                string cmdStrUserInfo = $"select policyN, birthdate from PatientsData where userId = '{id}'";
                SqlCommand sqlUserInfo = new SqlCommand(cmdStrUserInfo, sqlCon);
                SqlDataReader reader2 = sqlUserInfo.ExecuteReader();
                reader2.Read();
                try
                {
					//File.AppendAllText(@"C:\College\ТРПО\labService\Check" + orderId + ".txt", $"Дата заказа: {DateTime.Now}\nНомер заказа: {orderId}\nНомер пробирки: {orderId}{DateTime.Today.Day}{DateTime.Today.Month}{DateTime.Today.Year}123456\nНомер страхового полиса: {reader2[0]}\nФИО: {comboBox1.Text}\nДата рождения: {reader2[1]}");
					string vialnumber = $"{orderId}{DateTime.Today.Day}{DateTime.Today.Month}{DateTime.Today.Year}123456";
                    //foreach (string ser in services)
                    //{
                    //    File.AppendAllText(@"C:\College\ТРПО\labService\Check" + orderId + ".txt", "\nУслуга: " + ser);
                    //}

                    makeOrdersPDF(orderId, vialnumber, reader2[0].ToString(), comboBox1.Text, (DateTime)reader2[1], services, Price.Count(prices));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                reader2.Close();

                
            }
            sqlCon.Close();

            AssistantMain am = new AssistantMain();
            am.id = id;
            am.Show();
            this.Close();
        }

        private List<string> printArgs;
        private Font mainFont = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular);

        private void makeOrdersPDF(int orderNumber, string vialNumber, string insurNumber, string name, DateTime birthday, List<string> services, double price)
        {
            PrintDocument pdf = new PrintDocument();

            string servicesStr = "";
            foreach (string i in services)
            {
                servicesStr += i + " | ";
            }

            printArgs = new List<string>()
            {
                "Номер заказа: " + orderNumber.ToString(),
                "Дата заказа: " + DateTime.Now.ToLongDateString(),
                "Номер пробирки: " + vialNumber,
                "Номер страхового полиса: " + insurNumber,
                "ФИО пациента: " + name,
                "Дата рождения: " + birthday.ToLongDateString(),
                "Услуги: " + servicesStr,
                $"Стоимость: {Math.Round(price, 2)} руб."
            };

            pdf.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);

            PrintDialog dialog = new PrintDialog();
            dialog.Document = pdf;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.Document.Print();
                MessageBox.Show("Чек создан!", "Upload to pdf");
            }
        }

        private void PrintTextFileHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            Graphics graph = ppeArgs.Graphics;

            for (int i = 0; i < printArgs.Count; i++)
            {
                string line = printArgs[i];
                graph.DrawString(line, mainFont, Brushes.Black, 50, 50 + (i * mainFont.GetHeight(graph)), new StringFormat());
            }
        }

        private void biomaterial_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
            AssistantMain am = new AssistantMain();
            am.id = id;
            am.Show();
            this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
            AddPatients ap = new AddPatients();
            ap.id = id;
            ap.Show();
            this.Close();
		}
	}
}
