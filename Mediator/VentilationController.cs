
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Thiết bị điều khiển hệ thống thông gió
public sealed class VentilationController
{
    public bool IsEmergencyMode { get; private set; }

    public VentilationController()
    {
        IsEmergencyMode = false;
    }

    // Bật chế độ thông gió khẩn cấp
    public void StartEmergencyMode()
    {
        IsEmergencyMode = true;

        Console.WriteLine(
            "[VENTILATION] Da bat che do khan cap."
        );
    }
}
