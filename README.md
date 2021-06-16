# KworkClient
Unofficial .NET Client for kwork.com

It is a simple library for working with kwork.com
[Documentation](https://homakz93.gitbook.io/documentation/)
#### Example:
```c#
    using Kwork;
    class Program
    {
        public static KworkClient client = new KworkClient(Login: "TestAccount2886", Password: "TestAccount2886Password");

        static void Main(string[] args)
        {


            client.OnMessage += NewMsg;
            client.StartReceiving();

            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();
        }
        public static void NewMsg(Kwork.Types.Updates.KworkUpdateNewInbox msg)
        {
            client.SendMessage(user_id: msg.from, text: "Do you need a bot?\nYou can look at examples of already done");
        }
    }
```
