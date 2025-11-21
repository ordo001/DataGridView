using DataGridView.Entities;
using DataGridView.Entities.Enums;
using DataGridView.Services.Contracts;

namespace DataGridView.Services;

/// <summary>
/// Хранилище студентов в оперативной памяти
/// </summary>
public class InMemoryStorage : IStorage
{
    private List<Student> students;

    public InMemoryStorage()
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
    
    public Task Add(Student student, CancellationToken cancellationToken)
    {
        students.Add(student);
        return Task.CompletedTask;
    }

    public Task Remove(Student student, CancellationToken cancellationToken)
    {
        students.Remove(student);
        return Task.CompletedTask;
    }

    public Task Update(Student student, CancellationToken cancellationToken)
    {
        var  index = students.FindIndex(x => x.Id == student.Id);
        students[index] = student;
        return Task.CompletedTask;
    }

    public Task<Student> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(students.FirstOrDefault(x => x.Id == id))!;
    }

    public Task<List<Student>> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(students);
    }

    public Task<int> GetCount(CancellationToken cancellationToken)
    {
        return Task.FromResult(students.Count);
    }
}