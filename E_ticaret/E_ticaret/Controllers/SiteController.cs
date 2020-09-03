using E_ticaret.AppClass;
using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;

namespace E_ticaret.Controllers
{
    public class SiteController : Controller
    {


        Model1 k = new Model1();

      


        #region ANA SAYFA
        public ActionResult S_UrunListele(int? page,string p)
        {
           var degerler = k.urunlers.Where(x => x.urun_adı.Contains(p) || x.marka.marka_adi.Contains(p) || x.kategori.kategori_adi.Contains(p) || x.renk.renk_adi.Contains(p) || p==null).ToList();

            return View(degerler.ToPagedList(page ??1,10));
         
        }
        #endregion

    
        #region ÜRÜN DETAY
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urunler Urunler = k.urunlers.Find(id);
            if (Urunler == null)
            {
                return HttpNotFound();
            }
            return View(Urunler);
        }
        #endregion


        #region LAYOUTTA LİSTELEMELER (PARTİAL VİEW)
        #region Layoutta Kategori Listeleme
        public PartialViewResult KategoriListe() //Layoutta kategori butonlarının listelenmesi için
        {
            List<kategori> Kategori = k.kategoris.ToList();
            return PartialView(Kategori);
        }
        #endregion
        #region Layoutta Marka Listeleme
        public PartialViewResult MarkaListe()//Layoutta marka butonlarının listelenmesi için
        {
            List<marka> Markalar = k.markas.ToList();
            return PartialView(Markalar);
        }
        #endregion
        #endregion

        #region Kategoriye göre ürün listeleme
        public ActionResult KategoriicinListe(int id)
        {
            var model = k.urunlers.Where(x => x.kategori_id == id).ToList();
            return View(model);
        }
        #endregion
        #region Markaya göre ürün listeleme
        public ActionResult MarkaicinListe(int id)
        {
            var model = k.urunlers.Where(x => x.marka_id == id).ToList();
            return View(model);
        }

        #endregion


        #region  SEPET İŞLEMLERİ



        #region Sepete Ekle (1)
        [Authorize] //sadece login olanlar 
        public ActionResult SepeteEkle(int id)
        {
            
                var u = k.urunlers.Find(id); 
                var sepet = k.Sepets.FirstOrDefault(x => x.UrunID == id); 

                if (sepet != null)//ürün sepette var ise miktar arttır
                {
                    sepet.Miktari++;
                    sepet.ToplamFiyati = u.fiyat * sepet.Miktari;
                    k.SaveChanges();

                    return RedirectToAction("S_UrunListele");
                }
                else
                {
                    var s = new Models.Sepet//ürün sepette yok ise yeni kayıt ile kaydet
                    {
                        KullaniciID = Convert.ToInt32(Session["KullaniciId"]),
                        UrunID = u.urun_id,
                        Miktari = 1, //Yeni kayıt olduğu için 1 tane
                        AlisFiyati = u.fiyat,
                        ToplamFiyati = u.fiyat,
                        Tarih = DateTime.Now,
                        Saat = DateTime.Now
                    };
                    k.Sepets.Add(s);
                    k.SaveChanges();
                    return RedirectToAction("Sepet_Listele");
                }
            }
      
        #endregion

        #region Sepette Listeleme (2)
        [Authorize]
        public ActionResult Sepet_Listele(decimal? Tutar)
        {
           
            int id = Convert.ToInt32(Session["KullaniciId"]);
            var kid = k.Sepets.FirstOrDefault(x => x.KullaniciID == id);
            if (kid != null) //Kullanıcı null değilse sepet listelenecek
            {
                List<Sepet> sListe = k.Sepets.Where(x => x.KullaniciID == id).ToList();
                Tutar = k.Sepets.Where(x => x.KullaniciID == kid.KullaniciID).Sum(x => x.ToplamFiyati);
                ViewBag.Tutar = "Toplam Tutar" + Tutar + "TL";
                Session["Tutar"] = Tutar;
                return View(sListe);
            }
            else //nullsa Ana sayfada kalıcak
            {
               return View("S_UrunListele");
                
                
            }
        }
        #endregion

              #region Sepette Miktar Arttırma
               public ActionResult Arttir(int id)
        {
            var model = k.Sepets.Find(id);
            model.Miktari++;
            model.ToplamFiyati = model.AlisFiyati * model.Miktari;
            k.SaveChanges();
            return RedirectToAction("Sepet_Listele");
        }
              #endregion

