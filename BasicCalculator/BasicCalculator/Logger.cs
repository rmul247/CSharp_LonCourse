﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    public enum LogType
    {
        Basic,
        Verbose
    }
    public static class Logger
    {
        private static readonly string _logPath = AppDomain.CurrentDomain.BaseDirectory;
        
        private static StreamWriter _logFile = null;
        
        public static void Log(string textToLog)
        {
            try
            {
                FileInfo fi = new FileInfo(_logPath + "BasicCalculatorLog.txt");
                fi.IsReadOnly = false;

                _logFile = new StreamWriter(_logPath + "BasicCalculatorLog.txt", true);

                _logFile.WriteLine(DateTime.Now.ToString() + ": " + textToLog);

            }
            catch (UnauthorizedAccessException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning: " + ex.Message);
                Console.ResetColor();
            }
            finally
            {
                _logFile?.Close();

            }

        }

        public static void Log(Exception ex, LogType logType)
        {

            try
            {
                FileInfo fi = new FileInfo(_logPath + "BasicCalculatorLog.txt");
                fi.IsReadOnly = false;


                _logFile = new StreamWriter(_logPath + "BasicCalculatorLog.txt", true);

                if (logType == LogType.Basic)
                {
                    _logFile.WriteLine($"Date: {DateTime.Now}, Exception name: {ex.GetType().Name}, Error message: {ex.Message}");
                }
                else if (logType == LogType.Verbose)
                {
                    _logFile.WriteLine($"Date: {DateTime.Now}, Exception name: {ex.GetType().Name}, Error message: {ex.Message}, Inner exception message: {ex.InnerException?.Message}, Stack trace: {ex.StackTrace}");

                    if (ex is ArgumentException)
                    {
                        _logFile.Write($", ParamName: {((ArgumentException)ex).ParamName}");
                    }
                }
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning: " + ex.Message);
                Console.ResetColor();

            }
            finally
            {
                _logFile?.Close();

            }


        }
    }
}
