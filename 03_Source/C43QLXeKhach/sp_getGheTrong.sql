drop procedure sp_getGheTrong
go
create procedure sp_getGheTrong(
		@machuyen int
)
as
begin
	select distinct g.MaGhe
	from GHE g
	inner join VE v
	on v.MaXe=g.MaXe
	where v.MaChuyen=@machuyen
	and g.MaGhe not in (select v2.MaGhe
						from VE v2
						where v2.MaChuyen=@machuyen and v.isDeleted!=1)

end
go
exec sp_getGheTrong 10000