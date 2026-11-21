
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;
using System.Collections.Generic;

// Lớp giám sát cảm biến và quản lý observer
public sealed class SensorMonitor
{
    private readonly List<IAlertObserver> observers
        = new List<IAlertObserver>();

    // Đăng ký đối tượng nhận cảnh báo
    public void Attach(IAlertObserver observer)
    {
        if (observer == null)
        {
            throw new ArgumentNullException(nameof(observer));
        }

        if (observers.Contains(observer) == false)
        {
            observers.Add(observer);
        }
        else
        {
            Console.WriteLine("Observer da duoc dang ky.");
        }
    }

    // Hủy đăng ký nhận cảnh báo
    public void Detach(IAlertObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    // Đọc cảm biến và kiểm tra mức độ nguy hiểm
    public void CheckSensor(string sensorName, ISensor sensor)
    {
        double value = sensor.ReadValue();
        string unit = sensor.GetUnit();
        string severity;

        Console.WriteLine("Sensor: " + sensorName);
        Console.WriteLine("Value: " + value.ToString("F1") + unit);

        // Xác định mức độ cảnh báo
        if (value >= 70)
        {
            severity = "CRITICAL";
        }
        else if (value >= 50)
        {
            severity = "WARNING";
        }
        else
        {
            Console.WriteLine("Trang thai binh thuong.");
            return;
        }

        AlertEvent alertEvent = new AlertEvent(
            sensorName,
            value,
            unit,
            severity,
            DateTime.Now
        );

        Notify(alertEvent);
    }

    // Gửi cảnh báo tới các observer
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
                Console.WriteLine("Loi observer: " + ex.Message);
            }
        }
    }
}
