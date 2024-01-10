using Lessons.Domain.DTO.Lesson;
using Lessons.Domain.Model;

namespace Services.Interfaces;

public interface ILessonService
{
    List<LessonDto> GetLessons();

    LessonDto? GetLesson(int id);

    /*LectureDto? GetLecture(int id);
    PracticalLessonDto? GetPracticalLesson(int id);*/
    
    int AddLesson(string name, DateTime dateTime, int classroom, LectureType lectureType, int teacherId, List<int> groupsId);
    int AddLesson(string name, DateTime dateTime, int classroom, PracticalLessonType practicalLessonType, int teacherId, int groupId);

    bool DeleteLesson(int id);
    bool UpdateLesson(int id, string name, DateTime dateTime, int classroom, LectureType lectureType, int teacherId, List<int> groupsId);
    bool UpdateLesson(int id, string name, DateTime dateTime, int classroom,
        PracticalLessonType practicalLessonType, int teacherId, int groupId);
    
    
}