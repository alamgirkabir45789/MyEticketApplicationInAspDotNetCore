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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agent = await _context.Agents
            .FirstOrDefaultAsync(m => m.AgentId == id);
            return View(agent);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Agent agent)
        {
            if(agent.ImageUrl != null )
            {
                
                
                agent.UrlImage = ProcessUploadImage(agent);

                _context.Agents.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            };
            return View(agent);
        }
        public string ProcessUploadImage(Agent agent)
        {
                string uniqueFileName = null;
            if (agent.ImageUrl != null)
            {

                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + agent.ImageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    agent.ImageUrl.CopyTo(fileStream);
                };
            }
                return uniqueFileName;
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var agent = await _context.Agents
            .FirstOrDefaultAsync(m => m.AgentId == id);
            return View(agent);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id != 0)
            {
                var agent = await _context.Agents
               .FirstOrDefaultAsync(m => m.AgentId == id);
               
                var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", agent.UrlImage);
                _context.Agents.Remove(agent);
                if (await _context.SaveChangesAsync() > 0)
                {
                    if (System.IO.File.Exists(CurrentImage))
                    {
                        System.IO.File.Delete(CurrentImage);
                    }
                }

                return RedirectToAction("Index");
            };
            return View();

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agent=await _context.Agents.FirstOrDefaultAsync(m => m.AgentId == id);
            return View(agent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Agent agent)
        {
            if (id != null)
            {
                if (agent.ImageUrl != null)
                {


                    agent.UrlImage = ProcessUploadImage(agent);
                    var data = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == id);
                    _context.Agents.Add(data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                };
            }
            return View(agent);
            //var uniqueImage = ProcessUploadImage(agent);
            //var data = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == id);
            //data.ImageUrl = uniqueImage;
            //_context.Agents.Update(data);
            //await _context.SaveChangesAsync();
            //return RedirectToAction("Index");
        }
    }
}
