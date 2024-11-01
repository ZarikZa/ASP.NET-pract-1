using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parashka_KakashkaASP.NET.Models;

namespace Parashka_KakashkaASP.NET.Controllers
{
    public class CRUDController : Controller
    {
        private RpmContext db;

        public CRUDController(RpmContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Unitazs.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Unitaz unit)
        {
            db.Unitazs.Add(unit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if(id != null)
            {
                Unitaz unit = await db.Unitazs.FirstOrDefaultAsync(p => p.UnitazId == id);
                if(unit != null) 
                    return View(unit);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Unitaz unit)
        {
            db.Unitazs.Update(unit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Unitaz unit = await db.Unitazs.FirstOrDefaultAsync(p => p.UnitazId == id);
                if (unit != null)
                    return View(unit);
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Unitaz unit = await db.Unitazs.FirstOrDefaultAsync(p => p.UnitazId == id);
                if (unit != null)
                    return View(unit);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Unitaz unit = await db.Unitazs.FirstOrDefaultAsync(p => p.UnitazId == id);
                if (unit != null)
                {
                    db.Unitazs.Remove(unit);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
