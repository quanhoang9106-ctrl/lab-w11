
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

        // Khởi tạo cảm biến và adapter
        LegacySmokeDetector legacy =
            new LegacySmokeDetector(300);

        ISensor sensor =
            new SmokeSensorAdapter(legacy);

        // Khởi tạo các thiết bị
        Alarm alarm = new Alarm();
        DoorController door = new DoorController();

        VentilationController ventilation =
            new VentilationController();

        // Khởi tạo mediator
        IEmergencyMediator mediator =
            new EmergencyMediator(alarm, door, ventilation);

        // Khởi tạo các observer
        DashboardObserver dashboard = new DashboardObserver();
        EmailAlertObserver email = new EmailAlertObserver();
        AuditLogObserver audit = new AuditLogObserver();

        EmergencyBridgeObserver bridge =
            new EmergencyBridgeObserver(mediator);

        SensorMonitor monitor = new SensorMonitor();

        // Đăng ký các observer
        monitor.Attach(dashboard);
        monitor.Attach(email);
        monitor.Attach(audit);
        monitor.Attach(bridge);

        // Chạy các trường hợp mẫu
        Console.WriteLine("\n===== CHAY CHUONG TRINH =====");

        RunTest(300, legacy, sensor, monitor);
        RunTest(550, legacy, sensor, monitor);
        RunTest(735, legacy, sensor, monitor);

        // Kiểm tra trạng thái cuối cùng
        PrintDeviceStatus(alarm, door, ventilation);

        // Chạy kiểm thử bổ sung
        RunThresholdTests(legacy, sensor);
        RunObserverTests(legacy, sensor);
        RunInvalidValueTest();

        Console.WriteLine();
        Console.WriteLine("Ket thuc chuong trinh.");
    }

    // Chạy một trường hợp cảm biến
    static void RunTest(
        int smokeLevel,
        LegacySmokeDetector legacy,
        ISensor sensor,
        SensorMonitor monitor)
    {
        Console.WriteLine();
        Console.WriteLine("========== TEST ==========");
        Console.WriteLine("Smoke level = " + smokeLevel);

        legacy.SetSmokeLevel(smokeLevel);

        monitor.CheckSensor("Smoke Sensor", sensor);
    }

    // Hiển thị trạng thái thiết bị
    static void PrintDeviceStatus(
        Alarm alarm,
        DoorController door,
        VentilationController ventilation)
    {
        Console.WriteLine();
        Console.WriteLine("===== TRANG THAI THIET BI =====");

        Console.WriteLine("Alarm active: " + alarm.IsActive);
        Console.WriteLine("Door locked: " + door.IsLocked);

        Console.WriteLine(
            "Emergency ventilation: "
            + ventilation.IsEmergencyMode
        );
    }

    // Kiểm thử các giá trị biên
    static void RunThresholdTests(
        LegacySmokeDetector legacy,
        ISensor sensor)
    {
        Console.WriteLine();
        Console.WriteLine("===== KIEM THU GIA TRI BIEN =====");

        (int Value, AlertSeverity? Expected)[] testCases =
        {
            (0, null),
            (499, null),
            (500, AlertSeverity.Warning),
            (699, AlertSeverity.Warning),
            (700, AlertSeverity.Critical),
            (735, AlertSeverity.Critical),
            (1000, AlertSeverity.Critical)
        };

        foreach (var test in testCases)
        {
            SensorMonitor testMonitor = new SensorMonitor();
            TestObserver observer = new TestObserver();

            testMonitor.Attach(observer);

            legacy.SetSmokeLevel(test.Value);

            testMonitor.CheckSensor("Test Sensor", sensor);

            AlertSeverity? actual = observer.LastAlert?.Severity;

            bool passed = actual == test.Expected;

            Console.WriteLine(
                "Test " + test.Value + ": "
                + (passed ? "PASS" : "FAIL")
            );
        }
    }

    // Kiểm thử đăng ký, hủy đăng ký và xử lý lỗi observer
    static void RunObserverTests(
        LegacySmokeDetector legacy,
        ISensor sensor)
    {
        Console.WriteLine();
        Console.WriteLine("===== KIEM THU OBSERVER =====");

        SensorMonitor monitor = new SensorMonitor();
        TestObserver observer = new TestObserver();

        // Thử đăng ký trùng
        monitor.Attach(observer);
        monitor.Attach(observer);

        legacy.SetSmokeLevel(550);
        monitor.CheckSensor("Test Sensor", sensor);

        Console.WriteLine(
            "Dang ky trung: "
            + (observer.Count == 1 ? "PASS" : "FAIL")
        );

        // Thử hủy đăng ký
        monitor.Detach(observer);

        monitor.CheckSensor("Test Sensor", sensor);

        Console.WriteLine(
            "Huy dang ky: "
            + (observer.Count == 1 ? "PASS" : "FAIL")
        );

        // Thử một observer phát sinh lỗi
        ErrorObserver errorObserver = new ErrorObserver();
        TestObserver anotherObserver = new TestObserver();

        monitor.Attach(errorObserver);
        monitor.Attach(anotherObserver);

        monitor.CheckSensor("Test Sensor", sensor);

        Console.WriteLine(
            "Xu ly loi observer: "
            + (anotherObserver.Count == 1 ? "PASS" : "FAIL")
        );

        // Thử gỡ observer ngay trong quá trình thông báo
        SelfRemovingObserver removingObserver =
            new SelfRemovingObserver(monitor);

        monitor.Attach(removingObserver);

        monitor.CheckSensor("Test Sensor", sensor);
        monitor.CheckSensor("Test Sensor", sensor);

        Console.WriteLine(
            "Go observer trong khi thong bao: "
            + (removingObserver.Count == 1 ? "PASS" : "FAIL")
        );
    }

    // Kiểm thử cảm biến cung cấp dữ liệu sai
    static void RunInvalidValueTest()
    {
        Console.WriteLine();
        Console.WriteLine("===== KIEM THU DU LIEU SAI =====");

        try
        {
            // Constructor của cảm biến cũ không giới hạn giá trị
            LegacySmokeDetector invalidLegacy =
                new LegacySmokeDetector(2000);

            ISensor invalidSensor =
                new SmokeSensorAdapter(invalidLegacy);

            invalidSensor.ReadValue();

            Console.WriteLine("Invalid value: FAIL");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Invalid value: PASS");
        }
    }

    // Observer phục vụ việc kiểm thử
    private sealed class TestObserver : IAlertObserver
    {
        public int Count { get; private set; }

        public AlertEvent? LastAlert { get; private set; }

        public void Update(AlertEvent alertEvent)
        {
            Count++;
            LastAlert = alertEvent;
        }
    }

    // Observer giả lập lỗi để kiểm tra try-catch
    private sealed class ErrorObserver : IAlertObserver
    {
        public void Update(AlertEvent alertEvent)
        {
            throw new Exception("Loi thu nghiem observer.");
        }
    }

    // Observer tự hủy đăng ký khi nhận cảnh báo
    private sealed class SelfRemovingObserver : IAlertObserver
    {
        private readonly SensorMonitor monitor;

        public int Count { get; private set; }

        public SelfRemovingObserver(SensorMonitor monitor)
        {
            this.monitor = monitor;
        }

        public void Update(AlertEvent alertEvent)
        {
            Count++;

            // Tự gỡ khỏi danh sách observer
            monitor.Detach(this);
        }
    }
}
