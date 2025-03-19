/* Nội dung:
1
- Sửa bảng btlKhachHang: sửa cột iSDT thành sSDT nvarchar (sửa tên ở Object Explorer rồi chạy code ở dưới)
- Sửa bảng btlNhaCungCap: sửa cột iSoDT thành sSDT nvarchar
- Sửa bảng btlNhanVien: thêm giới tính (có 5 bước ở dưới)
- Sửa bảng btlHoaDon và btlChiTietHoaDon:
	+ Chuyển % giảm giá từ btlChiTietHoaDon sang btlHoaDon
	+ Sửa cột iPhuongThucThanhToan thành sPhuongThucThanhToan

   Sửa xong ae nhớ thêm lại khóa ngoại vì nó mất :))
2
- Thêm khóa ngoại cho btlDonNhapHang
3
- Thêm dữ liệu vào bảng btlNhanVien, btlKhachHang, btlKhuyenMai, btlHoaDon
4
- Tạo v_HoaDon và v_DonNhapHang
*/

-------------------1. Tạo database và bảng----------------------------
create database BTL_HSK

create table btlKhachHang
(
sMaKH nvarchar(50) primary key,
sTenKH nvarchar(50) ,
dNgaySinh date ,
sDiaChi nvarchar(50) , 
sSDT bigint ,
sGioiTinh NVARCHAR(10)
)
alter table btlKhachHang
alter column sSDT nvarchar(10)


drop table btlChiTietHoaDon --1
drop table btlHoaDon --2
drop table btlNhanVien --3
create table btlNhanVien --4
(
sMaNV nvarchar(50) primary key,
sTenNV nvarchar(50),
sCCCD nvarchar(50),
sDiaChi nvarchar(50),
sSDT nvarchar(10) ,
dNgaySinh date,
sGioiTinh nvarchar(3) check(sGioiTinh = N'Nam' or sGioiTinh = N'Nữ'),
dNgayVaoLam date,
sTenDangNhap nvarchar(50),
sMatKhau nvarchar(50)
)
--5. Tạo lại bảng btlHoaDon và btlChiTietHoaDon

create table btlKhuyenMai
(
sMaGiamGia nvarchar(50) primary key,
iPhanTramKhuyenMai bigint
)

-- Thêm cột % giảm giá
drop table btlChiTietHoaDon --1
drop table btlHoaDon --2

create table btlHoaDon --3
(
sMaHD nvarchar(50) primary key,
sMaKH nvarchar(50),
sMaNVLapHoaDon nvarchar(50),
dNgayLap date,
sMaGiamGia nvarchar(50),
fTongTien float,
sPhuongThucThanhToan nvarchar(50),
dNgayDatHang date,
dNgayGiaoHang date,
)

CREATE TABLE btlChiTietHoaDon --4
(
    sMaHD NVARCHAR(50),
    sMaMH NVARCHAR(50),
    sMauSac NVARCHAR(50),
    sSize NVARCHAR(50),
    sTenMatHang NVARCHAR(50),
    fGiaBan FLOAT,
    iSoLuong BIGINT,
    sChatLieu NVARCHAR(50),
);

create table btlLoaiHang
(
sMaLoaiHang nvarchar(50) primary key,
sTenLoaiHang nvarchar(50)
)

CREATE TABLE btlMatHang (
    sMaMH NVARCHAR(50) PRIMARY KEY,
    sMaLoaiHang NVARCHAR(50),
    sTenMH NVARCHAR(50),
    sMaNCC NVARCHAR(50),
    iSoluong INT,
    fGiaHang FLOAT,
    sChatLieu NVARCHAR(50)
);

CREATE TABLE btlChiTietMatHang (
    sMaMH NVARCHAR(50),
    sMauSac NVARCHAR(50),
    sSize NVARCHAR(50),
    iSoLuong INT,
    PRIMARY KEY (sMaMH, sMauSac, sSize),
    FOREIGN KEY (sMaMH) REFERENCES btlMatHang(sMaMH)
);

create table btlDonNhapHang
(
sMaNhapHang nvarchar(50) primary key,
sMaNV nvarchar(50),
dNgayNhapHang DATETIME,
sMaNCC nvarchar(50),
iTongTien bigint
)

