using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace bloodService
{
    public partial class AccountantMain : Form
    {
        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";
        SqlConnection sqlCon;

        public int id { get; set; }
        Enter en = new Enter();

        public AccountantMain()
        {
            InitializeComponent();
        }

        private void AccountantMain_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(conStr);
            string cmdStr = "Select image, role from UsersEnter where id = '" + id + "'";
            string cmdStr2 = "Select fullname from UsersEnter where id = '" + id + "'";
            SqlCommand cmd1 = new SqlCommand(cmdStr, sqlCon);
            SqlCommand cmd2 = new SqlCommand(cmdStr2, sqlCon);
            sqlCon.Open();
            SqlDataReader reader;
            reader = cmd1.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    byte[] byteArray = new byte[0];
                    byteArray = (byte[])reader[0];
                    MemoryStream ms = new MemoryStream(byteArray);
                    this.pictureBox1.Image = Image.FromStream(ms);
                }
            }
            catch
            {
                MessageBox.Show("Картинки нет в базе данных");

            }

            sqlCon.Close();
            sqlCon.Open();
            label1.Text = "Бухгалтер";
            label2.Text = cmd2.ExecuteScalar().ToString();
            sqlCon.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            en.Show();
        }
    }
}
