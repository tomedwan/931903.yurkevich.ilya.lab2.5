using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationContext db;
        public DoctorsController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Doctors.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doc)
        {
            db.Doctors.Add(doc);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Doctor doc = await db.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                if (doc != null)
                    return View(doc);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Doctor doc = await db.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                if (doc != null)
                    return View(doc);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doc)
        {
            db.Doctors.Update(doc);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Doctor doc = await db.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                if (doc != null)
                    return View(doc);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Doctor doc = await db.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                if (doc != null)
                {
                    db.Doctors.Remove(doc);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
