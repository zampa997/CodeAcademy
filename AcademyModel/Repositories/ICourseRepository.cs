using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Repositories
{
	public interface ICourseRepository : ICrudRepository<Course, long>
	{
		IEnumerable<Course> GetAllFutureCourses();
		IEnumerable<Course> GetAllUnfinishedCourses();
	}
}
