using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;

public class SupervisorDto : PersonDto
{
    public SupervisorDto() : base()
    {
        
    }
    public SupervisorDto(int id, string lastName, string firstName, string? patronymicName) : base(id, lastName, firstName, patronymicName, PersonRole.Supervisor)
    {
    }

    public SupervisorDto(Model.Person person) : base(person)
    {
    }
}