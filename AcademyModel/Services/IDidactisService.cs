//using SchoolModel.BuisnessLogic;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using NodaTime;
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
		IEnumerable<Course> FindCourseByTitleLike(string title);
		IEnumerable<Course> FindCourseByCourseDescriptionLike(string description);
		IEnumerable<Course> FindCourseByArea(long idArea);

		IEnumerable<CourseEdition> GetAllEditions();
		CourseEdition GetEditionById(long id);
		CourseEdition EditCourseEdition(CourseEdition e);
		void DeleteCourseEdition(long id);
		IEnumerable<CourseEdition> Search(EditionSearchInfo info);

		

		IEnumerable<Lesson> FindLessonForEditionId(long id);
		IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end);




		
	}

}
