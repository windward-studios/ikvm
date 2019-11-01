# Jessie Lesbian's IKVM.NET fork (aka Jessie Lesbian's cute-looking .NET-based Java Virtual Machine)

## List of changes Jessie Lesbian made

 + Mono fork of IKVM.reflect
 + Precompiled classpath
 + Easy to use build script
 + Official builds
 + OpenJDK library performance optimizations
 + OpenJDK library base addresses behavior changed
 + Build OpenJDK tools alongside with core
 + OpenJDK library file alignment changed to 4096
 + Added OpenJDK.NET: The OpenJDK port for Microsoft.NET made by Jessie Lesbian
 + Removed excess spaces from response.txt
 + Added more JDK tools: jar, rmic and native2ascii
 + Use JDK tools from sun.tools instead of com.sun.tools when possible
 + Tweaked class loader wrapper for performance
 + Added new IKVMC command-line argument: -experimentaloptimizations
 + Optimized OpenJDK library and tools even more
 + Added an easter egg

## List of changes Jessie Lesbian want to make

 + Fully support Swing and AWT
 + Some tweaks around object, string and throwable
 + Play Minecraft with this IKVM.NET fork

## Build

step 1: extract the repository

step 2: add your MSVC and .NET toolchains to your path environmental variable

step 3: run build.bat

NOTE: The built-in NANT tool may not work if you extract using windows explorer's built-in ZIP extractor due to some stupid security measures. You may need to unblock the archive in properties or extract using 7-zip.

If you hate building or can't build, don't worry, you will still experience the Java Virtual Machine made in C#. The cute-looking Jessie Lesbian had built all of this herself just in case you don't want to or can't build.

[download](https://github.com/jessielesbian/ikvm/releases/download/8.5.0.3b3/ikvm_8.5.0.3b3_bin_windows.zip)

If you have a problem or an opinion, please send me an email. My email is jessielesbian@protonmail.com.

## About OpenJDK.NET: The OpenJDK port for Microsoft.NET made by Jessie Lesbian

OpenJDK.NET is an OpenJDK port for Microsoft.NET made by Jessie Lesbian. It contains 6 JDK tools: javac, javah, javap, jar, native2ascii, and rmic. It is currently an experimental feature and may not work.
