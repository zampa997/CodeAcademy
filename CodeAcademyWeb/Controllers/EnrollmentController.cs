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
	public class EnrollmentController : Controller
	{
		private IPeopleService service;
		private IMapper mapper;
		public EnrollmentController(IPeopleService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}
		[HttpGet]
		[Route("student/{id}")]
		public IActionResult GetEnrollmentByStudentId(long id)
		{
			var enrollments = service.GetEnrollmentByStudentId(id);
			var enrollmentDTOs = mapper.Map<IEnumerable<EnrollmentDTO>>(enrollments);
			return Ok(enrollmentDTOs);
		}
	}
}
