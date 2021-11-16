## Explanation
A laboratory kit control program. Made using C#, XAML and database used is SQLite. Comment lines are English.

## What it can do
- Laboratory device can be added.
- Laboratory device name can be updated.
- Laboratory device and kits attached to it can be deleted.
- The kit can be added to be used on the added devices. Each kit can have ownership on one laboratory device.
- Updates can be made on kits. Such as Name, Lot Number, Device and Quantity.
- Kits can be deleted.

## Requirements
- C#
- SQLite
- Visual Studio

### NORMAL PAGES

## App.xaml
- There are styles and design parts in the form interface.
## CihazEklePenceresi.xaml
- It visualizes device adding process and contains these operations.
## Guncelleme.xaml
- It visualizes kit update statuses and hosts their processes.
## GuncellemeCihaz.xaml
- It visualizes device update statuses and hosts their processes.
## KayitPopUp.xaml
- Alert popup that changes based on actions.
## kitEklePenceresi.xaml
- It visualizes kit adding process and contains these operations.
## MainWindows.xaml
- It is the main block window of the software. It contains the user interface.

### CLASSLAR FILE

## cagir.cs
- We use this field to open the userController on the MainWindow.
## DBbaglanti.cs 
- Database connection part. Its directory is static, the database is placed in the same location in new installations.
## DBIstem.cs
- The main class where we make database queries. The main queries are always referenced from here.
## mainprmt.cs
- Contains parameters to be used in operations.
### images file
- It is the folder that contains the visual files of the software.
## banner
- This folder contains images used in areas such as backgrounds.
## icons
- This folder contains the icons used in the software.

### userController file
## CihazList
- Adds a user interface for devices on the main window.
## KullaniciStokList
- Adds a user interface for kits on the main window.
