Declare @DsrNumber as int

Set @DsrNumber = 4

Declare @DailySale Table (ItemID bigint,ItemName varchar(Max),IssuedCtn int,IssuedPcs int,IssuedKgs float,ReturnedCtns int,ReturnedPcs int,ReturnedKgs int,DamagedCtns int,DamagedPcs int,DamagedKgs int)

Insert into @DailySale (ItemID,ItemName,IssuedCtn,IssuedPcs,IssuedKgs) select
	i.sysSerial,
	i.Name,
	SUM(sdci.CTN),
	SUM(sdci.PC),
	(SUM((Cast(i.UnitWeight as float)/Cast(1000 as float))*((i.CTNSize*sdci.CTN)+sdci.PC)))
	from DailySales ds
	inner join SalesDeliveryChallan sdc on ds.sysSerial = sdc.DSRNumber 
	inner join SalesDeliveryChallanItems sdci on sdc.sysSerial = sdci.DCID
	inner join Items i on sdci.ItemID = i.sysSerial where ds.sysSerial = @DsrNumber group by i.Name,i.sysSerial

	Insert into @DailySale (ItemID,ItemName,ReturnedCtns,ReturnedPcs,ReturnedKgs) select
	i.sysSerial,
	i.Name,
	SUM(srci.CTN),
	SUM(srci.PC),
	(SUM((Cast(i.UnitWeight as float)/Cast(1000 as float))*((i.CTNSize*srci.CTN)+srci.PC)))
	from DailySales ds
	inner join SalesReturnChallan src on ds.sysSerial = src.DSRNumber 
	inner join SalesReturnChallanItems srci on src.sysSerial = srci.RCID
	inner join Items i on srci.ItemID = i.sysSerial where ds.sysSerial = @DsrNumber group by i.Name,i.sysSerial

	Insert into @DailySale (ItemID,ItemName,DamagedCtns,DamagedPcs,DamagedKgs) select
	i.sysSerial,
	i.Name,
	SUM(sdci.CTN),
	SUM(sdci.PC),
	(SUM((Cast(i.UnitWeight as float)/Cast(1000 as float))*((i.CTNSize*sdci.CTN)+sdci.PC)))
	from DailySales ds
	inner join SalesDamageChallan sdc on ds.sysSerial = sdc.DSRNumber 
	inner join SalesDamageChallanItems sdci on sdc.sysSerial = sdci.DamCID
	inner join Items i on sdci.ItemID = i.sysSerial where ds.sysSerial = @DsrNumber group by i.Name,i.sysSerial


Select ItemId,ItemName,MAX(IssuedCtn) IssuedCtns,MAX(IssuedPcs) IssuedPcs,MAX(IssuedKgs)IssuedKgs,MAX(ReturnedCtns)ReturnedCtns,MAX(ReturnedPcs)ReturnedPcs,MAX(ReturnedKgs)ReturnedKgs,MAX(DamagedCtns)DamagedCtns,MAX(DamagedPcs)DamagedPcs,MAX(DamagedKgs)DamagedKgs from @DailySale group by ItemID,ItemName