using System.ComponentModel.DataAnnotations;

namespace DataGridViewProject.Models.Enums
{
    /// <summary>
    /// Форма обучения
    /// </summary>
    public enum FormEducation
    {
        /// <summary>
        /// Неизвестная
        /// </summary>
        [Display(Name = "Неизвестная")]
        Unknown,

        /// <summary>
        /// Очная
        /// </summary>
        [Display(Name = "Очная")]
        FullTime,

        /// <summary>
        /// Заочная
        /// </summary>
        [Display(Name = "Заочная")]
        Correspondence,
    }
}
