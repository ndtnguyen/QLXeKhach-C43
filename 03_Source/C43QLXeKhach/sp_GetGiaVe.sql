drop procedure sp_GetGiaVe
go
create procedure sp_GetGiaVe(
		@maTramLen int,
		@maTramXuong int,
		@machuyen int
		)
as
begin
	select g.GiaCoBan
	from GIACOBAN g
	where g.MaTT1 like(select tx.MaTT
				  from TRAMXE tx
				  where tx.MaTram=@maTramLen
				  )
		  and g.MaTT2 like (select tx2.MaTT
				  from TRAMXE tx2
				  where tx2.MaTram=@maTramXuong
				  )
		  and g.MaLoai=(select x.LoaiXe
						from CHUYENXE cx
						left join XE x
						on cx.MaXe=x.MaXe
						where cx.MaChuyen=@machuyen
					)
end
go
