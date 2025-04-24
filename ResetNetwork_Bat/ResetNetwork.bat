@echo off
:: reet_network.bat - 一鍵重製網路設定
:: 請以系統管理員身分執行

color 0A
cls

echo ==========================
echo 正在重置網路狀態...
echo ==========================

::釋放IP
ipconfig /release

::清除DNS
ipconfig /flushdns

::重新取得IP
ipconfig /renew

::重設TCP/IP協定堆疊
netsh int ip reset

::重設Winsock
netsh winsock reset

::暫停等待使用者確認
echo.
echo 網路重置已完成，建議重新啟動電腦
pause

:: 自動重啟電腦(已註解)
:: shutdown /r /t 5