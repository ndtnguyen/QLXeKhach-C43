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
			and cx.isDeleted!=1
			and tx.isDeleted!=1
			and x.isDeleted!=1
			and lx.isDeleted!=1
end
go

