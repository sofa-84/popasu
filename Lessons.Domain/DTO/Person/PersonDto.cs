using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;


public class PersonDto
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? PatronymicName { get; set; }
    private PersonRole PersonRole { get; set; }

    public PersonDto()
    {
        
    }
    public PersonDto(int id, string lastName, string firstName, string? patronymicName, PersonRole personRole)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        PatronymicName = patronymicName;
        PersonRole = personRole;
    }

    public PersonDto(Model.Person person) : this(person.Id, person.LastName, person.FirstName, person.PatronymicName, person.PersonRole)
    {
        
    }
}