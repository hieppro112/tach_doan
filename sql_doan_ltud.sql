create database quanly_cuahang_dienmay

use quanly_cuahang_dienmay


--Phan Hiep Dep trai

CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY, -- Mã tài khoản tự động tăng
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE, -- Tên đăng nhập duy nhất
    MatKhau NVARCHAR(100) NOT NULL,           -- Mật khẩu
    HoTen nvarchar(100),                      -- Họ tên người dùng
    Email NVARCHAR(100),                      -- Email liên hệ
    VaiTro NVARCHAR(50) DEFAULT 'User',       -- Vai trò (Admin/User...)
    NgayTao DATETIME DEFAULT GETDATE()        -- Ngày tạo tài khoản
);
drop table TaiKhoan

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, VaiTro)
VALUES
('admin', 'hashed_password_123', N'Quản Trị Viên', 'admin@domain.com', 'Admin'),
('user1', 'hashed_password_456', N'Người Dùng 1', 'user1@domain.com', 'User'),
('user2', 'hashed_password_789', N'Người Dùng 2', 'user2@domain.com', 'User'),
('user3', '123', 'Lê Đại Hiệp', N'user2@domain.com', 'User');

select * from TaiKhoan

create proc dangnhap_taikhoan(@user nvarchar(50), @pass nvarchar(100))

create proc tp_xemTaiKhoan
as 
Select * From TaiKhoan

exec tp_xemTaiKhoan


create proc tp_get_vaitro(@user nvarchar(50))
as
select VaiTro from TaiKhoan
where TenDangNhap = @user

drop proc tp_get_vaitro

create procedure tp_getvaitro
@user nvarchar(50)
as
begin 
	select VaiTro from TaiKhoan
	where TenDangNhap = @user
	end

	exec tp_getvaitro'hieppro1'

--start stored seach tai khoan

create proc seach_user(@user nvarchar(50))
as
select * from TaiKhoan 
where TenDangNhap = @user

create proc seach_maTK(@maTK int)
as
select * from TaiKhoan 
where MaTaiKhoan = @maTK



create proc seach_name(@name nvarchar(100))
as
select * from TaiKhoan 
where HoTen = @name

create proc seach_email(@email nvarchar(100))
as
select * from TaiKhoan 
where Email = @email

create proc seach_vaitro(@vaitro nvarchar(50))
as
select * from TaiKhoan 
where VaiTro = @vaitro



exec seach_user'hieppro1'
exec seach_maTK '1'
exec seach_name 'le dai hiep'
exec seach_email 'lehiep08052005@gmail.com'
exec seach_vaitro 'User'

--end seach store taikhoan

--Store Dang Ky
create proc tp_ThemTaiKhoan(@tenDangNhap nvarchar(50), @matKhau nvarchar(100),@hoTen nvarchar(100),@email nvarchar(100), @vaiTro nvarchar(50), @ngayTao datetime)
as 
insert into TaiKhoan values (@tenDangNhap, @matKhau ,@hoTen,@email,@vaiTro,@ngayTao)


exec tp_ThemTaiKhoan 'dongpham','123',N'Phạm Đình Phương Đông','dong12062004@gmail.com','Tro vien','12/12/2020'

create proc tp_XoaTaiKhoan(@tenDangNhap nvarchar(50))
as
delete TaiKhoan
where TenDangNhap = @tenDangNhap

exec tp_XoaTaiKhoan 'dongpham'

create proc tp_SuaTaiKhoan(@tenDangNhap nvarchar(50), @matKhauNew nvarchar(100),@hoTenNew nvarchar(100),@emailNew nvarchar(100), @vaiTroNew nvarchar(50), @ngayTaoNew datetime)
as
update TaiKhoan
set MatKhau = @matKhauNew,
    HoTen = @hoTenNew,
	Email = @emailNew,
	VaiTro = @vaiTroNew,
	NgayTao = @ngayTaoNew
where TenDangNhap = @tenDangNhap

exec tp_SuaTaiKhoan 'dongpham','456','Pham Dinh Phuong','23211TT3228@mail.tdc.edu.vn','Giang vien','11/25/2024'


--ket thuc phan cua hiep


--phan san pham cua thuan

	create table SanPham(
		MaNhapHang INT IDENTITY(1,1) PRIMARY KEY, 
		MaSanPham nvarchar(50) not null,
		TenSanPham NVARCHAR(50) NOT NULL UNIQUE,
		NgayNhap DATETIME DEFAULT GETDATE(),
		SoLuong int not null,
		DonGia decimal(18,2) not null,
		ThanhTien decimal(18,2) not null,
		DanhMuc nvarchar(100)
	);

	
INSERT INTO SanPham (MaSanPham, TenSanPham, SoLuong, DonGia, ThanhTien, DanhMuc)
VALUES 
('SP001', 'Tủ Lạnh Samsung', 10, 15000000, 150000000, 'Điện Lạnh'),
('SP002', 'Máy Giặt LG', 5, 10000000, 50000000, 'Gia Dụng'),
('SP003', 'Điều Hòa Panasonic', 8, 12000000, 96000000, 'Điện Lạnh'),
('SP004', 'Lò Vi Sóng Sharp', 7, 3000000, 21000000, 'Gia Dụng'),
('SP005', 'Smart TV Sony', 4, 20000000, 80000000, 'Điện Tử');

select * SanPham
	
	create proc tp_xemkho
as
select * from Sanpham

exec tp_xemkho


