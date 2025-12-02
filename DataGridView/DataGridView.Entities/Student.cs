using System.ComponentModel.DataAnnotations;
using DataGridView.Entities.Attributes;
using DataGridView.Entities.Enums;

namespace DataGridView.Entities
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
        [StringLength(EntityConstants.MaxLengthFullName,MinimumLength = EntityConstants.MinLengthFullName)]
        public string FullName { get; set; } = string.Empty;

        /// <inheritdoc/>
        [Required(ErrorMessage = "Пол обязателен")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DateRange(EntityConstants.MinYear, EntityConstants.MaxYear)]
        public DateTime BirthDate { get; set; }
        
        /// <inheritdoc/>
        [Required(ErrorMessage = "Форма обучения обязательна")]
        public FormEducation FormEducation { get; set; }

        /// <summary>
        /// Баллы по математике
        /// </summary>
        [Range(EntityConstants.MinScore, EntityConstants.MaxScore)]
        public decimal MathScore { get; set; }

        /// <summary>
        /// Баллые по русскому языку
        /// </summary>
        [Range(EntityConstants.MinScore, EntityConstants.MaxScore)]
        public decimal RussianScore { get; set; }

        /// <summary>
        /// Баллы по информатике
        /// </summary>
        [Range(EntityConstants.MinScore, EntityConstants.MaxScore)]
        public decimal InformaticsScore { get; set; }
    }
}
