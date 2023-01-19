using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace bloodService
{
    public partial class AssistantExplorerMain : Form
    {
        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";
        SqlConnection sqlCon;
        DataSet ds;
        SqlDataAdapter adapter;

        string sql = "select * from AnalyzeServices";

        private int min = 10; // стандартно 150
        public int id { get; set; }

        Enter en = new Enter();
        public AssistantExplorerMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            en.Show();
        }

        private void AssistantExplorerMain_Load(object sender, EventArgs e)
        {
			// TODO: данная строка кода позволяет загрузить данные в таблицу "bloodServiceDataSet1.AnalyzeServices". При необходимости она может быть перемещена или удалена.
			this.analyzeServicesTableAdapter.Fill(this.bloodServiceDataSet1.AnalyzeServices);
			using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();

                string cmdStr = "Select image from UsersEnter where id = '" + id + "'";
                string cmdStr2 = "Select fullname from UsersEnter where id = '" + id + "'";
                SqlCommand cmd1 = new SqlCommand(cmdStr, sqlCon);
                SqlCommand cmd2 = new SqlCommand(cmdStr2, sqlCon);
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

                label1.Text = "Лаборант-исследователь";
                label2.Text = cmd2.ExecuteScalar().ToString();
                sqlCon.Close();
            }
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

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    try
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value != null || dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            TimeSpan diff1 = ((DateTime)dataGridView1.Rows[i].Cells[1].Value).Subtract((DateTime)dataGridView1.Rows[i].Cells[0].Value);
                            dataGridView1.Rows[i].Cells[2].Value = diff1;
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }
                }
            }
        }

		private void button2_Click_1(object sender, EventArgs e)
		{
            try
            {
                this.analyzeServicesTableAdapter.Update(this.bloodServiceDataSet1.AnalyzeServices);
                MessageBox.Show("Успешно сохранено!");
            }
            catch (Exception ex) { 
                MessageBox.Show("Изменения не были сохранены!\n\n" + ex.Message);
            }
        }
    }
}
