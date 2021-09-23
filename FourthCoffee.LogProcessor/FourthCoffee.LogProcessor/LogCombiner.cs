using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace FourthCoffee.LogProcessor
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.LogProcessor.LogCombiner" /> class in the object model.
    /// </summary>
    public class LogCombiner
    {
        LogLocator _locator;

        /// <summary>
        /// Create an instance of the LogCombiner class.
        /// </summary>
        /// <param name="locator">The LogLocator object.</param>
        public LogCombiner(LogLocator locator)
        {
            if (locator == null)
                throw new NullReferenceException("locator");

            this._locator = locator;
        }

        /// <summary>
        /// Combines one or more logfiles into a single log file.
        /// </summary>
        /// <param name="combinedLogPath">The output file path for the combined log file.</param>
        public void CombineLogs(string combinedLogPath)
        {
            if (File.Exists(combinedLogPath))
                File.Delete(combinedLogPath);

            var logFiles = this._locator.GetLogFilePaths();

            if (logFiles.Count() == 0)
            {
                File.WriteAllText(combinedLogPath, "No log files to combine.");
            }
            else
            {
                this.WriteFileHeading(combinedLogPath);

                foreach (var logFile in logFiles)
                    this.WriteLog(combinedLogPath, logFile);
            }
        }

        public void ArchiveLog(string archivePath)
        {
            var logFiles = this._locator.GetLogFilePaths();
            var zip = ZipFile.Open(archivePath, ZipArchiveMode.Create);
            foreach (var file in logFiles)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            zip.Dispose();
        } 

        private void WriteFileHeading(string combinedLogPath)
        {
            var heading = new List<string>();
            heading.Add("########################################");
            heading.Add("######### Combined Log File ############");
            heading.Add("########################################");

            var fileStream = new FileStream(combinedLogPath, FileMode.Create);

            //foreach (var line in heading) {
            //    var bytes = Encoding.ASCII.GetBytes(line);
            //    fileStream.Write(bytes, 0, bytes.Length);
            //}

            var streamWriter = new StreamWriter(fileStream);
            foreach (var line in heading)
                streamWriter.WriteLine(line);

            streamWriter.Dispose();

            fileStream.Dispose();

            //File.WriteAllLines(combinedLogPath, heading);
        }

        private void WriteLog(string combinedLogPath, string logPath)
        {
            var logName = Path.GetFileNameWithoutExtension(logPath);
         

            if (logName.Equals("combinedlog"))
                return;

            var logText = this.GetLogFileText(logPath);

            var logContent = new List<string>();
            logContent.Add("");
            logContent.Add(string.Format("######### [{0}]", logName));
            logContent.Add(logText);
            logContent.Add("");

            File.AppendAllLines(combinedLogPath, logContent);
        }

        private string GetLogFileText(string logPath)
        {
            var logText = File.ReadAllText(logPath);

            if (string.IsNullOrEmpty(logText))
            {
                logText = "No entries";
            }

            return logText;
        }
    }
}
