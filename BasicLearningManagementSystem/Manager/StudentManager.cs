using System;
using System.Collections.Generic;
using System.Linq;
using BasicLearningManagementSystem.Models;
using System.Data;
using System.Web;

namespace BasicLearningManagementSystem.Manager
{
    public class StudentManager
    {
        public void AddStudent(Student student) 
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries(@"INSERT INTO Student (name, email, password, gender, phone, city, address) 
                                VALUES('"+student.name+"', '"+student.email+"', '"+student.password+"', '"+student.gender+"', '"+student.phone+"', '"+student.city+"', '"+student.address+"')");
            Connection.CloseConnection();
        }
        public List<Student> ViewStudent()
        {
            Connection.OpenConnection();
            DataTable dt = Connection.DataView("SELECT * FROM Student");

            List<Student> data = new List<Student>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student obj = new Student();
                obj.id = int.Parse(dt.Rows[i][0].ToString());
                obj.name = dt.Rows[i][1].ToString();
                obj.gender = dt.Rows[i][4].ToString();
                obj.phone = dt.Rows[i][5].ToString();
                obj.city = dt.Rows[i][6].ToString();
                obj.address = dt.Rows[i][7].ToString();

                data.Add(obj);
            }
            
            Connection.CloseConnection();
            return data;
        }
        public void DeleteStudent(int id)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries("DELETE FROM Student WHERE id= " + id + "");
            Connection.CloseConnection();
        }
        public Student GetStudent(int id)
        {
            Student student = new Student();

            Connection.OpenConnection();
            DataTable dt = Connection.DataView("SELECT * FROM Student WHERE id= " + id + "");

            student.id = int.Parse(dt.Rows[0][0].ToString());
            student.name = dt.Rows[0][1].ToString();
            student.email = dt.Rows[0][2].ToString();
            student.password = dt.Rows[0][3].ToString();
            student.gender = dt.Rows[0][4].ToString();
            student.phone = dt.Rows[0][5].ToString();
            student.city = dt.Rows[0][6].ToString();
            student.address = dt.Rows[0][7].ToString();

            Connection.CloseConnection();
            return student;
        }
        public void UpdateStudent(Student student)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries(@"UPDATE Student
                                   SET name = '" + student.name + "', email = '" + student.email + "', password = '" + student.password + "', gender = '" + student.gender + "', phone = '" + student.phone + "', city = '" + student.city + "', address = '" + student.address + "' WHERE id = " + student.id + "");
            Connection.CloseConnection();
        }
    }
}