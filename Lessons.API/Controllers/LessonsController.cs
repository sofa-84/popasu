using Lessons.Domain.DTO.Lesson;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Lessons.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }


    [HttpGet]
    public IEnumerable<LessonDto> GetLessons()
    {
        return _lessonService.GetLessons();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetLesson([FromRoute]int id)
    {
        var lesson = _lessonService.GetLesson(id);
        return lesson != null ? Ok(lesson) : BadRequest("Данного занятия не существует!");
    }
    
    [HttpPost("Lectures")]
    public IActionResult AddLecture([FromBody]CreateLectureDto dto)
    {
        var id = _lessonService.AddLesson(dto.Name, dto.DateTime, dto.Classroom, dto.LectureType, dto.TeacherId, dto.GroupsId);
        return id > 0 ? Ok(id) : BadRequest("Такое занятие уже существует!");
    }
    
    [HttpPost("PracticalLessons")]
    public IActionResult AddPracticalLesson([FromBody]CreatePracticalLessonDto dto)
    {
        var id = _lessonService.AddLesson(dto.Name, dto.DateTime, dto.Classroom, dto.PracticalLessonType, dto.TeacherId, dto.GroupId);
        return id > 0 ? Ok(id) : BadRequest("Такое занятие уже существует!");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteLesson([FromRoute]int id)
    {
        var result = _lessonService.DeleteLesson(id);
        return result ? Ok(result) : BadRequest("Такого занятия не существует!");
    }
    

    
    [HttpPut("Lectures/{id}")]
    public IActionResult UpdateLecture([FromRoute]int id, [FromBody]CreateLectureDto dto)
    {
        var result = _lessonService.UpdateLesson(id, dto.Name, dto.DateTime, dto.Classroom, dto.LectureType, dto.TeacherId, dto.GroupsId);
        return result ? Ok(result) : BadRequest("Такого занятия не существует!");
    }
    
    [HttpPut("PracticalLessons/{id}")]
    public IActionResult UpdatePracticalLesson([FromRoute]int id, [FromBody]CreatePracticalLessonDto dto)
    {
        var result = _lessonService.UpdateLesson(id, dto.Name, dto.DateTime, dto.Classroom, dto.PracticalLessonType, dto.TeacherId, dto.GroupId);
        return result ? Ok(result) : BadRequest("Такого занятия не существует!");
    }
}