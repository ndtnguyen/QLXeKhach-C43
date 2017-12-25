drop procedure sp_GetGioKH
go
create procedure sp_GetGioKH(
		@maDiemDi varchar(10),
		@maDiemDen varchar(10)
		)
as
begin 
	select cx.MaChuyen
			,convert(varchar,cx.NgayKH,22)+'('+lx.TenLoai +')' as GioKH
	from TUYENXE tx
	inner join CHUYENXE cx
	on tx.MaTuyen=cx.MaTuyen
	inner join XE x
	on cx.MaXe=x.MaXe
	inner join LOAIXE lx
	on x.LoaiXe=lx.MaLoai
	where  tx.DiemDi=@maDiemDi
			and tx.DiemDen=@maDiemDen
end
go

