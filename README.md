# Windward IKVM

## Build

See HOWTO for the build instructions.  A note on using NAnt.  It didn't work
out of the box and few changes were needed to NAnt.exe.config.

Replace the line

```xml
<section name="nant" type="NAnt.Core.ConfigurationSection, NAnt.Core" />
```

with

```xml
<section name="nant" type="NAnt.Core.ConfigurationSection, NAnt.Core" requirePermission="false" />
```

Make sure that

```xml
<supportedRuntime version="v2.0.50727" />
```

is listed first in the `<startup>` section.


To build a debug version of IKVM assemblies, execute

```nant -D:debug=true```
