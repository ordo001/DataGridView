using DataGridViewProject.Models;
using System.ComponentModel.DataAnnotations;

namespace DataGridViewProject.Services
{
    /// <summary>
    /// Класс с кастомными правилами валидации
    /// </summary>
    public class CustomValidate
    {
        /// <summary>
        /// Проверка даты рождения
        /// </summary>
        public static ValidationResult? ValidateBirthDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Now.AddYears(-Constants.MinYear))
                return new ValidationResult($"Возраст должен быть больше {Constants.MinYear} лет");
            return ValidationResult.Success;
        }
    }
}
