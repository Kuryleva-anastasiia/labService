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
	public partial class AddPatients : Form
	{
		public int id { get; set; }

		string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";
		SqlConnection sqlCon;

		public AddPatients()
		{
			InitializeComponent();
		}

		private void AddPatients_Load(object sender, EventArgs e)
		{
			sqlCon = new SqlConnection(conStr);
			string cmdStrCompanies = "select name from PolicyCompanyData";
			SqlCommand cmdCompanies = new SqlCommand(cmdStrCompanies, sqlCon);

			sqlCon.Open();

			SqlDataReader reader = cmdCompanies.ExecuteReader();
			while (reader.Read())
			{
				comboBox2.Items.Add(reader.GetString(0));
			}
			reader.Close();

			sqlCon.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Biomaterial bm = new Biomaterial();
			bm.id = id;
			bm.Show();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			sqlCon = new SqlConnection(conStr);

			sqlCon.Open();

			string cmdStrUser = $"insert into UsersEnter (role, fullname) values ('patient', '{textBox1.Text}')";
			SqlCommand cmdUser = new SqlCommand(cmdStrUser, sqlCon);
			cmdUser.ExecuteNonQuery();

			string cmdStrId = "select IDENT_CURRENT('UsersEnter');";
			SqlCommand cmdId = new SqlCommand(cmdStrId, sqlCon);
			int userId = Convert.ToInt32(cmdId.ExecuteScalar());

			string cmdStrCompanyId = "select id from PolicyCompanyData where name = '" + comboBox2.Text + "'";
			SqlCommand cmdCompanyId = new SqlCommand(cmdStrCompanyId, sqlCon);
			int companyId = Convert.ToInt32(cmdCompanyId.ExecuteScalar());

			string cmdStrPatient = $"insert into PatientsData values ('{userId}', '{dateTimePicker1.Value}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{comboBox1.Text}', {companyId})";
			SqlCommand cmdPatient = new SqlCommand(cmdStrPatient, sqlCon);
			cmdPatient.ExecuteNonQuery();

			sqlCon.Close();

			MessageBox.Show("Новый пациент добавлен!");

			Biomaterial bm = new Biomaterial();
			bm.id = id;
			bm.Show();
			this.Close();
		}
	}
}
