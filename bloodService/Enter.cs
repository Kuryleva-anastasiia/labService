using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bloodService
{
    public partial class Enter : Form
    {
        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";

        SqlDataAdapter da;
        DataSet ds;
        SqlConnection sqlCon;

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
                try
                {
                    sqlCon = new SqlConnection(conStr);
                    string cmdStr = "Select role from UsersEnter where login = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                    string cmdStrId = "Select id from UsersEnter where login = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(cmdStr, sqlCon);
                    SqlCommand cmd2 = new SqlCommand(cmdStrId, sqlCon);
                    sqlCon.Open();
                    string role = cmd1.ExecuteScalar().ToString();
                    userId = Convert.ToInt32(cmd2.ExecuteScalar());
                    sqlCon.Close();
                    
                    switch (role)
                    {
                        case "assistant":
                            AssistantMain am = new AssistantMain();
                            am.id = userId;
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
                            aem.id = userId;
                            this.Hide();
                            aem.Show();
                            break;
                    }
                }
                catch {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }else
            {
                MessageBox.Show("Заполните поля логина и пароля!");
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