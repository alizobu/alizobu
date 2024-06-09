using Sube1.HelloMvc.Models;
using Sube1.HelloMvc.Models.Relationships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DersController.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult Index()
        {
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                return View(lst);

            }
        }


        [HttpGet]
        public IActionResult AddStudent()
        {

            return View();
        }

        [HttpPost] 
        public IActionResult AddStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Ogrenciler.Add(ogr);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);

                return View(ogr);
            }
        }

        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Entry(ogr).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                if (ogr != null)
                {
                    ctx.Ogrenciler.Remove(ogr);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult OgrenciDersleri(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrenci = ctx.Ogrenciler.Include(o => o.OgrenciDersler!).ThenInclude(od => od.Ders).FirstOrDefault(o => o.ogrid == id);

                return View(ogrenci);
            }
        }

        [HttpGet]
        public IActionResult AddDersForOgrenci(int studentId)
        {
            using (var ctx = new OkulDbContext())
            {
                var dersler = ctx.Dersler.ToList();
                var ogrenciDersler = ctx.OgrenciDersler.Where(od => od.ogrid == studentId).Select(od => od.dersid).ToList();
                var aktders = dersler.Where(d => !ogrenciDersler.Contains(d.Dersid)).ToList();

                ViewBag.StudentId = studentId;
                return View(aktders);
            }
        }


        [HttpPost]
        public IActionResult AddDersForOgrenci(int studentId, List<int> dersids)
        {
            using (var ctx = new OkulDbContext())
            {
                var mvcders = ctx.OgrenciDersler.Where(od => od.ogrid == studentId).Select(od => od.dersid).ToList();
                var newders = dersIds.Except(mevcutDersId).ToList();

                foreach (var dersid in newders)
                {
                    var ogrders = new OgrenciDers
                    {
                        ogrid = studentId,
                        dersid = dersId
                    };
                    ctx.OgrenciDersler.Add(ogrenciDers);
                }
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}