using Lessons.Domain.DTO;
using Lessons.Domain.DTO.Person;
using Lessons.Domain.Model;
using Services.Interfaces;

namespace Lessons.Infrastructure.Repository.Realization;

public class GroupService : IGroupService
{
    private LessonsDbContext _dbContext;
    
    public GroupService(LessonsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<GroupDto> GetGroups()
    {
        return _dbContext.Groups.Select(x => new GroupDto(x)).ToList<GroupDto>();
    }

    public GroupDto? GetGroup(int id)
    {
        var group = _dbContext.Groups
            .FirstOrDefault(x => x.Id == id);

        return (group != null) ? new GroupDto(group) : null;
    }

    public int AddGroup(int course, string number, string speciality)
    {
        var group = _dbContext.Groups.FirstOrDefault(g => g.Number == number);
        if (group != null) return -1;
        
        var newGroup = _dbContext.Groups.Add(new Group()
        {
            Course = course, Number = number, Speciality = speciality
        });
        
        _dbContext.SaveChanges();
        return newGroup.Entity.Id;
    }

    public bool DeleteGroup(int id)
    {
        var group = _dbContext.Groups.FirstOrDefault(g => g.Id == id);
        if (group == null) return false;

        _dbContext.Groups.Remove(group);
        _dbContext.SaveChanges();
        return true;
    }

    public int UpdateGroup(int id, int course, string number, string speciality)
    {
        var group = _dbContext.Groups.FirstOrDefault(g => g.Id == id);
        if (group == null) return -1;

        var anotherGroup = _dbContext.Groups.FirstOrDefault(g => g.Number == number && g.Id != id);
        if (anotherGroup != null) return 0;
        
        group.Course = course;
        group.Number = number;
        group.Speciality = speciality;
        _dbContext.SaveChanges();

        return 1;
    }

    public int AddStudentsToGroup(int groupId, List<int> studentsId)
    {
        var group = _dbContext.Groups.FirstOrDefault(x => x.Id == groupId);
        if (group == null) return -1;

        var students = _dbContext.Students.Where(x => studentsId.Contains(x.Id));

        foreach (var student in students)
        {
            student.GroupId = groupId;
        }

        _dbContext.SaveChanges();
        return 1;
    }
}