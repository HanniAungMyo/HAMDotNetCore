
using HAMDotNetCore.ConsoleApp;
using HAMDotNetCore.ConsoleApp.HTTPClientExample;
using System.Data;
using System.Data.SqlClient;


//AdoDotNetExample example =new AdoDotNetExample();
//example.Update();
//EFCoreExample ef= new EFCoreExample();
//ef.Read();
HttpClientExample1 http=new HttpClientExample1();
await http.Run();