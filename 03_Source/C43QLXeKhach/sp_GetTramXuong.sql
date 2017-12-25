drop procedure sp_GetTramXuong
go
create procedure sp_GetTramXuong(
		@maDiemDi varchar(10),
		@maDiemDen varchar(10),
		@thuTuTramLen int
		)
as
begin
	select t.MaTram 
		  ,(t.TenTram + ': ' + t.DiaChi) as TenTram
	from TUYENXE tx
	left join LOTRINH lt
	on tx.MaTuyen=lt.MaTuyen
	left join TRAMXE t
	on lt.MaTram=t.MaTram
	where  tx.DiemDi=@maDiemDi
		and tx.DiemDen=@maDiemDen
		and tx.isDeleted !=1
		and lt.ThuTu>@thuTuTramLen
		and lt.isDeleted !=1
		and t.isDeleted!=1
end

