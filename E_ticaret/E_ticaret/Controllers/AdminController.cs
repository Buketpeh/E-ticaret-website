using E_ticaret.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using System.Data.Entity.Migrations;
using System;
using System.Web;
using System.Web.Helpers;
using System.IO;
using System.Web.Security;

namespace E_ticaret.Controllers
{
    public  class AdminController : Controller
    {
        // GET: Admin
        Model1 k = new Model1();

        #region anasayfa
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region LOGİN LOG OUT İŞLEMLERİ
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }  
        
      
        [HttpPost]
       public ActionResult Login(Kullanici u)
        {
            Kullanici kullanici = k.Kullanicis.FirstOrDefault(x => x.Eposta == u.Eposta && x.parola == u.parola);
            string m = "Müşteri";
            string a = "Admin";
            string t = "Tedarikçi";
           
            if (kullanici != null)
            {
                string roll = kullanici.Rol; //
                string rol = roll.Trim();
                string keposta= kullanici.Eposta.Trim(); //if içerisinde yazıldığında boşluklardan kaynaklı sorun yaşanmakta
                string kparola= kullanici.parola.Trim();
                string uEposta = u.Eposta.Trim();
                string uparola=u.parola.Trim();
                if (uEposta == keposta && uparola == kparola && rol == m) {
                    Session["KullaniciId"] = kullanici.Kullanici_id;
                    FormsAuthentication.SetAuthCookie(kullanici.Eposta, false); //false beni hatırla

                return RedirectToAction("S_UrunListele", "Site");
                }
                if (uEposta == keposta && uparola == kparola && rol == a)
                {
                    Session["KullaniciId"] = kullanici.Kullanici_id;
                    FormsAuthentication.SetAuthCookie(kullanici.Eposta, false); //false beni hatırla
                    return RedirectToAction("Index", "Admin");
                }
                if (uEposta == keposta && uparola == kparola && rol == t)
                {
                    Session["KullaniciId"] = kullanici.Kullanici_id;
                    FormsAuthentication.SetAuthCookie(kullanici.Eposta, false); //false beni hatırla
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View();

                }
            }
            else
            {
                ViewBag.Uyari = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
        }


      
      
        public ActionResult LogOut()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            string Eposta = HttpContext.User.Identity.Name;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name; //You have the UserName!

            Kullanici u = k.Kullanicis.FirstOrDefault(x => x.Eposta == Eposta);

            FormsAuthentication.SignOut();
            Session["KullaniciId"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }

        #endregion

        #region MÜŞTERİ VE TEDARİKÇİ KAYIT    
        [HttpPost]
            public ActionResult MusteriKayit(string ad,string soyad,string Eposta,string parola) //Siteye müşteri kaydı
        {
            DateTime bugun = DateTime.Now;
            try
            {
                Kullanici MusteriEkle = new Kullanici //kullanıcı modelinden bir nesne oluşturulur parametre olarak alınan değerler atanır.
                {

                    Kullanici_adi = ad,
                    kullanici_soyadi = soyad,
                    kayit_tarih =bugun ,
                    Eposta = Eposta,
                    parola = parola,
                    Rol ="Müşteri", 
                };

                k.Kullanicis.Add(MusteriEkle); //Kullanici tablosuna ekleme yapılır.
                k.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.KayitHata = "Kayıt Eklenemedi";
                throw;
            }
            return View("Login");
        }


        [HttpPost]
        public ActionResult TedarikciKayit(string ad, string soyad, string Eposta, string parola)
        {
            DateTime bugun = DateTime.Now;
            try
            {
                Kullanici TedarikciEkle = new Kullanici
                {

                    Kullanici_adi = ad,
                    kullanici_soyadi = soyad,
                    kayit_tarih = bugun,
                    Eposta = Eposta,
                    parola = parola,
                    Rol = "Tedarikçi",
                };

                k.Kullanicis.Add(TedarikciEkle);
                k.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.KayitHata = "Kayıt Eklenemedi";
                throw;
            }
            return View("Login");
        }
        #endregion


        #region Tedarikçi olan kullanıcıları ekleme güncelleme listeleme
        public ActionResult Tedarikciler()
        {
            List<Kullanici> KullaniciListesi = k.Kullanicis.Where(x => x.Rol == "Tedarikçi").ToList();
            return View(KullaniciListesi);
        }

        public ActionResult TedarikciEkle()
        {
            ViewBag.fatura = k.Kullanicis.Where(x => x.Rol == "Tedarikçi").ToList();
            //ViewBag.Rol_id = new SelectList(k.Rollers, "Rol_id", "Rol_adi");
            return View();
        }
        [HttpPost]
        public ActionResult TedarikciEkle(Kullanici u)
        {
            k.Kullanicis.Add(u);
            k.SaveChanges();
            return RedirectToAction("Tedarikciler");
        }


        public ActionResult T_Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.Kullanicis.Where(x => x.Kullanici_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Rol_id = new SelectList(k.Rol, "Rol_id", "Rol_adi", f.Rol_id);

            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult T_Guncelle(int id, Kullanici f)
        {
            if (ModelState.IsValid)
            {
                var Musteriler = k.Kullanicis.Where(x => x.Kullanici_id == id).SingleOrDefault();
                Musteriler.Kullanici_adi = f.Kullanici_adi;
                Musteriler.kullanici_soyadi = f.kullanici_soyadi;
                Musteriler.kayit_tarih = f.kayit_tarih;
                Musteriler.parola = f.parola;
                Musteriler.Rol = f.Rol;
                //Musteriler = f;
                //k.Kullanicis.AddOrUpdate(Musteriler);
                k.SaveChanges();
                
                return RedirectToAction("Tedarikciler");


            }
            return View(f);
        }
        #endregion

        #region Müşteri olan kullanıcıları ekleme güncelleme listeleme
        public ActionResult Musteriler()
        {
            List<Kullanici> KullaniciListesi = k.Kullanicis.Where(x => x.Rol == "Müşteri").ToList();
            return View(KullaniciListesi);
        }


      
        public ActionResult MusteriEkle()
        {
            ViewBag.fatura = k.Kullanicis.Where(x => x.Rol == "Müşteri").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(Kullanici u)
        {

            k.Kullanicis.Add(u);
            k.SaveChanges();
            return RedirectToAction("Musteriler");
        }

        public ActionResult M_Guncelle(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.Kullanicis.Where(x => x.Kullanici_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
         
           
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult M_Guncelle(int id, Kullanici f)
        {
            if (ModelState.IsValid)
            {
                var Musteriler = k.Kullanicis.Where(x => x.Kullanici_id == id).SingleOrDefault();
                Musteriler.Kullanici_adi = f.Kullanici_adi;
                Musteriler.kullanici_soyadi = f.kullanici_soyadi;
                Musteriler.kayit_tarih = f.kayit_tarih;
                Musteriler.parola = f.parola;
                Musteriler.Rol = f.Rol;
                k.SaveChanges();
                return RedirectToAction("Musteriler");


            }
            return View(f);
        }

        #endregion

       

        #region Tedarikçiye ait siparişlerin listeleme ekleme güncelleme
        public ActionResult T_Siparislerim() //Tedarikçiye ait siparişlerin listelenmesi
        {
            int id = Convert.ToInt32(Session["KullaniciId"]);

            List<sipari> siparislerListesi = k.siparis.Where(x => x.urunler.Tedarikci_id == id).ToList();
            return View(siparislerListesi);
        }
        public ActionResult T_SGuncelle(int? id)
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
            ViewBag.urun_id = new SelectList(k.urunlers, "urun_id", "urun_adı", f.urun_id);
            ViewBag.kargo_id = new SelectList(k.kargoes, "kargo_id", "firma", f.kargo_id);
            ViewBag.odeme_id = new SelectList(k.odemes, "odeme_id", "odeme_id", f.odeme_id);
            ViewBag.adres_id = new SelectList(k.Adres, "adres_id", "adres_id", f.adres_id);
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult T_SGuncelle(int id, sipari f)
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
                return RedirectToAction("T_Siparislerim");


            }
            return View(f);
        }

        #endregion
      
        #region Tedarikçiye ait ürünlerin listlenmesi eklenmesi güncellenmesi
        public ActionResult T_Urunlerim() //Tedarikçiye ait ürünlerin listelenmesi
        {
            int id = Convert.ToInt32(Session["KullaniciId"]);

            List<urunler> UrunlerListesi = k.urunlers.Where(x => x.Tedarikci_id == id).ToList();
            return View(UrunlerListesi);
        }

        [HttpPost]
        public ActionResult T_UrunlerimEkle(string urun_adı, int kategori_id, int renk_id, int marka_id, int miktar, string aciklama, HttpPostedFileBase ResimURL, HttpPostedFileBase ResimURL1, HttpPostedFileBase ResimURL2, HttpPostedFileBase ResimURL3)
        {
            try
            {
                urunler urunekle = new urunler
                {

                    urun_adı = urun_adı,
                    kategori_id = kategori_id,
                    renk_id = renk_id,
                    marka_id = marka_id,
                    miktar = miktar,
                    aciklama = aciklama,
                    Tedarikci_id = Convert.ToInt32(Session["KullaniciId"]),
                };
                if (ResimURL != null) { 
                           WebImage img = new WebImage(ResimURL.InputStream);
                           FileInfo imginfo = new FileInfo(ResimURL.FileName); //ismini alıyoruz

                           string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                           img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                           img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                           urunekle.ResimURL = "/Uploads/Urun/" + urunimg;

                 }
                if (ResimURL1 != null)
                {
                    WebImage img = new WebImage(ResimURL1.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL1.FileName); //ismini alıyoruz

                    string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    urunekle.ResimURL1 = "/Uploads/Urun/" + urunimg;

                }
                if (ResimURL2 != null)
                {
                    WebImage img = new WebImage(ResimURL2.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL2.FileName); //ismini alıyoruz

                    string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    urunekle.ResimURL2 = "/Uploads/Urun/" + urunimg;

                }
                if (ResimURL3 != null)
                {
                    WebImage img = new WebImage(ResimURL3.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL3.FileName); //ismini alıyoruz

                    string urunimg = Guid.NewGuid().ToString() + imginfo.Extension; //burada extension uzantı demek uzantı değerini de almak gerekiyor
                    img.Resize(300, 200); //logonun boyutunu belirliyor(genişlik,yükseklik)
                    img.Save("~/Uploads/Urun/" + urunimg); //bu logoyu nereye kaydedicez onu belirliyoruz,logoname diyerek ismiyle birlikte kaydedilmesini sağlıyorum
                    urunekle.ResimURL3 = "/Uploads/Urun/" + urunimg;

                }
                k.urunlers.Add(urunekle);
                k.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.KayitHata = "Kayıt Eklenemedi";
                throw;
            }
            return Redirect("/Admin/T_Urunlerim");
        }

        public ActionResult T_UGuncelle(int? id)
        {
            int kulid = Convert.ToInt32(Session["KullaniciId"]);
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bulunamadi..";
            }

            var f = k.urunlers.Where(x => x.urun_id == id).FirstOrDefault();
            if (f == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategori_id = new SelectList(k.kategoris, "kategori_id", "kategori_adi", f.kategori_id);
            ViewBag.marka_id = new SelectList(k.markas, "marka_id", "marka_adi", f.marka_id);
            ViewBag.renk_id = new SelectList(k.renks, "renk_id", "renk_adi", f.renk_id);
            ViewBag.Kullanici_id = new SelectList(k.Kullanicis, "Kullanici_id", "Kullanici_adi", f.Tedarikci_id);
            return View(f);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult T_UGuncelle(int id, urunler f, HttpPostedFileBase ResimURL, HttpPostedFileBase ResimURL1, HttpPostedFileBase ResimURL2)
        {
            if (ModelState.IsValid)
            {
                int kulid = Convert.ToInt32(Session["KullaniciId"]);
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

                urunler.urun_adı = f.urun_adı;
                urunler.kategori_id = f.kategori_id;
                urunler.renk_id = f.renk_id;
                urunler.marka_id = f.marka_id;
                urunler.miktar = f.miktar;
                urunler.aciklama = f.aciklama;
                urunler.Tedarikci_id = kulid;

                k.SaveChanges();
                return RedirectToAction("T_Urunlerim");


            }
            return View(f);
        }
        #endregion



    }
}