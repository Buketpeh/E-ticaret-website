using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_ticaret.Models;

namespace E_ticaret.AppClass
{
    public class Sepett
    {
        //    public static Sepet AktifSepet
        //    {
        //        get
        //        {
        //            HttpContext ctx = HttpContext.Current;
        //            if (ctx.Session["AktifSepet"] == null)
        //                ctx.Session["AktifSepet"] = new Sepet();
        //            return (Sepet)ctx.Session["AktifSepet"];
        //        }
        //    }
        //    private List<SepetItem> urun = new List<SepetItem>();

        //    public List<SepetItem> Urun
        //    {
        //        get {
        //            return urun;
        //                }
        //        set {
        //            urun = value;
        //        }
        //    }
        //    public void SepeteEkle(SepetItem si)
        //    {
        //        if (HttpContext.Current.Session["AktifSepet"] != null)
        //        {
        //            Sepet s = (Sepet)HttpContext.Current.Session["AktifSepet"];

        //            if ( s.Urun.Any(x => x.urunler.urun_id == si.urunler.urun_id)) { 
        //            s.Urun.FirstOrDefault(x => x.urunler.urun_id == si.urunler.urun_id).Adet++;
        //            }
        //           else
        //            {
        //          s.Urun.Add(si);
        //            }
        //        }
        //        else 
        //        {
        //            Sepet s = new Sepet();
        //            s.Urun.Add(si); //sepet nullsa yeni bir sepet nesnesi oluşturuluyor ve ekleme işlemi gerçekleştiriliyor.
        //            HttpContext.Current.Session["AktifSepet"] = s;
        //        }


        //    }
        //    public decimal ToplamTutar => Urun.Sum(x => x.Tutar);

        //}
        //public class SepetItem
        //{
        //    public urunler urunler { get; set; }
        //    public int Adet { get; set; }
        //    public double Indirim { get; set; }
        //    public decimal Tutar
        //    {
        //        get
        //        {
        //            return (decimal)urunler.fiyat * Adet * (decimal)(1 - Indirim);
        //        }
        //    }
    }


}