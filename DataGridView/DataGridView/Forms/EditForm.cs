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
        /// <summary>
        /// Текущий студент
        /// </summary>
        public Student Student;

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="EditForm"/>
        /// </summary>
        public EditForm(Student student)
        {
            InitializeComponent();
            Student = student;
            InitBindings();
        }

        private void InitBindings()
        {
            comboBoxFormEducation.DataSource = Enum.GetValues(typeof(FormEducation))
                    .Cast<FormEducation>()
                    .Select(g => new { Value = g, Name = g.GetDisplayName() })
                    .ToArray();
            comboBoxFormEducation.DisplayMember = "Name";
            comboBoxFormEducation.ValueMember = "Value";

            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender))
                    .Cast<Gender>()
                    .Select(g => new { Value = g, Name = g.GetDisplayName() })
                    .ToArray();
            comboBoxGender.DisplayMember = "Name";
            comboBoxGender.ValueMember = "Value";

            textBoxFullName.AddBinding(x => x.Text, Student, x => x.FullName, errorProvider);
            comboBoxGender.AddBinding(x => x.Text, Student, x => x.Gender, errorProvider);
            comboBoxFormEducation.AddBinding(x => x.Text, Student, x => x.FormEducation, errorProvider);
            maskedTextBoxDate.AddBinding(x => x.Text, Student, x => x.BirthDate, errorProvider);
            numericUpDownMath.AddBinding(x => x.Value, Student, x => x.MathScore, errorProvider);
            numericUpDownRussian.AddBinding(x => x.Value, Student, x => x.RussianScore, errorProvider);
            numericUpDownInformatics.AddBinding(x => x.Value, Student, x => x.InformaticsScore, errorProvider);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Student.BirthDate = Student.BirthDate.Date;

            var context = new ValidationContext(Student);
            var results = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(Student, context, results, true);
            if (!valid)
            {
                foreach (var result in results)
                {
                    foreach (var member in result.MemberNames)
                    {
                        var control = Controls.Cast<Control>()
                            .FirstOrDefault(c => c.DataBindings.Cast<Binding>()
                                .Any(b => b.BindingMemberInfo.BindingField == member));

                        if (control != null)
                        {
                            errorProvider.SetError(control, result.ErrorMessage);
                            break;
                        }
                    }
                }
                return;
            }

            DialogResult = DialogResult.OK;


        }
    }
}