CREATE TABLE btlChiTietDonNhapHang (
    sMaNhapHang NVARCHAR(50),
    sMaMH NVARCHAR(50),
    iGiaNhap INT,
    fSoLuongNhap BIGINT,
    PRIMARY KEY (sMaNhapHang, sMaMH),
    FOREIGN KEY (sMaNhapHang) REFERENCES btlDonNhapHang(sMaNhapHang),
    FOREIGN KEY (sMaMH) REFERENCES btlMatHang(sMaMH)
);

create table btlNhaCungCap
(
sMaNCC nvarchar(50) primary key,
sTenNCC nvarchar(50),
sDiaChi nvarchar(50),
sSDT bigint,
sEmail nvarchar(50)
)

alter table btlNhaCungCap
alter column sSDT nvarchar(10)


--------------------2. Thêm khóa ngoại-------------------------
ALTER TABLE btlHoaDon 
ADD CONSTRAINT FK_sMaKH FOREIGN KEY (sMaKH) REFERENCES btlKhachHang(sMaKH),
    CONSTRAINT FK_sMaNV FOREIGN KEY (sMaNVLapHoaDon) REFERENCES btlNhanVien(sMaNV),
    CONSTRAINT FK_sMaGiamGia FOREIGN KEY (sMaGiamGia) REFERENCES btlKhuyenMai(sMaGiamGia);

ALTER TABLE btlChiTietHoaDon 
ADD CONSTRAINT FK_sMaHD FOREIGN KEY (sMaHD) REFERENCES btlHoaDon(sMaHD),
    CONSTRAINT FK_sMaMH FOREIGN KEY (sMaMH, sMauSac, sSize) REFERENCES btlChiTietMatHang(sMaMH, sMauSac, sSize);

ALTER TABLE btlMatHang 
ADD CONSTRAINT FK_sMaLoaiHang FOREIGN KEY (sMaLoaiHang) REFERENCES btlLoaiHang(sMaLoaiHang),
    CONSTRAINT FK_sMaNCC FOREIGN KEY (sMaNCC) REFERENCES btlNhaCungCap(sMaNCC);

-- 17/03/2025
alter table btlDonNhapHang
add constraint FK_sMaNV_DNH foreign key (sMaNV) references btlNhanVien(sMaNV),
	constraint FK_sMaNCC_DNH foreign key (sMaNCC) references btlNhaCungCap(sMaNCC);

-----------------------3. Thêm dữ liệu--------------------------------
INSERT INTO btlLoaiHang (sMaLoaiHang, sTenLoaiHang)
VALUES 
('LH01', N'Áo thun'),
('LH02', N'Quần jean'),
('LH03', N'Giày thể thao');


INSERT INTO btlNhaCungCap (sMaNCC, sTenNCC, sDiaChi, sSDT, sEmail)
VALUES 
('NCC01', N'Công ty Dệt May Hà Nội', N'Hà Nội', 0123456789, 'congtydetmayhn@gmail.com'),
('NCC02', N'Công ty Star Fashion', N'TP. Hồ Chí Minh', 0987654321, 'starfashion@gmail.com');

INSERT INTO btlMatHang (sMaMH, sMaLoaiHang, sTenMH, sMaNCC, iSoluong, fGiaHang, sChatLieu)
VALUES 
('MH01', 'LH01', N'Áo Polo', 'NCC01', 100, 150000, N'Cotton'),
('MH02', 'LH02', N'Quần Jean Skinny', 'NCC01', 200, 300000, N'Denim'),
('MH03', 'LH03', N'Giày Sneaker', 'NCC02', 150, 500000, N'Da tổng hợp');

INSERT INTO btlChiTietMatHang (sMaMH, sMauSac, sSize, iSoLuong)
VALUES 
('MH01', N'Đen', 'M', 30),
('MH01', N'Đen', 'L', 20),
('MH01', N'Trắng', 'M', 25),
('MH02', N'Xanh', 'S', 50),
('MH02', N'Xanh', 'M', 40),
('MH02', N'Đen', 'L', 30),
('MH03', N'Trắng', '40', 30),
('MH03', N'Trắng', '42', 20),
('MH03', N'Đen', '41', 25);

INSERT INTO btlKhachHang (sMaKH, sTenKH, dNgaySinh, sDiaChi, sSDT, sGioiTinh)
VALUES 
('KH01', N'Nguyễn Văn Toản', '1995-06-15', N'Hà Nội', 0123456789, N'Nam'),
('KH02', N'Trần Thị Mai', '2000-10-20', N'Hồ Chí Minh', 0987654321, N'Nữ');

