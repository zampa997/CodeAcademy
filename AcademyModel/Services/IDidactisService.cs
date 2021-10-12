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
		


		CourseEdition CreateCourseEdition(CourseEdition e);
		IEnumerable<Course> GetAllFutureCourses();
		IEnumerable<Course> GetAllUnfinishedCourses();
		IEnumerable<CourseEdition> GetAllEditions();
		CourseEdition GetEditionById(long id);
		CourseEdition EditCourseEdition(CourseEdition e);
		void DeleteCourseEdition(long id);




		//void EnrollSudentToCourse(EnrollData data);
	}

}
