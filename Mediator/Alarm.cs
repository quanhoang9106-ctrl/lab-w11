
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
        IsActive = true;

        Console.WriteLine("[ALARM] Coi bao dong da bat.");
    }
}
