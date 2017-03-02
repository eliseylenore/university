using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace University
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>{
                List<Department> AllDepartments = Department.GetAll();
                return View["index.cshtml", AllDepartments];
            };

            Post["/department/new"] = _ => {
                Department newDepartment = new Department(Request.Form["department-name"]);
                newDepartment.Save();

                List<Department> AllDepartments = Department.GetAll();
                return View["index.cshtml", AllDepartments];
            };

            Get["/courses"] = _ => {
                List<Course> AllCourses = Course.GetAll();
                return View["courses.cshtml", AllCourses];
            };

            Post["/course/new"] = _ => {
                Course newCourse = new Course(Request.Form["course-name"], Request.Form["course-number"]);
                newCourse.Save();
                List<Course> AllCourses = Course.GetAll();
                return View["courses.cshtml", AllCourses];
            };

            Get["/students"] = _ => {
                List<Student> AllStudents = Student.GetAll();
                return View["students.cshtml", AllStudents];
            };

            Post["/student/new"] = _ => {
                Student newStudent = new Student(Request.Form["student-name"]);
                newStudent.Save();
                List<Student> AllStudents = Student.GetAll();
                return View["students.cshtml", AllStudents];
            };

            Delete["/student/delete/{id}"] = parameters =>  {
                Student foundStudent = Student.Find(parameters.id);
                foundStudent.Delete();
                List<Student> AllStudents = Student.GetAll();
                return View["students.cshtml", AllStudents];
            };

        }
    }
}
