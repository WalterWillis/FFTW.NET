# FFTW.NET
C#/.NET wrapper for FFTW (http://www.fftw.org/)

## Installation
Install NuGet package: https://www.nuget.org/packages/FFTW.NET
or
Download the FFTW binaries ("libfftw3-3.dll") from http://www.fftw.org/download.html,
rename them to "libfftw3-3-x86.dll" and "libfftw3-3-x64.dll" and put them in your application directory.
FFTW.NET will automatically load the right one.
This is currently only tested for Windows, but it also should work on other platforms using Mono.
(Of course you would need the appropriate platform specific FFTW binaries.)

## Help
See TestApp/Program.cs for examples on how to use it.
Altough you should be able to use it from looking at the examples,
for a better understanding on how to use it efficiently, it is highly recommended
that you gain a little insight on how FFTW works: http://www.fftw.org/doc/index.html

## Array classes
There are three array classes which you can use to perform transformations:
* AlignedArray<T>: This class guarantees a certain memory alignment.
  This should be the default class to use.
* PinnedArray<T>: Use this class if you want to use an existing .NET array and
  want to avoid copying memory. The drawback is, that the .NET array might not
  be aligned on a 16 bytes boundary and thus FFTW cannot use SIMD.
* FftwArray<T>: This class allocates unmanaged memory using fftw_malloc.
  This class was somewhat rendered obsolete by the introduction of AlignedArray<T>.

If none of these fit your needs, you can always create your own by
implementing the IPinnedArray<T> interface.

## License
FFTW is licensed under the GNU GPL, therefore FFTW.NET as a whole adapts this license.
However, if for some reason you want to use classes/code from this project
without using FFTW, you are free to do so under the Microsoft Reciprocal License (MS-RL).

## Modifications
This library has been slightly modified to support ARM processors, specifically for the Raspberry Pi.
This code was forked and is being used in a .Net Core program that uses the FFT functions to send a summary of accelerometer peaks via Telemetry for a RockSat-X project.

On Raspberry Pi, the user will need to use:

sudo apt-get install libfftw3-3

sudo apt-get install libfftw3-dev

The latter specifically has the files needed for this.

Merely build the project and copy the FFTW.NET.dll manually and use as a reference/dependency. Or just replace the one in your program with this one on the raspberry pi.
