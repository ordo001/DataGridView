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
        Unknown = 0,

        /// <summary>
        /// Очная
        /// </summary>
        [Display(Name = "Очная")]
        FullTime = 1,

        /// <summary>
        /// Заочная
        /// </summary>
        [Display(Name = "Заочная")]
        Correspondence = 2,

    }
}
