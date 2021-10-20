using AcademyEFPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.Repository
{
	public class EFEnrollmentRepository : EFCrudRepository<Enrollment, long>, IEnrollmentRepository
	{
		public EFEnrollmentRepository(AcademyContext ctx) : base(ctx)
		{
		}
		public IEnumerable<Enrollment> GetSubscribedEnrollmentByStudentId(long id)
		{
			return ctx.Enrollments.Include(e => e.Student).Include(e => e.CourseEdition).Where(e => e.StudentId == id);
		}
		public IEnumerable<Enrollment> GetAvailableEnrollmentByStudentId(long id)
		{
			LocalDate today = LocalDate.FromDateTime(new DateTime());
			return ctx.Enrollments.Include(e => e.Student).Include(e => e.CourseEdition).Where(e => e.StudentId != id && e.CourseEdition.StartDate > today);
		}
	}
}
