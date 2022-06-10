using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationContext db;
        public PatientsController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Patients.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient pat)
        {
            db.Patients.Add(pat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Patient pat = await db.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                    return View(pat);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Patient pat = await db.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                    return View(pat);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Patient pat)
        {
            db.Patients.Update(pat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Patient pat = await db.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                    return View(pat);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Patient pat = await db.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                {
                    db.Patients.Remove(pat);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
