
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

// Các sự kiện khẩn cấp
public enum EmergencyEvent
{
    FireDetected
}

// Giao diện điều phối thiết bị
public interface IEmergencyMediator
{
    void Notify(EmergencyEvent eventName);
}
