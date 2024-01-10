using Lessons.Domain.DTO.Lesson;
using Lessons.Domain.DTO.Person;
using Lessons.Domain.Model;

namespace Services.Interfaces;

public interface IPersonService
{
    List<PersonDto> GetPersons();
    List<TeacherDto> GetTeachers();
    List<StudentDto> GetStudents();
    List<SupervisorDto> GetSupervisors();

    int AddTeacher(string lastName, string firstName, string? patronymicName, string position);
    int AddStudent(string lastName, string firstName, string? patronymicName, int? groupId);
    int AddSupervisor(string lastName, string firstName, string? patronymicName);
    
    bool DeletePerson(int id);
    
    bool UpdateTeacher(int id, string lastName, string firstName, string? patronymicName, string position);
    bool UpdateStudent(int id, string lastName, string firstName, string? patronymicName, int? groupId);
    bool UpdateSupervisor(int id, string lastName, string firstName, string? patronymicName);

    List<LessonDto> GetLessonsByTeacher(int teacherId);

    List<LessonDto> GetLessonsByStudent(int studentId);
    
    bool UpdateLessonByTeacher(int teacherId, int lessonId, string name);

}