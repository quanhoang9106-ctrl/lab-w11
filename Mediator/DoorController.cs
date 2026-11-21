
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Thiết bị điều khiển cửa
public sealed class DoorController
{
    public bool IsLocked { get; private set; }

    public DoorController()
    {
        IsLocked = true;
    }

    // Mở khóa cửa thoát hiểm
    public void Unlock()
    {
        IsLocked = false;

        Console.WriteLine("[DOOR] Cua da duoc mo khoa.");
    }
}
