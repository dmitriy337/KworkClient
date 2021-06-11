# KworkClient
Unofficial .NET Client for kwork.com

It is a simple library for working with kwork.com

#### Example:
```c#
using Kwork;
static void Main(string[] args)
	{
     	KworkClient kworkClient = new KworkClient("<Login>", "<Password>");
      kworkClient.OnMessage += NewMsg;
		  kworkClient.StartReceiving();

      Console.WriteLine("Press any key for exit...");
      Console.ReadKey();
	}
public static void NewMsg(Kwork.Types.Updates.KworkUpdateNewInbox msg)
  {
     kworkClient.SendMessage(user_id:msg.from, text:"Do you need a bot?\nYou can look at examples of already done");    
  }
```
