
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("==================================");
        Console.WriteLine("        CAMPUS SAFETY HUB");
        Console.WriteLine("==================================");

        // 1. Khởi tạo cảm biến cũ và adapter
        LegacySmokeDetector legacy =
            new LegacySmokeDetector(300);

        ISensor sensor =
            new SmokeSensorAdapter(legacy);

        // 2. Khởi tạo các thiết bị
        Alarm alarm = new Alarm();

        DoorController door = new DoorController();

        VentilationController ventilation =
            new VentilationController();

        // 3. Khởi tạo mediator
        IEmergencyMediator mediator =
            new EmergencyMediator(
                alarm,
                door,
                ventilation
            );

        // 4. Khởi tạo các observer
        DashboardObserver dashboard =
            new DashboardObserver();

        EmailAlertObserver email =
            new EmailAlertObserver();

        AuditLogObserver audit =
            new AuditLogObserver();

        EmergencyBridgeObserver bridge =
            new EmergencyBridgeObserver(mediator);

        // 5. Khởi tạo hệ thống giám sát
        SensorMonitor monitor = new SensorMonitor();

        // Đăng ký các observer
        monitor.Attach(dashboard);
        monitor.Attach(email);
        monitor.Attach(audit);
        monitor.Attach(bridge);

        // 6. Kiểm thử trường hợp bình thường
        Console.WriteLine();
        Console.WriteLine("========== TEST 1 ==========");
        Console.WriteLine("Muc khoi binh thuong");

        legacy.SetSmokeLevel(300);

        monitor.CheckSensor("Smoke Sensor", sensor);

        // 7. Kiểm thử trường hợp cảnh báo
        Console.WriteLine();
        Console.WriteLine("========== TEST 2 ==========");
        Console.WriteLine("Muc khoi canh bao");

        legacy.SetSmokeLevel(550);

        monitor.CheckSensor("Smoke Sensor", sensor);

        // 8. Kiểm thử trường hợp nguy hiểm
        Console.WriteLine();
        Console.WriteLine("========== TEST 3 ==========");
        Console.WriteLine("Muc khoi nguy hiem");

        legacy.SetSmokeLevel(735);

        monitor.CheckSensor("Smoke Sensor", sensor);

        // 9. Kiểm tra trạng thái các thiết bị
        Console.WriteLine();
        Console.WriteLine("===== TRANG THAI THIET BI =====");

        Console.WriteLine(
            "Alarm active: " + alarm.IsActive
        );

        Console.WriteLine(
            "Door locked: " + door.IsLocked
        );

        Console.WriteLine(
            "Emergency ventilation: "
            + ventilation.IsEmergencyMode
        );

        Console.WriteLine();
        Console.WriteLine("Ket thuc chuong trinh.");
    }
}
