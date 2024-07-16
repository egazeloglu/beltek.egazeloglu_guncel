using beltek.egazeloglu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace beltek.egazeloglu.Controllers
{
    public class SinifController : Controller
    {
        public readonly OgrDbContext _context;

        public SinifController(OgrDbContext context)
        {
            _context = context;
        }
        // Benim Kodum
        //public IActionResult Index()
        //{
        //    using (var ctx = new OgrDbContext())
        //    {
        //        var siniflar = ctx.Siniflar.ToList();
        //        return View(siniflar);
        //    }
        //}

        // ChatGPT destekli Benim Kodum
        public async Task<IActionResult> Index()
        {
            var siniflar = await _context.Siniflar.ToListAsync();
            return View(siniflar);
        }

        //public IActionResult SinifEkle(Sinif snf)
        //{
        //    using (var ctx = new OgrDbContext())
        //    {
        //        ctx.Siniflar.Add(snf);
        //        ctx.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> SinifEkle(string sinifAd, int kontenjan)
        {
            if (ModelState.IsValid)
            {
                var yeniSinif = new Sinif
                {
                    SinifAd = sinifAd,
                    Kontenjan = kontenjan
                };

                _context.Siniflar.Add(yeniSinif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index), await _context.Siniflar.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SinifDuzenle(int id, string sinifAd, int kontenjan)
        {
            var sinif = await _context.Siniflar.FindAsync(id);
            if (sinif == null)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                sinif.SinifAd = sinifAd;
                sinif.Kontenjan = kontenjan;
                _context.Update(sinif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinif);
        }

        public async Task<IActionResult> SinifSil(int id)
        {
            var sinif = await _context.Siniflar.FindAsync(id);
            if (sinif != null)
            {
                _context.Siniflar.Remove(sinif);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
