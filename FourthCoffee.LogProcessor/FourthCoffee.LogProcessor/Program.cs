using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.LogProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\20483-Programming-in-C-Sharp-master\Allfiles\Mod06\Democode\Data\Logs";
            var logLocator = new LogLocator(path);
            var logCombiner = new LogCombiner(logLocator);

            logCombiner.CombineLogs($@"{path}\CombinedLog.txt");
            logCombiner.ArchiveLog($@"{path}\archive.zip");
        }
    }
}
