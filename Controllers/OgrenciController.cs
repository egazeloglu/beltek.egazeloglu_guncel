using beltek.egazeloglu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace beltek.egazeloglu.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OgrDbContext())
            {
                var ogrenciler = ctx.Ogrenciler.Include(o => o.Sinif).ToList();
                return View(ogrenciler);
            }
        }

        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            using (var ctx = new OgrDbContext())
            {
                var lst = ctx.Siniflar.ToList();
                ViewBag.Siniflar = ctx.Siniflar.Select(s => new SelectListItem
                {
                    Value = s.SinifId.ToString(),
                    Text = s.SinifAd
                }).ToList();
                return View();
            }
        }

        [HttpPost]
        public IActionResult OgrenciEkle(Ogrenci ogr)
        {
            using (var ctx = new OgrDbContext())
            {
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges(); 
            }
            return RedirectToAction("Index");

        }

        public ViewResult OgrenciDuzenle(int id)
        {
            using (var ctx = new OgrDbContext())
            {
                var lst = ctx.Siniflar.ToList();
                ViewBag.Siniflar = ctx.Siniflar.Select(s => new SelectListItem
                {
                    Value = s.SinifId.ToString(),
                    Text = s.SinifAd
                }).ToList();

                var ogr = ctx.Ogrenciler.Find(id);
                return View(ogr);
            }
        }

        [HttpPost]
        public IActionResult OgrenciDuzenle(Ogrenci ogr)
        {
            using (var ctx = new OgrDbContext())
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult OgrenciSil(int id)
        {
            using (var ctx = new OgrDbContext())
            {
                ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
