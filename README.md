# Verimor.NET
An easy-to-use verimor.com.tr API with .NET

# Installation
```bash
dotnet add package Verimor --version 1.2.1
```

# Usage
```c#
namespace Verimor {
    internal class Program {
        static void Main(string[] args) {
            var verimor = new Verimor();
            verimor.SetUsername("api username");
            verimor.SetPassword("api password");
            var messages = new List<Verimor.Message> {
                new() { Msg = "message", No = "905551234567" }
            };
            var sent = verimor.Sms("header", messages);
            if (sent) {
                Console.WriteLine("Message sent");
            } else {
                Console.WriteLine("Message not sent");
            }
            var balance = verimor.Balance();
            Console.WriteLine("Balance: " + balance);
        }
    }
}
```
