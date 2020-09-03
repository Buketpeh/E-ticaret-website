using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_ticaret.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Model1 k = new Model1();



        #region Fatura Listeleme

        [Authorize(Roles = "Admin")]
        public ActionResult Faturalar()
        {
            List<fatura> Faturalar = k.faturas.ToList();
            return View(Faturalar);
        }
        #endregion

        #region Fatura Ekleme
        public ActionResult FaturaEkle() //GET
        {
            ViewBag.fatura = k.faturas.ToList(); 
            ViewBag.siparis_id = new SelectList(k.siparis, "siparis_id", "siparis_id"); 
            ViewBag.urun_id = new SelectList(k.urunlers, "urun_id", "urun_adı");//Ürün id başka tablodan referans oalrak alınmaktadır.
                                                                                 //İlişkili ürün id ye sahip ürün adları bu şekilde listlenir.
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(fatura u)//POST
        {
            k.faturas.Add(u);
            k.SaveChanges();
            return RedirectToAction("Faturalar");
        }
        #endregion

        #region Fatura Güncelleme
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.faturas.Where(x => x.fatura_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            ViewBag.siparis_id = new SelectList(k.siparis,"siparis_id", "siparis_id", f.siparis_id);
            ViewBag.urun_id = new SelectList(k.urunlers,"urun_id", "urun_adı", f.urun_id);
            return View(f);

            
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Dışarıdan gelebilecek isteklerden korumak için...(Sql injection gibi)
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, fatura f)
        {
            if (ModelState.IsValid)
            {
                var faturalar = k.faturas.Where(x => x.fatura_id == id).SingleOrDefault();
                faturalar.siparis_id = f.siparis_id;
                faturalar.urun_id = f.urun_id;
                faturalar.urun_fiyat = f.urun_fiyat;
                faturalar.kdv = f.kdv;
                faturalar.toplam_fiyat = f.toplam_fiyat;
                k.SaveChanges();
                return RedirectToAction("Faturalar");

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
            var h = k.faturas.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.faturas.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Faturalar");

        }
        #endregion
    }
}