using desktopBlazorWAKicker;
using System.Diagnostics;

int port = 19190;
string root = Directory.GetCurrentDirectory();

if( args.Length >= 1)
{
    if( !int.TryParse(args[0],out port) ) usage();
}
if( args.Length >= 2) root = args[1];
if( args.Length >= 3) usage();

var httpServer = new HttpServer(root,port);
httpServer.Start();

url.kickUrl($"http://localhost:{port}/");

Console.WriteLine("Type Enter to End");
Console.ReadLine();

httpServer.Stop();

void usage()
{
    Console.WriteLine("usage: desktopBlazorWAKicker [[portNumber] blazorProgramRoot]");
    Process.GetCurrentProcess().Kill();
}