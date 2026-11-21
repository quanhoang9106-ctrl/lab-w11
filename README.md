
# Campus Safety Hub

## 1. Thông tin sinh viên

- Họ tên: Hoàng Văn Quân
- Mã sinh viên: 202418971
- Môn học: Lập trình hướng đối tượng
- Bài thực hành: Tuần 11 - Design Pattern

## 2. Giới thiệu

Chương trình mô phỏng hệ thống giám sát an toàn
cho phòng máy.

Hệ thống đọc dữ liệu từ cảm biến khói, kiểm tra
mức độ nguy hiểm, gửi cảnh báo và điều khiển các
thiết bị khi xảy ra tình huống khẩn cấp.

Chương trình được viết bằng C# và chạy trên Console.

## 3. Các mẫu thiết kế sử dụng

### Adapter Pattern

Chuyển đổi dữ liệu của cảm biến khói cũ từ
thang đo 0-1000 sang thang đo 0-100%.

### Observer Pattern

Thông báo cảnh báo đến các đối tượng đã đăng ký:

- DashboardObserver
- EmailAlertObserver
- AuditLogObserver
- EmergencyBridgeObserver

### Mediator Pattern

Điều phối hoạt động của các thiết bị:

- Còi báo động
- Cửa thoát hiểm
- Hệ thống thông gió

## 4. Cấu trúc chương trình

- adapter/: Các lớp xử lý cảm biến.
- Observer/: Các lớp xử lý cảnh báo.
- Mediator/: Các lớp điều phối thiết bị.
- Program.cs: Chương trình chính.
- CampusSafetyHub.csproj: File cấu hình project.

## 5. Quy tắc cảnh báo

| Mức độ khói | Trạng thái |
|---|---|
| Dưới 50% | NORMAL |
| Từ 50% đến dưới 70% | WARNING |
| Từ 70% trở lên | CRITICAL |

Khi xảy ra cảnh báo CRITICAL, hệ thống mô phỏng
việc bật còi báo động, mở khóa cửa thoát hiểm
và kích hoạt thông gió khẩn cấp.

## 6. Hướng dẫn chạy

Yêu cầu: Máy tính đã cài đặt .NET SDK phù hợp
với phiên bản được khai báo trong file csproj.

Tải mã nguồn:

```bash
git clone https://github.com/quanhoang9106-ctrl/lab-w11.git
cd lab-w11
```

Biên dịch chương trình:

```bash
dotnet build
```

Chạy chương trình:

```bash
dotnet run
```

## 7. Các trường hợp chạy thử

- Giá trị 300: Trạng thái bình thường.
- Giá trị 550: Trạng thái cảnh báo WARNING.
- Giá trị 735: Trạng thái nguy hiểm CRITICAL.

## 8. Hạn chế của chương trình

- Chưa có chức năng nhập dữ liệu từ bàn phím.
- Chưa lưu nhật ký cảnh báo vào file.
- Chưa có chức năng reset thiết bị.
- Chưa kiểm thử đầy đủ các trường hợp đặc biệt.
- Một số đoạn code còn dài và chưa được tối ưu.

## 9. Hướng phát triển

- Bổ sung các trường hợp kiểm thử.
- Hoàn thiện xử lý ngoại lệ.
- Cải thiện cách tổ chức mã nguồn.
- Tối ưu các phương thức trong chương trình.
