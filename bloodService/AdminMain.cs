using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace bloodService
{
    public partial class AdminMain : Form
    {
        string conStr = @"Data Source= ADCLG1; Initial catalog=Kuryleva_4194; Integrated Security=True";
        SqlConnection sqlCon;
        public int id { get; set; }
        public AdminMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Enter en = new Enter();    
            this.Close();
            en.Show();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kuryleva_4194DataSet.UsersEnter". При необходимости она может быть перемещена или удалена.
            this.usersEnterTableAdapter.Fill(this.kuryleva_4194DataSet.UsersEnter);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kuryleva_4194DataSet1.UsersEnter". При необходимости она может быть перемещена или удалена.
            this.usersEnterTableAdapter1.Fill(this.kuryleva_4194DataSet1.UsersEnter);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kuryleva_4194DataSet.UsersEnter". При необходимости она может быть перемещена или удалена.
            this.usersEnterTableAdapter.Fill(this.kuryleva_4194DataSet.UsersEnter);
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

            label1.Text = "Администратор";
            label2.Text = cmd2.ExecuteScalar().ToString();

            sqlCon.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand("select login, lastEnter, enterResult from UsersEnter where login like '%" + textBox1.Text + "%'", con);
                    con.Open();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else { MessageBox.Show("Введите логин"); }
        }
    }
}
