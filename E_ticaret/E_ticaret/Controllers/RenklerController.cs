using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class RenklerController : Controller
    {
        // GET: Renkler 
        Model1 k = new Model1();

        #region Renk listeleme
        public ActionResult Renkler()
        {
            List<renk> Renkler = k.renks.ToList();
            return View(Renkler);
        }
        #endregion
        #region Renk Ekleme
        public ActionResult RenkEkle()
        {
            ViewBag.renk = k.renks.ToList();
            
            return View();
        }
        [HttpPost]
        public ActionResult RenkEkle(renk u)
        {
            k.renks.Add(u);
            k.SaveChanges();
            return RedirectToAction("Renkler");
        }

        #endregion

        #region renk güncelleme
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.renks.Where(x => x.renk_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, renk f)
        {
            if (ModelState.IsValid)
            {
                var renkler = k.renks.Where(x => x.renk_id == id).SingleOrDefault();
                renkler.renk_adi = f.renk_adi;
                renkler.renk_resim = f.renk_resim;
                
                k.SaveChanges();
                return RedirectToAction("Renkler");


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
            var h = k.renks.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.renks.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Renkler");

        }
        #endregion 
    }
}