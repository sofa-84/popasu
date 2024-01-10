using Lessons.Domain.DTO;
using Lessons.Domain.DTO.Person;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Lessons.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public IEnumerable<GroupDto> GetGroups()
    {
        return _groupService.GetGroups();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetGroup([FromRoute]int id)
    {
        var group = _groupService.GetGroup(id);
        return group != null ? Ok(group) : BadRequest("Данной группы не существует!");
    }

    [HttpPost]
    public IActionResult AddGroup([FromBody]CreateGroupDto dto)
    {
        var id = _groupService.AddGroup(dto.Course, dto.Number, dto.Speciality);
        return id > 0 ? Ok(id) : BadRequest("Такая группа уже существует!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGroup([FromRoute]int id)
    {
        var result = _groupService.DeleteGroup(id);
        return result ? Ok(result) : BadRequest("Такой группы не существует!");
    }
    
    [HttpPut("{id}")]
    public IActionResult DeleteGroup([FromRoute]int id, [FromBody]CreateGroupDto dto)
    {
        var result = _groupService.UpdateGroup(id, dto.Course, dto.Number, dto.Speciality);
        return result switch
        {
            -1 => BadRequest("Такой группы не существует!"),
            0 => BadRequest("Группа с таким номером уже существует!"),
            _ => Ok()
        };
    }

    [HttpPost("{groupId}")]
    public IActionResult AddStudentsToGroup([FromRoute]int groupId, [FromBody]List<int> studentsId)
    {
        var result = _groupService.AddStudentsToGroup(groupId, studentsId);
        return result switch
        {
            -1 => BadRequest("Такой группы не существует!"),
            _ => Ok()
        };
    }
}