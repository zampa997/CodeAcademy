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
		private IInstructorRepository instructorRepo;
		private ICourseRepository courseRepo;
		private IEditionRepository editionRepo;

		private AcademyContext ctx;
		public EFDidactisService(ICourseRepository courseRepo,IEditionRepository editionRepo, IInstructorRepository instructorRepo, AcademyContext ctx)
		{
			this.courseRepo = courseRepo;
			this.editionRepo = editionRepo;
			this.instructorRepo = instructorRepo;
			this.ctx = ctx;
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



		public IEnumerable<CourseEdition> GetAllEditions()
		{
			return editionRepo.GetAll();
		}

		public CourseEdition GetEditionById(long id)
		{
			return editionRepo.FindById(id);
		}

		public CourseEdition CreateCourseEdition(CourseEdition e)
		{
			CheckCourse(e.CourseId);
			CheckInstructor(e.InstructorId);
			editionRepo.Create(e);
			ctx.SaveChanges();
			return e;			
		}

		public CourseEdition EditCourseEdition(CourseEdition e)
		{
			CheckCourse(e.CourseId);
			CheckInstructor(e.InstructorId);
			CheckCourseEdition(e.Id);
			editionRepo.Update(e);
			ctx.SaveChanges();
			return e;
		}
		public void DeleteCourseEdition(long id)
		{
			var edition = CheckCourseEdition(id);
			editionRepo.Delete(edition);
			ctx.SaveChanges();
		}

		private Course CheckCourse(long id)
		{
			var course = courseRepo.FindById(id);
			if (course == null)
			{
				throw new EntityNotFoundException("L'id del corso non corrisponde ad un corso esistente", nameof(Course));
			}
			return course;
		}
		private Instructor CheckInstructor(long id)
		{
			var instructor = instructorRepo.FindById(id);
			if (instructor == null)
			{
				throw new EntityNotFoundException("L'id dell'istruttore non corrisponde ad un istruttore esistente", nameof(Instructor));
			}
			return instructor;
		}
		private CourseEdition CheckCourseEdition(long id)
		{
			var courseEdition = editionRepo.FindById(id);
			if (courseEdition == null)
			{
				throw new EntityNotFoundException("L'id dell'edizione non corrisponde ad un edizione esistente", nameof(CourseEdition));
			}
			return courseEdition;
		}

		
	}
}
