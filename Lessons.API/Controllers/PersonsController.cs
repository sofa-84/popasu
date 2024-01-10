using Lessons.Domain.DTO.Lesson;
using Lessons.Domain.DTO.Person;
using Lessons.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Lessons.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IEnumerable<PersonDto> GetPersons()
    {
        return _personService.GetPersons();
    }
    
    [HttpGet("Teachers")]
    public IEnumerable<PersonDto> GetTeachers()
    {
        return _personService.GetTeachers();
    }
    [HttpGet("Students")]
    public IEnumerable<PersonDto> GetStudents()
    {
        return _personService.GetStudents();
    }
    [HttpGet("Supervisors")]
    public IEnumerable<PersonDto> GetSupervisors()
    {
        return _personService.GetSupervisors();
    }


    [HttpPost("Teachers")]
    public IActionResult AddTeacher([FromBody]CreateTeacherDto dto)
    {
        var id = _personService.AddTeacher(dto.LastName, dto.FirstName, dto.PatronymicName, dto.Position);
        return id > 0 ? Ok(id) : BadRequest("Такой преподаватель уже существует!");
    }
    
    [HttpPost("Students")]
    public IActionResult AddStudent([FromBody]CreateStudentDto dto)
    {
        var id = _personService.AddStudent(dto.LastName, dto.FirstName, dto.PatronymicName, dto.GroupId);
        return id > 0 ? Ok(id) : BadRequest("Такой студент уже существует!");
    }
    
    [HttpPost("Supervisors")]
    public IActionResult AddSupervisor([FromBody]CreateSupervisorDto dto)
    {
        var id = _personService.AddSupervisor(dto.LastName, dto.FirstName, dto.PatronymicName);
        return id > 0 ? Ok(id) : BadRequest("Такой диспетчер уже существует!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson([FromRoute]int id)
    {
        var result = _personService.DeletePerson(id);
        return result ? Ok(result) : BadRequest("Такого человека не существует!");
    }
    
    [HttpPut("Teachers/{id}")]
    public IActionResult UpdateTeacher([FromRoute]int id, [FromBody]CreateTeacherDto dto)
    {
        var result = _personService.UpdateTeacher(id, dto.LastName, dto.FirstName, dto.PatronymicName, dto.Position);
        return result ? Ok(result) : BadRequest("Такого преподавателя не существует!");
    }
    
    [HttpPut("Students/{id}")]
    public IActionResult UpdateStudent([FromRoute]int id, [FromBody]CreateStudentDto dto)
    {
        var result = _personService.UpdateStudent(id, dto.LastName, dto.FirstName, dto.PatronymicName, dto.GroupId);
        return result ? Ok(result) : BadRequest("Такого студента не существует!");
    }
    
    [HttpPut("Supervisors/{id}")]
    public IActionResult UpdateSupervisor([FromRoute]int id, [FromBody]CreateSupervisorDto dto)
    {
        var result = _personService.UpdateSupervisor(id, dto.LastName, dto.FirstName, dto.PatronymicName);
        return result ? Ok(result) : BadRequest("Такого диспетчера не существует!");
    }

    [HttpGet("Students/{id}/Lessons")]
    public IEnumerable<LessonDto> GetLessonsByStudent([FromRoute]int id)
    {
        return _personService.GetLessonsByStudent(id);
    }
    
    [HttpGet("Teachers/{id}/Lessons")]
    public IEnumerable<LessonDto> GetLessonsByTeacher([FromRoute]int id)
    {
        return _personService.GetLessonsByTeacher(id);
    }
    
    [HttpPut("Teachers/{teacherId}/Lessons/{lessonId}")]
    public IActionResult UpdateLessonByTeacher([FromRoute]int teacherId, [FromRoute]int lessonId, [FromBody]string name)
    {
        var result = _personService.UpdateLessonByTeacher(teacherId, lessonId, name);
        return result ? Ok(result) : BadRequest("Такого занятия не существует!");
    }
}