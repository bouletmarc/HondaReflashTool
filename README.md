# HondaReflashTool

CanBUS J2534 Honda Reflash Tool (Work in Progress)

You can download the Tool and **use at Your Own Risk!**

### **The Tool is accessible in the 'bin/debug' folder**

### Or download the lastest release [HERE](https://github.com/bouletmarc/HondaReflashTool/releases)

# Description

This is a Work In Progress Honda/Acura Reflash Tool under CanBUS Interface.

The Honda communauty is far behind on the other manufacturers when come to Reflash and Tuning capabilities for vehicules working under CanBUS. Reflash tools that are guenine and works are getting very costly and the vehicules to work with the tools are getting older everydays which is not resonable.

I hope this tool will help others developers to pick up on the developement just like me and make reflash capability for Honda/Acura a lot easier for all of us.

# Tool Capability and Information

You can perform all the works to the ecu if using the Unlock button (0x27,0x41), which includes reading the rom & writing/flashing a complete .bin to the ecu however this unlock method is only compatible for the listed ecus bellow.

You cannot perform all the works to the ecu if using the Unlock button (0x27,0x01). When using this button you cannot read the ECU rom and cannot write binary file (.bin) to the ECU however this unlock method can be used to write a firmware file update (.rwd|.gz) to the ECU.

Firmware files update (.rwd|.gz) can be obtained when downloading HDS (Honda Diagnostic System) software from others websites and look inside the installation folder of 'J2534 Rewrite software' which is generally installed while installed HDS on the pc.

Firmware files update (.rwd|.gz) are only partial and encrypted ROM file. This is not the complete ROM file and it is encrypted too, those file are missing the bootloader section of the original ROM (.bin). However you can decrypt and convert the firmware file (.rwd|.gz) to a decrypted ROM file (.bin) with the missing bootloader section, then modifiy the .bin on your own, then remake a new encrypted firmware (.rwd|.gz) from the modified .bin, then flash the modified firmware file to the ECU using Unlock (0x27,0x01).

# Tool Features

| Done? | Feature Description | 
|------|---------|
| :white_check_mark: | Read ECU rom |
| :white_check_mark: | Write/Flash ECU binary (.bin) rom file |
| :white_check_mark: | Write/Flash ECU firmware (.rwd) file |
| :white_check_mark: | Checksum Verification for 1Mb (.bin) file (SH07058) |
| :white_large_square: | Checksum Verification for 2Mb (.bin) file (SH72531) |
| :white_check_mark: | Seed/Key ECU Unlock Algorithms(0x27,0x01) -> All ECUS?? |
| :exclamation: | Seed/Key ECU Unlock Algorithms(0x27,0x41) -> ONLY Specified ECUS (see compatible list below) |
| :white_check_mark: | RWD firmware file X-RAY/Decryptor to binary file (.bin) |
| :white_check_mark: | Binary file (.bin) to RWD firmware file builder |
| :white_check_mark: | OBD2 Scan Tools |

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

# Compatible ECU's (using unlock 0x27,0x41 button)

