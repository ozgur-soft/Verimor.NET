# Verimor.NET
An easy-to-use verimor.com.tr API with .NET

# Installation
```bash
dotnet add package Verimor --version 1.1.0
```

# Usage
```c#
namespace Verimor {
    internal class Program {
        static void Main(string[] args) {
            var verimor = new Verimor();
            verimor.SetUsername("api username");
            verimor.SetPassword("api password");
            var messages = new List<Verimor.Message> { };
            messages.Add(new() { Msg = "message", No = "905551234567" });
            verimor.Sms("header", messages);
        }
    }
}
```
