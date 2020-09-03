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
    public class UrunlerController : Controller
    {
        // GET: Urunler
        Model1 k = new Model1();
        #region urun listele
        public ActionResult Urunler()
        {
            List<urunler> Urunler = k.urunlers.ToList();
            return View(Urunler);
        }
        #endregion

        #region urun ekle
        public ActionResult UrunEkle()
        {
            
            ViewBag.urunler = k.urunlers.ToList();
            ViewBag.kategori_id = new SelectList(k.kategoris, "kategori_id", "kategori_adi");
            ViewBag.marka_id = new SelectList(k.markas, "marka_id", "marka_adi");
            ViewBag.renk_id = new SelectList(k.renks, "renk_id", "renk_adi");
            ViewBag.Kullanici_id = new SelectList(k.Kullanicis, "Kullanici_id", "Kullanici_adi");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult UrunEkle(urunler u, HttpPostedFileBase ResimURL, HttpPostedFileBase ResimURL1, HttpPostedFileBase ResimURL2, HttpPostedFileBase ResimURL3)
        {
            if (ResimURL != null)
            {
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName); //ismini alıyoruz

                string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                u.ResimURL = "/Uploads/Urun/" + urunimg;

            }
            if (ResimURL1 != null)
            {
                WebImage img = new WebImage(ResimURL1.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL1.FileName); //ismini alıyoruz

                string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                u.ResimURL1 = "/Uploads/Urun/" + urunimg;

            }
            if (ResimURL2 != null)
            {
                WebImage img = new WebImage(ResimURL2.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL2.FileName); //ismini alıyoruz

                string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                u.ResimURL = "/Uploads/Urun/" + urunimg;

            }
            if (ResimURL3 != null)
            {
                WebImage img = new WebImage(ResimURL3.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL3.FileName); //ismini alıyoruz

                string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                u.ResimURL3 = "/Uploads/Urun/" + urunimg;

            }
            k.urunlers.Add(u);
            k.SaveChanges();
            return RedirectToAction("Urunler");
        }
        #endregion

        #region güncelle
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.urunlers.Where(x => x.urun_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategori_id  = new SelectList(k.kategoris, "kategori_id", "kategori_adi", f.kategori_id);
            ViewBag.marka_id = new SelectList(k.markas, "marka_id", "marka_adi", f.marka_id);
            ViewBag.renk_id = new SelectList(k.renks, "renk_id", "renk_adi", f.renk_id);
            ViewBag.Kullanici_id = new SelectList(k.Kullanicis, "Kullanici_id", "Kullanici_adi",f.Tedarikci_id);
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Guncelle(int id, urunler f, HttpPostedFileBase ResimURL, HttpPostedFileBase ResimURL1, HttpPostedFileBase ResimURL2, HttpPostedFileBase ResimURL3)
        {
            if (ModelState.IsValid)
            {
                var urunler = k.urunlers.Where(x => x.urun_id == id).SingleOrDefault();

                if (ResimURL != null)
                {
                    
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName); //ismini alıyoruz

                    string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    urunler.ResimURL = "/Uploads/Urun/" + urunimg;

                }
                if (ResimURL1 != null)
                {

                    WebImage img = new WebImage(ResimURL1.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL1.FileName); //ismini alıyoruz

                    string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    urunler.ResimURL1 = "/Uploads/Urun/" + urunimg;

                }
                if (ResimURL2 != null)
                {

                    WebImage img = new WebImage(ResimURL2.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL2.FileName); //ismini alıyoruz

                    string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    urunler.ResimURL2 = "/Uploads/Urun/" + urunimg;

                }
                if (ResimURL3 != null)
                {

                    WebImage img = new WebImage(ResimURL3.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL3.FileName); //ismini alıyoruz

                    string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    urunler.ResimURL3 = "/Uploads/Urun/" + urunimg;

                }

                urunler.urun_adı = f.urun_adı;
                urunler.kategori_id = f.kategori_id;
                urunler.renk_id = f.renk_id;
                urunler.marka_id = f.marka_id;
                urunler.miktar = f.miktar;
                urunler.aciklama = f.aciklama;
                urunler.fiyat = f.fiyat;
                k.SaveChanges();
                return RedirectToAction("Urunler");


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
            var h = k.urunlers.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.urunlers.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Urunler");

        }
        #endregion
    }
}