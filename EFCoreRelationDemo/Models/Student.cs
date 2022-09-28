using System;
using System.Collections.Generic;

namespace EFCoreRelationDemo.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string  Name { get; set; }

        public IEnumerable<StudentCourse> StudentCourses { get; set; }
    }

    public class Course 
    {
        public int CourseId { get; set; }
        public string  Name { get; set; }

        public IEnumerable<StudentCourse> StudentCourses { get; set; }
    }

    //Join Table Entity 
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //Navigation Property 
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}