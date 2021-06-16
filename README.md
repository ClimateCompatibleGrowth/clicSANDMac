# clicSANDMac

## Installation
### Install mono framework for Mac
[Download here](https://www.mono-project.com/download/stable/)

### Install prerequisites gcc, cbc and glpsol
If you don't have cbc and glpsol installed, the instructions below will install them. glpsol will be compiled from source code, so you might need to install gcc. To install gcc, run the following in a terminal: **xcode-select --install**. 
Download and execute [install.sh](https://raw.githubusercontent.com/ClimateCompatibleGrowth/clicSANDMac/main/install.sh) to download and install coin-cbc and glpk. These are required to be installed before proceeding. The script needs curl and unzip to be installed, which should be installed by default. clicSANDMac currently expects these to be installed in /usr/local/bin

### Install clicSANDMac
Download the latest clicSANDMac.zip from https://github.com/ClimateCompatibleGrowth/clicSANDMac/releases, unzip and double-click on clicSANDMac.app to launch. If you experience permission issues, refer to https://stackoverflow.com/a/65010167/9704090
