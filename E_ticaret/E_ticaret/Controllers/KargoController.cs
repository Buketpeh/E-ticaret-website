using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Model1 k = new Model1();
        #region Kargo Liste
        public ActionResult Kargolar()
        {
            List<kargo> Kargolar = k.kargoes.ToList();
            return View(Kargolar);
        }
        #endregion

        #region Kargo Ekle
        public ActionResult KargoEkle()
        {
            ViewBag.kargo = k.kargoes.ToList();
         
            return View();
        }

        [HttpPost]
        public ActionResult KargoEkle(kargo u)
        {
            k.kargoes.Add(u);
            k.SaveChanges();
            return RedirectToAction("Kargolar");
        }
        #endregion

        #region Kargo Güncelle
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.kargoes.Where(x => x.kargo_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, kargo f)
        {
            if (ModelState.IsValid)
            {
                var kargolar = k.kargoes.Where(x => x.kargo_id == id).SingleOrDefault();
                kargolar.firma = f.firma;
                kargolar.aciklama = f.aciklama;
                kargolar.telefon = f.telefon;
                kargolar.website = f.website;
                kargolar.e_posta = f.e_posta;
                k.SaveChanges();
                return RedirectToAction("Kargolar");


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
            var h = k.kargoes.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.kargoes.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Kampanyalar");

        }
        #endregion 

    }
}