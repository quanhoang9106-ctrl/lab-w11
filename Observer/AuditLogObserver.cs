
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Ghi lại thông tin cảnh báo
public sealed class AuditLogObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine("[AUDIT LOG]");

        Console.WriteLine(
            "Time: " + alertEvent.OccurredAt.ToString(
                "dd/MM/yyyy HH:mm:ss"
            )
        );

        Console.WriteLine("Sensor: " + alertEvent.SensorName);
        Console.WriteLine("Value: " + alertEvent.Value);
        Console.WriteLine("Severity: " + alertEvent.Severity);
    }
}
