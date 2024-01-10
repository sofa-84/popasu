using System.ComponentModel.DataAnnotations.Schema;

namespace Lessons.Domain.Model;

[Table("Students")]
public class Student : Person
{
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
}