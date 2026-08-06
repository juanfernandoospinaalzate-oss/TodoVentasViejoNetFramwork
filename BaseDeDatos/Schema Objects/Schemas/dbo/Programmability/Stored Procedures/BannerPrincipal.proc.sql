CREATE PROCEDURE BannerPrincipalInsert
	@BigBanner1 AS  nvarchar(50)
	,@BigBanner2 AS  nvarchar(50)
	,@BigBanner3 AS  nvarchar(50)
	,@BigBanner4 AS  nvarchar(50)
	,@BigBanner5 AS  nvarchar(50)
	,@SmallBanner1 AS  nvarchar(50)
	,@SmallBanner2 AS  nvarchar(50)
	,@SmallBanner3 AS  nvarchar(50)
	,@SmallBanner4 AS  nvarchar(50)
	,@SmallBanner5 AS  nvarchar(50)
	,@VideoDataSource  AS  nvarchar(30)
	,@VideoDataId AS NVARCHAR(50)
	,@VideoImagenMiniatura AS NVARCHAR(50)
	,@UrlPresentacionArticulo1 AS NVARCHAR(500)
	,@UrlPresentacionArticulo2 AS NVARCHAR(500)
	,@UrlPresentacionArticulo3 AS NVARCHAR(500)
	,@UrlPresentacionArticulo4 AS NVARCHAR(500)
	,@UrlPresentacionArticulo5 AS NVARCHAR(500)
	,@UrlPresentacionArticulo6 AS NVARCHAR(500)
	,@UrlPresentacionArticulo7 AS NVARCHAR(500)
	,@UrlPresentacionArticulo8 AS NVARCHAR(500)
	,@UrlPresentacionArticulo9 AS NVARCHAR(500)
	,@UrlPresentacionArticulo10 AS NVARCHAR(500)
	,@SegundoAutoplayFotorama AS INT
AS
INSERT INTO [dbo].[BannerPrincipal]
           ([BigBanner1]
           ,[BigBanner2]
           ,[BigBanner3]
           ,[BigBanner4]
           ,[BigBanner5]
           ,[SmallBanner1]
           ,[SmallBanner2]
           ,[SmallBanner3]
           ,[SmallBanner4]
           ,[SmallBanner5]
           ,[VideoDataSource]
           ,[VideoDataId]
           ,[VideoImagenMiniatura]
		   ,[UrlPresentacionArticulo1]
		   ,[UrlPresentacionArticulo2]
		   ,[UrlPresentacionArticulo3]
		   ,[UrlPresentacionArticulo4]
		   ,[UrlPresentacionArticulo5]
		   ,[UrlPresentacionArticulo6]
		   ,[UrlPresentacionArticulo7]
		   ,[UrlPresentacionArticulo8]
		   ,[UrlPresentacionArticulo9]
		   ,[UrlPresentacionArticulo10]
		   ,[SegundoAutoplayFotorama])
     VALUES
           (@BigBanner1
		   ,@BigBanner2
		   ,@BigBanner3
		   ,@BigBanner4
		   ,@BigBanner5
           ,@SmallBanner1
		   ,@SmallBanner2
		   ,@SmallBanner3
		   ,@SmallBanner4
		   ,@SmallBanner5
           ,@VideoDataSource
           ,@VideoDataId
           ,@VideoImagenMiniatura
		   ,@UrlPresentacionArticulo1
		   ,@UrlPresentacionArticulo2
		   ,@UrlPresentacionArticulo3
		   ,@UrlPresentacionArticulo4
		   ,@UrlPresentacionArticulo5
		   ,@UrlPresentacionArticulo6
		   ,@UrlPresentacionArticulo7
		   ,@UrlPresentacionArticulo8
		   ,@UrlPresentacionArticulo9
		   ,@UrlPresentacionArticulo10
		   ,@SegundoAutoplayFotorama)
GO

