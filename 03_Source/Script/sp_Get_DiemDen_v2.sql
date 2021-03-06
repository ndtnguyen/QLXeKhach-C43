drop procedure sp_Get_DiemDen_v2
go
create procedure sp_Get_DiemDen_v2(
				@maDiemDi varchar(10),
				@maTramLen int,
				@maTramXuong int
				)
as 
begin
	select distinct tt.MaTT
		  ,tt.TenTT
	from TUYENXE tx
	inner join
	(
	select lt.MaTuyen
	from LOTRINH lt
	where lt.MaTram=@maTramLen and lt.isDeleted!=1
	INTERSECT
	select lt2.MaTuyen
	from LOTRINH lt2
	where lt2.MaTram=@maTramXuong and lt2.isDeleted!=1) dsT
	on tx.MaTuyen=dsT.MaTuyen
	inner join TINHTHANH tt
	on tx.DiemDi=@maDiemDi and tx.DiemDen=tt.MaTT
	where tx.isDeleted!=1
	and tt.isDeleted!=1
end

go
exec sp_Get_DiemDen_v2 2,10001,10002