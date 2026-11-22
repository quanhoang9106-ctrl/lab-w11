
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Thiết bị còi báo động
public sealed class Alarm
{
    public bool IsActive { get; private set; }

    public Alarm()
    {
        IsActive = false;
    }

    // Bật còi báo động
    public void Activate()
    {
        if (IsActive)
        {
            Console.WriteLine("[ALARM] Coi dang hoat dong.");
            return;
        }

        IsActive = true;

        Console.WriteLine("[ALARM] Coi bao dong da bat.");
    }

    // Tắt còi khi được cho phép reset
    public void Deactivate()
    {
        IsActive = false;
        Console.WriteLine("[ALARM] Coi bao dong da tat.");
    }
}
