using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class SiparisController : Controller
    {
        // GET: Siparis
        Model1 k = new Model1();


        #region siparis listeleme
        public ActionResult Siparisler()
        {
            List<sipari> Siparisler = k.siparis.ToList();
            return View(Siparisler);
        }
        #endregion
        #region Siparis Ekleme
        public ActionResult SiparisEkle()
        {
            ViewBag.sipari = k.siparis.ToList();
            ViewBag.urun_id = new SelectList(k.urunlers, "urun_id", "urun_adı");
            ViewBag.kargo_id = new SelectList(k.kargoes, "kargo_id", "firma");
            ViewBag.odeme_id = new SelectList(k.odemes, "odeme_id", "odeme_id");
            ViewBag.adres_id = new SelectList(k.Adres, "adres_id", "adres_id");

            return View();
        }
 

        [HttpPost]
        public ActionResult SiparisEkle(sipari u)
        {
            k.siparis.Add(u);
            k.SaveChanges();
            return RedirectToAction("Siparisler");
        }
        #endregion
        #region Siparis Güncelleme
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.siparis.Where(x => x.siparis_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            ViewBag.urun_id = new SelectList(k.urunlers, "urun_id", "urun_adı",f.urun_id);
            ViewBag.kargo_id = new SelectList(k.kargoes, "kargo_id", "firma",f.kargo_id);
            ViewBag.odeme_id = new SelectList(k.odemes, "odeme_id", "odeme_id",f.odeme_id);
            ViewBag.adres_id = new SelectList(k.Adres, "adres_id", "adres_id", f.adres_id);
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, sipari f)
        {
            if (ModelState.IsValid)
            {
                var siparisler = k.siparis.Where(x => x.siparis_id == id).SingleOrDefault();
                siparisler.siparis_talep_tarih = f.siparis_talep_tarih;
                siparisler.urun_id = f.urun_id;
                siparisler.kargo_id = f.kargo_id;
                siparisler.cikis_tarih = f.cikis_tarih;
                siparisler.teslim_tarih = f.teslim_tarih;
                siparisler.kargo_ucret = f.kargo_ucret;
                siparisler.odeme_id = f.odeme_id;
                siparisler.adres_id = f.adres_id;

                k.SaveChanges();
                return RedirectToAction("Siparisler");


            }
            return View(f);
        }
        #endregion
        #region Silme
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = k.siparis.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.siparis.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Siparisler");

        }
        #endregion
    }
}