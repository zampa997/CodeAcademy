using AcademyEfPersistance.EFContext;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using AcademyModel.Exceptions;
using AcademyModel.Repositories;
using AcademyModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.Services
{
	public class EFDidactisService : IDidactisService
	{
		private IStudentRepository studentRepo;
		private ICourseRepository courseRepo;
		private AcademyContext ctx;
		public EFDidactisService(IStudentRepository studentRepo, ICourseRepository courseRepo, AcademyContext ctx)
		{
			this.studentRepo = studentRepo;
			this.courseRepo = courseRepo;
			this.ctx = ctx;
		}

		public Student CreateStudent(Student s)
		{
			studentRepo.Create(s);
			ctx.SaveChanges(); //Salviamo qui invece che nella repository
			return s;
		}

		public IEnumerable<Student> GetAllStudents()
		{
			return studentRepo.GetAll();
		}

		public IEnumerable<Student> GetStudentsByLastnameLike(string lastnameLike)
		{
			return studentRepo.FindByLastnameLike(lastnameLike).ToList(); //Non più una query, ma una lista vera e propria grazie a .ToList
		}
		public Student GetStudentById(long id)
		{
			return studentRepo.FindStudentWithCoursesById(id);
		}

		public void UpdateStudent(Student s)
		{
			studentRepo.Update(s);
			ctx.SaveChanges();
		}
		public void Delete(Student s)
		{
			studentRepo.Delete(s);
			ctx.SaveChanges();
		}

		public IEnumerable<Course> GetAllFutureCourses()
		{
			return courseRepo.GetAllFutureCourses().ToList();
		}

		public IEnumerable<Course> GetAllUnfinishedCourses()
		{
			return courseRepo.GetAllUnfinishedCourses().ToList();
		}

		public void EnrollSudentToCourse(EnrollData data)
		{
			//var student = studentRepo.FindById(data.IdStudent);
			//if (student==null)
			//{
			//	throw new EntityNotFoundException($"Lo studente con id {data.IdStudent} non esiste.",  nameof(Student));
			//}
			//var course = courseRepo.FindById(data.IdCourse);
			//if (course == null)
			//{
			//	throw new EntityNotFoundException($"Il corso con id {data.IdCourse} non esiste.", nameof(Course));
			//}
			//student.Courses.Add(course);
			//course.EnrollStudents.Add(student);
			//ctx.SaveChanges();
		}
	}
}
