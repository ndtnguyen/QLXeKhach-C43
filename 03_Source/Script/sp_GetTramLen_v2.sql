drop procedure sp_GetTramLen_v2
go
create procedure sp_GetTramLen_v2
as
begin
	select t.MaTram
		  ,(t.TenTram + ': ' + t.DiaChi) as TenTram
	from TRAMXE t
	where t.isDeleted!=1
end
go
exec sp_GetTramLen_v2