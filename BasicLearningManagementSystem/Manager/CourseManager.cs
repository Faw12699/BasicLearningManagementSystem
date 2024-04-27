using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using BasicLearningManagementSystem.Models;
using System.Web;

namespace BasicLearningManagementSystem.Manager
{
    public class CourseManager
    {
        public void AddCourse(Course course)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries(@"INSERT INTO Course(name, crhrs, instructor) 
                                    VALUES('" + course.name + "', " + course.crhrs + ", '" + course.instructor + "')");
            Connection.CloseConnection();
        }

        public List<Course> ViewCourse()
        {
            Connection.OpenConnection();
            DataTable dt = Connection.DataView("SELECT * FROM Course");

            List<Course> data = new List<Course>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Course obj = new Course();
                obj.id = int.Parse(dt.Rows[i][0].ToString());
                obj.name = dt.Rows[i][1].ToString();
                obj.crhrs = int.Parse(dt.Rows[i][2].ToString());
                obj.instructor = dt.Rows[i][3].ToString();

                data.Add(obj);
            }

            Connection.CloseConnection();
            return data;
        }
    }
}