| ECU Code | Car Model/Year(s) |
|------|---------|
| 37805-REX-X540 | CR-V (10) |
| 37805-REZ-A570 | CR-V (10) |
| 37805-RJE-A840 | RIDGELINE (06, 07, 08, 09, 10, 11, 12, 13) |
| 37805-RJE-A960 | RIDGELINE (06, 07, 08, 09, 10, 11, 12, 13) |
| 37805-RJE-K020 | RIDGELINE (06, 07, 08, 09, 10, 11, 12, 13) |
| 37805-RJE-K720 | RIDGELINE (06, 07, 08, 09, 10, 11, 12, 13) |
| 37805-RJE-X640 | RIDGELINE (06, 07, 08, 09, 10, 11, 12, 13) |
| 37805-RJE-X730 | RIDGELINE (06, 07, 08, 09, 10, 11, 12, 13) |
| 37805-RK8-N520 | FREED (11, 13) **(IN PROGRESS)** |
| 37805-RK8-N740 | FREED (11, 13) **(IN PROGRESS)** |
| 37805-RK8-N840 | FREED (11, 13) **(IN PROGRESS)** |
| 37805-RMX-3250 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RMX-5070 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RMX-5150 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RMX-A060 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RMX-A130 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RMX-A630 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RMX-X050 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RMX-X550 | Civic + Civic IMA (06, 07, 08, 09) |
| 37805-RNA-3260 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-3290 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-3450 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-3470 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-A150 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-A240 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-A340 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-A680 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-A740 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-A840 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C130 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C240 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C340 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C440 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C640 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C740 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C840 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-C910 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-K080 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-K590 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-U720 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-U840 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-U950 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-Y030 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-Y330 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-Y530 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-Y720 | Civic (06, 07, 08, 09, 10) |
| 37805-RNA-Y830 | Civic (06, 07, 08, 09, 10) |
| 37805-RNB-X040 | Civic (06, 07, 09, 10) |
| 37805-RNB-X120 | Civic (06, 07, 09, 10) |
| 37805-RNB-X560 | Civic (06, 07, 09, 10) |
| 37805-RNB-X620 | Civic (06, 07, 09, 10) |
| 37805-RND-M030 | Civic (06, 07, 08, 09) |
| 37805-RND-M530 | Civic (06, 07, 08, 09) |
| 37805-RND-M620 | Civic (06, 07, 08, 09) |
| 37805-RND-M720 | Civic (06, 07, 08, 09) |
| 37805-RND-P030 | Civic (06, 07, 08, 09) |
| 37805-RND-P540 | Civic (06, 07, 08, 09) |
| 37805-RND-P740 | Civic (06, 07, 08, 09) |
| 37805-RNE-A550 | Civic (06, 07, 08, 09, 10) |
| 37805-RNF-U050 | Civic (06, 07, 09) |
| 37805-RNF-U540 | Civic (06, 07, 09) |
| 37805-RNF-U730 | Civic (06, 07, 09) |
| 37805-RNT-U030 | Civic (07, 09) |
| 37805-RNT-U520 | Civic (07, 09) |
| 37805-RNV-B030 | Civic (07, 08, 09, 10) |
| 37805-RNV-B530 | Civic (07, 08, 09, 10) |
| 37805-RNV-B630 | Civic (07, 08, 09, 10) |
| 37805-RNV-B730 | Civic (07, 08, 09, 10) |
| 37805-RNV-M070 | Civic (07, 08, 09, 10) |
| 37805-RNV-M560 | Civic (07, 08, 09, 10) |
| 37805-RNV-M660 | Civic (07, 08, 09, 10) |
| 37805-RNV-R020 | Civic (07, 08, 09, 10) |
| 37805-RNV-R520 | Civic (07, 08, 09, 10) |
| 37805-RNV-R620 | Civic (07, 08, 09, 10) |
| 37805-RNV-R720 | Civic (07, 08, 09, 10) |
| 37805-RNV-Z020 | Civic (07, 08, 09, 10) |
| 37805-RNV-Z520 | Civic (07, 08, 09, 10) |
| 37805-RNV-Z620 | Civic (07, 08, 09, 10) |
| 37805-RNV-Z720 | Civic (07, 08, 09, 10) |
| 37805-RNX-M020 | Civic (09) |
| 37805-RNX-M520 | Civic (09) |
| 37805-RNX-M620 | Civic (09) |
| 37805-RRA-C040 | Civic (06, 07, 08, 09, 10) |
| 37805-RRA-C540 | Civic (06, 07, 08, 09, 10) |
| 37805-RRB-3150 | Civic (06, 07, 09) |
| 37805-RRB-A090 | Civic (06, 07, 09) |
| 37805-RRB-A140 | Civic (06, 07, 09) |
| 37805-RRB-K020 | Civic (06, 07, 09) |
| 37805-RRB-X120 | Civic (06, 07, 09) |
| 37805-RRD-M220 | Civic (07, 09, 10) |
| 37805-RRD-P120 | Civic (07, 09, 10) |
| 37805-RRD20 | Civic (07, 09, 10) |
| 37805-RRH-U020 | Civic (06, 09) |
| 37805-RRH-U520 | Civic (06, 09) |
| 37805-RRH-U620 | Civic (06, 09) |
| 37805-RWC-A570 | RDX (07, 09, 10, 12) **(IN PROGRESS)** |
| 37805-RWC-A620 | RDX (07, 09, 10, 12) **(IN PROGRESS)** |
| 37805-RWC-A720 | RDX (07, 09, 10, 12) **(IN PROGRESS)** |
| 37805-RWC-X560 | RDX (07, 09, 10, 12) **(IN PROGRESS)** |
| 37805-RWC-X620 | RDX (07, 09, 10, 12) **(IN PROGRESS)** |
| 37805-RZA-A570 | CR-V (07, 08, 09, 10) |
| 37805-RZA-A770 | CR-V (07, 08, 09, 10) |
| 37805-RZA-K130 | CR-V (07, 08, 09, 10) |
| 37805-RZA-K230 | CR-V (07, 08, 09, 10) |
| 37805-RZA-K320 | CR-V (07, 08, 09, 10) |
| 37805-RZA-K520 | CR-V (07, 08, 09, 10) |
| 37805-RZA-K620 | CR-V (07, 08, 09, 10) |
| 37805-RZA-K720 | CR-V (07, 08, 09, 10) |
| 37805-RZA-K930 | CR-V (07, 08, 09, 10) |
| 37805-RZA-X630 | CR-V (07, 08, 09, 10) |
| 37805-RZA-X830 | CR-V (07, 08, 09, 10) |
| 37805-RZP-M020 | CR-V (07, 08, 10) |
| 37805-RZP-M520 | CR-V (07, 08, 10) |
| 37805-RZP-M720 | CR-V (07, 08, 10) |
| 37805-RZP-M820 | CR-V (07, 08, 10) |

