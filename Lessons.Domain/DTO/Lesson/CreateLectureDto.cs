using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Lesson;

public class CreateLectureDto : CreateLessonDto
{
    public LectureType LectureType { get; set; }
    public List<int> GroupsId { get; set; }

    public CreateLectureDto() : base()
    {
        LectureType  = LectureType.Offline;
    }
    public CreateLectureDto( string name, DateTime dateTime, int classroom, int teacherId, LectureType lectureType, List<int> groupsId) 
        : base(name, dateTime, classroom, teacherId, LessonType.Lecture)
    {
        LectureType = lectureType;
        GroupsId = groupsId;
    }

    public CreateLectureDto(Lecture lecture) : this(lecture.Name, lecture.DateTime, lecture.Classroom, lecture.TeacherId, lecture.Type, lecture.Groups.Select(x => x.Id).ToList())
    {
        
    }

}