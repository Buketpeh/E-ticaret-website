using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class KampanyalarController : Controller
    {
        Model1 k = new Model1();
        // GET: Kampanyalar

        #region Kampanya Listeleme
        public ActionResult Kampanyalar()
        {
            List<kampanya> Kampanyalar = k.kampanyas.ToList();
            return View(Kampanyalar);
        }
        #endregion

        #region Kampanya Ekle
        public ActionResult KampanyaEkle()
        {
            ViewBag.kampanya = k.faturas.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult KampanyaEkle(kampanya u)
        {
            k.kampanyas.Add(u);
            k.SaveChanges();
            return RedirectToAction("Kampanyalar");
        }
        #endregion

        #region Kampanya Güncelle
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.kampanyas.Where(x => x.kampanya_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, kampanya f)
        {
            if (ModelState.IsValid)
            {
                var kampanyalar = k.kampanyas.Where(x => x.kampanya_id == id).SingleOrDefault();
                kampanyalar.kampanya_id = f.kampanya_id;
                kampanyalar.kampanya_adi = f.kampanya_adi;
                kampanyalar.baslangic_tarih = f.baslangic_tarih;
                kampanyalar.bitis_tarih = f.bitis_tarih;
                kampanyalar.aciklama = f.aciklama;
                k.SaveChanges();
                return RedirectToAction("Kampanyalar");


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
            var h = k.kampanyas.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.kampanyas.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Kampanyalar");

        }
        #endregion
    }
}