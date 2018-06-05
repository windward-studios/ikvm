# Windward IKVM

## Build

See HOWTO for the build instructions.

**A note on using NAnt**.  If you encounter a System.Security.SecurityException
while running nant, apply the following fix.

From [stackoverflow](https://stackoverflow.com/questions/8605122/how-do-i-resolve-configuration-errors-with-nant-0-91)

> I found that the problem was Windows security related in that the downloaded
> NAnt zip file needed additional security related configuration to be performed:
> before extracting, one must right click on the zip file, select Properties and
> under the General tab, click the button labelled Unblock, the click OK on the
> Properties window.  Now, extract the file to your desired location.

To build a debug version of IKVM assemblies, execute

```nant -D:debug=true```
