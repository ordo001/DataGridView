using System.ComponentModel.DataAnnotations;

namespace DataGridViewProject.Models.Enums
{
    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Неизвестный
        /// </summary>
        [Display(Name = "Неизвестный")]
        Unknown,

        /// <summary>
        /// Мужской
        /// </summary>
        [Display(Name = "Мужской")]
        Male,

        /// <summary>
        /// Женский
        /// </summary>
        [Display(Name = "Женский")]
        Female,

        /// <summary>
        /// Боевой вертолёт
        /// </summary>
        [Display(Name = "Боевой вертолёт")]
        CombatHelicopter,
    }
}
