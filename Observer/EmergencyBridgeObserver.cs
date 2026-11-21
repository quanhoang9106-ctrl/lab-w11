
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Kết nối hệ thống cảnh báo với hệ thống ứng phó
public sealed class EmergencyBridgeObserver : IAlertObserver
{
    private readonly IEmergencyMediator mediator;

    public EmergencyBridgeObserver(IEmergencyMediator mediator)
    {
        this.mediator = mediator ??
            throw new ArgumentNullException(nameof(mediator));
    }

    public void Update(AlertEvent alertEvent)
    {
        if (alertEvent.Severity == "CRITICAL")
        {
            Console.WriteLine("[EMERGENCY BRIDGE]");
            Console.WriteLine("Phat hien tinh huong khan cap.");

            mediator.Notify("FIRE_DETECTED");
        }
    }
}
