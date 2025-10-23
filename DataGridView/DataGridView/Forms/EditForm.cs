using DataGridViewProject.Infrastructure;
using DataGridViewProject.Models;
using DataGridViewProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewProject.Forms
{
    /// <summary>
    /// Форма редактирования студентов
    /// </summary>
    public partial class EditForm : Form
    {
        private readonly BindingSource bindingSource = new();

        /// <summary>
        /// Текущий студент
        /// </summary>
        public Student Student => (Student)bindingSource.Current;

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="EditForm"/>
        /// </summary>
        public EditForm(Student student)
        {
            InitializeComponent();
            bindingSource.DataSource = student;
            InitBindings();
        }

        private void InitBindings()
        {
            textBoxFullName.AddBinding<TextBox, Student>(c => c.Text, bindingSource, s => s.FullName, errorProvider);

            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender))
                    .Cast<Gender>()
                    .Select(g => new { Value = g, Name = g.GetDisplayName() })
                    .ToArray();
            comboBoxGender.DisplayMember = "Name";
            comboBoxGender.ValueMember = "Value";
            comboBoxGender.DataBindings.Add("SelectedValue", bindingSource, nameof(Student.Gender), true, DataSourceUpdateMode.OnPropertyChanged);

            maskedTextBoxDate.AddBinding<MaskedTextBox, Student>(c => c.Text, bindingSource, s => s.BirthDate, errorProvider);

            comboBoxFormEducation.DataSource = Enum.GetValues(typeof(FormEducation))
                    .Cast<FormEducation>()
                    .Select(g => new { Value = g, Name = g.GetDisplayName() })
                    .ToArray();
            comboBoxFormEducation.DisplayMember = "Name";
            comboBoxFormEducation.ValueMember = "Value";
            comboBoxFormEducation.DataBindings.Add("SelectedValue", bindingSource, nameof(Student.FormEducation), true, DataSourceUpdateMode.OnPropertyChanged);


            numericUpDownMath.AddBinding<NumericUpDown, Student>(c => c.Value, bindingSource, s => s.MathScore, errorProvider);
            numericUpDownRussian.AddBinding<NumericUpDown, Student>(c => c.Value, bindingSource, s => s.RussianScore, errorProvider);
            numericUpDownInformatics.AddBinding<NumericUpDown, Student>(c => c.Value, bindingSource, s => s.InformaticsScore, errorProvider);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            var student = (Student)bindingSource.Current;
            student.BirthDate = student.BirthDate.Date;

            var context = new ValidationContext(student);
            var results = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(Student, context, results, true);
            if (!valid)
            {
                foreach (var result in results)
                {
                    var member = result.MemberNames.FirstOrDefault();
                    var control = Controls.Cast<Control>()
                        .FirstOrDefault(c => c.DataBindings.Cast<Binding>().Any(b => b.BindingMemberInfo.BindingField == member));

                    if (control != null)
                        errorProvider.SetError(control, result.ErrorMessage);
                }
                return;
            }

            DialogResult = DialogResult.OK;


        }
    }
}
