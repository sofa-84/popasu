using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;

public class CreatePersonDto
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? PatronymicName { get; set; }
    private PersonRole PersonRole { get; set; }

    public CreatePersonDto()
    {
        
    }
    public CreatePersonDto(string lastName, string firstName, string? patronymicName, PersonRole personRole)
    {
        LastName = lastName;
        FirstName = firstName;
        PatronymicName = patronymicName;
        PersonRole = personRole;
    }

    public CreatePersonDto(Model.Person person) : this(person.LastName, person.FirstName, person.PatronymicName, person.PersonRole)
    {
        
    }
}