drop procedure sp_GetTramLen
go
create procedure sp_GetTramLen(
		@maDiemDi varchar(10),
		@maDiemDen varchar(10)
		)
as
begin
	select t.MaTram
		  ,t.TenTram
		  ,lt.ThuTu
	from TUYENXE tx
	inner join LOTRINH lt
	on tx.MaTuyen=lt.MaTuyen
	inner join TRAMXE t
	on lt.MaTram=t.MaTram
	where  tx.DiemDi=@maDiemDi
		and tx.DiemDen=@maDiemDen
end
go
