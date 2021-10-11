//using SchoolModel.BuisnessLogic;
using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Services
{
	public interface IDidactisService
	{
		IEnumerable<Student> GetAllStudents();
		IEnumerable<Student> GetStudentsByLastnameLike(string lastnameLike);
		Student CreateStudent(Student s);
		Student GetStudentById(long id);
		void UpdateStudent(Student s);
		void Delete(Student s);
		IEnumerable<Course> GetAllFutureCourses();
		IEnumerable<Course> GetAllUnfinishedCourses();
		//void EnrollSudentToCourse(EnrollData data);
	}

}
