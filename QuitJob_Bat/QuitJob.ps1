param()

function Remove-PathRecursive {
    param(
        [Parameter(Mandatory)] [string]$Path
    )
    if (Test-Path -LiteralPath $Path) {
        Get-ChildItem -LiteralPath $Path -Force -Recurse -ErrorAction SilentlyContinue |
            Remove-Item    -Force -Recurse -ErrorAction SilentlyContinue
    }
}

# ------------------------- 要刪除的路徑清單 -------------------------------
$UserProfile = [Environment]::GetFolderPath('UserProfile')
$LocalApp    = $env:LOCALAPPDATA
$RoamingApp  = $env:APPDATA

$PathsToWipe = @(
    # 基本
    "$UserProfile\\Downloads",
    "$env:TEMP", "$env:TMP", "C:\\Windows\\Temp",

    # ── 瀏覽器 ───────────────────────────────────
    "$LocalApp\\Microsoft\\Edge\\User Data\\Default\\Cache",
    "$LocalApp\\Google\\Chrome\\User Data\\Default\\Cache",
    "$RoamingApp\\Mozilla\\Firefox\\Profiles\\*\\cache2",

    # ── 通訊 / 協作 ───────────────────────────────
    # Microsoft Teams
    "$RoamingApp\\Microsoft\\Teams\\Cache",
    "$RoamingApp\\Microsoft\\Teams\\logs",
    # Slack
    "$RoamingApp\\Slack\\Cache",
    "$RoamingApp\\Slack\\Service Worker\\CacheStorage",
    # Zoom
    "$RoamingApp\\Zoom\\bin\\logs",

    # ── 新增：LINE ────────────────────────────────
    "$LocalApp\\LINE\\Cache",
    "$RoamingApp\\LINE\\Cache",

    # ── 新增：Facebook / Messenger ───────────────
    "$LocalApp\\Packages\\Facebook.Facebook_*\\LocalCache",
    "$RoamingApp\\Messenger\\Cache",

    # ── 新增：Discord ─────────────────────────────
    "$RoamingApp\\discord\\Cache",
    "$RoamingApp\\discord\\Code Cache",
    "$RoamingApp\\discord\\GPUCache",

    # ── 新增：Webex ───────────────────────────────
    "$RoamingApp\\Cisco\\Webex Teams\\Cache",
    "$RoamingApp\\Cisco\\Webex Teams\\Logs",
    "$LocalApp\\WebEx",

    # ── Office / Recent / Quick Access ───────────
    "$RoamingApp\\Microsoft\\Office\\Recent",
    "$RoamingApp\\Microsoft\\Windows\\Recent",
    "$LocalApp\\Microsoft\\Windows\\Explorer\\*destinations*"
)

# ------------------------- 執行刪除 --------------------------------------
Write-Host "========== 離職清理開始 ==========" -ForegroundColor Cyan

foreach ($p in $PathsToWipe) {
    Write-Host "[清理] $p" -ForegroundColor DarkGray
    Remove-PathRecursive $p
}

# 垃圾桶
try {
    Write-Host "[清理] 回收筒 (Recycle Bin)" -ForegroundColor DarkGray
    Clear-RecycleBin -Force -ErrorAction SilentlyContinue
} catch {}

Write-Host "========== 清理完成 ==========" -ForegroundColor Green
