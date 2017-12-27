drop procedure sp_GetGioLenXe
go
create procedure sp_GetGioLenXe(
		@maDiemDi varchar(10),
		@maDiemDen varchar(10),
		@machuyen int,
		@maTramLen int
		)
as
begin
	select 
		(select convert(varchar, DATEADD(minute,lt.KhoangThoiGian,cx.NgayKH),22)
		from CHUYENXE cx
		where cx.MaChuyen=@machuyen) as GioLenXe
	from TUYENXE tx
	left join LOTRINH lt
	on tx.MaTuyen=lt.MaTuyen
	where  tx.DiemDi=@maDiemDi
		and tx.DiemDen=@maDiemDen
		and lt.MaTram=@maTramLen
		and tx.isDeleted !=1
		and lt.isDeleted!=1
end
go
exec sp_GetGioLenXe 1,4,10000,10001
