using AcademyEFPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using Microsoft.EntityFrameworkCore;
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
		public IEnumerable<Enrollment> GetEnrollmentByStudentId(long id)
		{
			return ctx.Enrollments.Include(e => e.Student).Include(e => e.CourseEdition).Where(e => e.StudentId == id);
		}
	}
}
