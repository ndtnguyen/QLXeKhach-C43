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
end
