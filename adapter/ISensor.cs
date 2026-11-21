
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

// Giao diện chung cho các cảm biến
public interface ISensor
{
    // Đọc giá trị của cảm biến
    double ReadValue();

    // Lấy đơn vị đo
    string GetUnit();
}
