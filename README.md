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
 + Added an easter egg
 + Removed SwingAWT Remap
 + 5 passes of expiremental optimization in OpenJDK library
 + Controllable optimization level
 + Optimization in IKVM Dynamic Launcher
 + Optimize encodings in dynamic mode to save RAM
 + Optimize branch sizes in dynamic mode to save RAM
 + Refactored OpenJDK Library build
 + Removed allsources.lst
 + Slight speedup for IKVMC and ikvmstub
 + Bumped version to 8.5.1.0
 + Added ikvmw.exe - the IKVM equivalent of javaw.exe

## List of changes Jessie Lesbian want to make

 + MORE OPTIMIZATIONS!
 + Fully support Swing and AWT
 + Play Minecraft with this IKVM.NET fork

## Build

step 1: extract the repository

step 2: add your MSVC and .NET toolchains to your path environmental variable

step 3: run build.bat

NOTE: The built-in NANT tool may not work if you extract using windows explorer's built-in ZIP extractor due to some stupid security measures. You may need to unblock the archive in properties or extract using 7-zip.

If you hate building or can't build, don't worry, you will still experience the Java Virtual Machine made in C#. The cute-looking Jessie Lesbian had built all of this herself just in case you don't want to or can't build.

[download](https://github.com/jessielesbian/ikvm/releases/download/8.5.1.0/ikvm_8.5.1.0_bin_windows.zip)

If you have a problem or an opinion, please send an email to jessielesbian@protonmail.com or go to https://www.reddit.com/r/IKVM/.

NOTE: The official build doesn't come with proper JNI support.

## About OpenJDK.NET: The OpenJDK port for Microsoft.NET made by Jessie Lesbian

OpenJDK.NET is an OpenJDK port for Microsoft.NET made by Jessie Lesbian. It contains 6 JDK tools: javac, javah, javap, jar, native2ascii, and rmic. It is currently an experimental feature and may not work.
