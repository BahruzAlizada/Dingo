﻿using Microsoft.AspNetCore.Mvc;

namespace Dingo.Controllers
{
	public class ReservationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}