-- 17/3/2025
INSERT INTO btlNhanVien (sMaNV, sTenNV, sCCCD, sDiaChi, sSDT, dNgaySinh, sGioiTinh, dNgayVaoLam, sTenDangNhap, sMatKhau)
VALUES 
('NV01', N'Nguyễn Hữu Tín', '001205050505', N'Hà Nội', 0981101921, '2005-11-11', N'Nam', '2024-05-10', 'tin', '123456'),
('NV02', N'Nguyễn Hữu Thanh', '001205054233', N'Hà Nội', 0948234382, '2005-1-12', N'Nam', '2024-04-10', 'thanh', '123456'),
('NV03', N'Vũ Việt Anh', '001205053293', N'Hà Nội', 0938284373, '2005-4-20', N'Nam', '2024-05-1', 'vietanh', '123456'),
('NV04', N'Trần Khánh Duy', '001205055494', N'Bắc Ninh', 0973204983, '2005-7-21', N'Nam', '2024-11-10', 'duy', '123456'),
('NV05', N'Hoàng Quốc Đạt', '001204322392', N'Hà Nội', 0949483928, '2005-5-1', N'Nam', '2024-1-10', 'dat', '123456');

-- 17/3/2025
INSERT INTO btlKhachHang (sMaKH, sTenKH, dNgaySinh, sDiachi, sSDT, sGioiTinh)
VALUES 
('KH001', N'Nguyễn Minh Quân', '1992-04-12', N'Hà Nội', 0987123456, N'Nam'),
('KH002', N'Lê Hoài An', '1995-09-25', N'Hồ Chí Minh', 0978654321, N'Nữ'),
('KH003', N'Trần Gia Huy', '1988-11-30', N'Đà Nẵng', 0369785214, N'Nam'),
('KH004', N'Phạm Khánh Linh', '2001-06-15', N'Hải Phòng', 0965412378, N'Nữ'),
('KH005', N'Hoàng Bảo Long', '1990-07-20', N'Cần Thơ', 0912983745, N'Nam');

-- 17/3/2025
insert into btlKhuyenMai (sMaGiamGia, iPhanTramKhuyenMai)
values
('MGG01', 10),
('MGG02', 20),
('MGG03', 30),
('MGG04', 40),
('MGG05', 50);

