using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdfWithImage.Models;
using PdfWithImage.Report;

namespace PdfWithImage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _oHostEnvironment;

        public HomeController(IWebHostEnvironment oHostEnvironment)
        {
            _oHostEnvironment = oHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrintStudent(int param)
        {
            List<Student> students = new List<Student>();
            for (int i = 1; i <= 9; i++)
            {
                students.Add(new Student()
                {
                    StudentId = i,
                    Name = "Stu" + i,
                    Roll = "100" + i
                });
            }

            StudentReport rpt = new StudentReport(_oHostEnvironment);
            return File(rpt.Report(students), "application/pdf");
        }

    }
}
