CREATE DATABASE QLXeKhach;

CREATE TABLE NHANVIEN (
	MaNV int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	TenNV nvarchar (50),
	CMND varchar (12),
	NgaySinh date,
	DiaChi nvarchar (100),
	SDT varchar (12),
	Email varchar (50),
	Password varchar(100),
	TrangThaiTaiKhoan int,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE KHAOSAT (
	MaKS int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	NgayKS date,
	NguoiKS int,
	DiaChiKS nvarchar (100),
	TiLeDonKhach float,
	GiaKS decimal,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO

CREATE TABLE _SESSION (
	MaSession int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	MaNV int,
	LoginTime datetime,
	LogoutTime datetime DEFAULT NULL,
	_Status int,
	
);
GO
CREATE TABLE TINHTHANH (
	MaTT varchar (10) PRIMARY KEY,
	TenTT nvarchar (50),
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE TUYENXE (
	MaTuyen int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	DiemDi varchar (10), -- TINHTHANH đi
	DiemDen varchar (10), -- TINHTHANH đến
	QuangDuong int,
	ThoiGian float,
	SoChuyen1Ngay int,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE LOTRINH (
	MaTuyen int,
	MaTram int,
	ThuTu int,
	KhoangThoiGian int,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int,
	PRIMARY KEY (MaTuyen, MaTram)
);
GO
CREATE TABLE TRAMXE (
	MaTram int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	TenTram nvarchar (50),
	MaTT varchar (10),
	DiaChi nvarchar (50),
	MoTa text DEFAULT NULL,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE HOPDONG (
	MaHD int  NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	NgayLap date,
	GiaThoaThuan decimal,
	MaTram int,
	ThoiHanThue date,
	MaDT int,
	NguoiLap int,
	MoTa text DEFAULT NULL,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE DOITAC (
	MaDT int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	TenDT nvarchar (50),
	NguoiDaiDien nvarchar (50),
	SDT varchar (12),
	DiaChi nvarchar (100),
	Email varchar (50),
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE GIACOBAN (
	MaTT1 varchar (10),
	MaTT2 varchar (10),
	MaLoai int, -- Mã loại xe
	GiaCoBan decimal,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
	PRIMARY KEY (MaTT1, MaTT2, MaLoai)
);
GO
CREATE TABLE LOAIXE (
	MaLoai int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	TenLoai nvarchar (50),
	SLGhe int,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE XE (
	MaXe int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	LoaiXe int,
	BienSoXe varchar (12),
	HangXe nvarchar (20),
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE GHE (
	MaXe int,
	MaGhe int,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
	PRIMARY KEY (MaXe, MaGhe)
);
GO
CREATE TABLE TAIXE (
	MaTX int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	TenTX nvarchar (50),
	CMND varchar (12),
	SDT varchar (12),
	DiaChi nvarchar (100),
	NgaySinh date,
	SoBangLai varchar (12),
	LoaiBangLai varchar (10),
	ThoiHanBangLai date,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE CHUYENXE (
	MaChuyen int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	NgayKH datetime,
	NgayDen datetime,
	MaTuyen int,
	MaXe int,
	MaTX int,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE VE (
	MaVe int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	NgayMua datetime,
	GiaMua decimal,
	MaGhe int,
	MaXe int,
	MaChuyen int,
	MaKH int,
	TramLen int,
	TramXuong int,
	GioDi datetime,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);
GO
CREATE TABLE KHACHHANG (
	MaKH int NOT NULL IDENTITY (10000, 1) PRIMARY KEY,
	TenKH nvarchar (50),
	SDT varchar (12),
	CMND varchar (12),
	DiaChi nvarchar (100) DEFAULT NULL,
	NgaySinh date DEFAULT NULL,
	Email varchar (50) DEFAULT NULL,
	createUser int,
	lastupdateUser int,
	createDate datetime,
	lastupdateDate datetime,
	isDeleted int
);