drop view vw_ve
go
create view vw_ve as
select v.MaVe
		,v.NgayMua
		,v.GiaMua
		,v.MaGhe
		,v.GioDi
		,kh.TenKH
		,kh.SDT
		,tx1.TenTram as TramLen
		,tx2.TenTram as TramXuong
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
where v.isDeleted!=1