using DataGridView.Entities;
using DataGridView.Services.Contracts;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace DataGridView.Services.Tests;

/// <summary>
/// Модульные тесты для методов <see cref="StudentService"/>
/// </summary>
public class StudentServiceTests
{
    private readonly IStudentService studentService;
    private readonly Mock<IStorage> storageMock;

    public StudentServiceTests()
    {
        storageMock = new Mock<IStorage>();
        var mockLogger = new Mock<ILogger>(); 
        var mockLoggerFactory = new Mock<ILoggerFactory>();
        mockLoggerFactory
            .Setup(f => f.CreateLogger(It.IsAny<string>()))
            .Returns(mockLogger.Object);
        
        studentService = new StudentService(storageMock.Object, mockLoggerFactory.Object);
    }
    
    
    /// <summary>
    /// метод Add() <see cref="StudentService"/> должен добавить студента в хранилище
    /// </summary>
    [Fact]
    public async Task AddShouldAddNewStudent()
    {
        // Arrange
        var student = new Student();

        storageMock
            .Setup(x => x.Add(student, CancellationToken.None));
        
        // Act
        await studentService.Add(student, CancellationToken.None);
        
        // Assert
        storageMock.Verify(x => 
            x.Add(student, It.IsAny<CancellationToken>()), Times.Once);
    }
    
    /// <summary>
    /// метод Remove() <see cref="StudentService"/> должен удалить студента из хранилища
    /// </summary>
    [Fact]
    public async Task RemoveShouldRemoveStudent()
    {
        // Arrange
        var student = new Student();
        
        storageMock
            .Setup(x => x.GetById(student.Id, CancellationToken.None))
            .ReturnsAsync(student);

        storageMock
            .Setup(x => x.Remove(student, CancellationToken.None));
        
        // Act
        await studentService.Remove(student.Id, CancellationToken.None);
        
        // Assert
        storageMock.Verify(x => 
            x.GetById(student.Id, CancellationToken.None), Times.Once);
        storageMock.Verify(x => 
            x.Remove(student, CancellationToken.None), Times.Once);
    }
    
    /// <summary>
    /// метод Update() <see cref="StudentService"/> должен обновить студента в хранилище
    /// </summary>
    [Fact]
    public async Task UpdateShouldUpdateStudent()
    {
        // Arrange
        var student = new Student
        {
            FullName = "Aboba",
        };

        var updatedStudent = new Student
        {
            Id = student.Id,
            FullName = "Updated"
        };
        
        storageMock
            .Setup(x => x.GetById(student.Id, CancellationToken.None))
            .ReturnsAsync(student);

        storageMock
            .Setup(x => x.Update(student, CancellationToken.None));
        
        // Act
        await studentService.Update(updatedStudent, CancellationToken.None);
        
        // Assert
        student.FullName.Should().Be(updatedStudent.FullName);
        
        storageMock.Verify(x => 
            x.Update(student, CancellationToken.None), Times.Once);
    }
    
    /// <summary>
    /// метод GetAll() <see cref="StudentService"/> должен вернуть всех студентов в хранилище
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnAllStudents()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student(),
            new Student(),
            new Student()
        };
        
        storageMock
            .Setup(x => x.GetAll(CancellationToken.None))
            .ReturnsAsync(students);
        
        // Act
        var studentsFromService =  await studentService.GetAll(CancellationToken.None);
        
        // Assert
        studentsFromService.Should().BeEquivalentTo(students);
        storageMock.Verify(x => 
            x.GetAll(CancellationToken.None), Times.Once);
    }
    
    /// <summary>
    /// метод GetStudentsByMinScore() <see cref="StudentService"/> должен вернуть студентов с определенным мин кол-во очков
    /// </summary>
    [Theory]
    [InlineData(150, 2)]
    [InlineData(200, 1)]
    [InlineData(300, 0)]
    public async Task GetStudentsByMinScoreShouldReturnStudentsByMinScore(int minScore, int expectedCount)
    {
        // Arrange
        var students = new List<Student>
        {
            new Student{ MathScore = 100, InformaticsScore = 100, RussianScore = 50},
            new Student{ MathScore = 100, InformaticsScore = 51},
            new Student{ MathScore = 99}
        };
        
        storageMock
            .Setup(x => x.GetAll(CancellationToken.None))
            .ReturnsAsync(students);
        
        // Act
        var studentsFromService =  await studentService.GetStudentsByMinScore(minScore,CancellationToken.None);
        
        // Assert
        studentsFromService.Should().Be(expectedCount);
        storageMock.Verify(x => 
            x.GetAll(CancellationToken.None), Times.Once);
    }
    
    /// <summary>
    /// метод GetCountStudents() <see cref="StudentService"/> должен вернуть количество студентов
    /// </summary>
    [Fact]
    public async Task GetCountStudentsShouldReturnCountStudents()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student(),
            new Student(),
            new Student()
        };
        
        storageMock
            .Setup(x => x.GetCount(CancellationToken.None))
            .ReturnsAsync(students.Count);
        
        // Act
        var studentsFromService =  await studentService.GetCountStudents(CancellationToken.None);
        
        // Assert
        studentsFromService.Should().Be(students.Count);
        storageMock.Verify(x => 
            x.GetCount(CancellationToken.None), Times.Once);
    }
}