[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Verimor.NET/blob/main/LICENSE.md)

# Verimor.NET
An easy-to-use verimor.com.tr API with .NET

# Installation
```bash
dotnet add package Verimor --version 1.0.0
```

# Usage
```c#
using Verimor;

var verimor = new Verimor();
verimor.SetUsercode("api usercode");
verimor.SetPassword("api password");
verimor.Sms("message header", "phone number", "message"); // Sending SMS message
```
