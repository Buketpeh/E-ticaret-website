using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        Model1 k = new Model1();


        #region Kategoriler Liste
        public ActionResult Kategoriler()
        {
            List<kategori> Kategoriler = k.kategoris.ToList();
            return View(Kategoriler);
        }
        #endregion
        #region Kategori Ekle
        public ActionResult KategoriEkle()
        {
            ViewBag.kategori = k.kategoris.ToList();
            ViewBag.a_kat_id = new SelectList(k.ana_kategori, "a_kat_id", "a_kat_id");
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(kategori u)
        {
            k.kategoris.Add(u);
            k.SaveChanges();
            return RedirectToAction("Kategoriler");
        }
        #endregion
        #region kategori güncelle
        public ActionResult k_Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.kategoris.Where(x => x.kategori_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            ViewBag.a_kat_id = new SelectList(k.ana_kategori, "a_kat_id", "a_kat_id", f.a_kat_id);
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken] //dışardan istekleri engellemek için...
        [ValidateInput(false)]// Default true'dur.Eğer false yaparsak, doğrulama yapmadan geçer.
        public ActionResult k_Guncelle(int id, kategori f)
        {
            if (ModelState.IsValid)
            {
                var kategoriler = k.kategoris.Where(x => x.kategori_id == id).SingleOrDefault();
                kategoriler.kategori_adi = f.kategori_adi;
                kategoriler.a_kat_id = f.a_kat_id;
             
                k.SaveChanges();
                return RedirectToAction("Kategoriler");


            }
            return View(f);
        }
        #endregion
        #region Kategori Sil
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = k.kategoris.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.kategoris.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Kategoriler");

        }
        #endregion
        
     
        
        #region Ana Kategoriler Liste
        public ActionResult AnaKategoriler()
        {
            List<ana_kategori> AnaKategoriler = k.ana_kategori.ToList();
            return View(AnaKategoriler);
        }
        #endregion
        #region Ana kategori Ekleme
        public ActionResult A_KategoriEkle()
        {
            ViewBag.ana_kategori = k.ana_kategori.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult A_KategoriEkle(ana_kategori u)
        {
            k.ana_kategori.Add(u);
            k.SaveChanges();
            return RedirectToAction("AnaKategoriler");
        }
        #endregion
        #region Ana kategori güncelle
        public ActionResult A_Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.ana_kategori.Where(x => x.a_kat_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult A_Guncelle(int id, ana_kategori f)
        {
            if (ModelState.IsValid)
            {
                var ana_kategoriler = k.ana_kategori.Where(x => x.a_kat_id == id).SingleOrDefault();
                ana_kategoriler.a_kat_adi = f.a_kat_adi;
                k.SaveChanges();
                return RedirectToAction("AnaKategoriler");


            }
            return View(f);
        }
        #endregion
        #region ana Kategori Silme
        public ActionResult A_Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = k.ana_kategori.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.ana_kategori.Remove(h);
            k.SaveChanges();
            return RedirectToAction("AnaKategoriler");

        }
        #endregion

    }
}