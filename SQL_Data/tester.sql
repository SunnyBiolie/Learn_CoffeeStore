select * from ChiTietHoaDon where idHoaDon = 2
select * from HoaDon
select * from MonAn
select * from DanhMuc
select * from Ban

-- Hiển thị cả những hóa đơn đã thanh toán
select fd.TenMon, ctb.SoMon, fd.GiaMonAn, fd.GiaMonAn*ctb.SoMon as ThanhTien from ChiTietHoaDon as ctb, HoaDon as b, MonAn as fd
where ctb.idHoaDon = b.ID and ctb.idMonAn = fd.ID and b.idBan = 3 and b.TrangThai = 0

select max(ID) from HoaDon 

--delete from HoaDon
--where ID = 7 or ID = 6 or ID = 7 or ID = 8
--go
--Xóa món nên sửa id lại
--DBCC CHECKIDENT ('[HoaDon]', RESEED, 6);
--GO

