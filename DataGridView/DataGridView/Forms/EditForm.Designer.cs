namespace DataGridViewProject.Forms
{
    partial class EditForm
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
            components = new System.ComponentModel.Container();
            buttonSave = new Button();
            panelTop = new Panel();
            labelTitle = new Label();
            labelFullName = new Label();
            labelGender = new Label();
            labelBirthDate = new Label();
            labelFormEducation = new Label();
            labelMathScore = new Label();
            labelRussianScore = new Label();
            labelInformaticsScore = new Label();
            textBoxFullName = new TextBox();
            comboBoxGender = new ComboBox();
            errorProvider = new ErrorProvider(components);
            comboBoxFormEducation = new ComboBox();
            numericUpDownMath = new NumericUpDown();
            numericUpDownRussian = new NumericUpDown();
            numericUpDownInformatics = new NumericUpDown();
            maskedTextBoxDate = new MaskedTextBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRussian).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInformatics).BeginInit();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Dock = DockStyle.Bottom;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSave.Location = new Point(0, 307);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(330, 23);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.Click += btnSave_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.PaleGreen;
            panelTop.Controls.Add(labelTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(330, 40);
            panelTop.TabIndex = 1;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitle.Location = new Point(20, 10);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(289, 19);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Добавить / Редактировать абитуриента";
            // 
            // labelFullName
            // 
            labelFullName.Location = new Point(20, 60);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(100, 23);
            labelFullName.TabIndex = 2;
            labelFullName.Text = "ФИО:";
            // 
            // labelGender
            // 
            labelGender.Location = new Point(20, 95);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(100, 23);
            labelGender.TabIndex = 4;
            labelGender.Text = "Пол:";
            // 
            // labelBirthDate
            // 
            labelBirthDate.Location = new Point(20, 130);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(100, 23);
            labelBirthDate.TabIndex = 6;
            labelBirthDate.Text = "Дата рождения:";
            // 
            // labelFormEducation
            // 
            labelFormEducation.Location = new Point(20, 165);
            labelFormEducation.Name = "labelFormEducation";
            labelFormEducation.Size = new Size(100, 23);
            labelFormEducation.TabIndex = 8;
            labelFormEducation.Text = "Форма обучения:";
            // 
            // labelMathScore
            // 
            labelMathScore.Location = new Point(20, 200);
            labelMathScore.Name = "labelMathScore";
            labelMathScore.Size = new Size(100, 23);
            labelMathScore.TabIndex = 10;
            labelMathScore.Text = "ЕГЭ Математика:";
            // 
            // labelRussianScore
            // 
            labelRussianScore.Location = new Point(20, 235);
            labelRussianScore.Name = "labelRussianScore";
            labelRussianScore.Size = new Size(100, 23);
            labelRussianScore.TabIndex = 12;
            labelRussianScore.Text = "ЕГЭ Русский:";
            // 
            // labelInformaticsScore
            // 
            labelInformaticsScore.Location = new Point(20, 270);
            labelInformaticsScore.Name = "labelInformaticsScore";
            labelInformaticsScore.Size = new Size(100, 23);
            labelInformaticsScore.TabIndex = 14;
            labelInformaticsScore.Text = "ЕГЭ Информатика:";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(150, 60);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(150, 23);
            textBoxFullName.TabIndex = 3;
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Location = new Point(150, 95);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(150, 23);
            comboBoxGender.TabIndex = 5;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // comboBoxFormEducation
            // 
            comboBoxFormEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormEducation.Location = new Point(150, 165);
            comboBoxFormEducation.Name = "comboBoxFormEducation";
            comboBoxFormEducation.Size = new Size(150, 23);
            comboBoxFormEducation.TabIndex = 9;
            // 
            // numericUpDownMath
            // 
            numericUpDownMath.Location = new Point(150, 200);
            numericUpDownMath.Name = "numericUpDownMath";
            numericUpDownMath.Size = new Size(60, 23);
            numericUpDownMath.TabIndex = 11;
            // 
            // numericUpDownRussian
            // 
            numericUpDownRussian.Location = new Point(150, 235);
            numericUpDownRussian.Name = "numericUpDownRussian";
            numericUpDownRussian.Size = new Size(60, 23);
            numericUpDownRussian.TabIndex = 13;
            // 
            // numericUpDownInformatics
            // 
            numericUpDownInformatics.Location = new Point(150, 270);
            numericUpDownInformatics.Name = "numericUpDownInformatics";
            numericUpDownInformatics.Size = new Size(60, 23);
            numericUpDownInformatics.TabIndex = 15;
            // 
            // maskedTextBoxDate
            // 
            maskedTextBoxDate.Location = new Point(150, 130);
            maskedTextBoxDate.Mask = "00/00/0000";
            maskedTextBoxDate.Name = "maskedTextBoxDate";
            maskedTextBoxDate.Size = new Size(150, 23);
            maskedTextBoxDate.TabIndex = 16;
            maskedTextBoxDate.ValidatingType = typeof(DateTime);
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 330);
            Controls.Add(maskedTextBoxDate);
            Controls.Add(buttonSave);
            Controls.Add(panelTop);
            Controls.Add(labelFullName);
            Controls.Add(textBoxFullName);
            Controls.Add(labelGender);
            Controls.Add(comboBoxGender);
            Controls.Add(labelBirthDate);
            Controls.Add(labelFormEducation);
            Controls.Add(comboBoxFormEducation);
            Controls.Add(labelMathScore);
            Controls.Add(numericUpDownMath);
            Controls.Add(labelRussianScore);
            Controls.Add(numericUpDownRussian);
            Controls.Add(labelInformaticsScore);
            Controls.Add(numericUpDownInformatics);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить / Редактировать абитуриента";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMath).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRussian).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInformatics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Panel panelTop;
        private Label labelTitle;
        private Label labelFullName;
        private Label labelGender;
        private Label labelBirthDate;
        private Label labelFormEducation;
        private Label labelMathScore;
        private Label labelRussianScore;
        private Label labelInformaticsScore;

        private TextBox textBoxFullName;
        private ComboBox comboBoxGender;
        private ComboBox comboBoxFormEducation;
        private NumericUpDown numericUpDownMath;
        private NumericUpDown numericUpDownRussian;
        private NumericUpDown numericUpDownInformatics;

        private ErrorProvider errorProvider;
        private MaskedTextBox maskedTextBoxDate;
    }
}