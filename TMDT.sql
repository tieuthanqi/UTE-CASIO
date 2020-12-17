Create DATABASE DONGHOCASIO

use DONGHOCASIO

--Tạo bảng Loại Sản Phẩm
Create table LoaiSanPham
(	MaLoai varchar(10) PRIMARY KEY,
	TinhTrang Nvarchar(30)
)
Insert into LoaiSanPham(MaLoai) values('G-SHOCK')
Insert into LoaiSanPham(MaLoai) values('BABY-G')

--Tạo bảng Sản Phẩm
Create table SanPham
(	MaSP varchar(30) Primary Key,
	Gia money not null,
	NgayThem date,
	SoLuongKho int,
	SoLuongBan int,
	MaLoai varchar(10) references LoaiSanPham(MaLoai),
	Hinh char(200),
	TinhNang Ntext,
	MoTa Ntext
)
Alter table SanPham Add Constraint default_SL Default(0) for SoLuongBan
Alter table SanPham Add Constraint default_SL Default(getdate()) for NgayThem

Insert into SanPham(MaSP, Gia, NgayThem, SoLuongKho, MaLoai) values ('G-SHOCK GST-B300WLP-1A', 12103000, '2020-12-5', 200, 'G-SHOCK')
Insert into SanPham(MaSP, Gia, NgayThem, SoLuongKho, MaLoai) values ('G-SHOCK DW-5600WM-5', 3220000, '2020-12-5', 200, 'G-SHOCK')
Insert into SanPham(MaSP, Gia, NgayThem, SoLuongKho, MaLoai) values ('G-SHOCK GA-110SGG-3A', 5523000, '2020-12-5', 200, 'G-SHOCK')

Insert into SanPham(MaSP, Gia, NgayThem, SoLuongKho, MaLoai) values ('BABY-G BGD-560WM-5', 2773000, '2020-12-5', 200, 'BABY-G')
Insert into SanPham(MaSP, Gia, NgayThem, SoLuongKho, MaLoai) values ('BABY-G LOV-20A-7A', 8155000, '2020-12-5', 200, 'BABY-G')
Insert into SanPham(MaSP, Gia, NgayThem, SoLuongKho, MaLoai) values ('BABY-G LOV-20B-4', 5687000, '2020-12-5', 200, 'BABY-G')

--Tạo bảng Khuyến Mãi
Create table KhuyenMai
(
	MaKM int identity Primary key,
	ThoiGianBD date,
	ThoiGianKT date
)

--Tạo bảng Chi Tiết Khuyến Mãi
Create table CTKM
(
	ID int identity Primary key,
	MaKM int references KhuyenMai(MaKM) ON DELETE SET NULL ON UPDATE CASCADE,
	MaSP varchar(30) references SanPham(MaSP) ON DELETE SET NULL ON UPDATE CASCADE,
	PhanTram int default 0
)
--Tạo bảng Đơn Hàng
Create table DonHang 
(
	MaDH int identity Primary key,
	NgayMua date,
	TongTien money,
	DiaChi nvarchar(100),
	SDT nvarchar(10) not null unique,
	Email nvarchar(50),
	TrangThai nvarchar(20)
)

--Tạo bảng Chi Tiết Đơn Hàng
Create table ChiTietDonHang
(
	ID int identity Primary key,
	MaDH int references DonHang(MaDH) ON DELETE SET NULL ON UPDATE CASCADE,
	MaSP varchar(30) references SanPham(MaSP) ON DELETE SET NULL ON UPDATE CASCADE,
	SoLuong int not null,
	Gia money not null,
)

-- Tạo bảng Người Dùng
Create table Uses
(
	UserID int identity primary key,
	UserName nvarchar(30) not null,
	[Password] nvarchar(30) not null,
	Email nvarchar(50),
	SDT char(10),
	Avatar char(200),
	Allowed int default (0)
)
