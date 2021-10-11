using AcademyEfPersistance.EFContext;
using NodaTime;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.Repository
{
	public class EFCourseRepository : EFCrudRepository<Course, long>, ICourseRepository
	{
	public EFCourseRepository(AcademyContext ctx) : base(ctx)
	{ }
		public IEnumerable<Course> GetAllFutureCourses()
		{
			//LocalDate Today = LocalDate.FromDateTime(new DateTime());
			//return ctx.Courses.Where(c => c.StartDate >= Today).OrderBy(c=> c.StartDate);
			return null;
		}

		public IEnumerable<Course> GetAllUnfinishedCourses()
		{
			//LocalDate Today = LocalDate.FromDateTime(new DateTime());
			//return ctx.Courses.Where(c => c.EndDate >= Today).OrderBy(c => c.StartDate);
			return null;
		}
	}
}
