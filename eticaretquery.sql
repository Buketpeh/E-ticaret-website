USE [eticaret]
GO
/****** Object:  Table [dbo].[Adres]    Script Date: 27/08/2020 01:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adres](
	[adres_id] [int] IDENTITY(1,1) NOT NULL,
	[kullanici_id] [int] NULL,
	[ulke] [varchar](50) NULL,
	[sehir] [varchar](50) NULL,
	[mahllle] [varchar](50) NULL,
	[cadde] [varchar](50) NULL,
	[sokak] [varchar](50) NULL,
	[apt_no] [int] NULL,
	[daire_no] [int] NULL,
 CONSTRAINT [PK_Adres] PRIMARY KEY CLUSTERED 
(
	[adres_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ana_kategori]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ana_kategori](
	[a_kat_id] [int] NOT NULL,
	[a_kat_adi] [varchar](50) NULL,
 CONSTRAINT [PK_ana_kategori] PRIMARY KEY CLUSTERED 
(
	[a_kat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fatura]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fatura](
	[fatura_id] [int] NOT NULL,
	[siparis_id] [int] NULL,
	[urun_id] [int] NULL,
	[urun_fiyat] [int] NULL,
	[kdv] [int] NULL,
	[toplam_fiyat] [int] NULL,
 CONSTRAINT [PK_fatura] PRIMARY KEY CLUSTERED 
(
	[fatura_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorilerim]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorilerim](
	[Favori_id] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[UrunID] [int] NULL,
	[Fiyati] [int] NULL,
 CONSTRAINT [PK_Favorilerim] PRIMARY KEY CLUSTERED 
(
	[Favori_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hakkimizda]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hakkimizda](
	[Hakkimizda_id] [int] NOT NULL,
	[Baslik] [varchar](50) NULL,
	[Aciklama] [varchar](max) NULL,
 CONSTRAINT [PK_Hakkimizda] PRIMARY KEY CLUSTERED 
(
	[Hakkimizda_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iletisim]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iletisim](
	[Iletisim_id] [int] NOT NULL,
	[Adres] [varchar](max) NULL,
	[Telefon] [nchar](10) NULL,
	[fax] [nchar](10) NULL,
	[Whatsapp] [nchar](10) NULL,
 CONSTRAINT [PK_Iletisim] PRIMARY KEY CLUSTERED 
(
	[Iletisim_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kampanya]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kampanya](
	[kampanya_id] [int] NOT NULL,
	[kampanya_adi] [varchar](50) NULL,
	[baslangic_tarih] [date] NULL,
	[bitis_tarih] [date] NULL,
	[aciklama] [varchar](max) NULL,
 CONSTRAINT [PK_kampanya] PRIMARY KEY CLUSTERED 
(
	[kampanya_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kargo]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kargo](
	[kargo_id] [int] NOT NULL,
	[firma] [varchar](50) NULL,
	[aciklama] [varchar](max) NULL,
	[telefon] [int] NULL,
	[website] [varchar](50) NULL,
	[e_posta] [varchar](50) NULL,
 CONSTRAINT [PK_kargo] PRIMARY KEY CLUSTERED 
(
	[kargo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kart_]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kart_](
	[id] [int] NOT NULL,
	[kart_no] [int] NOT NULL,
	[son_kullanma_tarihi] [date] NOT NULL,
	[cvv] [int] NOT NULL,
 CONSTRAINT [PK_kart_] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kategori]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kategori](
	[kategori_id] [int] NOT NULL,
	[kategori_adi] [varchar](50) NULL,
	[a_kat_id] [int] NULL,
 CONSTRAINT [PK_kategori] PRIMARY KEY CLUSTERED 
(
	[kategori_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kredi_karti]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kredi_karti](
	[kart_id] [int] IDENTITY(1,1) NOT NULL,
	[kullanici_id] [int] NULL,
	[kart_no] [int] NULL,
	[son_kullanma_tarih] [date] NULL,
	[cvv] [int] NULL,
 CONSTRAINT [PK_kredi_karti] PRIMARY KEY CLUSTERED 
(
	[kart_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[Kullanici_id] [int] IDENTITY(1,1) NOT NULL,
	[Kullanici_adi] [varchar](50) NULL,
	[kullanici_soyadi] [varchar](50) NULL,
	[kayit_tarih] [date] NULL,
	[parola] [nchar](10) NULL,
	[Eposta] [varchar](50) NOT NULL,
	[Rol] [nchar](10) NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[Kullanici_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marka]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marka](
	[marka_id] [int] NOT NULL,
	[marka_adi] [varchar](50) NULL,
	[marka_logo] [nvarchar](250) NULL,
 CONSTRAINT [PK_marka] PRIMARY KEY CLUSTERED 
(
	[marka_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[odeme]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[odeme](
	[odeme_id] [int] IDENTITY(1,1) NOT NULL,
	[odeme_secenek_id] [int] NULL,
	[kredi_karti_id] [int] NULL,
	[odeme_zamani] [date] NULL,
	[musteri_id] [int] NULL,
	[tutar] [int] NOT NULL,
 CONSTRAINT [PK_odeme] PRIMARY KEY CLUSTERED 
(
	[odeme_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[renk]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[renk](
	[renk_id] [int] NOT NULL,
	[renk_adi] [varchar](50) NULL,
	[renk_resim] [nvarchar](250) NULL,
 CONSTRAINT [PK_renk] PRIMARY KEY CLUSTERED 
(
	[renk_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sepet]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sepet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[UrunID] [int] NULL,
	[AlisFiyati] [decimal](28, 2) NULL,
	[Miktari] [decimal](28, 2) NULL,
	[ToplamFiyati] [decimal](28, 2) NULL,
	[Tarih] [date] NULL,
	[Saat] [datetime] NULL,
 CONSTRAINT [PK_Sepet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[siparis]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[siparis](
	[siparis_id] [int] IDENTITY(1,1) NOT NULL,
	[siparis_talep_tarih] [date] NULL,
	[urun_id] [int] NULL,
	[kargo_id] [int] NULL,
	[cikis_tarih] [date] NULL,
	[teslim_tarih] [date] NULL,
	[kargo_ucret] [int] NULL,
	[odeme_id] [int] NULL,
	[adres_id] [int] NULL,
 CONSTRAINT [PK_siparis] PRIMARY KEY CLUSTERED 
(
	[siparis_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[urun_kampanya]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[urun_kampanya](
	[u_k_id] [int] NOT NULL,
	[urun_id] [int] NULL,
	[kampanya] [int] NULL,
 CONSTRAINT [PK_urun_kampanya] PRIMARY KEY CLUSTERED 
(
	[u_k_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[urunler]    Script Date: 27/08/2020 01:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[urunler](
	[urun_id] [int] IDENTITY(1,1) NOT NULL,
	[urun_adı] [varchar](50) NULL,
	[kategori_id] [int] NULL,
	[renk_id] [int] NULL,
	[marka_id] [int] NULL,
	[miktar] [int] NULL,
	[ResimURL] [nvarchar](250) NULL,
	[aciklama] [varchar](max) NULL,
	[fiyat] [int] NULL,
	[ResimURL1] [varchar](250) NULL,
	[ResimURL2] [varchar](250) NULL,
	[ResimURL3] [varchar](250) NULL,
	[Tedarikci_id] [int] NULL,
 CONSTRAINT [PK_urunler] PRIMARY KEY CLUSTERED 
(
	[urun_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Adres] ON 
GO
INSERT [dbo].[Adres] ([adres_id], [kullanici_id], [ulke], [sehir], [mahllle], [cadde], [sokak], [apt_no], [daire_no]) VALUES (0, NULL, N'test', N'test', N'test', N'test', N'test', 2, 33)
GO
INSERT [dbo].[Adres] ([adres_id], [kullanici_id], [ulke], [sehir], [mahllle], [cadde], [sokak], [apt_no], [daire_no]) VALUES (1, 1, N'test', N'test', N'test', N'test', N'test', 1, 2)
GO
INSERT [dbo].[Adres] ([adres_id], [kullanici_id], [ulke], [sehir], [mahllle], [cadde], [sokak], [apt_no], [daire_no]) VALUES (2, 6, N'test', N'test', N'test', N'test', N'test', 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Adres] OFF
GO
INSERT [dbo].[ana_kategori] ([a_kat_id], [a_kat_adi]) VALUES (1, N'Elektronikkkk')
GO
INSERT [dbo].[ana_kategori] ([a_kat_id], [a_kat_adi]) VALUES (2, N'tekstil')
GO
INSERT [dbo].[fatura] ([fatura_id], [siparis_id], [urun_id], [urun_fiyat], [kdv], [toplam_fiyat]) VALUES (1, 1, 1, 60, 12, 70)
GO
SET IDENTITY_INSERT [dbo].[Favorilerim] ON 
GO
INSERT [dbo].[Favorilerim] ([Favori_id], [KullaniciID], [UrunID], [Fiyati]) VALUES (0, 1, 1, 15)
GO
INSERT [dbo].[Favorilerim] ([Favori_id], [KullaniciID], [UrunID], [Fiyati]) VALUES (1, 6, 5, 85)
GO
SET IDENTITY_INSERT [dbo].[Favorilerim] OFF
GO
INSERT [dbo].[Hakkimizda] ([Hakkimizda_id], [Baslik], [Aciklama]) VALUES (1, N'Tarihçemiz', N'Agora Bilişim olarak 2005 yılında domain tescili ve hosting hizmeti vererek bilişim sektörüne adım attık. Faaliyetlerimizin temelinde hosting kalmak üzere, 2007 yılında Türkçe karakterli domain adı tesciline yönelik olarak Türkçe İsim Tescil hizmetimizi, 2008 yılında hazır şablonlarla web sitesi yapım aracı Site Yapıcı hizmetimizi ve 2009 yılında Türkiye’de e-ticaret sektörünün hızla gelişmesi üzerine e-ticaret paketleri geliştirmeye başladık. Faaliyetlerimize e-ticaret ağırlıklı olmak üzere kurumsal site tasarımları, firmaya özel e-ticaret uygulamaları ve web tabanlı yazılımlar konusunda devam etmekteyiz.')
GO
INSERT [dbo].[Hakkimizda] ([Hakkimizda_id], [Baslik], [Aciklama]) VALUES (2, N'Vizyonumuz', N'Dijitalleşme tüm dünyada olduğu gibi Türkiye’deki firmaların da iş modellerini temelden etkilemektedir. Bu kapsamda, firmaların satış ve pazarlama kanallarını sanal ortama taşımaları hızla gelişen pazarlarda rekabetçi olabilmeleri için bir zorunluluk haline gelmiştir. Site Yapıcı E-ticaret olarak vizyonumuz; tecrübemizi ve bilgi birikimimizi harmanlayarak en yenilikçi e-ticaret çözümlerini sunmak ve bu yolla firmaların e-ticaret sektöründe istikrarlı bir şekilde büyümelerine olanak sağlamaktır.')
GO
INSERT [dbo].[Hakkimizda] ([Hakkimizda_id], [Baslik], [Aciklama]) VALUES (3, N'Misyonumuz', N'Sunduğumuz hizmetleri firmalar için mümkün olduğunca kişiselleştirerek bir çözüm ortağı şeklinde faaliyetlerinize katkıda bulunmak ve dijitalleşme çağının sunduğu olanaklardan maksimum şekilde yararlanmanızı sağlamaktır.')
GO
INSERT [dbo].[Iletisim] ([Iletisim_id], [Adres], [Telefon], [fax], [Whatsapp]) VALUES (1, N'Çiftehavuzlar Mah. Eski Londra Asfaltı Cad. Yıldız Teknik Üniversitesi Davutpaşa Kampüsü Teknoparkı A1 Blok – Kat:2 – No:201 P.K. 34220 Esenler / İstanbul / TÜRKİYE', N'0212 86 33', N'0212 86 33', N'554 345   ')
GO
INSERT [dbo].[kampanya] ([kampanya_id], [kampanya_adi], [baslangic_tarih], [bitis_tarih], [aciklama]) VALUES (2, N'yemek kampanyasi', CAST(N'2020-02-01' AS Date), CAST(N'2020-02-05' AS Date), N'asdasayayayyayayyayaya')
GO
INSERT [dbo].[kargo] ([kargo_id], [firma], [aciklama], [telefon], [website], [e_posta]) VALUES (1, N'yurtiçi', N'aaa', 216, N'www.yk.com', N'yk@yk.com')
GO
INSERT [dbo].[kart_] ([id], [kart_no], [son_kullanma_tarihi], [cvv]) VALUES (1, 55555555, CAST(N'2020-03-01' AS Date), 444)
GO
INSERT [dbo].[kategori] ([kategori_id], [kategori_adi], [a_kat_id]) VALUES (1, N'Elektronik', 1)
GO
INSERT [dbo].[kategori] ([kategori_id], [kategori_adi], [a_kat_id]) VALUES (2, N'Giyim', 2)
GO
INSERT [dbo].[kategori] ([kategori_id], [kategori_adi], [a_kat_id]) VALUES (3, N'Ev Ürünleri', 1)
GO
INSERT [dbo].[kategori] ([kategori_id], [kategori_adi], [a_kat_id]) VALUES (4, N'Kozmatik', 1)
GO
INSERT [dbo].[kategori] ([kategori_id], [kategori_adi], [a_kat_id]) VALUES (5, N'Saat & Aksesuar', 1)
GO
SET IDENTITY_INSERT [dbo].[kredi_karti] ON 
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (0, 0, 1111112121, CAST(N'2030-01-01' AS Date), 333)
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (1, 0, 55555555, CAST(N'2020-03-01' AS Date), 444)
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (2, 0, 222, CAST(N'2030-01-01' AS Date), 543)
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (3, 0, 545454, CAST(N'2030-01-01' AS Date), 123)
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (4, 1, 1111112121, CAST(N'2030-01-01' AS Date), 333)
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (5, 1, 123123, CAST(N'2030-01-01' AS Date), 666)
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (6, 1, 55555555, CAST(N'2020-03-01' AS Date), 444)
GO
INSERT [dbo].[kredi_karti] ([kart_id], [kullanici_id], [kart_no], [son_kullanma_tarih], [cvv]) VALUES (7, 6, 55555555, CAST(N'2020-03-01' AS Date), 444)
GO
SET IDENTITY_INSERT [dbo].[kredi_karti] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (0, NULL, NULL, CAST(N'2020-08-26' AS Date), N'1234      ', N'nazlı@outlook.com', N'Müşteri   ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (1, N'Burcu', N'Kabarcaoğlu', CAST(N'2020-01-02' AS Date), N'123456789 ', N'burcuka@gmail.com', N'Müşteri   ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (2, N'Buket', N'Pehlivan', CAST(N'2020-09-03' AS Date), N'1234      ', N'buketpeh@gmail.com', N'Admin     ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (3, N'Ali', N'Ar', CAST(N'2020-09-03' AS Date), N'1234      ', N'a@gmail.com', N'Müşteri   ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (4, N'nedim', N'gül', CAST(N'2020-09-01' AS Date), N'202020    ', N'nedim@outlook.com', N'Tedarikçi ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (5, NULL, NULL, CAST(N'2020-08-26' AS Date), N'1234      ', N'nazli@outlook.com', N'Müşteri   ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (6, N'Sevgi', N'Kuru', CAST(N'2020-08-26' AS Date), N'4321      ', N'sevgi@outlook.com', N'Müşteri   ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (7, N'Sevgi', N'dere', CAST(N'2020-08-26' AS Date), N'123456789 ', N'sevgidere@outlook.com', N'Müşteri   ')
GO
INSERT [dbo].[Kullanici] ([Kullanici_id], [Kullanici_adi], [kullanici_soyadi], [kayit_tarih], [parola], [Eposta], [Rol]) VALUES (8, N'azra', N'kara', CAST(N'2020-08-26' AS Date), N'123456    ', N'azra@outlook.com', N'Tedarikçi ')
GO
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
INSERT [dbo].[marka] ([marka_id], [marka_adi], [marka_logo]) VALUES (1, N'HYTECH', N'aaaa')
GO
INSERT [dbo].[marka] ([marka_id], [marka_adi], [marka_logo]) VALUES (2, N'mango', N'b')
GO
INSERT [dbo].[marka] ([marka_id], [marka_adi], [marka_logo]) VALUES (4, N'zara', NULL)
GO
INSERT [dbo].[marka] ([marka_id], [marka_adi], [marka_logo]) VALUES (5, N'aryol', NULL)
GO
SET IDENTITY_INSERT [dbo].[odeme] ON 
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (0, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1, 1, 1, CAST(N'2020-02-02' AS Date), 1, 70)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (2, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (3, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (4, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (5, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (6, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (7, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (8, NULL, 6, CAST(N'2020-08-24' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1002, NULL, 6, CAST(N'2020-08-26' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1003, NULL, 6, CAST(N'2020-08-26' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1004, NULL, 6, CAST(N'2020-08-26' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1005, NULL, 6, CAST(N'2020-08-26' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1006, NULL, 6, CAST(N'2020-08-26' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1007, NULL, 6, CAST(N'2020-08-26' AS Date), 1, 0)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1008, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 85)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1009, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 85)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1010, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 85)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1011, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 85)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1012, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 100)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1013, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 85)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1014, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 85)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1015, NULL, 7, CAST(N'2020-08-26' AS Date), 6, 100)
GO
INSERT [dbo].[odeme] ([odeme_id], [odeme_secenek_id], [kredi_karti_id], [odeme_zamani], [musteri_id], [tutar]) VALUES (1016, NULL, 6, CAST(N'2020-08-26' AS Date), 1, 130)
GO
SET IDENTITY_INSERT [dbo].[odeme] OFF
GO
INSERT [dbo].[renk] ([renk_id], [renk_adi], [renk_resim]) VALUES (1, N'siyahhh', N'a')
GO
INSERT [dbo].[renk] ([renk_id], [renk_adi], [renk_resim]) VALUES (2, N'mavi', N'mavi')
GO
INSERT [dbo].[renk] ([renk_id], [renk_adi], [renk_resim]) VALUES (3, N'turuncu', N'turuncu')
GO
SET IDENTITY_INSERT [dbo].[Sepet] ON 
GO
INSERT [dbo].[Sepet] ([ID], [KullaniciID], [UrunID], [AlisFiyati], [Miktari], [ToplamFiyati], [Tarih], [Saat]) VALUES (29, 6, 5, CAST(85.00 AS Decimal(28, 2)), CAST(1.00 AS Decimal(28, 2)), CAST(85.00 AS Decimal(28, 2)), CAST(N'2020-08-26' AS Date), CAST(N'2020-08-26T21:49:40.163' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Sepet] OFF
GO
SET IDENTITY_INSERT [dbo].[siparis] ON 
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (1, CAST(N'2020-02-02' AS Date), 1, 1, CAST(N'2020-03-02' AS Date), CAST(N'2020-05-02' AS Date), 10, 1, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (2, CAST(N'2020-08-24' AS Date), 1, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (3, CAST(N'2020-08-24' AS Date), 2, 1, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 6, 0, 0)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (4, CAST(N'2020-08-24' AS Date), 1, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (5, CAST(N'2020-08-24' AS Date), 2, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (6, CAST(N'2020-08-24' AS Date), 1, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (7, CAST(N'2020-08-24' AS Date), 2, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (8, CAST(N'2020-08-24' AS Date), 1, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (9, CAST(N'2020-08-24' AS Date), 2, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (10, CAST(N'2020-08-24' AS Date), 1, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (11, CAST(N'2020-08-24' AS Date), 2, NULL, CAST(N'2020-08-25' AS Date), CAST(N'2020-08-28' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (12, CAST(N'2020-08-26' AS Date), 1, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (13, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, NULL)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (14, CAST(N'2020-08-26' AS Date), 1, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (15, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (16, CAST(N'2020-08-26' AS Date), 1, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (17, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (18, CAST(N'2020-08-26' AS Date), 1, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (19, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (20, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (21, CAST(N'2020-08-26' AS Date), 5, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (22, CAST(N'2020-08-26' AS Date), 5, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (23, CAST(N'2020-08-26' AS Date), 5, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (24, CAST(N'2020-08-26' AS Date), 5, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (25, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (26, CAST(N'2020-08-26' AS Date), 5, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (27, CAST(N'2020-08-26' AS Date), 5, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (28, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 1008, 2)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (29, CAST(N'2020-08-26' AS Date), 1, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
INSERT [dbo].[siparis] ([siparis_id], [siparis_talep_tarih], [urun_id], [kargo_id], [cikis_tarih], [teslim_tarih], [kargo_ucret], [odeme_id], [adres_id]) VALUES (30, CAST(N'2020-08-26' AS Date), 2, NULL, CAST(N'2020-08-27' AS Date), CAST(N'2020-08-30' AS Date), 5, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[siparis] OFF
GO
SET IDENTITY_INSERT [dbo].[urunler] ON 
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1, N'JBL', 1, 3, 1, 4, N'/Uploads/Urun/905d5de3-ed71-4dec-abcd-185ba09f9f8d.jpg', N'Bluetooth Hoparlör', 15, N'/Uploads/Urun/005ba0e3-b3e6-43f5-ab5f-d33adf425e1e.jpg', N'/Uploads/Urun/fd83c5a5-e133-40f6-a4fe-3fafaafd3052.jpg', N'/Uploads/Urun/8e65fe0c-94fe-48aa-9d24-3f26b68a0452.jpg', 2)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (2, N'Redmi2', 1, 1, 1, 95, N'/Uploads/Urun/89f324a4-8e7e-4318-bc3f-b151f867d598.jpg', N'Telefon', 100, N'/Uploads/Urun/7647e26c-2d00-4005-a054-d060801e4d08.jpg', N'/Uploads/Urun/48a6ae47-254e-40e3-982b-74667c9e90db.jpg', N'/Uploads/Urun/45756d29-60fa-4a8c-bc53-1a07f5ccc023.jpg', 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (3, N'AWOX', 1, 1, 1, 20, N'/Uploads/Urun/5cfbe10a-5783-4d3b-b9de-eff0395cb14c.jpg', N'Televizyon', 125, N'/Uploads/Urun/40839bc3-37b6-46d3-aecd-149c086178bd.jpg', N'/Uploads/Urun/16cbe8e2-c26a-4c66-ac18-3b4568b1729c.jpg', N'/Uploads/Urun/6e37693f-fc27-45f5-b46a-37a8c88875fe.jpg', 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (4, N'Angel Eyee', 1, 1, 1, 56, N'/Uploads/Urun/59c909b9-5532-44fe-b462-f44f59cbffe6.jpg', N'Eye 080p Hd Su Geçirmez Aksiyon Kamerası Siyah 1394968', 70, N'/Uploads/Urun/88720997-18d2-4872-a0d9-578c4146ba14.jpg', N'/Uploads/Urun/d59e0075-5433-42eb-b8e9-1e4bd1c75239.jpg', N'/Uploads/Urun/0098964e-99cc-4e3d-9656-f81a42597595.jpg', 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (5, N'Sweatshirt', 2, 3, 4, 59, N'/Uploads/Urun/74e41a00-5b3c-47a1-a166-0f21098f9410.jpg', N'Kadın Yumuşak Pembe Sweatshirt 0WH922Z8', 85, N'/Uploads/Urun/066aaf8a-d798-4b02-a536-0fe2d02aae00.jpg', N'/Uploads/Urun/7fee5ad9-6878-4e80-8c88-8288d5a7cb1e.jpg', N'/Uploads/Urun/a98c788b-0c18-4276-9489-7b1ea011ec36.jpg', 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (6, N'Eşofman', 2, 1, 2, 45, N'/Uploads/Urun/3b9ff086-29cc-464d-b341-4fd1dbc296aa.jpg', N'Eşofman Siyah', 90, N'/Uploads/Urun/3f87ff2c-f7e2-4782-8108-6c91ce3d5e04.jpg', N'/Uploads/Urun/6fb579c0-507e-49fb-98c4-8229268447c3.jpg', N'/Uploads/Urun/9d7cf27b-f573-4e0c-ac73-f90c48124b10.jpg', 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (7, N'Sweatshirt', 2, 1, 4, 56, N'/Uploads/Urun/91d483ae-2c7c-41b3-ada2-889a6a910f06.jpg', N'Sweatshirt siyah', 123, N'/Uploads/Urun/623fc9a6-8d2c-4241-9e59-f591c17c5cf9.jpg', N'/Uploads/Urun/3c2cdf2d-559c-465a-9a1c-c2134e7f092d.jpg', N'/Uploads/Urun/b59a6486-3ed3-4cea-9f71-0d2c9f03003a.jpg', 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (8, N'Kazak', 2, 2, 4, 5, N'/Uploads/Urun/35860a18-3ec3-4a69-9f9d-eda2fb0125a0.jpg', N'Kazak mavi', 200, N'/Uploads/Urun/5f5689bc-4f7f-4bed-95f9-87206d8ab108.jpg', N'/Uploads/Urun/1cdeff4e-2853-4039-ae9f-6e65debba110.jpg', N'/Uploads/Urun/25f7e3e5-927b-4a1a-8b33-f291722435d0.jpg', 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (9, N'Enlora Home', 3, 2, 5, 5, N'/Uploads/Urun/ca53dcbf-c568-45f2-8f27-9c3d3bed7ae3.jpg', N'100 Doğal Pamuk Tek Kişilik Nevresim Takımı Spacex Lacivert Ep-019646', NULL, N'/Uploads/Urun/6afb9f3d-b1b6-418e-8aec-df15a9deb7a2.jpg', N'/Uploads/Urun/23383fdf-64e5-42ee-bcc1-0138f7d27a31.jpg', N'/Uploads/Urun/3c89c3de-b479-4de4-8908-9d875011d71e.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (10, N'Kate Louise', 3, 1, 5, 5, N'/Uploads/Urun/84fa1fb1-0f6b-48ae-ad99-33d45992fc70.jpg', N'Mdf Lambader - Krem/Kahve KTL-KREM-KAHVE', 565, N'/Uploads/Urun/b0e7dec8-9663-4eba-84cf-c63df6a46c15.jpg', N'/Uploads/Urun/a5df3441-dd0b-477b-aa6a-e20351d83d2d.jpg', N'/Uploads/Urun/66b9710c-d82e-4b73-83e8-c3b73b294334.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (11, N'Halı', 3, 3, 5, 155, N'/Uploads/Urun/11936a4b-3593-4708-ada0-b65c7fc4b5ef.jpg', N'Halı', 55, N'/Uploads/Urun/73448380-0244-480a-966c-33b360b765c6.jpg', N'/Uploads/Urun/dcb95d27-8a84-405b-bdec-af6858c238b6.jpg', N'/Uploads/Urun/bdf977e8-c1bc-4ad3-acc8-464cc527a8f3.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (12, N'Rabi', 3, 1, 1, 5, N'/Uploads/Urun/354b15e4-f19b-43ea-99d8-54bfb82bb68b.jpg', N'Buse Lüx Tv Ünitesi tv1001', NULL, N'/Uploads/Urun/412573ca-8156-4136-9e60-081556408646.jpg', N'/Uploads/Urun/242bdc48-64a7-4125-8595-cd09c4dc92b6.jpg', N'/Uploads/Urun/cf59c534-f846-4bd7-bb9e-adca1d1b35a4.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (13, N'Meleni Home', 4, 1, 5, 55, N'/Uploads/Urun/18d892fb-9f9e-41cb-85f4-b0f625bcbc51.jpg', N'5 Katlı 6 Çekmeceli Makyaj Düzenleyici Set Akrilik Organizer MeleniHome-11038', NULL, N'/Uploads/Urun/343f5faf-f119-442c-8c8b-3d557d930838.jpg', N'/Uploads/Urun/6bbbf74c-3a97-422f-a7bf-cb694c38c905.jpg', N'/Uploads/Urun/c2250f74-fca5-451e-a626-6ff42b2c1486.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (14, N'Gliss Şampuan', 4, 2, 5, 5, N'/Uploads/Urun/9da7e606-da4e-40bd-a153-c8b0dbb64e77.jpg', N'Nutrıbalance Şampuan 525 ml X2 Adet SET.HNKL.1510', 55, N'/Uploads/Urun/6528eddd-8d9d-4679-a446-07d14314b2bb.jpg', N'/Uploads/Urun/b7b5c1ed-359d-4b38-9a51-3bb42ede6f7f.jpg', N'/Uploads/Urun/c0cee9da-1767-4f97-8557-4a1b81898e66.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1009, N'Kolye', 5, 2, 2, 5, N'/Uploads/Urun/4db46b37-97f7-46fc-9f34-326fea122857.jpg', N'Mavi Mineli Sır Kelebek Kolye _rose / Tektaş Kolye Hediyeli RGK30743', 55, N'/Uploads/Urun/fd011b31-f62f-4f45-9881-d2f3bc7e3ab1.jpg', N'/Uploads/Urun/09365220-dc74-4ae8-8f1d-7ad24b5cf53e.jpg', N'/Uploads/Urun/8929e20f-34ec-4af8-9b07-11d93a4b6ea6.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1010, N'Midyat Gümüş Dünyası', 5, 2, 2, 55, N'/Uploads/Urun/6608208d-3638-4ab9-9eae-9c8f79475b82.jpg', N'Kadın Tek taş Gümüş Küpe 2020203', NULL, N'/Uploads/Urun/a9a1302e-a3a6-43b0-b3aa-5f8e286994b1.jpg', N'/Uploads/Urun/1ed48445-63e4-444a-a829-e914a873b9c8.jpg', N'/Uploads/Urun/f033ec87-58e2-431d-a832-ff66ff2a6fe1.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1011, N'Aqua Di Polo', 5, 1, 1, 5, N'/Uploads/Urun/403cde32-01f5-4ce4-872f-494c0422b0df.jpg', N'Unisex Kol Saati APL12C185H01', 250, N'/Uploads/Urun/7a93c4f8-ddd7-4940-847d-840862012acf.jpg', N'/Uploads/Urun/6ed29d33-6f8c-4c45-b57e-bde1fc2ce322.jpg', N'/Uploads/Urun/9f15bc6f-ee20-4fc1-8ece-85548afa4d35.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1012, N'test', 1, 1, 1, 7, N'/Uploads/Urun/8031b6c2-cb1b-44e1-b731-e1422d6f3634.jpg', N'test', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1013, N'test', 1, 2, 1, 5, N'/Uploads/Urun/6e7829b7-b1d9-4859-a745-92f051a69a58.jpg', N'Bluetooth Hoparlör', 55, N'/Uploads/Urun/361a52a9-5f07-453f-83a8-25fde9dbc676.jpg', N'System.Web.HttpPostedFileWrapper', N'/Uploads/Urun/2226a474-e80f-4060-b808-7e62465fc45f.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1014, N'a', 1, 1, 1, 5, N'/Uploads/Urun/fd717846-9978-47cd-9206-76b3311638e6.jpg', N'Bluetooth Hoparlör', 55, N'/Uploads/Urun/1cda08cc-3081-4e3a-a4d6-94607af1578b.jpg', N'/Uploads/Urun/cdd2f833-cb1b-4768-b517-9935f7d4d7ac.jpg', N'/Uploads/Urun/f2bb4327-5c5b-4881-bbf3-2d1348addf79.jpg', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1015, N'Sweatshirt', 1, 1, 1, 5, NULL, N'Telefon', 6, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1016, N'testson', 1, 1, 1, 5, N'asda', N'aa', 55, N'1', N'2', N'3', NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1017, N'test', 1, 1, 1, 55, N'/Uploads/Urun/a30f47e4-1468-404c-83a2-792ab1159584.jpg', NULL, NULL, N'/Uploads/Urun/b12b2d03-b638-48fe-8ae5-7f00b755f9ba.jpg', NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1018, N'test', 1, 1, 1, 55, NULL, N'gb', 44, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1019, N'testson', 1, 1, 1, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1020, N'testson123', 1, 1, 1, 55, NULL, NULL, 55, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1021, NULL, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1022, N'testson123', 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1023, N'Sweatshirttest', 1, 1, 1, 55, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1024, N'Sweatshirttest', 3, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1025, N'Sweatshirttest1234', 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1026, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1027, N'', 5, 1, 1, 55, NULL, N'1', NULL, NULL, NULL, NULL, 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1028, N'', 1, 1, 1, 1, NULL, N'1', NULL, NULL, NULL, NULL, 4)
GO
INSERT [dbo].[urunler] ([urun_id], [urun_adı], [kategori_id], [renk_id], [marka_id], [miktar], [ResimURL], [aciklama], [fiyat], [ResimURL1], [ResimURL2], [ResimURL3], [Tedarikci_id]) VALUES (1029, N'a', 5, 1, 1, 1, NULL, N'aa', NULL, NULL, NULL, NULL, 4)
GO
SET IDENTITY_INSERT [dbo].[urunler] OFF
GO
ALTER TABLE [dbo].[Adres]  WITH CHECK ADD  CONSTRAINT [FK_Adres_Kullanici] FOREIGN KEY([kullanici_id])
REFERENCES [dbo].[Kullanici] ([Kullanici_id])
GO
ALTER TABLE [dbo].[Adres] CHECK CONSTRAINT [FK_Adres_Kullanici]
GO
ALTER TABLE [dbo].[fatura]  WITH CHECK ADD  CONSTRAINT [FK_fatura_siparis] FOREIGN KEY([siparis_id])
REFERENCES [dbo].[siparis] ([siparis_id])
GO
ALTER TABLE [dbo].[fatura] CHECK CONSTRAINT [FK_fatura_siparis]
GO
ALTER TABLE [dbo].[fatura]  WITH CHECK ADD  CONSTRAINT [FK_fatura_urunler] FOREIGN KEY([urun_id])
REFERENCES [dbo].[urunler] ([urun_id])
GO
ALTER TABLE [dbo].[fatura] CHECK CONSTRAINT [FK_fatura_urunler]
GO
ALTER TABLE [dbo].[Favorilerim]  WITH CHECK ADD  CONSTRAINT [FK_Favorilerim_Kullanici] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanici] ([Kullanici_id])
GO
ALTER TABLE [dbo].[Favorilerim] CHECK CONSTRAINT [FK_Favorilerim_Kullanici]
GO
ALTER TABLE [dbo].[Favorilerim]  WITH CHECK ADD  CONSTRAINT [FK_Favorilerim_urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[urunler] ([urun_id])
GO
ALTER TABLE [dbo].[Favorilerim] CHECK CONSTRAINT [FK_Favorilerim_urunler]
GO
ALTER TABLE [dbo].[kategori]  WITH CHECK ADD  CONSTRAINT [FK_kategori_ana_kategori] FOREIGN KEY([a_kat_id])
REFERENCES [dbo].[ana_kategori] ([a_kat_id])
GO
ALTER TABLE [dbo].[kategori] CHECK CONSTRAINT [FK_kategori_ana_kategori]
GO
ALTER TABLE [dbo].[odeme]  WITH CHECK ADD  CONSTRAINT [FK_odeme_kredi_karti] FOREIGN KEY([kredi_karti_id])
REFERENCES [dbo].[kredi_karti] ([kart_id])
GO
ALTER TABLE [dbo].[odeme] CHECK CONSTRAINT [FK_odeme_kredi_karti]
GO
ALTER TABLE [dbo].[odeme]  WITH CHECK ADD  CONSTRAINT [FK_odeme_Kullanici] FOREIGN KEY([musteri_id])
REFERENCES [dbo].[Kullanici] ([Kullanici_id])
GO
ALTER TABLE [dbo].[odeme] CHECK CONSTRAINT [FK_odeme_Kullanici]
GO
ALTER TABLE [dbo].[Sepet]  WITH CHECK ADD  CONSTRAINT [FK_Sepet_Kullanici] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanici] ([Kullanici_id])
GO
ALTER TABLE [dbo].[Sepet] CHECK CONSTRAINT [FK_Sepet_Kullanici]
GO
ALTER TABLE [dbo].[Sepet]  WITH CHECK ADD  CONSTRAINT [FK_Sepet_urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[urunler] ([urun_id])
GO
ALTER TABLE [dbo].[Sepet] CHECK CONSTRAINT [FK_Sepet_urunler]
GO
ALTER TABLE [dbo].[siparis]  WITH CHECK ADD  CONSTRAINT [FK_siparis_Adres] FOREIGN KEY([adres_id])
REFERENCES [dbo].[Adres] ([adres_id])
GO
ALTER TABLE [dbo].[siparis] CHECK CONSTRAINT [FK_siparis_Adres]
GO
ALTER TABLE [dbo].[siparis]  WITH CHECK ADD  CONSTRAINT [FK_siparis_kargo] FOREIGN KEY([kargo_id])
REFERENCES [dbo].[kargo] ([kargo_id])
GO
ALTER TABLE [dbo].[siparis] CHECK CONSTRAINT [FK_siparis_kargo]
GO
ALTER TABLE [dbo].[siparis]  WITH CHECK ADD  CONSTRAINT [FK_siparis_odeme] FOREIGN KEY([odeme_id])
REFERENCES [dbo].[odeme] ([odeme_id])
GO
ALTER TABLE [dbo].[siparis] CHECK CONSTRAINT [FK_siparis_odeme]
GO
ALTER TABLE [dbo].[siparis]  WITH CHECK ADD  CONSTRAINT [FK_siparis_urunler] FOREIGN KEY([urun_id])
REFERENCES [dbo].[urunler] ([urun_id])
GO
ALTER TABLE [dbo].[siparis] CHECK CONSTRAINT [FK_siparis_urunler]
GO
ALTER TABLE [dbo].[urun_kampanya]  WITH CHECK ADD  CONSTRAINT [FK_urun_kampanya_kampanya] FOREIGN KEY([u_k_id])
REFERENCES [dbo].[kampanya] ([kampanya_id])
GO
ALTER TABLE [dbo].[urun_kampanya] CHECK CONSTRAINT [FK_urun_kampanya_kampanya]
GO
ALTER TABLE [dbo].[urun_kampanya]  WITH CHECK ADD  CONSTRAINT [FK_urun_kampanya_urunler] FOREIGN KEY([urun_id])
REFERENCES [dbo].[urunler] ([urun_id])
GO
ALTER TABLE [dbo].[urun_kampanya] CHECK CONSTRAINT [FK_urun_kampanya_urunler]
GO
ALTER TABLE [dbo].[urunler]  WITH CHECK ADD  CONSTRAINT [FK_urunler_kategori] FOREIGN KEY([kategori_id])
REFERENCES [dbo].[kategori] ([kategori_id])
GO
ALTER TABLE [dbo].[urunler] CHECK CONSTRAINT [FK_urunler_kategori]
GO
ALTER TABLE [dbo].[urunler]  WITH CHECK ADD  CONSTRAINT [FK_urunler_Kullanici] FOREIGN KEY([Tedarikci_id])
REFERENCES [dbo].[Kullanici] ([Kullanici_id])
GO
ALTER TABLE [dbo].[urunler] CHECK CONSTRAINT [FK_urunler_Kullanici]
GO
ALTER TABLE [dbo].[urunler]  WITH CHECK ADD  CONSTRAINT [FK_urunler_marka] FOREIGN KEY([marka_id])
REFERENCES [dbo].[marka] ([marka_id])
GO
ALTER TABLE [dbo].[urunler] CHECK CONSTRAINT [FK_urunler_marka]
GO
ALTER TABLE [dbo].[urunler]  WITH CHECK ADD  CONSTRAINT [FK_urunler_renk] FOREIGN KEY([renk_id])
REFERENCES [dbo].[renk] ([renk_id])
GO
ALTER TABLE [dbo].[urunler] CHECK CONSTRAINT [FK_urunler_renk]
GO