CREATE PROCEDURE BannerPrincipalUpdate
	@BigBanner1 AS  nvarchar(50)
	,@BigBanner2 AS  nvarchar(50)
	,@BigBanner3 AS  nvarchar(50)
	,@BigBanner4 AS  nvarchar(50)
	,@BigBanner5 AS  nvarchar(50)
	,@SmallBanner1 AS  nvarchar(50)
	,@SmallBanner2 AS  nvarchar(50)
	,@SmallBanner3 AS  nvarchar(50)
	,@SmallBanner4 AS  nvarchar(50)
	,@SmallBanner5 AS  nvarchar(50)
	,@VideoDataSource  AS  nvarchar(30)
	,@VideoDataId AS NVARCHAR(50)
	,@VideoImagenMiniatura AS NVARCHAR(50)
	,@UrlPresentacionArticulo1 AS NVARCHAR(500)
	,@UrlPresentacionArticulo2 AS NVARCHAR(500)
	,@UrlPresentacionArticulo3 AS NVARCHAR(500)
	,@UrlPresentacionArticulo4 AS NVARCHAR(500)
	,@UrlPresentacionArticulo5 AS NVARCHAR(500)
	,@UrlPresentacionArticulo6 AS NVARCHAR(500)
	,@UrlPresentacionArticulo7 AS NVARCHAR(500)
	,@UrlPresentacionArticulo8 AS NVARCHAR(500)
	,@UrlPresentacionArticulo9 AS NVARCHAR(500)
	,@UrlPresentacionArticulo10 AS NVARCHAR(500)
	,@SegundoAutoplayFotorama AS INT
AS
UPDATE [dbo].[BannerPrincipal]
   SET [BigBanner1] = @BigBanner1
      ,[BigBanner2] = @BigBanner2
      ,[BigBanner3] = @BigBanner3
      ,[BigBanner4] = @BigBanner4
      ,[BigBanner5] = @BigBanner5
      ,[SmallBanner1] = @SmallBanner1
      ,[SmallBanner2] = @SmallBanner2
      ,[SmallBanner3] = @SmallBanner3
      ,[SmallBanner4] = @SmallBanner4
      ,[SmallBanner5] = @SmallBanner5
      ,[VideoDataSource] = @VideoDataSource
      ,[VideoDataId] = @VideoDataId
      ,[VideoImagenMiniatura] = @VideoImagenMiniatura
	  ,[UrlPresentacionArticulo1] = @UrlPresentacionArticulo1
	  ,[UrlPresentacionArticulo2] = @UrlPresentacionArticulo2
	  ,[UrlPresentacionArticulo3] = @UrlPresentacionArticulo3
	  ,[UrlPresentacionArticulo4] = @UrlPresentacionArticulo4
	  ,[UrlPresentacionArticulo5] = @UrlPresentacionArticulo5
	  ,[UrlPresentacionArticulo6] = @UrlPresentacionArticulo6
	  ,[UrlPresentacionArticulo7] = @UrlPresentacionArticulo7
	  ,[UrlPresentacionArticulo8] = @UrlPresentacionArticulo8
	  ,[UrlPresentacionArticulo9] = @UrlPresentacionArticulo9
	  ,[UrlPresentacionArticulo10] = @UrlPresentacionArticulo10
	  ,[SegundoAutoplayFotorama] = @SegundoAutoplayFotorama
GO

CREATE PROCEDURE BannerPrincipalSelect
AS
SELECT TOP 1
		[BigBanner1]
		,[BigBanner2]
		,[BigBanner3]
		,[BigBanner4]
		,[BigBanner5]
		,[SmallBanner1]
		,[SmallBanner2]
		,[SmallBanner3]
		,[SmallBanner4]
		,[SmallBanner5]
		,[VideoDataSource]
		,[VideoDataId]
		,[VideoImagenMiniatura]
		,[UrlPresentacionArticulo1]
		,[UrlPresentacionArticulo2]
		,[UrlPresentacionArticulo3]
		,[UrlPresentacionArticulo4]
		,[UrlPresentacionArticulo5]
		,[UrlPresentacionArticulo6]
		,[UrlPresentacionArticulo7]
		,[UrlPresentacionArticulo8]
		,[UrlPresentacionArticulo9]
		,[UrlPresentacionArticulo10]
		,[SegundoAutoplayFotorama]
  FROM [dbo].[BannerPrincipal]
GO
