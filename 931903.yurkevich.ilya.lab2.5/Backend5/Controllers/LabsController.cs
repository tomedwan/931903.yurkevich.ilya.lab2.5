using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class LabsController : Controller
    {
        private ApplicationContext db;
        public LabsController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Labs.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Lab lb)
        {
            db.Labs.Add(lb);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Lab lb = await db.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lb != null)
                    return View(lb);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Lab lb = await db.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lb != null)
                    return View(lb);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Lab lb)
        {
            db.Labs.Update(lb);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Lab lb = await db.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lb != null)
                    return View(lb);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Lab lb = await db.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lb != null)
                {
                    db.Labs.Remove(lb);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