create proc tp_xem_cuahang
as
select *
from CuaHang

exec tp_xem_cuahang


CREATE PROC tp_ThemSanPham
    @MaSanPham NVARCHAR(50),
    @TenSanPham NVARCHAR(50), 
    @SoLuong INT,
    @DonGia DECIMAL(18, 2),
    @ThanhTien DECIMAL(18, 2),
    @DanhMuc NVARCHAR(100)
AS
BEGIN
    -- Chèn dữ liệu vào bảng SanPham
    INSERT INTO SanPham (MaSanPham, TenSanPham, SoLuong, DonGia, ThanhTien, DanhMuc)
    VALUES (@MaSanPham, @TenSanPham,  @SoLuong, @DonGia, @ThanhTien, @DanhMuc);
END;

exec tp_ThemSanPham
create proc tp_XoaSanPham(@MaSanPham nvarchar(50))
as
begin
delete SanPham
where MaSanPham = @MaSanPham
end;


CREATE PROCEDURE tp_SuaSanPham
    @MaSanPham NVARCHAR(50),
    @TenSanPham NVARCHAR(255),
    @SoLuong INT,
    @DonGia DECIMAL(18, 2),
    @ThanhTien DECIMAL(18, 2),
    @DanhMuc NVARCHAR(255)
AS
BEGIN
    -- Cập nhật thông tin sản phẩm trong bảng
    UPDATE SanPham
    SET
        TenSanPham = @TenSanPham,
        SoLuong = @SoLuong,
        DonGia = @DonGia,
        ThanhTien = @ThanhTien,
        DanhMuc = @DanhMuc
    WHERE MaSanPham = @MaSanPham;
end;

-- store seach san pham
create proc sp_timKiem_DanhMuc(@DanhMuc nvarchar (100))
as
begin
select * from SanPham
where DanhMuc = @DanhMuc
end;

create proc sp_timKiem_MaSanPham (@MaSanPham nvarchar(50))
as
begin
select * from SanPham
where MaSanPham = @MaSanPham
end;

create proc sp_timKiem_TenSP
@tenSanPham nvarchar (100)
as
begin
select * from SanPham
where TenSanPham like '%' + @tenSanPham +'%';
end;



--ket thuc phan san pham cua thuan


--phan cua hang cua dong


	CREATE TABLE CuaHang (
		MaCuaHang INT IDENTITY(1,1) PRIMARY KEY,  -- Mã cửa hàng tự động tăng
		TenCuaHang NVARCHAR(100) NOT NULL,        -- Tên cửa hàng
		DiaChi NVARCHAR(200) NOT NULL,            -- Địa chỉ cửa hàng
		SoDienThoai NVARCHAR(15) NOT NULL         -- Số điện thoại liên hệ
	);



	INSERT INTO CuaHang (TenCuaHang, DiaChi, SoDienThoai)
	VALUES 
	('Cửa Hàng Điện Máy Xanh', '123 Đường Lê Lợi, Quận 1, TP.HCM', '0901234567'),
	('Cửa Hàng Nguyễn Kim', '456 Đường Hoàng Văn Thụ, Quận Tân Bình, TP.HCM', '0912345678'),
	('Cửa Hàng Điện Máy Chợ Lớn', '789 Đường 3 Tháng 2, Quận 10, TP.HCM', '0987654321'),
	('Cửa Hàng MediaMart', '101 Đường Phạm Hùng, Hà Nội', '0923456789'),
	('Cửa Hàng Pico', '303 Đường Nguyễn Trãi, Hà Nội', '0934567890');

	-- sql hóa đơn xuất

	ALTER TABLE SanPham
ADD CONSTRAINT UQ_MaSanPham UNIQUE (MaSanPham);

	CREATE TABLE HDXuatHang (
    MaHoaDon NVARCHAR(50) PRIMARY KEY,           -- Mã hóa đơn, người dùng nhập
    MaSanPham NVARCHAR(50) NOT NULL,             -- Mã sản phẩm xuất bán
    MaCuaHang INT NOT NULL,                      -- Mã cửa hàng xuất hàng
    MaNhanVien INT NOT NULL,                     -- Mã nhân viên xuất hàng
    SoLuong INT NOT NULL,                        -- Số lượng sản phẩm xuất bán
    NgayXuat DATETIME DEFAULT GETDATE(),        -- Ngày xuất hàng
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham),  -- Liên kết với bảng SanPham
    FOREIGN KEY (MaCuaHang) REFERENCES CuaHang(MaCuaHang),  -- Liên kết với bảng CuaHang
    FOREIGN KEY (MaNhanVien) REFERENCES TaiKhoan(MaTaiKhoan) -- Liên kết với bảng TaiKhoan
	);


	-- hóa đơn
	create proc them_HDxuat(@mahd nvarchar(50) , @masp nvarchar(50), @mach int , @manv int, @soluong int ,@ngayxuat datetime)
	as
	insert into HDXuatHang values (@mahd,@masp,@mach,@manv,@soluong,@ngayxuat)

	create proc xoa_HDxuat(@mahd nvarchar(50))
	as
	delete HDXuatHang
	where MaHoaDon = @mahd

	create proc xem_HDxuat
	as
	select *
	from HDXuatHang

	create proc tp_xemHD
	as
	select *
	from HDXuatHang

	exec tp_xemHD
	exec xoa_HDxuat 'hd1'
	exec them_HDxuat 'hd2','SP002','1','4','12','2/5/2024'
	select * from HDXuatHang

	




