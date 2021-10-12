using AcademyEfPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using EFSchoolPersistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEfPersistance.Repository
{
	public class EFInstructorRepository : EFCrudRepository<Instructor, long>, IInstructorRepository
	{
		public EFInstructorRepository(AcademyContext ctx) : base(ctx)
		{
			// CTRL + . per crearlo in auto
		}
	}
}
