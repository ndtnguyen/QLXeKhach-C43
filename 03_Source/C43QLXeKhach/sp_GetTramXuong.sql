
create procedure sp_GetTramXuong(
		@maDiemDi varchar(10),
		@maDiemDen varchar(10),
		@thuTuTramLen int
		)
as
begin
	select t.MaTram
		  ,t.TenTram
	from TUYENXE tx
	left join LOTRINH lt
	on tx.MaTuyen=lt.MaTuyen
	left join TRAMXE t
	on lt.MaTram=t.MaTram
	where  tx.DiemDi=@maDiemDi
		and tx.DiemDen=@maDiemDen
		and lt.ThuTu>@thuTuTramLen
end

