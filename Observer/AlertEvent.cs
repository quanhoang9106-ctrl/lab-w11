
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Các mức độ cảnh báo
public enum AlertSeverity
{
    Warning,
    Critical
}

// Lưu thông tin của một sự kiện cảnh báo
public sealed record AlertEvent(
    string SensorName,
    double Value,
    string Unit,
    AlertSeverity Severity,
    DateTime OccurredAt
);
