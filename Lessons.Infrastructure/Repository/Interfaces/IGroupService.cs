using System.Text.RegularExpressions;
using Lessons.Domain.DTO;
using Lessons.Domain.DTO.Person;

namespace Services.Interfaces;

public interface IGroupService
{
    List<GroupDto> GetGroups();
    GroupDto? GetGroup(int id);
    int AddGroup(int course, string number, string speciality);
    bool DeleteGroup(int id);
    int UpdateGroup(int id, int course, string number, string speciality);
    int AddStudentsToGroup(int groupId, List<int> studentsId);

}