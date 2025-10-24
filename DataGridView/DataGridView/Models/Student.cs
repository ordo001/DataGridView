using DataGridViewProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewProject.Models
{
    /// <summary>
    /// Модель ученика
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Полное имя
        /// </summary>
        [Required(ErrorMessage = "ФИО обязательно")]
        [StringLength(Constants.MaxLengthFullName,MinimumLength = Constants.MinLengthFullName)]
        public string FullName { get; set; } = string.Empty;

        /// <inheritdoc/>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Дата рождения обязательна")]
        [CustomValidation(typeof(Student), nameof(ValidateBirthDate))]
        public DateTime BirthDate { get; set; } 


        /// <inheritdoc/>
        public FormEducation FormEducation { get; set; } = 0;

        /// <summary>
        /// Баллы по математике
        /// </summary>
        [Range(Constants.MinScore, Constants.MaxScore)]
        public decimal MathScore { get; set; }

        /// <summary>
        /// Баллые по русскому языку
        /// </summary>
        [Range(Constants.MinScore, Constants.MaxScore)]
        public decimal RussianScore { get; set; }

        /// <summary>
        /// Баллы по информатике
        /// </summary>
        [Range(Constants.MinScore, Constants.MaxScore)]
        public decimal InformaticsScore { get; set; }

        /// <summary>
        /// Общее количество баллов
        /// </summary>
        public decimal TotalScore => MathScore + RussianScore + InformaticsScore;

        public static ValidationResult? ValidateBirthDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Now.AddYears(-Constants.MinYear))
                return new ValidationResult($"Возраст должен быть больше {Constants.MinYear} лет");
            return ValidationResult.Success;
        }
    }
}
