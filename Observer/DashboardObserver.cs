
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Hiển thị các thông tin cảnh báo
public sealed class DashboardObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine("[DASHBOARD]");

        Console.WriteLine("Sensor: " + alertEvent.SensorName);

        Console.WriteLine(
            "Value: " + alertEvent.Value.ToString("F1")
            + alertEvent.Unit
        );

        Console.WriteLine("Severity: " + alertEvent.Severity);
    }
}
