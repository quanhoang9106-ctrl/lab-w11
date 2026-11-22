
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Điều khiển thiết bị thông gió
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
        if (IsEmergencyMode)
        {
            Console.WriteLine(
                "[VENTILATION] Che do khan cap dang hoat dong."
            );
            return;
        }

        IsEmergencyMode = true;

        Console.WriteLine(
            "[VENTILATION] Da bat che do khan cap."
        );
    }

    // Kết thúc chế độ khẩn cấp
    public void StopEmergencyMode()
    {
        IsEmergencyMode = false;

        Console.WriteLine(
            "[VENTILATION] Da tat che do khan cap."
        );
    }
}
