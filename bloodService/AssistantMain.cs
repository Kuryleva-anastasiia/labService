using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace bloodService
{
    public partial class AssistantMain : Form
    {
        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";
        SqlConnection sqlCon;
        public int id { get; set; }
        private int min = 10; // стандартно 150

        Enter en = new Enter();

        public AssistantMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            en.Show();
        }

        private void AssistantMain_Load(object sender, EventArgs e)
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

            label1.Text = "Лаборант";
            label2.Text = cmd2.ExecuteScalar().ToString();

            sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            biomaterial b = new biomaterial();
            b.id = id;
            b.Show();
            this.Hide();
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
            min--;
            int hour = min / 60;
            int minute = min - hour * 60;
            label3.Text = $"{hour}ч. {minute}мин.";

            if (min == 5) // стандартно 15 мин
            {
                MessageBox.Show("Окончание времени сеанса", "Уведомление");
            }
            if (min == 0)
            {
                en.Block();
                en.Show();
                this.Close();
            }
        }

        public void AssistantTimer()
        {
            timer1.Start();
            label3.Text = $"{min / 60}ч. {min - (min / 60) * 60}мин.";
            label3.Visible = true;
        }

		private void button3_Click(object sender, EventArgs e)
		{
            try
            {
                File.WriteAllText(@"C:\College\ТРПО\labService\AssistantReport.txt", "Отчет");
                MessageBox.Show("Отчет создан", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
	}
}
