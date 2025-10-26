using DataGridViewProject.Forms;
using DataGridViewProject.Infrastructure;
using DataGridViewProject.Models;
using DataGridViewProject.Models.Enums;
using DataGridViewProject.Services;

namespace DataGridViewProject
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly StudentService studentService = new();
        private readonly BindingSource bindingSource = new();

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="MainForm"/>
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            bindingSource.DataSource = studentService.GetAll();
            dataGridView.DataSource = bindingSource;

            ConfigureColumns();
            RefreshStats();
        }

        private void ConfigureColumns()
        {

            Fio.DataPropertyName = nameof(Student.FullName);
            Gender.DataPropertyName = nameof(Student.Gender);
            DateOfBirth.DataPropertyName = nameof(Student.BirthDate);
            Form.DataPropertyName = nameof(Student.FormEducation);
            ScoresMath.DataPropertyName = nameof(Student.MathScore);
            ScoresRussian.DataPropertyName = nameof(Student.RussianScore);
            ScoreInform.DataPropertyName = nameof(Student.InformaticsScore);
            //TotalScores.DataPropertyName = nameof(Student.TotalScore);
        }


        private void RefreshStats()
        {
            toolStripStatusLabelCount.Text = $"Всего студентов: {studentService.GetCount()}";
            toolStripStatusLabelStatusStudent.Text = $"Всего студентов с более 150 баллов: {studentService.GetCountAbove150()}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditForm(new Student());
            if (form.ShowDialog() == DialogResult.OK)
            {
                studentService.Add(form.Student);
                bindingSource.DataSource = studentService.GetAll();
                RefreshStats();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is not Student selected)
            {
                return;
            }

            var clone = new Student
            {
                Id = selected.Id,
                FullName = selected.FullName,
                Gender = selected.Gender,
                BirthDate = selected.BirthDate,
                FormEducation = selected.FormEducation,
                MathScore = selected.MathScore,
                RussianScore = selected.RussianScore,
                InformaticsScore = selected.InformaticsScore
            };

            var form = new EditForm(clone);
            if (form.ShowDialog() == DialogResult.OK)
            {
                studentService.Update(form.Student);
                bindingSource.DataSource = studentService.GetAll();
                RefreshStats();
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is Enum enumVal)
            {
                e.Value = enumVal.GetDisplayName();
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "TotalScores"
                && dataGridView.Rows[e.RowIndex].DataBoundItem is Student student)
            {
                e.Value = student.MathScore + student.RussianScore + student.InformaticsScore;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is not Student selected)
            {
                return;
            }
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                studentService.Delete(selected.Id);
                bindingSource.DataSource = studentService.GetAll();
                RefreshStats();
            }
        }

    }
}
