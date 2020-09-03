using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class KartlarController : Controller
    {
        // GET: Kartlar
        Model1 k = new Model1();

        #region
        public ActionResult Kartlar()
        {
            List<kredi_karti> Kartlar = k.kredi_karti.ToList();
            return View(Kartlar);
        }
        #endregion

        #region Kart Ekle
        public ActionResult KartEkle()
        {
            ViewBag.kredi_karti = k.kredi_karti.ToList();
            ViewBag.kullanici_id = new SelectList(k.Kullanicis, "kullanici_id", "kullanici_id");
            return View();
        }
        [HttpPost]
        public ActionResult KartEkle(kredi_karti u)
        {
            k.kredi_karti.Add(u);
            k.SaveChanges();
            return RedirectToAction("Kartlar");
        }
        #endregion

        #region Kart güncelle
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.kredi_karti.Where(x => x.kart_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            ViewBag.kullanici_id = new SelectList(k.Kullanicis, "kullanici_id", "kullanici_id", f.kullanici_id);
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, kredi_karti f)
        {
            if (ModelState.IsValid)
            {
                var kartlar = k.kredi_karti.Where(x => x.kart_id == id).SingleOrDefault();
                kartlar.kullanici_id = f.kullanici_id;
                kartlar.kart_no = f.kart_no;
                kartlar.son_kullanma_tarih = f.son_kullanma_tarih;
                kartlar.cvv = f.cvv;
                k.SaveChanges();
                return RedirectToAction("Kartlar");


            }
            return View(f);
        }

        #endregion

        #region silme
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = k.kredi_karti.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.kredi_karti.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Kartlar");

        }
        #endregion

    }
}