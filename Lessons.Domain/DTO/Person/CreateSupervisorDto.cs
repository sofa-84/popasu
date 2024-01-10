using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;

public class CreateSupervisorDto : CreatePersonDto
{
    public CreateSupervisorDto() : base()
    {
        
    }
    public CreateSupervisorDto(string lastName, string firstName, string? patronymicName) : base(lastName, firstName, patronymicName, PersonRole.Supervisor)
    {
    }

    public CreateSupervisorDto(Supervisor supervisor) : base(supervisor)
    {
    }
}