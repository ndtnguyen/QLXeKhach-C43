drop procedure sp_Get_Ve_Detail
go
create procedure sp_Get_Ve_Detail(
			@maVe int)
as
begin
	select v.MaVe
		   ,v.MaChuyen
		   ,v.MaGhe
		   ,v.MaXe
		   ,convert(varchar, v.GioDi,22 ) as GioDi
		   ,v.GiaMua
		   ,v.TramLen
		   ,v.TramXuong
		   ,tx.DiemDi
		   ,tx.DiemDen
	from VE v
	inner join CHUYENXE cx
	on v.MaChuyen=cx.MaChuyen
	inner join TUYENXE tx
	on cx.MaTuyen=tx.MaTuyen
	where v.MaVe=@maVe
end
go
exec sp_Get_Ve_Detail 10001