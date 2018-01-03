drop procedure sp_ve_info
go
create procedure sp_ve_info(
		@mave int
		)
as
begin
select v.MaVe
		,v.NgayMua
		,v.GiaMua
		,v.MaGhe
		,v.GioDi
		,kh.TenKH
		,kh.SDT
		,kh.DiaChi
		,kh.Email
		,kh.CMND
		,tx1.TenTram + '(' +tx1.DiaChi+ ')' as TramLen
		,tx2.TenTram + '(' +tx2.DiaChi+ ')' as TramXuong
		,x.BienSoXe
		,lx.TenLoai
from VE v
left join TRAMXE tx1
on v.TramLen=tx1.MaTram
left join TRAMXE tx2
on v.TramXuong=tx2.MaTram
left join XE x
on v.MaXe=x.MaXe
left join LOAIXE lx
on x.LoaiXe=lx.MaLoai
left join KHACHHANG kh
on v.MaKH=kh.MaKH
where v.MaVe=@mave and v.isDeleted!=1
end
go
exec sp_ve_info 10001