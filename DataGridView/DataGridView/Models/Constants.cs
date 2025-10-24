using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewProject.Models
{
    /// <summary>
    /// Статический класс для констант
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Максимальная длина ФИО
        /// </summary>
        public const int MaxLengthFullName = 100;

        /// <summary>
        /// Минимальная длина ФИО
        /// </summary>
        public const int MinLengthFullName = 5;

        /// <summary>
        /// Минимальный год поступления
        /// </summary>
        public const int MinYear = 6;

        /// <summary>
        /// Минимальное кол-во баллов
        /// </summary>
        public const int MinScore = 0;

        /// <summary>
        /// Максимальное кол-во баллов
        /// </summary>
        public const int MaxScore = 100;

    }
}
