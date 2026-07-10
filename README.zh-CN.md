# Cedroid

Cedroid 是一个早期阶段的跨平台 Windows CE / Windows Mobile 仿真框架。首个宿主目标是 64 位 Raspberry Pi OS；便携核心和设备模型稳定后，再落地 Android。

> **当前状态：仅完成工程基础。** 仓库包含 .NET/Avalonia 控制面、虚拟机生命周期、QMP 客户端、平台能力抽象、测试、文档和 CI；目前还不能启动 Windows CE，也不包含 QEMU 或任何专有 ROM。

## 目标

- 支持 CE 5、CE 6、WEC 7、WEC 2013、WM 5/6/6.5。
- 产品逻辑和宿主硬件集成尽可能使用 C#。
- 将 QEMU 视为隔离的 C 原生后端，通过 QMP 和 Cedroid 协议控制。
- 先支持树莓派 ARM64，再扩展桌面 Linux、Windows 和 Android。
- 同时规划原始 ROM 兼容机型与可重编译 BSP 使用的 `cevirt` 半虚拟化机型。
- 通过带版本的 CEBridge 接入显示、触摸、音频、网络、WLAN、蓝牙、电话控制、定位和传感器。

## 技术选择

- .NET 10
- Avalonia 12
- CommunityToolkit.Mvvm
- QMP
- QEMU（后续以独立进程或 Android native service 集成）
- 少量不可避免的原生代码只使用 C：QEMU 设备模型和 WinCE 驱动

## 构建

需要预先安装 .NET 10 SDK。仓库脚本不会安装任何软件或修改系统环境。

```powershell
./eng/build.ps1
```

没有本地 SDK 时，可直接依赖 GitHub Actions 做编译与测试验证。Visual Studio 不是必需条件。

## 重要限制

- 仓库不分发微软或 OEM 的 ROM、SDK、BSP、CAB 和固件。
- 普通 Android 应用不能承诺 KVM 或近乎原生性能。
- 通话音频、原始蓝牙 HCI、Wi-Fi 控制器不能作为普通应用透明直通。
- 第一阶段只做 framebuffer 和输入，2D/3D 加速按路线图逐步实现。

参见[架构说明](docs/architecture/overview.md)、[路线图](docs/roadmap.md)和[贡献指南](CONTRIBUTING.md)。
