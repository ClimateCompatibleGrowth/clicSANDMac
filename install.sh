#!/bin/sh
cd ~/Downloads
#download and install cbc
/usr/bin/curl -# https://ampl.com/dl/open/cbc/cbc-osx.zip -O
unzip cbc-osx.zip -d cbc-osx
install cbc-osx/cbc /usr/local/bin

#download, configure, compile and install glpk
/usr/bin/curl -# https://ftp.gnu.org/gnu/glpk/glpk-5.0.tar.gz -O
/usr/bin/tar -zxvf glpk-5.0.tar.gz
cd glpk-5.0
./configure
make
make install

