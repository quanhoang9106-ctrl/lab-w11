
/****************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
****************/

using System;

// Lưu thông tin của một sự kiện cảnh báo
public sealed record AlertEvent(
    string SensorName,
    double Value,
    string Unit,
    string Severity,
    DateTime OccurredAt
);
