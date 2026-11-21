
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Mô phỏng gửi email khi có cảnh báo
public sealed class EmailAlertObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine("[EMAIL]");

        if (alertEvent.Severity == "CRITICAL")
        {
            Console.WriteLine("Gui email canh bao khan cap.");
        }
        else
        {
            Console.WriteLine("Gui email canh bao thong thuong.");
        }

        Console.WriteLine("Sensor: " + alertEvent.SensorName);
        Console.WriteLine("Severity: " + alertEvent.Severity);
    }
}
