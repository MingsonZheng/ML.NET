// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
打开 PowerShell，并输入以下代码（其中，PORT 是应用程序正在侦听的端口）。
$body = @{
    Vendor_id="CMT"
    Rate_code=1.0
    Passenger_count=1.0
    Trip_distance=3.8
    Payment_type="CRD"
}

Invoke-RestMethod "https://localhost:<PORT>/predict" -Method Post -Body ($body | ConvertTo-Json) -ContentType "application/json"
 */

/*
如果成功，输出文本应如下所示：
score
-----
15.020833
 */