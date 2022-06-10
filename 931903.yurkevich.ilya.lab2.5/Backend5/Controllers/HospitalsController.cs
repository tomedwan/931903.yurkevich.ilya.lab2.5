using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class HospitalsController : Controller
    {
        private ApplicationContext db;
        public HospitalsController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Hospitals.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Hospital hosp)
        {
            if (!ModelState.IsValid) View(hosp);

                db.Hospitals.Add(hosp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Hospital hosp = await db.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hosp != null)
                    return View(hosp);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Hospital hosp = await db.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hosp != null)
                    return View(hosp);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Hospital hosp)
        {
            db.Hospitals.Update(hosp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Hospital hosp = await db.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hosp != null)
                    return View(hosp);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Hospital hosp = await db.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hosp != null)
                {
                    db.Hospitals.Remove(hosp);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
