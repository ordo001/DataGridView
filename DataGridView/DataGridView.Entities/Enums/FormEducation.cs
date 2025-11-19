using System.ComponentModel.DataAnnotations;

namespace DataGridView.Entities.Enums
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
