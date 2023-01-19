using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bloodService
{
    public partial class biomaterial : Form
    {
        public int id { get; set; }

        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";
        SqlConnection sqlCon;

        public biomaterial()
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

                foreach (string service in checkedListBox1.CheckedItems)
                {
                    string str = $"select id from LabServices where name = '{service}'";
                    SqlCommand cmdStr = new SqlCommand(str, sqlCon);
                    int serviceId = Convert.ToInt32(cmdStr.ExecuteScalar());

                    string cmdStrInsertService = $"insert into ListOfServices values('{orderId}', '{serviceId}')";
                    SqlCommand cmdInsertService = new SqlCommand(cmdStrInsertService, sqlCon);
                    cmdInsertService.ExecuteNonQuery();
                }
                MessageBox.Show("Биоматериал успешно добавлен!\nЗаказ был сформирован!");
            }
            sqlCon.Close();

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
	}
}
