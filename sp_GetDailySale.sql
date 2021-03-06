USE [SPEEDYSOL]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailySales_Report]    Script Date: 7/22/2018 4:38:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetDailySales_Report] 
	-- Add the parameters for the stored procedure here
	@DsrNumber nvarchar(MAX)
AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;
	--Select @DsrNumber
    -- Insert statements for procedure here
	Declare @DailySale Table (ItemID bigint,ItemName varchar(Max),IssuedCtn int,IssuedPcs int,IssuedKgs float,ReturnedCtns int,ReturnedPcs int,ReturnedKgs float,DamagedCtns int,DamagedPcs int,DamagedKgs float,ItemNetValue float,ItemCtnSize int,SalesMan varchar(MAX),DSRDate date)

	Insert into @DailySale (ItemID,ItemName,IssuedCtn,IssuedPcs,IssuedKgs,ItemNetValue,ItemCtnSize,SalesMan,DSRDate) select
	i.sysSerial,
	i.Name,
	SUM(sdci.CTN),
	SUM(sdci.PC),
	(SUM((Cast(i.UnitWeight as float)/Cast(1000 as float))*((i.CTNSize*sdci.CTN)+sdci.PC))),
	MAX(i.SalePrice),
	MAX(i.CTNSize),
	s.Name,
	MAX(ds.CreatedOn)
	from DailySales ds
	inner join SalesDeliveryChallan sdc on ds.sysSerial = sdc.DSRNumber 
	inner join SalesDeliveryChallanItems sdci on sdc.sysSerial = sdci.DCID
	inner join Items i on sdci.ItemID = i.sysSerial
	inner join Salesman s on s.sysSerial = ds.SalesManID 
	where ds.DSRNumber = @DsrNumber group by i.Name,i.sysSerial,s.Name

	Insert into @DailySale (ItemID,ItemName,ReturnedCtns,ReturnedPcs,ReturnedKgs,SalesMan) select
	i.sysSerial,
	i.Name,
	SUM(srci.CTN),
	SUM(srci.PC),
	(SUM((Cast(i.UnitWeight as float)/Cast(1000 as float))*((i.CTNSize*srci.CTN)+srci.PC))),
	s.Name
	from DailySales ds
	inner join SalesReturnChallan src on ds.sysSerial = src.DSRNumber 
	inner join SalesReturnChallanItems srci on src.sysSerial = srci.RCID
	inner join Items i on srci.ItemID = i.sysSerial
	inner join Salesman s on s.sysSerial = ds.SalesManID  
	where ds.DSRNumber = @DsrNumber group by i.Name,i.sysSerial,s.Name

	Insert into @DailySale (ItemID,ItemName,DamagedCtns,DamagedPcs,DamagedKgs,SalesMan) select
	i.sysSerial,
	i.Name,
	SUM(sdci.CTN),
	SUM(sdci.PC),
	(SUM((Cast(i.UnitWeight as float)/Cast(1000 as float))*((i.CTNSize*sdci.CTN)+sdci.PC))),
	s.Name
	from DailySales ds
	inner join SalesDamageChallan sdc on ds.sysSerial = sdc.DSRNumber 
	inner join SalesDamageChallanItems sdci on sdc.sysSerial = sdci.DamCID
	inner join Items i on sdci.ItemID = i.sysSerial
	inner join Salesman s on s.sysSerial = ds.SalesManID 
	where ds.DSRNumber = @DsrNumber group by i.Name,i.sysSerial,s.Name


	Select ItemId,ItemName,MAX(IssuedCtn) IssuedCtns,MAX(IssuedPcs) IssuedPcs,MAX(IssuedKgs)IssuedKgs,MAX(ReturnedCtns)ReturnedCtns,MAX(ReturnedPcs)ReturnedPcs,MAX(ReturnedKgs)ReturnedKgs,MAX(DamagedCtns)DamagedCtns,MAX(DamagedPcs)DamagedPcs,MAX(DamagedKgs)DamagedKgs,MAX(ItemNetValue) ItemNetValue,MAX(ItemCtnSize) ItemCtnSize,SalesMan,MAX(DSRDate) DSRDate from @DailySale group by ItemID,ItemName,SalesMan

