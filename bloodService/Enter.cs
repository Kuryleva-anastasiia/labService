using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bloodService
{
    public partial class Enter : Form
    {
        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";

        SqlDataAdapter da;
        DataSet ds;
        SqlConnection sqlCon;

        int min = 1; // стандартно 30

        public int userId { get; set; }
        public Enter()
        {
            InitializeComponent();

		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                string cmdStrHistory;
                string login = textBox1.Text;
                try
                {

                    sqlCon = new SqlConnection(conStr);
                    string cmdStr = "Select role from UsersEnter where login = '" + login + "' and password = '" + textBox2.Text + "'";
                    string cmdStrId = "Select id from UsersEnter where login = '" + login + "' and password = '" + textBox2.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(cmdStr, sqlCon);
                    SqlCommand cmd2 = new SqlCommand(cmdStrId, sqlCon);

                    sqlCon.Open();

                    string role = cmd1.ExecuteScalar().ToString();
                    userId = Convert.ToInt32(cmd2.ExecuteScalar());

                    cmdStrHistory = "insert into enterHistory values ('" + login + "','" + DateTime.Now + "', 1)";
                    SqlCommand cmdHistory = new SqlCommand(cmdStrHistory, sqlCon);
                    cmdHistory.ExecuteNonQuery();


                    switch (role)
                    {
                        case "assistant":
                            AssistantMain am = new AssistantMain();
                            am.id = userId;
                            am.AssistantTimer();
                            this.Hide();
                            am.Show();
                            break;
                        case "admin":
                            AdminMain a = new AdminMain();
                            a.id = userId;
                            this.Hide();
                            a.Show();
                            break;
                        case "accountant":
                            AccountantMain acm = new AccountantMain();
                            acm.id = userId;
                            this.Hide();
                            acm.Show();
                            break;
                        case "patient":
                            PatientsMain pm = new PatientsMain();
                            pm.id = userId;
                            this.Hide();
                            pm.Show();
                            break;
                        case "assistantExplorer":
                            AssistantExplorerMain aem = new AssistantExplorerMain();
                            aem.AssistantTimer();
                            aem.id = userId;
                            this.Hide();
                            aem.Show();
                            break;
                    }
                }
                catch {
                    cmdStrHistory = "insert into enterHistory values ('" + login + "','" + DateTime.Now + "', '0')";
                    SqlCommand cmdHistory = new SqlCommand(cmdStrHistory, sqlCon);

                    cmdHistory.ExecuteNonQuery();
                    sqlCon.Close();

                    MessageBox.Show("Неверный логин или пароль");
                    textBox2.Text = "";
                }
            }else
            {
                MessageBox.Show("Заполните поля для логина и пароля!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar == true)
                textBox2.UseSystemPasswordChar = false;
            else textBox2.UseSystemPasswordChar = true;
        }

        private void Enter_Load(object sender, EventArgs e)
        {
            
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
            min--;
            label3.Text = $"{min}мин.";
            if (min == 0)
            {
                timer1.Stop();
                label3.Visible = false;
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        public void Block()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            timer1.Start();
            label3.Visible = true;
        }
    }
}

// Код для добавления картинки в бд


//      using (SqlConnection connection = new SqlConnection(conStr)) // создаем подключение
//            {
//                OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
//                openFileDialog.ShowDialog(); // показываем
//                byte[] image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла

//                connection.Open(); // откроем подключение
//                SqlCommand command = new SqlCommand(); // создадим запрос
//                command.Connection = connection; // дадим запросу подключение
//                command.CommandText = @"UPDATE UsersEnter SET [image] = @ImageData WHERE id = 20"; // пропишем запрос
//                command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);
//                command.Parameters["@ImageData"].Value = image_bytes;// скалярной переменной ImageData присвоем массив байтов
//                command.ExecuteNonQuery(); // запустим
//            }