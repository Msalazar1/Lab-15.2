using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab_15._2.Models;
using static Lab_15._2.Models.Movie;

namespace Lab_15._2.Controllers
{
	public class MovieController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[Route("[controller]")]
		[ApiController]
		public class Movie_Controller : ControllerBase
		{
			[HttpGet]
			public List<Movie> Movie()
			{
				List<Movie> movies = Movies.Read();
				return movies;
			}

			[HttpGet("Category")]
			public List<string> MovieCategories()
			{
				List<string> categories = Movies.ReadCategories();
				return categories;
			}

			[HttpGet("Category/{category}")]
			public List<Movie> Movie(string category)
			{
                List<Movie> movies = Movies.Read(category);
				return movies;
			}
		}
	}
}
