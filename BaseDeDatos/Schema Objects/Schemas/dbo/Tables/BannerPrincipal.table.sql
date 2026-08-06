CREATE TABLE [dbo].[BannerPrincipal]
(
	BigBanner1 NVARCHAR(50) NOT NULL,
	BigBanner2 NVARCHAR(50) NOT NULL,
	BigBanner3 NVARCHAR(50) NOT NULL,
	BigBanner4 NVARCHAR(50) NOT NULL,
	BigBanner5 NVARCHAR(50) NOT NULL,
	SmallBanner1 NVARCHAR(50) NOT NULL,
	SmallBanner2 NVARCHAR(50) NOT NULL,
	SmallBanner3 NVARCHAR(50) NOT NULL,
	SmallBanner4 NVARCHAR(50) NOT NULL,
	SmallBanner5 NVARCHAR(50) NOT NULL,
	VideoDataSource NVARCHAR(30) NOT NULL,
	VideoDataId NVARCHAR(250) NOT NULL, 
    VideoImagenMiniatura NCHAR(50) NOT NULL,
	UrlPresentacionArticulo1 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo2 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo3 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo4 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo5 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo6 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo7 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo8 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo9 NVARCHAR(500) NOT NULL,
	UrlPresentacionArticulo10 NVARCHAR(500) NOT NULL,
	SegundoAutoplayFotorama INT NOT NULL
)

