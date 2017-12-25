drop procedure sp_Get_DiemDen
go
create procedure sp_Get_DiemDen(
		@maDiemDi varchar(10)
)
as
begin 
		select tt.MaTT
			  ,tt.TenTT
		from TUYENXE tx
		left join TINHTHANH tt
		on tx.DiemDen=tt.MaTT
		where tx.DiemDi=@maDiemDi
			 and tt.isDeleted!=1
			 and tx.isDeleted!=1
end
