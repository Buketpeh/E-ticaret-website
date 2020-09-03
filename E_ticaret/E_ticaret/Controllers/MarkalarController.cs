using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class MarkalarController : Controller
    {
        Model1 k = new Model1();
        // GET: Markalar


        #region Marka listeleme
        public ActionResult Markalar()
        {
            List<marka> Markalar = k.markas.ToList();
            return View(Markalar);
        }
        #endregion

        #region Marka Ekle
        public ActionResult MarkaEkle()
        {
            ViewBag.marka = k.markas.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult MarkaEkle(marka u)
        {
            k.markas.Add(u);
            k.SaveChanges();
            return RedirectToAction("Markalar");
        }
        #endregion

        #region Marka Güncelle

        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.markas.Where(x => x.marka_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Saldırıları önlemk için
        [ValidateInput(false)] /// Default true'dur.Eğer false yaparsak, doğrulama yapmadan geçer.
        public ActionResult Guncelle(int id, marka f, HttpPostedFileBase marka_logo)
        {
            if (ModelState.IsValid)
            {
                var markalar = k.markas.Where(x => x.marka_id == id).SingleOrDefault();
                if (marka_logo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(markalar.marka_logo))) //k dan gelen logo url i bul
                    {
                        System.IO.File.Delete(Server.MapPath(markalar.marka_logo)); //k dan gelen logourl i sil upload dosyasından yer kaplamasın 
                    }
                    WebImage img = new WebImage(marka_logo.InputStream);
                    FileInfo imginfo = new FileInfo(marka_logo.FileName); //ismini alıyoruz

                    string markalogoname = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Marka/" + markalogoname); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    markalar.marka_logo = "/Uploads/Marka/" + markalogoname;

                }

                markalar.marka_adi = f.marka_adi;
                markalar.marka_logo = f.marka_logo;
                k.SaveChanges();
                return RedirectToAction("Markalar");


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
            var h = k.markas.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.markas.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Markalar");

        }
        #endregion
    }
}