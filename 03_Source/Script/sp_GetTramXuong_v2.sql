drop procedure sp_GetTramXuong_v2
go
create procedure sp_GetTramXuong_v2(
		@maTramLen int
		) 
as
begin
	select distinct t.MaTram 
		  ,(t.TenTram + ': ' + t.DiaChi) as TenTram
	from  LoTrinh lt
	inner join
	(select lt2.MaTuyen,lt2.ThuTu
	from LOTRINH lt2
	where lt2.MaTram=@maTramLen
		 and lt2.isDeleted!=1
	)dsTL
	on lt.MaTuyen=dsTL.MaTuyen
	inner join TRAMXE t
	on lt.MaTram=t.MaTram
	where lt.ThuTu>dsTL.ThuTu
	and lt.isDeleted!=1
	and t.isDeleted!=1
end

go
exec sp_GetTramXuong_v2 10003