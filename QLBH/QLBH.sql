USE QLBH;

-- Xóa dữ liệu các bảng cũ (Nếu có)
DELETE FROM HoaDon_ChiTiet;
DELETE FROM HoaDon;
DELETE FROM SanPham;
DELETE FROM HangSanXuat;
DELETE FROM LoaiSanPham;
DELETE FROM NhanVien;
DELETE FROM KhachHang;

-- Reset identity
IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = 'HoaDon_ChiTiet' AND last_value IS NOT NULL)
	DBCC CHECKIDENT('HoaDon_ChiTiet', RESEED, 0);

IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = 'HoaDon' AND last_value IS NOT NULL)
	DBCC CHECKIDENT('HoaDon', RESEED, 0);

IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = 'SanPham' AND last_value IS NOT NULL)
	DBCC CHECKIDENT('SanPham', RESEED, 0);

IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = 'HangSanXuat' AND last_value IS NOT NULL)
	DBCC CHECKIDENT('HangSanXuat', RESEED, 0);

IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = 'LoaiSanPham' AND last_value IS NOT NULL)
	DBCC CHECKIDENT('LoaiSanPham', RESEED, 0);

IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = 'NhanVien' AND last_value IS NOT NULL)
	DBCC CHECKIDENT('NhanVien', RESEED, 0);
	
IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = 'KhachHang' AND last_value IS NOT NULL)
	DBCC CHECKIDENT('KhachHang', RESEED, 0);

SET IDENTITY_INSERT HangSanXuat ON
INSERT INTO HangSanXuat(ID, TenHangSanXuat) VALUES
(1, 'Acer'),
(2, 'Apple'),
(3, 'Asus'),
(4, 'Dell'),
(5, 'HP'),
(6, 'Huawei'),
(7, 'Itel'),
(8, 'Lenovo'),
(9, 'LG'),
(10, 'Masstel'),
(11, 'Mobell'),
(12, 'MSI'),
(13, 'Nokia'),
(14, 'Oneplus'),
(15, 'Oppo'),
(16, 'Realme'),
(17, 'Samsung'),
(18, 'Vivo'),
(19, 'Xiaomi');
SET IDENTITY_INSERT HangSanXuat OFF

INSERT INTO NhanVien(HoVaTen, DienThoai, DiaChi, TenDangNhap, MatKhau, QuyenHan) VALUES
(N'Nguyễn Văn An', '0123456888', 'Long Xuyên', 'admin', '$2a$11$XGOVk9m4HqzXBlwVvhKN/ur8FS/keV9QyuCwikTL67sL0gqNUupMa', 1),
(N'Hoàng Thảo My', '0123456999', 'Châu Thành', 'user', '$2a$11$c1syEtekaZ6OJrX77mGoJ.6mu4YuUjUHvKrliW8oOU3M3u7I6zyuy', 0);

INSERT INTO KhachHang(HoVaTen, DienThoai, DiaChi) VALUES
(N'Lê Thị Kim Yến', '0123456777', 'Chợ Mới'),
(N'Võ Huỳnh Đông', '0123456555', 'Lấp Vò - Đồng Tháp'),
(N'Nguyễn Huỳnh Minh Trí', '0123456444', 'Phú Hòa');

SET IDENTITY_INSERT LoaiSanPham ON
INSERT INTO LoaiSanPham(ID, TenLoai) VALUES
(1, N'Điện thoại'),
(2, N'Máy tính bảng'),
(3, N'Máy tính xách tay');
SET IDENTITY_INSERT LoaiSanPham OFF

INSERT INTO SanPham(LoaiSanPhamID, HangSanXuatID, TenSanPham, DonGia, SoLuong, HinhAnh) VALUES
(1, 2, N'iPhone 15', 22990000, 100, 'iphone-15.jpg'),
(1, 2, N'iPhone 15 Plus', 25990000, 100, 'iphone-15-plus.jpg'),
(1, 2, N'iPhone 15 Pro', 27990000, 100, 'iphone-15-pro.jpg'),
(1, 2, N'iPhone 15 Pro Max', 34990000, 100, 'iphone-15-pro-max.jpg');