-- 17/3/2025
INSERT INTO btlHoaDon (sMaHD, sMaKH, sMaNVLapHoaDon, dNgayLap, fTongTien, sMaGiamGia, sPhuongThucThanhToan, dNgayDatHang, dNgayGiaoHang)
VALUES 
('HD001', 'KH001', 'NV01', '2025-03-10', 2500000, N'MGG01', N'Chuyển khoản', '2025-03-08', '2025-03-12'),
('HD002', 'KH002', 'NV02', '2025-03-11', 3750000, N'MGG02', N'Tiền mặt', '2025-03-09', '2025-03-13'),
('HD003', 'KH003', 'NV03', '2025-03-12', 1200000, N'MGG03', N'Chuyển khoản', '2025-03-10', '2025-03-14'),
('HD004', 'KH004', 'NV04', '2025-03-13', 5600000, N'MGG04', N'Master Card', '2025-03-11', '2025-03-15'),
('HD005', 'KH005', 'NV05', '2025-03-14', 890000, N'MGG05', N'Visa', '2025-03-12', '2025-03-16');
INSERT INTO btlHoaDon (sMaHD, sMaKH, sMaNVLapHoaDon, dNgayLap, fTongTien, sMaGiamGia, sPhuongThucThanhToan, dNgayDatHang, dNgayGiaoHang)
VALUES 
(N'HD006', N'KH001', N'NV01', '2000-02-29', 1500000, N'MGG01', N'Tiền mặt', '2000-02-25', '2000-03-05'),
(N'HD007', N'KH002', N'NV02', '2004-02-29', 1800000, N'MGG02', N'Chuyển khoản', '2004-02-26', '2004-03-06'),
(N'HD008', N'KH003', N'NV03', '2008-02-29', 2200000, N'MGG03', N'Tiền mặt', '2008-02-20', '2008-03-03'),
(N'HD009', N'KH004', N'NV04', '2012-02-29', 2500000, N'MGG04', N'Chuyển khoản', '2012-02-22', '2012-03-04'),
(N'HD010', N'KH005', N'NV05', '2016-02-29', 1900000, N'MGG05', N'Tiền mặt', '2016-02-23', '2016-03-05');
INSERT INTO btlHoaDon (sMaHD, sMaKH, sMaNVLapHoaDon, dNgayLap, fTongTien, sMaGiamGia, sPhuongThucThanhToan, dNgayDatHang, dNgayGiaoHang)
VALUES 
(N'HD011', N'KH001', N'NV01', '2024-05-31', 2000000, N'MGG01', N'Tiền mặt', '2024-05-25', '2024-06-05'),
(N'HD012', N'KH002', N'NV02', '2024-05-31', 2100000, N'MGG02', N'Chuyển khoản', '2024-05-26', '2024-06-06'),
(N'HD013', N'KH003', N'NV03', '2024-05-31', 2200000, N'MGG03', N'Tiền mặt', '2024-05-27', '2024-06-07'),
(N'HD014', N'KH004', N'NV04', '2024-05-31', 2300000, N'MGG04', N'Chuyển khoản', '2024-05-28', '2024-06-08'),
(N'HD015', N'KH005', N'NV05', '2024-05-31', 2400000, N'MGG05', N'Tiền mặt', '2024-05-29', '2024-06-09');
INSERT INTO btlHoaDon (sMaHD, sMaKH, sMaNVLapHoaDon, dNgayLap, fTongTien, sMaGiamGia, sPhuongThucThanhToan, dNgayDatHang, dNgayGiaoHang)
VALUES 
(N'HD016', N'KH001', N'NV01', '2023-01-10', 2050000, N'MGG01', N'Tiền mặt', '2023-01-05', '2023-01-15'),
(N'HD017', N'KH002', N'NV02', '2023-04-22', 2600000, N'MGG02', N'Chuyển khoản', '2023-04-18', '2023-04-28'),
(N'HD018', N'KH003', N'NV03', '2023-07-14', 1950000, N'MGG03', N'Tiền mặt', '2023-07-10', '2023-07-20'),
(N'HD019', N'KH004', N'NV04', '2023-09-09', 2800000, N'MGG04', N'Chuyển khoản', '2023-09-05', '2023-09-15'),
(N'HD020', N'KH005', N'NV05', '2023-11-28', 3000000, N'MGG05', N'Tiền mặt', '2023-11-23', '2023-12-05');





---------------------------4. View, trigger------------------------------------------
CREATE or alter TRIGGER trg_UpdateSoLuongMatHang
ON btlChiTietMatHang
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật số lượng tổng trong btlMatHang dựa trên tổng số lượng trong btlChiTietMatHang
    UPDATE btlMatHang
    SET iSoluong = (
        SELECT COALESCE(SUM(iSoluong), 0) 
        FROM btlChiTietMatHang 
        WHERE btlChiTietMatHang.sMaMH = btlMatHang.sMaMH
    )
END;

CREATE OR ALTER VIEW v_MatHang_ChiTiet AS
SELECT 
    mh.sMaMH AS "Mã mặt hàng",
    lh.sTenLoaiHang AS "Loại hàng",
    mh.sTenMH AS "Tên sản phẩm",
	ncc.sTenNCC as "Tên nhà cung cấp",
    mh.iSoluong AS "Tổng số lượng",
    mh.fGiaHang AS "Giá hàng",
    mh.sChatLieu AS "Chất liệu"
FROM 
    btlMatHang mh
JOIN 
    btlLoaiHang lh ON mh.sMaLoaiHang = lh.sMaLoaiHang
join
	btlNhaCungCap ncc on mh.sMaNCC = ncc.sMaNCC

create or alter view v_HoaDon -- 17/3/2025
as
select
	hd.sMaHD as "Mã hóa đơn",
	kh.sTenKH as "Tên khách hàng",
	nv.sTenNV as "Người lập",
	hd.dNgayLap as "Ngày lập",
	hd.fTongTien as "Tổng tiền",
	km.iPhanTramKhuyenMai as "Phần trăm giảm giá",
	hd.sPhuongThucThanhToan as "Phương thức thanh toán",
	hd.dNgayDatHang as "Ngày đặt",
	hd.dNgayGiaoHang as "Ngày giao"
from
	btlHoaDon hd
