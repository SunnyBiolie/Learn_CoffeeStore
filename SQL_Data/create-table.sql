create database TheCoffeeHouseCNPM
go

use TheCoffeeHouseCNPM
go

create table TaiKhoan (
	TenDangNhap nvarchar(50) not null primary key,
	TenHienThi nvarchar(50) not null,
	MatKhau nvarchar(1000) not null,
	PhanQuyen nvarchar(20) not null
)
go

create table Ban (
	ID int identity primary key,
	TenBan nvarchar(50) not null,
	TrangThai nvarchar(50) not null default N'Trống',	-- trống, có người, được đặt
)
go

create table DanhMuc (
	ID int identity primary key,
	TenDM nvarchar(50) not null default N'Đang cập nhật',
)
go

create table MonAn (
	ID int identity primary key,
	TenMon nvarchar(50) not null default N'Đang cập nhật',
	idDM int not null,
	GiaMonAn float not null default 0,
)
go

create table HoaDon (
	ID int identity primary key,
	ThoiGianVao Date not null default getDate(),
	ThoiGianRa Date,
	idBan int not null,
	TrangThai int not null default 0,		-- 0 chua thanh toan, 1 da thanh toan
)
go

create table ChiTietHoaDon (
	ID int identity primary key,
	idHoaDon int not null,
	idMonAn int not null,
	SoLuong int not null default 0,
)
go

-- Tạo khóa ngoại cho các bảng
alter table MonAn add foreign key (idDM) references dbo.DanhMuc(ID)

alter table HoaDon add foreign key (idBan) references dbo.Ban(id)

alter table ChiTietHoaDon add foreign key (idHoaDon) references dbo.HoaDon(id)
alter table ChiTietHoaDon add foreign key (idMonAn) references dbo.MonAn(id)
go

-- Tạo store proceduce
create proc USP_GetTableList
as select * from dbo.Ban
go

create proc USP_InsertBill
@idBan int
as
begin
	insert HoaDon (ThoiGianVao, ThoiGianRa, idBan, TrangThai)
	values (GETDATE(), null, @idBan, 0)
end
go

create proc USP_InsertBillInfo
@idHoaDon int, @idMonAn int, @SoLuong int
as
begin
	declare @isExitsBillInfo int
	declare @foodCount int

	select @isExitsBillInfo = ID, @foodCount = SoMon
	from ChiTietHoaDon
	where idHoaDon = @idHoaDon and idMonAn = @idMonAn

	-- Đã tồn tại hóa đơn của bàn
	if (@isExitsBillInfo > 0)
	begin
		declare @newCount int = @foodCount + @SoLuong
		if (@newCount > 0)
			update ChiTietHoaDon set SoMon = @newCount
		else	-- Trường hợp tổng số lượng của món âm -> xóa món
			delete ChiTietHoaDon where idHoaDon = @idHoaDon and idMonAn = @idMonAn
	end
	-- Bàn chưa có hóa đơn chưa thanh toán --Bàn trống
	else
	begin
		insert ChiTietHoaDon (idHoaDon, idMonAn, SoMon) values (@idHoaDon, @idMonAn, @SoLuong)
	end
end
go

-- Tạo Trigger
create trigger UTG_UpdateBillInfo	-- Thêm món
on ChiTietHoaDon for insert, update
as
begin
	declare @idBill int
	declare @idTable int

	select @idBill = idHoaDon from inserted
	select @idTable = idBan from HoaDon where ID = @idBill and TrangThai = 0

	update Ban set TrangThai = N'Có người' where ID = @idTable
end
go

create trigger UTG_UpdateBill	-- Thanh toán
on HoaDon for update
as
begin
	declare @idBill int
	declare @idTable int
	declare @soDongHoaDon int = 0

	select @idBill = ID from inserted
	select @idTable = idBan from HoaDon where ID = @idBill
	select @soDongHoaDon = count(*) from HoaDon where idBan = @idTable and TrangThai = 0

	if (@soDongHoaDon = 0)
		update Ban set TrangThai = N'Trống' where ID = @idTable
end
go



-- Tự thêm
--create table ChietKhau (
--	ID int identity primary key,
--	TenChietKhau nvarchar(100) not null,
--	MucChietKhau float not null default 0,
--	ApDungCho nvarchar(100) not null
--)
--create table NhanVien (
--	ID int identity primary key,
--	HoTen nvarchar(100) not null,
--	Email nvarchar(100),
--	SDT nvarchar(20),
--	TenTaiKhoan nvarchar(50),
--)
--create table DatBan (
--	ID int identity primary key,
--	HoTen nvarchar(100) not null,
--	SDT nvarchar(20) not null,
--	idBan int not null,
--	SoNguoi int not null
--)
--create table Topping (
--	ID int identity primary key,
--	TenTopping nvarchar(100) not null,
--	GiaTopping float not null default 0,
--	ApDungCho nvarchar(1000) not null
--)