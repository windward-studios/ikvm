# Windward IKVM

## Build

See HOWTO for the build instructions.  The quick start is

- Install NAnt (https://sourceforge.net/projects/nant/files/nant/0.92/).

**A note on using NAnt**.  If you encounter a System.Security.SecurityException
while running nant, apply the following fix.

From [stackoverflow](https://stackoverflow.com/questions/8605122/how-do-i-resolve-configuration-errors-with-nant-0-91)

> I found that the problem was Windows security related in that the downloaded
> NAnt zip file needed additional security related configuration to be performed:
> before extracting, one must right click on the zip file, select Properties and
> under the General tab, click the button labelled Unblock, the click OK on the
> Properties window.  Now, extract the file to your desired location.

- Must be set to use JDK 7 (not 8 or later).

- Download ICSharpCode.SharpZipLib.dll (http://www.icsharpcode.net/opensource/sharpziplib/) and copy to the bin folder.

- Download openjdk-7u6-b24 (https://sourceforge.net/projects/ikvm/files/ikvm/7.2.4630.5/) and unpack in the peer folder to ikvm.

- In the root folder run nant.

```nant```

Produces a release build.

```nant -D:debug=true```

Produces a debug build with all. pdb files in the bin folder.

## Package NuGet

- build the project as normal
- from the nuget directory run these commands
- nant IKVM.nuspec
- nant nupkg