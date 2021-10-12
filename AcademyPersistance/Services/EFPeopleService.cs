using AcademyEfPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using AcademyModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEfPersistance.Services
{
	
	public class EFPeopleService : IPeopleService
	{
		private IInstructorRepository instructorRepo;
		private IStudentRepository studentRepo;
		private AcademyContext ctx;

		public EFPeopleService(IStudentRepository studentRepo, IInstructorRepository instructorRepo, AcademyContext ctx)
		{
			this.instructorRepo = instructorRepo;
			this.instructorRepo = instructorRepo;
			this.ctx = ctx;
		}

		public Student CreateStudent(Student s)
		{
			studentRepo.Create(s);
			ctx.SaveChanges();  //Salviamo qui invece che nella repository
			return s;
		}
		public IEnumerable<Student> GetAllStudents()
		{
			return studentRepo.GetAll().ToList();
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
		public void DeleteStudent(Student s)
		{
			studentRepo.Delete(s);
			ctx.SaveChanges();
		}


		public Instructor GetInstructorById(long id)
		{
			return instructorRepo.FindById(id);
		}
	}
}
