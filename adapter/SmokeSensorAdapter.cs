
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Chuyển đổi cảm biến cũ sang giao diện ISensor
public sealed class SmokeSensorAdapter : ISensor
{
    private readonly LegacySmokeDetector legacy;

    public SmokeSensorAdapter(LegacySmokeDetector legacy)
    {
        if (legacy == null)
        {
            throw new ArgumentNullException(nameof(legacy));
        }

        this.legacy = legacy;
    }

    // Chuyển thang đo từ 0-1000 sang 0-100%
    public double ReadValue()
    {
        int oldValue = legacy.GetSmokeLevel();

        // Kiểm tra dữ liệu từ cảm biến cũ
        if (oldValue < 0 || oldValue > 1000)
        {
            throw new InvalidOperationException(
                "Gia tri cam bien cu khong hop le."
            );
        }

        double newValue = oldValue / 10.0;

        return newValue;
    }

    public string GetUnit()
    {
        return "% smoke";
    }
}
