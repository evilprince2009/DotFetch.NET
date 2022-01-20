# DotFetch.NET

## DotNet version of DotFetch , Written in C# rather than PowerShell

_DotFetch.NET_ is basically .NET port of _[DotFetch](https://github.com/evilprince2009/DotFetch)_ which is re-written in C#. If you want to take a look at original _DotFetch_ , you can find it _**[here](https://github.com/evilprince2009/DotFetch)**_. _DotFetch.NET_ displays information about your operating system, software and hardware in an way similar to _DotFetch_ , but it's little more time efficient than original _DotFetch_.

### Windows 11

![DotFetch.NET](https://github.com/evilprince2009/DotFetch.NET/blob/main/Images/Screenshot_2.png)

![DotFetch.NET](https://github.com/evilprince2009/DotFetch.NET/blob/main/Images/Screenshot_3.png)

### This is how it looks like

### Build DotFetch.NET from Source Code

- Clone DotFetch.NET source code and build it using Visual Studio.
- Build DotFetch.NET using `dotnet restore` and `dotnet build` command respectively on command line.

_**Note:- .NET 6.0 is required to build DotFetch.NET**_

### [Download Binary](https://github.com/evilprince2009/DotFetch.NET)

### Installation

Follow these simple steps to install _**DotFetch.NET**_:

- Set your execution policy to RemoteSigned by running `Set-ExecutionPolicy RemoteSigned` on an Administrative instance of PowerShell.
- Download the `DotFetch.Binary.rar` file from _**[here](https://github.com/evilprince2009/DotFetch.NET/releases/tag/v1.0.0)**_ and extract the `DotFetch Binary` folder. This folder contains all the required binary files to run `DotFetch.NET`. Alternatively, you can build `DotFetch.NET` from source code and use the _.exe_.
- Move the `DotFetch Binary` folder somewhere you prefer. For example, you can move it to your `C:\Program Files` folder. Don't delete or rename any file in the `DotFetch Binary` folder.
- Put the directory path till `DotFetch Binary` folder into path under Environment Variables. For example, if you moved the `DotFetch Binary` folder to `C:\Program Files\` , you need to put `C:\Program Files\DotFetch Binary` into path under Environment Variables.
- Now open PowerShell & type `notepad $profile`.
- Put below line inside the file and save.

```
DotFetch.NET
```

- Re-Launch PowerShell & you are good to go.

### What if there is a bug ?

- If you find any bug in _**DotFetch.NET**_ , you are requested to submit a issue with error messages and diagnostic information.

### If you want to look your Terminal even more beautiful

You can go through this _**[Repository](https://github.com/evilprince2009/Windows-Terminal-Customization)**_ to customize your Terminal.

### [Ibne Nahian](https://evilprince2009.netlify.app/)
