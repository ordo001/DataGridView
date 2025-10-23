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
        [StringLength(100, MinimumLength = 5, ErrorMessage = "ФИО должно быть от 5 до 100 символов")]
        public string FullName { get; set; } = string.Empty;

        /// <inheritdoc/>
        public Gender Gender { get; set; } = 0;

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Дата рождения обязательна")]
        [CustomValidation(typeof(Student), nameof(ValidateBirthDate))]
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-6);


        /// <inheritdoc/>
        public FormEducation FormEducation { get; set; } = 0;

        /// <summary>
        /// Баллы по математике
        /// </summary>
        [Range(0, 100, ErrorMessage = "Баллы по математике от 0 до 100")]
        public decimal MathScore { get; set; }

        /// <summary>
        /// Баллые по русскому языку
        /// </summary>
        [Range(0, 100, ErrorMessage = "Баллы по русскому от 0 до 100")]
        public decimal RussianScore { get; set; }

        /// <summary>
        /// Баллы по информатике
        /// </summary>
        [Range(0, 100, ErrorMessage = "Баллы по информатике от 0 до 100")]
        public decimal InformaticsScore { get; set; }

        /// <summary>
        /// Общее количество баллов
        /// </summary>
        public decimal TotalScore => MathScore + RussianScore + InformaticsScore;

        public static ValidationResult? ValidateBirthDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Now.AddYears(-6))
                return new ValidationResult("Возраст должен быть больше 6 лет");
            return ValidationResult.Success;
        }
    }
}
