using Lessons.Domain.DTO.Lesson;
using Lessons.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Lessons.Infrastructure.Repository.Realization;

public class LessonService : ILessonService
{
    private LessonsDbContext _dbContext;
    
    public LessonService(LessonsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<LessonDto> GetLessons()
    {
        return _dbContext.Lessons.Include(x => x.Teacher).Select(x => new LessonDto(x)).ToList();
    }

    public LessonDto? GetLesson(int id)
    {
        var lesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == id);
        if (lesson == null) return null;

        if (lesson.LessonType == LessonType.Lecture)
        {
            var lecture = _dbContext.Lectures.Include(x => x.Groups).Include(x => x.Teacher).FirstOrDefault(x => x.Id == id);
            return new LectureDto(lecture);
        }

        var practicalLesson = _dbContext.PracticalLessons.Include(x => x.Group).Include(x => x.Teacher).FirstOrDefault(x => x.Id == id);
        return new PracticalLessonDto(practicalLesson);
    }

    public int AddLesson(string name, DateTime dateTime, int classroom, LectureType lectureType, int teacherId,
        List<int> groupsId)
    {
        var groups = _dbContext.Groups.Where(x => groupsId.Contains(x.Id)).ToList();
        var lecture = new Lecture()
        {
            Name = name,
            DateTime = dateTime,
            Classroom = classroom,
            LessonType = LessonType.Lecture,
            Type = lectureType,
            TeacherId = teacherId,
            Groups = groups
        };

        var newLesson = _dbContext.Lectures.Add(lecture);
        _dbContext.SaveChanges();
        return newLesson.Entity.Id;    }

    public int AddLesson(string name, DateTime dateTime, int classroom,
        PracticalLessonType practicalLessonType, int teacherId, int groupId)
    {
        var practicalLesson = new PracticalLesson()
        {
            Name = name,
            DateTime = dateTime,
            Classroom = classroom,
            LessonType = practicalLessonType == PracticalLessonType.Practice ? LessonType.Practice : LessonType.Lab,
            Type = practicalLessonType,
            TeacherId = teacherId,
            GroupId = groupId
        };

        var newLesson = _dbContext.PracticalLessons.Add(practicalLesson);
        _dbContext.SaveChanges();
        return newLesson.Entity.Id;
    }

    public bool DeleteLesson(int id)
    {
        var lesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == id);
        if (lesson == null) return false;

        _dbContext.Lessons.Remove(lesson);
        _dbContext.SaveChanges();
        return true; 
    }



    public bool UpdateLesson(int id, string name, DateTime dateTime, int classroom, LectureType lectureType,
        int teacherId, List<int> groupsId)
    {
        var lecture = _dbContext.Lectures.Include(x => x.Groups).FirstOrDefault(x => x.Id == id);
        if (lecture == null) return false;
        
        
        var groups = _dbContext.Groups.Where(x => groupsId.Contains(x.Id)).ToList();

        lecture.Name = name;
        lecture.DateTime = dateTime;
        lecture.Classroom = classroom;
        lecture.Type = lectureType;
        lecture.TeacherId = teacherId;
        var allGroups = lecture.Groups.ToList();
        foreach (var lectureGroup in allGroups)
        {
            lecture.Groups.Remove(lectureGroup);
        }

        lecture.Groups.AddRange(groups);

        _dbContext.SaveChanges();

        return true;
    }

    public bool UpdateLesson(int id, string name, DateTime dateTime, int classroom,
        PracticalLessonType practicalLessonType, int teacherId, int groupId)
    {
        var practicalLesson = _dbContext.PracticalLessons.FirstOrDefault(x => x.Id == id);
        if (practicalLesson == null) return false;

        practicalLesson.Name = name;
        practicalLesson.DateTime = dateTime;
        practicalLesson.Classroom = classroom;
        practicalLesson.Type = practicalLessonType;
        practicalLesson.TeacherId = teacherId;
        practicalLesson.GroupId = groupId;
        _dbContext.SaveChanges();
        
        return true;
    }
}