              #region Sepette Miktar Azaltma
        public ActionResult Azalt(int id)
        {
            var model = k.Sepets.Find(id);
            if (model.Miktari == 1)
            {
                k.Sepets.Remove(model);
                k.SaveChanges();
            }
            model.Miktari--;
            model.ToplamFiyati = model.AlisFiyati * model.Miktari;
            k.SaveChanges();
            return RedirectToAction("Sepet_Listele");
        }
        #endregion

              #region Sepette Miktara göre fiyat değiştirme
        public void Dinamikmiktar(int id, decimal miktari)
        {
            var model = k.Sepets.Find(id);
            model.Miktari = miktari;
            model.ToplamFiyati = model.AlisFiyati * model.Miktari;
            k.SaveChanges();
        }
        #endregion

              #region Sepetten ürün Silme
        public ActionResult SepetSil(int id)
        {
            var model = k.Sepets.Find(id);
            k.Sepets.Remove(model);
            k.SaveChanges();
            return RedirectToAction("Sepet_Listele");
        }
        #endregion

        #region Satişta Adres Listeleme ve Seçme (3)

        public ActionResult Satis_AdresListeleme()
        { int k_id = Convert.ToInt32(Session["KullaniciId"]);
            var sepet = k.Sepets.FirstOrDefault(x => x.KullaniciID == k_id);
            if (Session["KullaniciId"] != null && sepet!=null) //login olunmuşsa ve sepet boş değilse adres listeleme yapılır
            {
                
                var kid = k.Adres.FirstOrDefault(x => x.kullanici_id == k_id);
                List<Adre> Liste = k.Adres.Where(x => x.kullanici_id == k_id).ToList();
                return View(Liste);

            }
            else
            {
                return RedirectToAction("Sepet_Listele");
            }
        }
        #endregion
              #region adres silme
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = k.Adres.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            k.Adres.Remove(h);
            k.SaveChanges();
            return RedirectToAction("Siparisler");

        }
        #endregion
              #region Kullanıcı Adres Ekle
        [HttpPost]
        public ActionResult AdresEkle(string ulke, string sehir,string mahalle,string cadde,string sokak,int apartmanno,int daireno)
        {

            try
            {
                Adre AdresEkle = new Adre
                {
                    
                    ulke = ulke,
                    sehir = sehir,
                    mahllle = mahalle,
                    cadde = cadde,
                    sokak = sokak,
                    apt_no = apartmanno,
                    daire_no = daireno,
                    kullanici_id=Convert.ToInt32(Session["KullaniciId"]),
                    
                };

                k.Adres.Add(AdresEkle);
                k.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.KayitHata = "Kayıt Eklenemedi";
                throw;
            }




            return Redirect("/Site/Satis_AdresListeleme");
        }
        #endregion

        #region Kredi Kartları Listeleniyor (4)
        public ActionResult Odeme(int Adres)
        {
            Session["AdresID"]= Adres;
            int KulID = Convert.ToInt32(Session["KullaniciId"]);
            var Model = k.kredi_karti.Where(x => x.kullanici_id == KulID).ToList();
            return View(Model);
        }
        #endregion
    

              #region Kart Ekle
        [HttpPost]
        public ActionResult KrediKartiKaydet( int KartNo, DateTime SonKulTarih, int Cvv)
        {
            int AdresID = Convert.ToInt32(Session["AdresID"]);
            int KulID = Convert.ToInt32(Session["KullaniciId"]);
            kredi_karti YeniKK = new kredi_karti
            {

                kart_no = KartNo,
                cvv = Cvv,
                son_kullanma_tarih = Convert.ToDateTime(SonKulTarih),
                kullanici_id = KulID


            };

            k.kredi_karti.Add(YeniKK);
            k.SaveChanges();
            return Redirect("/Site/Odeme?Adres=" + AdresID);
        }
        #endregion


        #region ödeme yap ve sipariş ekle (5)
        public ActionResult Kart_Bilgileri_Girme(int KartID)
        {
              
            int AdresID = Convert.ToInt32(Session["AdresID"]);
            DateTime bugun = DateTime.Now;
            var GelenKartBilgisi = k.kredi_karti.FirstOrDefault(x => x.kart_id == KartID);
            var GecerliKartmi = k.kart_.Where(x => x.kart_no == GelenKartBilgisi.kart_no).Where(x => x.cvv == GelenKartBilgisi.cvv).Where(x => x.son_kullanma_tarihi == GelenKartBilgisi.son_kullanma_tarih).FirstOrDefault();

            if(GecerliKartmi!=null)
            {//Kart Bilgileri Uyuştu. Sepet ürünleri siparişe gidebilir.speet sil Post olarak KartId ve ADres Id Gelmekte.,sepet onaylandı


                //ödeme bilgileri alınıyor
                int KulID = Convert.ToInt32(Session["KullaniciId"]);
                int tutar = Convert.ToInt32(Session["Tutar"]);

                var Sepet = k.Sepets.Where(x => x.KullaniciID == KulID).ToList();
                odeme ode = new odeme
                {
                    kredi_karti_id = KartID,
                    odeme_zamani = bugun,
                    musteri_id = KulID,
                    tutar =tutar ,
                   };
                   k.odemes.Add(ode);
                   k.SaveChanges();

                //ödeme bilgileri alındıktan sonra sipariş tablosuna ekleme yapılıyor
                var odeme = k.odemes.Where(x => x.musteri_id == KulID && x.kredi_karti_id == KartID ).FirstOrDefault();
                foreach (var spt in Sepet)
                {
                    sipari sp = new sipari
                    {
                        adres_id = AdresID,
                        urun_id = spt.UrunID,
                        siparis_talep_tarih = bugun,
                        cikis_tarih = DateTime.Now.AddDays(1),
                        teslim_tarih = DateTime.Now.AddDays(4),
                        kargo_ucret = 5,
                        odeme_id = odeme.odeme_id,
                    };
                    var urunmiktar = k.urunlers.Where(x => x.urun_id == spt.UrunID).FirstOrDefault(); 
                    urunmiktar.miktar = urunmiktar.miktar - (int)spt.Miktari;
                    k.siparis.Add(sp);
                    k.Sepets.Remove(spt);
                    k.SaveChanges();
                    
                }
                return View();
            }
            else
            {
                ViewBag.Hata = "Kart Bilgileri Geçersiz";
                return Redirect("/Site/Odeme?Adres=" + AdresID);
                    
            }

          //Ödeme Alındı sayfasına yönlendir. Fatura çıktısı v.s.
         }
        #endregion


       #endregion


        #region FAVORİ EKLEME SİLME
        [Authorize]
        public ActionResult Favorilerim(int id)
        {
            if (Session["KullaniciId"] != null )
            {

                var u = k.urunlers.Find(id);
                var favorilerim = k.Favorilerims.FirstOrDefault(x => x.UrunID == id);
                if (favorilerim != null)//ürün sepette var ise miktar arttır
                {
                    ViewBag.Mesaj = "Favorilere zaten seçilmiş!";

                    return RedirectToAction("S_UrunListele");
                }
                else
                {
                    var s = new Models.Favorilerim//ürün sepette yok ise yeni kayıt ile kaydet
                    {
                        KullaniciID = Convert.ToInt32(Session["KullaniciId"]),
                        UrunID = u.urun_id,
                        Fiyati = u.fiyat,
                    };
                    k.Favorilerims.Add(s);
                    k.SaveChanges();
                    return RedirectToAction("Favori_Listele");
                }
            }
            else
            {
                return RedirectToAction("S_UrunListele");
            }
        }

        [Authorize]
        public ActionResult Favori_Listele()
        {
            int id = Convert.ToInt32(Session["KullaniciId"]);
            var kid = k.Favorilerims.FirstOrDefault(x => x.KullaniciID == id);
            if (kid != null)
            {
                List<Favorilerim> sListe = k.Favorilerims.Where(x => x.KullaniciID == id).ToList();
                return View(sListe);
            }
            else
            {
            
                return View("S_UrunListele");
            }
        }

        public ActionResult FavoriSil(int id)
        {
            var model = k.Favorilerims.Find(id);
            k.Favorilerims.Remove(model);
            k.SaveChanges();
            return RedirectToAction("Favori_Listele");
        }
        #endregion

        #region İLETİŞİM VE HAKKIMIZDA
        public ActionResult Iletisim()
        {
            List<Iletisim> Iletisimler = k.Iletisims.ToList();
            return View(Iletisimler);
        }
        public ActionResult Hakkimizda()
        {
            List<Hakkimizda> Hakkimizda = k.Hakkimizdas.ToList();
            return View(Hakkimizda);
        }
        
        #endregion
    }
       
}