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
		(select DATEADD(minute,lt.KhoangThoiGian,cx.NgayKH) as GioLenXe
		from CHUYENXE cx
		where cx.MaChuyen=@machuyen) as GioLenXe
	from TUYENXE tx
	left join LOTRINH lt
	on tx.MaTuyen=lt.MaTuyen
	where  tx.DiemDi=@maDiemDi
		and tx.DiemDen=@maDiemDen
		and lt.MaTram=@maTramLen
end
go
