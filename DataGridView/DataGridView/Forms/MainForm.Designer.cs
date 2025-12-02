namespace DataGridViewProject.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStripAuto = new StatusStrip();
            toolStripStatusLabelCount = new ToolStripStatusLabel();
            toolStripStatusLabelStatusStudent = new ToolStripStatusLabel();
            toolStripMenu = new ToolStrip();
            btnDelete = new ToolStripLabel();
            btnEdit = new ToolStripLabel();
            btnAdd = new ToolStripLabel();
            dataGridView = new System.Windows.Forms.DataGridView();
            Fio = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            Form = new DataGridViewTextBoxColumn();
            ScoresMath = new DataGridViewTextBoxColumn();
            ScoresRussian = new DataGridViewTextBoxColumn();
            ScoreInform = new DataGridViewTextBoxColumn();
            TotalScores = new DataGridViewTextBoxColumn();
            statusStripAuto.SuspendLayout();
            toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // statusStripAuto
            // 
            statusStripAuto.BackColor = Color.White;
            statusStripAuto.ImageScalingSize = new Size(20, 20);
            statusStripAuto.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelCount, toolStripStatusLabelStatusStudent });
            statusStripAuto.Location = new Point(0, 370);
            statusStripAuto.Name = "statusStripAuto";
            statusStripAuto.Padding = new Padding(1, 0, 12, 0);
            statusStripAuto.Size = new Size(1088, 22);
            statusStripAuto.TabIndex = 0;
            statusStripAuto.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            toolStripStatusLabelCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            toolStripStatusLabelCount.Size = new Size(138, 17);
            toolStripStatusLabelCount.Text = "Количество студентов:";
            // 
            // toolStripStatusLabelStatusStudent
            // 
            toolStripStatusLabelStatusStudent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripStatusLabelStatusStudent.Name = "toolStripStatusLabelStatusStudent";
            toolStripStatusLabelStatusStudent.Size = new Size(285, 17);
            toolStripStatusLabelStatusStudent.Text = "Сколько студентов набрали больше 150 баллов:";
            // 
            // toolStripMenu
            // 
            toolStripMenu.BackColor = Color.LightGreen;
            toolStripMenu.ImageScalingSize = new Size(20, 20);
            toolStripMenu.Items.AddRange(new ToolStripItem[] { btnDelete, btnEdit, btnAdd });
            toolStripMenu.Location = new Point(0, 0);
            toolStripMenu.Name = "toolStripMenu";
            toolStripMenu.Size = new Size(1088, 25);
            toolStripMenu.TabIndex = 1;
            toolStripMenu.Text = "toolStrip1";
            // 
            // btnDelete
            // 
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(51, 22);
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(61, 22);
            btnEdit.Text = "Изменить";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(59, 22);
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Fio, Gender, DateOfBirth, Form, ScoresMath, ScoresRussian, ScoreInform, TotalScores });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.GridColor = SystemColors.WindowText;
            dataGridView.Location = new Point(0, 25);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1088, 345);
            dataGridView.TabIndex = 2;
            // 
            // Fio
            // 
            Fio.HeaderText = "ФИО";
            Fio.MinimumWidth = 6;
            Fio.Name = "Fio";
            Fio.Resizable = DataGridViewTriState.True;
            Fio.Width = 59;
            // 
            // Gender
            // 
            Gender.HeaderText = "Пол";
            Gender.MinimumWidth = 6;
            Gender.Name = "Gender";
            Gender.Width = 55;
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Дата рождения";
            DateOfBirth.MinimumWidth = 6;
            DateOfBirth.Name = "DateOfBirth";
            DateOfBirth.Width = 106;
            // 
            // Form
            // 
            Form.HeaderText = "Форма обучения";
            Form.MinimumWidth = 6;
            Form.Name = "Form";
            Form.Width = 115;
            // 
            // ScoresMath
            // 
            ScoresMath.HeaderText = "ЕГЭ Математика";
            ScoresMath.MinimumWidth = 6;
            ScoresMath.Name = "ScoresMath";
            ScoresMath.Width = 111;
            // 
            // ScoresRussian
            // 
            ScoresRussian.HeaderText = "ЕГЭ Русский язык";
            ScoresRussian.MinimumWidth = 6;
            ScoresRussian.Name = "ScoresRussian";
            ScoresRussian.Width = 117;
            // 
            // ScoreInform
            // 
            ScoreInform.HeaderText = "ЕГЭ Информатика";
            ScoreInform.MinimumWidth = 6;
            ScoreInform.Name = "ScoreInform";
            ScoreInform.Width = 121;
            // 
            // TotalScores
            // 
            TotalScores.HeaderText = "Общая сумма баллов";
            TotalScores.MinimumWidth = 6;
            TotalScores.Name = "TotalScores";
            TotalScores.Width = 140;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 392);
            Controls.Add(dataGridView);
            Controls.Add(toolStripMenu);
            Controls.Add(statusStripAuto);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Приёмная комиссия";
            statusStripAuto.ResumeLayout(false);
            statusStripAuto.PerformLayout();
            toolStripMenu.ResumeLayout(false);
            toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStripAuto;
        private ToolStripStatusLabel toolStripStatusLabelCount;
        private ToolStrip toolStripMenu;
        private System.Windows.Forms.DataGridView dataGridView;
        private ToolStripStatusLabel toolStripStatusLabelStatusStudent;
        private DataGridViewTextBoxColumn Fio;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn Form;
        private DataGridViewTextBoxColumn ScoresMath;
        private DataGridViewTextBoxColumn ScoresRussian;
        private DataGridViewTextBoxColumn ScoreInform;
        private DataGridViewTextBoxColumn TotalScores;
        private ToolStripLabel btnDelete;
        private ToolStripLabel btnEdit;
        private ToolStripLabel btnAdd;
    }
}
