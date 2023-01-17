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

        string conStr = @"Data Source= ADCLG1; Initial catalog=Kuryleva_4194; Integrated Security=True";
        SqlConnection sqlCon;

        public biomaterial()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(conStr);
            string cmdStr1 = "select id from UsersEnter";
            SqlCommand cmd1 = new SqlCommand(cmdStr1, sqlCon);
            SqlDataReader read;
            sqlCon.Open();
            read = cmd1.ExecuteReader();

            while (read.Read())
            {
                comboBox1.Items.Add(read[0]);
            }
            sqlCon.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //sqlCon = new SqlConnection(conStr);
            //string cmdStr1 = "insert into Orders values ('" + DateTime.Now + "', ";
            //SqlCommand cmd1 = new SqlCommand(cmdStr1, sqlCon);
        }
    }
}
