using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace bloodService
{
    public partial class Enter : Form
    {
        string conStr = @"Data Source= LAPTOP-T1QLKLDI\SQLEXPRESS; Initial catalog=BloodService; Integrated Security=True";

        SqlDataAdapter da;
        DataSet ds;
        SqlConnection sqlCon;

        int min = 2; // стандартно 30
        int sec = 10;

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
            bool captcha = true;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (pictureBox1.Visible == true) {
                    if (textBox3.Text != this.text)
                    {
                        MessageBox.Show("Ошибка при вводе текста с картинки!\nВозможность входа заблокирована на 10 секунд");
                        captcha = false;
                        timer2.Start();
                        button1.Enabled = false;
                        button2.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                    }
                    
                }
                if (captcha == true) {
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

                        pictureBox1.Visible = false;
                        label5.Visible = false;
                        textBox3.Visible = false;
                        button4.Visible = false;

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
                    catch
                    {
                        cmdStrHistory = "insert into enterHistory values ('" + login + "','" + DateTime.Now + "', '0')";
                        SqlCommand cmdHistory = new SqlCommand(cmdStrHistory, sqlCon);

                        cmdHistory.ExecuteNonQuery();
                        sqlCon.Close();

                        MessageBox.Show("Неверный логин или пароль");
                        textBox2.Text = "";
                        pictureBox1.Visible = true;
                        label5.Visible = true;
                        textBox3.Visible = true;
                        button4.Visible = true;
                        pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height); pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                    }
                }
                
            }
            else
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
            label4.Text = $"{min}мин.";
            if (min == 0)
            {
                timer1.Stop();
                label4.Visible = false;
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        public void Block()
        {
            label4.Visible = true;
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            timer1.Start();
            label4.Text = $"{min}мин.";
        }

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}
        string text;
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = 10;
            int Ypos = 10;

            //Добавим различные цвета ддя текста
            Brush[] colors = {
            Brushes.Black,
            Brushes.Red,
            Brushes.Tomato,
            Brushes.Sienna,
            Brushes.Pink };

            //Добавим различные цвета линий
            Pen[] colorpens = {
            Pens.Black,
            Pens.Red,
            Pens.RoyalBlue,
            Pens.Green,
            Pens.Pink };

            //Делаем случайный стиль текста
            FontStyle[] fontstyle = {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Regular,
            FontStyle.Strikeout,
            FontStyle.Underline};

            //Добавим различные углы поворота текста
            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Делаем случайный угол поворота текста
            g.RotateTransform(rnd.Next(rotate.Length));

            //Генерируем текст
            text = String.Empty;
            string ALF = "7890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text, new Font("Arial", 25, fontstyle[rnd.Next(fontstyle.Length)]), colors[rnd.Next(colors.Length)], new PointF(Xpos, Ypos));

            //Добавим немного помех
            //Линии из углов
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
            new Point(0, 0),
            new Point(Width - 1, Height - 1));
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
            new Point(0, Height - 1),
            new Point(Width - 1, 0));

            //Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

		private void button4_Click(object sender, EventArgs e)
		{
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

		private void button3_Click(object sender, EventArgs e)
		{
            
        }

		private void timer2_Tick(object sender, EventArgs e)
		{
            sec--;
            label6.Text = $"{sec} сек.";
            if (sec == 0)
            {
                timer2.Stop();
                label6.Text = "";
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
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