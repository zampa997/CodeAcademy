using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Profiles
{
	public class CourseEditionProfile : Profile
	{
		public CourseEditionProfile()
		{
			CreateMap<CourseEdition, CourseEditionDTO>();
			CreateMap<CourseEditionDTO, CourseEdition>();
			CreateMap<CourseEdition, CourseEditionDetailsDTO>()
				.ForMember(dto => dto.InstructorFullName, opt => opt.MapFrom(edition => $"{edition.Instructor.Firstname} {edition.Instructor.Lastname}"))
				.ForMember(dto => dto.StartDate, opt => opt.MapFrom(edition => edition.StartDate.ToString("yyyy/MM/dd", null)))
				.ForMember(dto => dto.FinalizationDate, opt => opt.MapFrom(edition => edition.FinalizationDate.ToString("yyyy/MM/dd", null)));
			CreateMap<CourseEditionDetailsDTO, CourseEdition>()
				.ForMember(edition => edition.StartDate, opt => opt.MapFrom(dto => Parse(dto.StartDate)))
				.ForMember(edition => edition.FinalizationDate, opt => opt.MapFrom(dto => Parse(dto.FinalizationDate)));
				
		}
		private LocalDate Parse(string dateString)
		{
			LocalDatePattern pattern = LocalDatePattern.CreateWithCurrentCulture("yyyy/MM/dd");
			var result = pattern.Parse(dateString);
			return result.Value;
		}
	}
}
