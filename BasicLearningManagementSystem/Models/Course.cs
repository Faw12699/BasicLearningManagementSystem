using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicLearningManagementSystem.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int crhrs { get; set; }
        public string instructor { get; set; }
    }
}