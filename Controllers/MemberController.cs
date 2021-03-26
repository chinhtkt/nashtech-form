using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nashtech_form.Mvc.Models;


namespace nashtech_form.Mvc.Controllers
{
    public class MemberController : Controller
    {
        private readonly Service _service;
        public MemberController(Service service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.Get());
        }

        public IActionResult Details(int id)
        {
            var b = _service.Get(id);
            if (b == null) return NotFound();
            else return View(b);
        }
        public IActionResult Delete(int id)
        {
            var b = _service.Get(id);
            if (b == null) return NotFound();
            else return View(b);
        }

        [HttpPost]
        public IActionResult Delete(Member member)
        {
            _service.Delete(member.Id);
            _service.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}