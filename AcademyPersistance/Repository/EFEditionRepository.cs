using AcademyModel.Entities;
using EFSchoolPersistence.Repository;
using AcademyModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyEfPersistance.EFContext;
using Microsoft.EntityFrameworkCore;

namespace AcademyEfPersistance.Repository
{
	public class EFEditionRepository : EFCrudRepository<CourseEdition, long>, IEditionRepository
	{
		public EFEditionRepository(AcademyContext ctx) : base(ctx)
		{
			
		}
		public override CourseEdition FindById(long id)
		{
			return ctx.CourseEditions.Include( e => e.Course ).Include( e => e.Instructor ).SingleOrDefault ( e => e.Id == id );
		}
	}
}
