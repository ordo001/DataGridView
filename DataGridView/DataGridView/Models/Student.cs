using DataGridViewProject.Models.Enums;
using DataGridViewProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridViewProject.Models.Attributes;

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
        [Required(ErrorMessage = "Пол обязателен")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DateRange(Constants.MinYear, Constants.MaxYear)]
        public DateTime BirthDate { get; set; }
        
        /// <inheritdoc/>
        [Required(ErrorMessage = "Форма обучения обязательна")]
        public FormEducation FormEducation { get; set; }

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
    }
}
