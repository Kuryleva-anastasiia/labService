namespace bloodService
{
    partial class AdminMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMain));
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.bloodServiceDataSet1 = new bloodService.BloodServiceDataSet1();
			this.enterHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.enterHistoryTableAdapter = new bloodService.BloodServiceDataSet1TableAdapters.EnterHistoryTableAdapter();
			this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.enterResultDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bloodServiceDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.enterHistoryBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(387, 15);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 0;
			this.button1.Text = "Вход";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(32, 215);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 24);
			this.label2.TabIndex = 6;
			this.label2.Text = "label2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(32, 172);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.pictureBox1.Location = new System.Drawing.Point(16, 15);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(184, 140);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(227)))), ((int)(((byte)(131)))));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.Location = new System.Drawing.Point(16, 260);
			this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(184, 28);
			this.button2.TabIndex = 7;
			this.button2.Text = "Сформировать отчеты";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button3.Location = new System.Drawing.Point(16, 295);
			this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(276, 28);
			this.button3.TabIndex = 8;
			this.button3.Text = "Данные о расходных материалах";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 422);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(200, 22);
			this.textBox1.TabIndex = 10;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(227)))), ((int)(((byte)(131)))));
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button4.Location = new System.Drawing.Point(225, 420);
			this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(116, 28);
			this.button4.TabIndex = 11;
			this.button4.Text = "Поиск";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(16, 348);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(132, 24);
			this.label3.TabIndex = 12;
			this.label3.Text = "История входа";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(16, 384);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(276, 24);
			this.label4.TabIndex = 13;
			this.label4.Text = "Поиск по логину пользователя:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loginDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.enterResultDataGridViewCheckBoxColumn});
			this.dataGridView1.DataSource = this.enterHistoryBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(16, 461);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(471, 150);
			this.dataGridView1.TabIndex = 14;
			// 
			// bloodServiceDataSet1
			// 
			this.bloodServiceDataSet1.DataSetName = "BloodServiceDataSet1";
			this.bloodServiceDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// enterHistoryBindingSource
			// 
			this.enterHistoryBindingSource.DataMember = "EnterHistory";
			this.enterHistoryBindingSource.DataSource = this.bloodServiceDataSet1;
			// 
			// enterHistoryTableAdapter
			// 
			this.enterHistoryTableAdapter.ClearBeforeFill = true;
			// 
			// loginDataGridViewTextBoxColumn
			// 
			this.loginDataGridViewTextBoxColumn.DataPropertyName = "login";
			this.loginDataGridViewTextBoxColumn.HeaderText = "login";
			this.loginDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
			this.loginDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// dateDataGridViewTextBoxColumn
			// 
			this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
			this.dateDataGridViewTextBoxColumn.HeaderText = "date";
			this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
			this.dateDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// enterResultDataGridViewCheckBoxColumn
			// 
			this.enterResultDataGridViewCheckBoxColumn.DataPropertyName = "enterResult";
			this.enterResultDataGridViewCheckBoxColumn.HeaderText = "enterResult";
			this.enterResultDataGridViewCheckBoxColumn.MinimumWidth = 6;
			this.enterResultDataGridViewCheckBoxColumn.Name = "enterResultDataGridViewCheckBoxColumn";
			this.enterResultDataGridViewCheckBoxColumn.ReadOnly = true;
			// 
			// AdminMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(503, 631);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "AdminMain";
			this.Text = "AdminMain";
			this.Load += new System.EventHandler(this.AdminMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bloodServiceDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.enterHistoryBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource usersEnterBindingSource;
        private System.Windows.Forms.BindingSource usersEnterBindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView dataGridView1;
		private BloodServiceDataSet1 bloodServiceDataSet1;
		private System.Windows.Forms.BindingSource enterHistoryBindingSource;
		private BloodServiceDataSet1TableAdapters.EnterHistoryTableAdapter enterHistoryTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn enterResultDataGridViewCheckBoxColumn;
	}
}