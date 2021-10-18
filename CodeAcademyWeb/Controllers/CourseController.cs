using AcademyModel.Entities;
using AcademyModel.Services;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : Controller
	{
		private IDidactisService service;
		private IMapper mapper;
		public CourseController(IDidactisService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var course = service.GetAllCourses();
			var courseDTOs = mapper.Map<IEnumerable<CourseDTO>>(course);
			return Ok(courseDTOs);
		}
	}
}
