using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StudentCourseDetailDto : IDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentNumber { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Final { get; set; }
        public int TotalGrade { get; set; }


    }
}
