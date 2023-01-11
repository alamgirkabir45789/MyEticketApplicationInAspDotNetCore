using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEticketApplication.Data;
using MyEticketApplication.Models;
using System.Net;

namespace MyEticketApplication.Controllers
{
    public class AgentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public AgentController(ApplicationDbContext context,IWebHostEnvironment environment) 
        { 
        _context= context;
            _environment= environment;
        }
        public async Task <IActionResult> Index()
        {
            var data=await _context.Agents.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Agent agent)
        {
            if(agent.ImageUrl != null && agent.JoiningDate !=null)
            {
                string uniqueFileName = null;
              
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + agent.ImageUrl.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        agent.ImageUrl.CopyTo(fileStream);
                    }
                agent.UrlImage = uniqueFileName;

                _context.Agents.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }
    }
}
