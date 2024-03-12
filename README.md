# clicSANDMac

## Installation
### Install mono framework for Mac
[Download here](https://www.mono-project.com/download/stable/)

### Install prerequisites gcc, cbc and glpsol
If you don't have cbc and glpsol installed, the instructions below will install them. glpsol will be compiled from source code, so you might need to install gcc. To install gcc, run the following in a terminal: **xcode-select --install**. 
Download and execute [install.sh](https://raw.githubusercontent.com/ClimateCompatibleGrowth/clicSANDMac/main/install.sh) to download and install coin-cbc and glpk. These are required to be installed before proceeding. The script needs curl and unzip to be installed, which should be installed by default. clicSANDMac currently expects these to be installed in /usr/local/bin

### Install clicSANDMac
Download the latest clicSANDMac.zip from https://github.com/ClimateCompatibleGrowth/clicSANDMac/releases, unzip and double-click on clicSANDMac.pkg to launch the installer. The installer will display a popup indicating that clicSANDMac.pkg cannot be opened because it is from an unidentifier developer. Click Ok. Open System Preferences, open Security and Privacy. There should be a message in the bottom half of the window stating clicSANDMac.pkg was blocked, click the Open Anyway button to launch the installer. A popup will be displayed stating macOS cannot verify the developer of clicSANDMac.pkg, click Open. 

Click Continue on the installer welcome screen.
Click Install, you will be prompted for your password next.
Once complete the Summary window should be displayed stating the installation was successful, click Close.
You will be asked whether you want to Keep the installer or Move to Bin, I've found that Move to Bin is not successful.


Open the Launchpad, and open clicSANDMac

The user interface for clicSANDMac should be displayed, provided the Mono framework has been installed.

## License
This software is licensed under the MIT License, details in license
