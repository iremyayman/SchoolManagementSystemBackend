using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class StudentCourse :IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Final { get; set; }
        public int TotalGrade { get; set; }
    }
}
