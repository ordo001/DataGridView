using DataGridView.Entities;
using DataGridView.Services;
using DataGridView.Services.Contracts;
using DataGridViewProject.Infrastructure;

namespace DataGridViewProject.Forms
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly InMemoryStorage storage = new();
        private readonly BindingSource bindingSource = new();

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="MainForm"/>
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            InitBindingSources();

            ConfigureColumns();
            _ = RefreshStats();
        }

        private async void InitBindingSources()
        {
            var stds = await storage.GetAll(CancellationToken.None);
            bindingSource.DataSource = stds.ToList();
            dataGridView.DataSource = bindingSource;
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


        private async Task RefreshStats()
        {
            var students = await storage.GetAll(CancellationToken.None);
            toolStripStatusLabelCount.Text = $"Всего студентов: {students.Count()}";
            toolStripStatusLabelStatusStudent.Text = $"Всего студентов с более 150 баллов: {students.Count(x => 
                x.InformaticsScore + x.MathScore + x.RussianScore > ServiceConstants.MinTotalScore)}";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditForm(new Student());
            if (form.ShowDialog() == DialogResult.OK)
            {
                await storage.Add(form.Student, CancellationToken.None);
                bindingSource.DataSource = storage.GetAll(CancellationToken.None);
                await RefreshStats();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
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
                await storage.Update(form.Student, CancellationToken.None);
                bindingSource.DataSource = await storage.GetAll(CancellationToken.None);
                await RefreshStats();
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is not Student selected)
            {
                return;
            }
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await storage.Remove(selected.Id,  CancellationToken.None);
                var stds  = await storage.GetAll(CancellationToken.None);
                bindingSource.DataSource = stds.ToList();
                await RefreshStats();
            }
        }

    }
}
