use TheCoffeeHouseCNPM

-- Insert dữ liệu cho table TaiKhoan
insert into TaiKhoan values ('admin', N'Chi Khoa', '1234', 'Admin')
insert into TaiKhoan values ('thu123', N'Thu Thủy', 'qwer', N'Thu Ngân')
insert into TaiKhoan values ('tiendz', N'Minh Tiến', 'zxcv', N'Thu Ngân')
go

-- Insert dữ liệu cho table Ban
insert dbo.Ban (TenBan) values (N'Bàn 1')
insert dbo.Ban (TenBan) values (N'Bàn 2')
insert dbo.Ban (TenBan) values (N'Bàn 3')
insert dbo.Ban (TenBan) values (N'Bàn 4')
insert dbo.Ban (TenBan) values (N'Bàn 5')
insert dbo.Ban (TenBan) values (N'Bàn 6')
insert dbo.Ban (TenBan) values (N'Bàn 7')
insert dbo.Ban (TenBan) values (N'Bàn 8')
insert dbo.Ban (TenBan) values (N'Bàn 9')
insert dbo.Ban (TenBan) values (N'Bàn 10')
go

-- Insert dữ liệu cho table DanhMuc
insert DanhMuc (TenDM) values (N'Cà phê')
insert DanhMuc (TenDM) values (N'Trà')
insert DanhMuc (TenDM) values (N'Hi-Tea Healthy')
insert DanhMuc (TenDM) values (N'Bánh và Snack')
go

-- Insert dữ liệu cho table MonAn
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Cà phê sữa đá', 1, 29000)
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Cà phê sữa nóng', 1, 39000)
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Bạc Sỉu', 1, 29000)

insert MonAn (TenMon, idDM, GiaMonAn) values (N'Trà Lài Thơm', 2, 69000)
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Trà Hạt Sen - Đá', 2, 49000)

insert MonAn (TenMon, idDM, GiaMonAn) values (N'Hi-Tea Đào', 3, 49000)
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Hi-Tea Thơm', 3, 72000)
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Hi-Tea Đá Tuyết Yuzu Vải', 3, 69000)

insert MonAn (TenMon, idDM, GiaMonAn) values (N'Bánh Mì Que Pate', 4, 15000)
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Mochi Kem Việt Quất', 4, 19000)
insert MonAn (TenMon, idDM, GiaMonAn) values (N'Mít Sấy', 4, 20000)
go

-- Insert dữ liệu cho table HoaDon
insert HoaDon (ThoiGianVao, ThoiGianRa, idBan, TrangThai) values (GETDATE(), null, 1, 0)
insert HoaDon (ThoiGianVao, ThoiGianRa, idBan, TrangThai) values (GETDATE(), null, 3, 0)
insert HoaDon (ThoiGianVao, ThoiGianRa, idBan, TrangThai) values (GETDATE(), null, 8, 0)
insert HoaDon (ThoiGianVao, ThoiGianRa, idBan, TrangThai) values (GETDATE(), GETDATE(), 3, 1)
insert HoaDon (ThoiGianVao, ThoiGianRa, idBan, TrangThai) values (GETDATE(), null, 4, 0)
go

-- Insert dữ liệu cho table ChiTietHoaDon
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (1, 1, 1)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (1, 4, 1)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (1, 11, 2)

insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (2, 2, 1)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (2, 7, 1)

insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (3, 3, 3)

insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (4, 5, 2)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (4, 8, 1)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (4, 1, 1)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (4, 10, 2)

insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (5, 4, 2)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (5, 5, 1)
insert ChiTietHoaDon (idHoaDon, idMonAn, SoLuong) values (5, 9, 3)
go