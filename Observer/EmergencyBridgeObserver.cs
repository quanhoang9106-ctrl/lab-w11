
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Kết nối hệ thống cảnh báo với mediator
public sealed class EmergencyBridgeObserver : IAlertObserver
{
    private readonly IEmergencyMediator mediator;

    public EmergencyBridgeObserver(IEmergencyMediator mediator)
    {
        if (mediator == null)
        {
            throw new ArgumentNullException(nameof(mediator));
        }

        this.mediator = mediator;
    }

    public void Update(AlertEvent alertEvent)
    {
        if (alertEvent.Severity == AlertSeverity.Critical)
        {
            Console.WriteLine("[EMERGENCY BRIDGE]");
            Console.WriteLine("Phat hien tinh huong khan cap.");

            mediator.Notify(EmergencyEvent.FireDetected);
        }
    }
}
