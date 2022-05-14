# HondaReflashTool

Open Source CanBUS J2534 Honda/Acura Reflash Tool (Work in Progress)

You can download the Tool and **use at Your Own Risk!**

### **The Tool is accessible in the 'bin/debug' folder**

### Or download the lastest release [HERE](https://github.com/bouletmarc/HondaReflashTool/releases)

You can download some Honda/Acura firmwares updates files (.rwd/.bin) to give you a good head start [HERE](https://github.com/bouletmarc/HondaCalibFiles)

# Description

This is a Work In Progress Honda/Acura Reflash Tool under CanBUS Interface.

The Honda communauty is far behind on the other manufacturers when come to Reflash and Tuning capabilities for vehicules working under CanBUS. Reflash tools that are guenine and works are getting very costly and the vehicules to work with the tools are getting older everydays which is not resonable.

I hope this tool will help others developers to pick up on the developement just like me and make reflash capability for Honda/Acura a lot easier for all of us.

# Tool Capability and Information

You can perform all the works to the ecu if using the Unlock button (0x27,0x41), which includes reading the rom & writing/flashing a complete .bin to the ecu however this unlock method is only compatible for the listed ecus bellow.

You cannot perform all the works to the ecu if using the Unlock button (0x27,0x01). When using this button you cannot read the ECU rom and cannot write binary file (.bin) to the ECU however this unlock method can be used to write a firmware file update (.rwd|.gz) to the ECU.

Firmware files update (.rwd|.gz) can be obtained when downloading HDS (Honda Diagnostic System) software from others websites and look inside the installation folder of 'J2534 Rewrite software' which is generally installed while installing HDS on the pc.

Firmware files update (.rwd|.gz) are only partial and encrypted ROM file. This is not the complete ROM file and it is encrypted too, those file are missing the bootloader section of the original ROM (.bin). However you can convert the firmware file (.rwd|.gz) to a decrypted ROM file (.bin) with the missing bootloader section, then modifiy the .bin on your own, then remake a new encrypted firmware (.rwd|.gz) from the modified .bin, then flash the modified firmware file to the ECU using Unlock (0x27,0x01).

# Tool Features

| Done? | Feature Description | 
|------|---------|
| :white_check_mark: | Read ECU rom |
| :white_check_mark: | Write/Flash ECU binary (.bin) rom file |
| :white_check_mark: | Write/Flash ECU firmware (.rwd) file |
| :white_large_square: | Checksum Verification for 512Kb (.bin) file (SH7055) |
| :white_check_mark: | Checksum Verification for 1Mb (.bin) file (SH7058) |
| :white_large_square: | Checksum Verification for 1.5Mb (.bin) file (SH7059) |
| :white_check_mark: | Checksum Verification for 2Mb (.bin) file (SH72531/MPC5554) **(->TO CONFIRM)** |
| :white_check_mark: | Checksum Verification for 4Mb (.bin) file (MED17.9.3/TC179X) **(->TO CONFIRM)** |
| :white_check_mark: | Seed/Key ECU Unlock Algorithms(0x27,0x01) -> All ECUS?? |
| :exclamation: | Seed/Key ECU Unlock Algorithms(0x27,0x41) -> ONLY Specified ECUS (see compatible list below) |
| :white_check_mark: | RWD firmware file X-RAY/Decryptor to binary file (.bin) for 0x5A files |
| :white_large_square: | RWD firmware file X-RAY/Decryptor to binary file (.bin) for 0x31 files **(->IN PROGRESS)** |
| :white_check_mark: | Binary file (.bin) to RWD firmware file builder for 0x5A files |
| :white_large_square: | Binary file (.bin) to RWD firmware file builder for 0x31 files **(->IN PROGRESS)** |
| :white_check_mark: | OBD2 Scan Tools |
| :white_check_mark: | Binary ROM Tables Editor (with Definitions) |
| :white_large_square: | Immobilizer Tool **(->NOT YET IMPLEMENTED)** |

# Want to contribute your work to this project?

You can freely 'Fork' this repository to your github account, this will create a duplicated copy of the project inside your github account repositories!

To apply any changes and updates to the project, uploads the changes you have done to the duplicated project inside your reposities and then provide a 'Pull Requests' to this github repo to make the request to apply your changes done to the tool but inside my repository.

# Compatible J2534 API Adapters

I beleive ALL J2534 adapters are compatible with the Reflash tool if you have the appropriate drivers installed in your pc (this is generally done automaticly nowadays with usb protocols).

Common's J2534 adapters such as the GNA600, Mongoose, Tactrix Openport 2.0 (also the fakes ones!) should works with no issues.

# Compatible Cars (using unlock 0x27,0x01 button)

| Car Manufacturer | Year(s) | Models |
|------|---------|---------|
| Honda & Acura | 2007+ | All Models?? |

# Compatible Cars (using unlock 0x27,0x41 button)

| Car Model | Year(s) | Algorithm Byte | Key1 Bytes | Key2 Bytes |
|------|---------|---------|---------|---------|
| Honda Civic's (All?) | 2006-2010 | 0x01 | 0xAE, 0x0D, 0x23, 0xFF | 0x40, 0x65, 0x58, 0xB3 |
| Honda Ridgeline | 2006-2013 | 0x04 | 0x16, 0xA4, 0xAB, 0xB0 | 0xBF, 0xE8, 0x5A, 0x6D |
| Honda CR-V | 2007-2010 | 0x08 | 0x6D, 0x75, 0x32, 0xAC | 0x9D, 0x62, 0x3B, 0x64 |
| Acura RDX **(In Progress)** | 2007-2012 | 0x1A | 0x67, 0xE9, 0x76, 0xC1 | 0x78, 0x3E, 0x17, 0x39 |
| Honda Freed **(In Progress)** | 2011-2013 | 0x20 | 0x95, 0x58, 0x3E, 0x2C | 0xF3, 0x96, 0xB5, 0x6F |

**Notes: Keys Bytes can be found directly in the ecu ROM.bin by searching for them!

