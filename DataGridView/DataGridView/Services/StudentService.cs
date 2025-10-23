using DataGridViewProject.Models;
using DataGridViewProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewProject.Services
{
    /// <summary>
    /// Сервис для работы со студентами
    /// </summary>
    public class StudentService
    {
        private readonly List<Student> students;

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="StudentService"/>
        /// </summary>
        public StudentService()
        {
            students = new List<Student>
            {
                new Student {
                    FullName="Насрудин Колобов Бердникович",
                    Gender=Gender.Male,
                    BirthDate=new(2006,1,24),
                    FormEducation = FormEducation.FullTime,
                    MathScore=50,
                    RussianScore=50,
                    InformaticsScore=0
                },
                new Student {
                    FullName="Женщина Женщина Женщина",
                    Gender=Gender.Female,
                    BirthDate=new(2006,10,21),
                    FormEducation = FormEducation.Correspondence,
                    MathScore=75,
                    RussianScore=34,
                    InformaticsScore=12
                },
                new Student {
                    FullName="Легенда",
                    Gender=Gender.CombatHelicopter,
                    BirthDate=new(2006,5,02),
                    FormEducation = FormEducation.FullTime,
                    MathScore=12,
                    RussianScore=4,
                    InformaticsScore=100
                },
            };


        }

        /// <summary>
        /// Получить всех студентов
        /// </summary>
        public List<Student> GetAll() => students.ToList();

        /// <summary>
        /// Добавить студента
        /// </summary>
        public void Add(Student applicant) => students.Add(applicant);

        /// <summary>
        /// Обновить студента
        /// </summary>
        public void Update(Student updated)
        {
            var index = students.FindIndex(x => x.Id == updated.Id);
            if (index >= 0)
                students[index] = updated;
        }

        /// <summary>
        /// Удалить студента
        /// </summary>
        public void Delete(Guid id)
        {
            var found = students.FirstOrDefault(x => x.Id == id);
            if (found != null)
                students.Remove(found);
        }

        /// <summary>
        /// Получить количество студентов
        /// </summary>
        public int GetCount() => students.Count;

        /// <summary>
        /// Получить количество студентов которые набрали больше 150 баллов
        /// </summary>
        /// <returns></returns>
        public int GetCountAbove150() => students.Count(x => x.TotalScore > 150);


    }
}
