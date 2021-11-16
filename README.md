
## Explanation
A laboratory kit tracking program. Made using C# and database used is SQLite. Comment lines are both Turkish and English.

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
- Visual 

### Normal Pages
##App.xaml
##CihazEklePenceresi.xaml
##Guncelleme.xaml
##GuncellemeCihaz.xaml
##KayitPopUp.xaml
##kitEklePenceresi.xaml
##MainWindows.xaml


### classlar file
## cagir.cs
- We use this field to open the userController on the MainWindow.
## DBbaglanti.cs 
- Database connection part. Its directory is static, the database is placed in the same location in new installations.
## DBIstem
- The main class where we make database queries. The main queries are always referenced from here.

## parametreler file
- mainprmt.cs
### images file
- It is the folder that contains the visual files of the software.
##banner
- This folder contains images used in areas such as backgrounds.
##icons
- This folder contains the icons used in the software.

### userController file
##CihazList
##KullaniciStokList

