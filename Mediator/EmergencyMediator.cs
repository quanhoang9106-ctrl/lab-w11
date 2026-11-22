
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
        this.alarm = alarm ??
            throw new ArgumentNullException(nameof(alarm));

        this.door = door ??
            throw new ArgumentNullException(nameof(door));

        this.ventilation = ventilation ??
            throw new ArgumentNullException(nameof(ventilation));
    }

    // Tiếp nhận và xử lý sự kiện
    public void Notify(EmergencyEvent eventName)
    {
        if (eventName == EmergencyEvent.FireDetected)
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
