# ACF App Organizer

ACF App Organizer is a lightweight and fast GUI application launcher for Windows, built with **.NET 8** and **WPF**. It allows you to consolidate your frequently used tools, games, IDEs, and console scripts into a single custom dashboard for instant access.

## Features

* **Instant Launch:** Run any application or script in a single click
* **Custom Grid Layout:** Add, remove, and organize application shortcuts
* **CMD Integration:** Quick access to Windows Command Prompt
* **A-START (Auto-Start):** Manage automatic startup with Windows
* **System Tray:** Keep ACF App Organizer running in the background
* **Global Hotkey:** Open the application with `Win + Z`
* **Admin Launch:** Run applications with administrator privileges
* **Modern Stack:** Built with .NET 8 and WPF
* **GitHub Shortcut:** Direct link to the source repository from the UI

## Core UI Controls

* **+ADD** — Add a new application or `.bat` script to the organizer
* **CMD** — Open Windows Command Prompt
* **A-START** — Configure and toggle automatic startup
* **GitHub** — Open this repository in your browser

## System Tray

ACF App Organizer can run in the Windows system tray.

The tray menu provides:

* **Open ACF APP ORGANIZER** — Show the main window
* **Exit** — Completely close the application

The main window can be hidden without closing the application.

You can also open the application using:

`Win + Z`

## Requirements

* Windows 10 / 11 (64-bit)

The standalone version includes the required .NET 8 runtime and does not require a separate .NET installation.

The lightweight installer requires **.NET 8.0 Desktop Runtime**.

## Installation & Setup

Choose **one** of the following installation methods from the Releases page:

### Method 1: Portable Standalone Executable (~70 MB)

* No installation required
* Includes the built-in .NET 8 runtime
* Self-contained
* Runs out of the box on compatible Windows systems

### Method 2: Lightweight Installer (~3 MB)

* Traditional setup wizard
* Installs the application into `Program Files`
* Does not include the .NET 8 runtime
* Requires [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/ru-ru/download/dotnet/8.0)

## Changelog

### v1.4.0

* Added system tray support
* Added global `Win + Z` hotkey to open the application
* Added tray menu with Open and Exit
* Added background operation through the system tray
* Added administrator launch option
* Improved single-instance handling
* Improved window hiding and restoring

### v1.0.0

* Initial release
* Core WPF + .NET 8 architecture
* Grid system for application shortcuts
* +ADD, CMD, A-START, and GitHub features implemented

## Version

Current version: `v1.4.0`
