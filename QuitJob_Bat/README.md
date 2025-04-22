# 說明文件

## 開發環境：

PowerShell

## 目的：

一鍵離職電腦清理腳本

##  功能：
* 清空下載資料夾、垃圾桶、Windows / 使用者暫存
* 清除瀏覽器 (Edge/Chrome/Firefox) 快取與歷史
* 清理通訊／社群軟體：Teams、Slack、Zoom、LINE、Facebook/Messenger、Discord、Webex
* 移除近期檔案、Office 最近清單、Quick Access
* 可擴充其他路徑，只需在 $PathsToWipe 追加

⚠️ 執行前請確認：
1. 已備份所有需留存之檔案與憑證。
2. 以 **系統管理員** 身份執行 PowerShell（右鍵→以系統管理員執行）
3. 建議先在測試機試跑。


##  使用：
Set-ExecutionPolicy Bypass -Scope Process -Force .\QuitJob.ps1


