using Lessons.Domain.DTO.Lesson;
using Lessons.Domain.DTO.Person;
using Lessons.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Lessons.Infrastructure.Repository.Realization;

public class PersonService : IPersonService
{
    
    private LessonsDbContext _dbContext;
    
    public PersonService(LessonsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<PersonDto> GetPersons()
    {
        return _dbContext.Persons.Select(x => new PersonDto(x)).ToList();
    }

    public List<TeacherDto> GetTeachers()
    {
        return _dbContext.Teachers.Select(x => new TeacherDto(x)).ToList();

    }

    public List<StudentDto> GetStudents()
    {
        return _dbContext.Students.Select(x => new StudentDto(x)).ToList();

    }

    public List<SupervisorDto> GetSupervisors()
    {
        return _dbContext.Supervisors.Select(x => new SupervisorDto(x)).ToList();

    }



    public int AddTeacher(string lastName, string firstName, string? patronymicName, string position)
    {
        var newTeacher = _dbContext.Teachers.Add(new Teacher()
        {
            LastName = lastName, FirstName = firstName, PatronymicName = patronymicName, Position = position
        });
        
        _dbContext.SaveChanges();
        return newTeacher.Entity.Id;
    }

    public int AddStudent(string lastName, string firstName, string? patronymicName, int? groupId)
    {
        var newStudent = _dbContext.Students.Add(new Student()
        {
            LastName = lastName, FirstName = firstName, PatronymicName = patronymicName, GroupId = groupId
        });
        
        _dbContext.SaveChanges();
        return newStudent.Entity.Id;
    }

    public int AddSupervisor(string lastName, string firstName, string? patronymicName)
    {
        var newSupervisor = _dbContext.Supervisors.Add(new Supervisor()
        {
            LastName = lastName, FirstName = firstName, PatronymicName = patronymicName
        });
        
        _dbContext.SaveChanges();
        return newSupervisor.Entity.Id;
    }

    public bool DeletePerson(int id)
    {
        var person = _dbContext.Persons.FirstOrDefault(p => p.Id == id);
        if (person == null) return false;

        _dbContext.Persons.Remove(person);
        _dbContext.SaveChanges();
        return true;
    }

    public bool UpdateTeacher(int id, string lastName, string firstName, string? patronymicName, string position)
    {
        var teacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null) return false;
        
        
        teacher.LastName = lastName;
        teacher.FirstName = firstName;
        teacher.PatronymicName = patronymicName;
        teacher.Position = position;
        
        _dbContext.SaveChanges();

        return true;
    }

    public bool UpdateStudent(int id, string lastName, string firstName, string? patronymicName, int? groupId)
    {
        var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return false;
        
        
        student.LastName = lastName;
        student.FirstName = firstName;
        student.PatronymicName = patronymicName;
        student.GroupId = groupId;
        
        _dbContext.SaveChanges();

        return true;
    }

    public bool UpdateSupervisor(int id, string lastName, string firstName, string? patronymicName)
    {
        var supervisor = _dbContext.Supervisors.FirstOrDefault(s => s.Id == id);
        if (supervisor == null) return false;
        
        
        supervisor.LastName = lastName;
        supervisor.FirstName = firstName;
        supervisor.PatronymicName = patronymicName;
        
        _dbContext.SaveChanges();

        return true;
    }

    public List<LessonDto> GetLessonsByTeacher(int teacherId)
    {
        return _dbContext.Lessons
            .Include(x => x.Teacher)
            .Where(x => x.TeacherId == teacherId)
            .Select(x => new LessonDto(x))
            .ToList();
    }

    public List<LessonDto> GetLessonsByStudent(int studentId)
    {
        var student = _dbContext.Students.FirstOrDefault(x => x.Id == studentId);
        if (student == null) return new List<LessonDto>();

        var practicalLessons = _dbContext.PracticalLessons
            .Include(x => x.Teacher)
            .Where(x => x.GroupId == student.GroupId);
        var lectures = _dbContext.Lectures
            .Include(x => x.Teacher)
            .Where(x => x.Groups.Select(y => y.Id == student.GroupId).Any());

        var lessons = new List<LessonDto>();
        lessons.AddRange(practicalLessons.Select(x => new LessonDto(x)));
        lessons.AddRange(lectures.Select(x => new LessonDto(x)));
        
        return lessons.OrderBy(x => x.DateTime).ToList();
    }

    public bool UpdateLessonByTeacher(int teacherId, int lessonId, string name)
    {

        var lesson = _dbContext.Lessons.FirstOrDefault(x => x.TeacherId == teacherId && x.Id == lessonId);
        if (lesson == null) return false;
        
        lesson.Name = name;

        _dbContext.SaveChanges();

        return true;

    }



}