﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicLearningManagementSystem.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string address { get; set; }
    }
}