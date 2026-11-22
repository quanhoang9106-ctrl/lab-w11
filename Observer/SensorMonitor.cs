
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;
using System.Collections.Generic;

// Giám sát cảm biến và quản lý các observer
public sealed class SensorMonitor
{
    private readonly List<IAlertObserver> observers
        = new List<IAlertObserver>();

    private const double WarningThreshold = 50;
    private const double CriticalThreshold = 70;

    // Đăng ký observer
    public void Attach(IAlertObserver observer)
    {
        if (observer == null)
        {
            throw new ArgumentNullException(nameof(observer));
        }

        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
        else
        {
            Console.WriteLine("Observer da duoc dang ky.");
        }
    }

    // Hủy đăng ký observer
    public void Detach(IAlertObserver observer)
    {
        observers.Remove(observer);
    }

    // Kiểm tra dữ liệu từ cảm biến
    public void CheckSensor(string sensorName, ISensor sensor)
    {
        if (sensor == null)
        {
            throw new ArgumentNullException(nameof(sensor));
        }

        if (string.IsNullOrWhiteSpace(sensorName))
        {
            throw new ArgumentException(
                "Ten cam bien khong hop le."
            );
        }

        double value = sensor.ReadValue();

        // Kiểm tra giá trị sau chuyển đổi
        if (double.IsNaN(value) ||
            double.IsInfinity(value) ||
            value < 0 || value > 100)
        {
            throw new InvalidOperationException(
                "Gia tri cam bien khong hop le."
            );
        }

        string unit = sensor.GetUnit();

        Console.WriteLine("Sensor: " + sensorName);
        Console.WriteLine("Value: " + value.ToString("F1") + unit);

        AlertSeverity severity;

        // Xác định mức độ cảnh báo
        if (value >= CriticalThreshold)
        {
            severity = AlertSeverity.Critical;
        }
        else if (value >= WarningThreshold)
        {
            severity = AlertSeverity.Warning;
        }
        else
        {
            Console.WriteLine("Trang thai binh thuong.");
            return;
        }

        // Tạo đối tượng chứa thông tin cảnh báo
        AlertEvent alertEvent = new AlertEvent(
            sensorName,
            value,
            unit,
            severity,
            DateTime.Now
        );

        Notify(alertEvent);
    }

    // Gửi cảnh báo đến từng observer
    private void Notify(AlertEvent alertEvent)
    {
        foreach (IAlertObserver observer in observers.ToArray())
        {
            try
            {
                observer.Update(alertEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Loi khi thong bao observer: " + ex.Message
                );
            }
        }
    }
}
