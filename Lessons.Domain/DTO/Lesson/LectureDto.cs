using Lessons.Domain.DTO.Person;
using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Lesson;

public class LectureDto : LessonDto
{
    public LectureType LectureType { get; set; }
    public List<GroupDto> Groups { get; set; }

    
    public LectureDto() : base()
    {
        LectureType  = LectureType.Offline;
    }
    public LectureDto(int id , string name, DateTime dateTime, int classroom, TeacherDto teacher, LectureType lectureType, List<GroupDto> groups) 
        : base(id, name, dateTime, classroom, teacher, LessonType.Lecture)
    {
        LectureType = lectureType;
        Groups = groups;
    }

    public LectureDto(Lecture lecture) 
        : this(lecture.Id, lecture.Name, lecture.DateTime, lecture.Classroom, new TeacherDto(lecture.Teacher), lecture.Type, lecture.Groups.Select(x => new GroupDto(x)).ToList())
    {
        
    }
}