using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class OdemelerController : Controller
    {
        // GET: Odemeler
        Model1 k = new Model1();

        #region Odemeleer
        public ActionResult Odemeler()
        {
            List<odeme> Odemeler = k.odemes.ToList();
            return View(Odemeler);
        }
        #endregion

        #region OdemeEkle
        public ActionResult OdemeEkle()
        {
            ViewBag.odeme = k.odemes.ToList();
            ViewBag.kart_id = new SelectList(k.kredi_karti, "kart_id", "kart_id");
            ViewBag.musteri_id = new SelectList(k.Kullanicis, "kullanici_id", "kullanici_id");
            return View();
        }
        [HttpPost]
        public ActionResult OdemeEkle(odeme u)
        {
            k.odemes.Add(u);
            k.SaveChanges();
            return RedirectToAction("Odemeler");
        }

        #endregion

        #region güncelleme
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.odemes.Where(x => x.odeme_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            ViewBag.kart_id = new SelectList(k.kredi_karti, "kart_id", "kart_id",f.kredi_karti_id);
            ViewBag.musteri_id = new SelectList(k.Kullanicis, "kullanici_id", "kullanici_id",f.kredi_karti_id);
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, odeme f)
        {
            if (ModelState.IsValid)
            {
                var odemeler = k.odemes.Where(x => x.odeme_id == id).SingleOrDefault();
                odemeler.odeme_secenek_id = f.odeme_secenek_id;
                odemeler.kredi_karti_id = f.kredi_karti_id;
                odemeler.odeme_zamani = f.odeme_zamani;
                odemeler.musteri_id = f.musteri_id;
                odemeler.tutar = f.tutar;
                k.SaveChanges();
                return RedirectToAction("Odemeler");


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
            var h = k.odemes.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.odemes.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Odemeler");

        }
        #endregion 
    }
}