using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo();
        }

        static void Foo()
        {
            Bar();
        }

        static void Bar()
        {
            DebugEx.CallerInfo = DebugOutputCallerInfo.Time | DebugOutputCallerInfo.MemberName;
            DebugEx.WriteLine("buz");
        }
    }
}
