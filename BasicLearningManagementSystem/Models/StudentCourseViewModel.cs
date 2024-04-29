using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicLearningManagementSystem.Models
{
    public class StudentCourseViewModel
    {
        public List<Course> Course { get; set; }
        public Student Student { get; set; }
        public List<Register> Register { get; set; }
    }
}