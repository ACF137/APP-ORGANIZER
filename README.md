# ACF App Organizer

ACF App Organizer is a lightweight and fast GUI application launcher for Windows, built with **.NET 8** and **WPF**. It allows you to consolidate your frequently used tools, games, IDEs, and console scripts into a single custom dashboard for instant access.

## Features

* **Instant Launch:** Run any application or script in a single click
* **Custom Grid Layout:** Add, remove, and organize application shortcuts
* **CMD Integration:** Quick access to Windows Command Prompt in the working directory context
* **A-START (Auto-Start):** Manage applications that should launch automatically on system startup
* **Modern Stack:** High performance and low resource footprint thanks to .NET 8 WPF
* **GitHub Shortcut:** Direct link to the source repository from the UI

## Core UI Controls

* **+ADD** — Add a new application to the organizer (select executable path and icon)
* **CMD** — Open Windows Command Prompt in the active directory
* **A-START** — Configure and toggle automatic startup rules
* **GitHub** — Instantly open this repository page in your browser

## Requirements

* Windows 10 / 11 (64-bit)
* **.NET 8.0 Desktop Runtime** (Required *only* if using the lightweight 3 MB installer)

## Installation & Setup

Choose **one** of the following installation methods from the Releases page:

### Method 1: Portable Standalone Executable (~70 MB)
* No installation required
* Includes the built-in .NET 8 runtime (Self-contained)
* Runs out of the box on any modern Windows PC

### Method 2: Lightweight Installer (~3 MB)
* Traditional setup wizard that installs the app into `Program Files`
* Does not include the .NET 8 runtime
* Requires [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/ru-ru/download/dotnet/8.0) to be installed on your system

## Changelog

### v1.0.0
* Initial release
* Core WPF + .NET 8 architecture
* Grid system for application shortcuts
* +ADD, CMD, A-START, and GitHub features implemented

## Version

Current version: `v1.0.0`
