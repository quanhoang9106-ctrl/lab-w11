
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Điều phối các thiết bị khi có sự kiện khẩn cấp
public sealed class EmergencyMediator : IEmergencyMediator
{
    private readonly Alarm alarm;
    private readonly DoorController door;
    private readonly VentilationController ventilation;

    public EmergencyMediator(
        Alarm alarm,
        DoorController door,
        VentilationController ventilation)
    {
        this.alarm = alarm;
        this.door = door;
        this.ventilation = ventilation;
    }

    // Nhận sự kiện và điều khiển các thiết bị
    public void Notify(string eventName)
    {
        if (eventName == "FIRE_DETECTED")
        {
            Console.WriteLine("[MEDIATOR]");
            Console.WriteLine("Bat dau xu ly su co.");

            alarm.Activate();

            door.Unlock();

            ventilation.StartEmergencyMode();
        }
        else
        {
            Console.WriteLine("Su kien chua duoc ho tro.");
        }
    }
}
