namespace E_ticaret.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model19")
        {
        }

        public virtual DbSet<Adre> Adres { get; set; }
        public virtual DbSet<ana_kategori> ana_kategori { get; set; }
        public virtual DbSet<fatura> faturas { get; set; }
        public virtual DbSet<Favorilerim> Favorilerims { get; set; }
        public virtual DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public virtual DbSet<Iletisim> Iletisims { get; set; }
        public virtual DbSet<kampanya> kampanyas { get; set; }
        public virtual DbSet<kargo> kargoes { get; set; }
        public virtual DbSet<kart_> kart_ { get; set; }
        public virtual DbSet<kategori> kategoris { get; set; }
        public virtual DbSet<kredi_karti> kredi_karti { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<marka> markas { get; set; }
        public virtual DbSet<odeme> odemes { get; set; }
        public virtual DbSet<renk> renks { get; set; }
        public virtual DbSet<Sepet> Sepets { get; set; }
        public virtual DbSet<sipari> siparis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<urun_kampanya> urun_kampanya { get; set; }
        public virtual DbSet<urunler> urunlers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adre>()
                .Property(e => e.ulke)
                .IsUnicode(false);

            modelBuilder.Entity<Adre>()
                .Property(e => e.sehir)
                .IsUnicode(false);

            modelBuilder.Entity<Adre>()
                .Property(e => e.mahllle)
                .IsUnicode(false);

            modelBuilder.Entity<Adre>()
                .Property(e => e.cadde)
                .IsUnicode(false);

            modelBuilder.Entity<Adre>()
                .Property(e => e.sokak)
                .IsUnicode(false);

            modelBuilder.Entity<ana_kategori>()
                .Property(e => e.a_kat_adi)
                .IsUnicode(false);

            modelBuilder.Entity<Hakkimizda>()
                .Property(e => e.Baslik)
                .IsUnicode(false);

            modelBuilder.Entity<Hakkimizda>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Telefon)
                .IsFixedLength();

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.fax)
                .IsFixedLength();

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Whatsapp)
                .IsFixedLength();

            modelBuilder.Entity<kampanya>()
                .Property(e => e.kampanya_adi)
                .IsUnicode(false);

            modelBuilder.Entity<kampanya>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<kampanya>()
                .HasOptional(e => e.urun_kampanya)
                .WithRequired(e => e.kampanya1);

            modelBuilder.Entity<kargo>()
                .Property(e => e.firma)
                .IsUnicode(false);

            modelBuilder.Entity<kargo>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<kargo>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<kargo>()
                .Property(e => e.e_posta)
                .IsUnicode(false);

            modelBuilder.Entity<kategori>()
                .Property(e => e.kategori_adi)
                .IsUnicode(false);

            modelBuilder.Entity<kredi_karti>()
                .HasMany(e => e.odemes)
                .WithOptional(e => e.kredi_karti)
                .HasForeignKey(e => e.kredi_karti_id);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.Kullanici_adi)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.kullanici_soyadi)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.parola)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.Eposta)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.Rol)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Favorilerims)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.KullaniciID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.odemes)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.musteri_id);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Sepets)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.KullaniciID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.urunlers)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.Tedarikci_id);

            modelBuilder.Entity<marka>()
                .Property(e => e.marka_adi)
                .IsUnicode(false);

            modelBuilder.Entity<renk>()
                .Property(e => e.renk_adi)
                .IsUnicode(false);

            modelBuilder.Entity<Sepet>()
                .Property(e => e.AlisFiyati)
                .HasPrecision(28, 2);

            modelBuilder.Entity<Sepet>()
                .Property(e => e.Miktari)
                .HasPrecision(28, 2);

            modelBuilder.Entity<Sepet>()
                .Property(e => e.ToplamFiyati)
                .HasPrecision(28, 2);

            modelBuilder.Entity<urunler>()
                .Property(e => e.urun_adı)
                .IsUnicode(false);

            modelBuilder.Entity<urunler>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<urunler>()
                .Property(e => e.ResimURL1)
                .IsUnicode(false);

            modelBuilder.Entity<urunler>()
                .Property(e => e.ResimURL2)
                .IsUnicode(false);

            modelBuilder.Entity<urunler>()
                .Property(e => e.ResimURL3)
                .IsUnicode(false);

            modelBuilder.Entity<urunler>()
                .HasMany(e => e.Favorilerims)
                .WithOptional(e => e.urunler)
                .HasForeignKey(e => e.UrunID);

            modelBuilder.Entity<urunler>()
                .HasMany(e => e.Sepets)
                .WithOptional(e => e.urunler)
                .HasForeignKey(e => e.UrunID);
        }
    }
}
