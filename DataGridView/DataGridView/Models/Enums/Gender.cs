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
        Unknown = 0,

        /// <summary>
        /// Мужской
        /// </summary>
        [Display(Name = "Мужской")]
        Male = 1,

        /// <summary>
        /// Женский
        /// </summary>
        [Display(Name = "Женский")]
        Female = 2,

        /// <summary>
        /// Боевой вертолёт
        /// </summary>
        [Display(Name = "Боевой вертолёт")]
        CombatHelicopter = 3
    }
}
