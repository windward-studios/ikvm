How to build:

1) Install nant (https://sourceforge.net/projects/nant/files/nant/0.92/)

2) Must be set to use JDK 7 (not 8 or later)

3) Copy ICSharpCode.SharpZipLib.dll to bin folder

4) Download openjdk-7u6-b24 (https://sourceforge.net/projects/ikvm/files/ikvm/7.2.4630.5/) and install in a peer folder to ikvm.

5) In root folder run nant

6) After the compilation copy *.pdb files you find in ikvm into ikvm/bin