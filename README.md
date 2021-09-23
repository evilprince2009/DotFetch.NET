## DotFetch.NET

### DotNet version of DotFetch , Written in C# rather than PowerShell

_DotFetch.NET_ is basically .NET port of _[DotFetch](https://github.com/evilprince2009/DotFetch)_ which is re-written in C#. If you want to take a look at original _DotFetch_ , you can find it _**[here](https://github.com/evilprince2009/DotFetch)**_. _DotFetch.NET_ displays information about your operating system, software and hardware in an way similar to _DotFetch_ , but it's little more time efficient than original _DotFetch_.

![DotFetch.NET](<https://github.com/evilprince2009/DotFetch/blob/main/Screenshot%20(55).png>)

### This is how it looks like

### [Download Source Code](https://github.com/evilprince2009/DotFetch.NET) it here

### Installation

Follow these simple steps to install DotFetch:

- Set your execution policy to RemoteSigned by running `Set-ExecutionPolicy RemoteSigned` on an Administrative instance of PowerShell. This is required to run DotFetch.
- Download the files from provided link and extract them.
- Put the `dotfetch.net.exe` inside the `C:\Program Files\WindowsPowerShell\Scripts` directory. Don't worry , there is nothing malicious.
- Put this directory `C:\Program Files\WindowsPowerShell\Scripts` into path under Environment Variables.
- Now open PowerShell & type `notepad $profile`.
- Put below line inside the file and save.

```
dotfetch.net.exe
```

- Re-Launch PowerShell & you are good to go.

#### [Ibne Nahian](https://evilprince2009.netlify.app/)