join
	btlKhachHang kh on hd.sMaKH = kh.sMaKH
join
	btlNhanVien nv on hd.sMaNVLapHoaDon = nv.sMaNV
join
	btlKhuyenMai km on hd.sMaGiamGia = km.sMaGiamGia

CREATE or alter PROCEDURE sp_LayHoaDonTheoNgayThangNam
    @ngay int = NULL,
    @thang INT = NULL,
    @nam INT = NULL
AS
BEGIN
select
	hd.sMaHD as "Mã hóa đơn",
	kh.sTenKH as "Tên khách hàng",
	nv.sTenNV as "Người lập",
	hd.dNgayLap as "Ngày lập",
	hd.fTongTien as "Tổng tiền",
	km.iPhanTramKhuyenMai as "Phần trăm giảm giá",
	hd.sPhuongThucThanhToan as "Phương thức thanh toán",
	hd.dNgayDatHang as "Ngày đặt",
	hd.dNgayGiaoHang as "Ngày giao"
from
	btlHoaDon hd
join
	btlKhachHang kh on hd.sMaKH = kh.sMaKH
join
	btlNhanVien nv on hd.sMaNVLapHoaDon = nv.sMaNV
join
	btlKhuyenMai km on hd.sMaGiamGia = km.sMaGiamGia
    WHERE 
        (@ngay IS NULL OR day(dNgayLap) = @ngay)
        AND (@thang IS NULL OR MONTH(dNgayLap) = @thang)
        AND (@nam IS NULL OR YEAR(dNgayLap) = @nam);
END;

CREATE or alter PROCEDURE sp_LayHoaDonTheoThangNam
    @thang INT = NULL,
    @nam INT = NULL
AS
BEGIN
select
	hd.sMaHD as "Mã hóa đơn",
	kh.sTenKH as "Tên khách hàng",
	nv.sTenNV as "Người lập",
	hd.dNgayLap as "Ngày lập",
	hd.fTongTien as "Tổng tiền",
	km.iPhanTramKhuyenMai as "Phần trăm giảm giá",
	hd.sPhuongThucThanhToan as "Phương thức thanh toán",
	hd.dNgayDatHang as "Ngày đặt",
	hd.dNgayGiaoHang as "Ngày giao"
from
	btlHoaDon hd
join
	btlKhachHang kh on hd.sMaKH = kh.sMaKH
join
	btlNhanVien nv on hd.sMaNVLapHoaDon = nv.sMaNV
join
	btlKhuyenMai km on hd.sMaGiamGia = km.sMaGiamGia
    WHERE 
        (@thang IS NULL OR MONTH(dNgayLap) = @thang)
        AND (@nam IS NULL OR YEAR(dNgayLap) = @nam);
END;

CREATE or alter PROCEDURE sp_LayHoaDonTheoNam
    @nam INT = NULL
AS
BEGIN
select
	hd.sMaHD as "Mã hóa đơn",
	kh.sTenKH as "Tên khách hàng",
	nv.sTenNV as "Người lập",
	hd.dNgayLap as "Ngày lập",
	hd.fTongTien as "Tổng tiền",
	km.iPhanTramKhuyenMai as "Phần trăm giảm giá",
	hd.sPhuongThucThanhToan as "Phương thức thanh toán",
	hd.dNgayDatHang as "Ngày đặt",
	hd.dNgayGiaoHang as "Ngày giao"
from
	btlHoaDon hd
join
	btlKhachHang kh on hd.sMaKH = kh.sMaKH
join
	btlNhanVien nv on hd.sMaNVLapHoaDon = nv.sMaNV
join
	btlKhuyenMai km on hd.sMaGiamGia = km.sMaGiamGia
    WHERE 
        (@nam IS NULL OR YEAR(dNgayLap) = @nam);
END;

create or alter view v_DonNhapHang -- 17/3/2025
as
select
	dnh.sMaNhapHang as "Mã đơn nhập hàng",
	nv.sTenNV as "Người lập",
	dnh.dNgayNhapHang as "Ngày nhập",
	ncc.sTenNCC as "Tên nhà cung cấp",
	dnh.iTongTien as "Tổng tiền"
from
	btlDonNhapHang dnh
join
	btlNhanVien nv on dnh.sMaNV = nv.sMaNV
join
	btlNhaCungCap ncc on dnh.sMaNCC = ncc.sMaNCC