using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace bloodService
{
    
    public partial class PatientsMain : Form
    {
        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";
        SqlConnection sqlCon;
        public int id { get; set; }

        public PatientsMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Enter en = new Enter();
            this.Close();
            en.Show();
        }

        private void PatientsMain_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(conStr);
            string cmdStr = "Select image from UsersEnter where id = '" + id + "'";
            string cmdStr2 = "Select fullname from UsersEnter where id = '" + id + "'";
            SqlCommand cmd1 = new SqlCommand(cmdStr, sqlCon);
            SqlCommand cmd2 = new SqlCommand(cmdStr2, sqlCon);
            sqlCon.Open();

            try
            {
                byte[] img = (byte[])cmd1.ExecuteScalar();
                MemoryStream ms = new MemoryStream(img);
                this.pictureBox1.Image = Image.FromStream(ms);
            }
            catch
            {
                MessageBox.Show("Картинки нет в базе данных");
            }

            label1.Text = "Пациент";
            label2.Text = cmd2.ExecuteScalar().ToString();

            sqlCon.Close();
        }
    }
}
