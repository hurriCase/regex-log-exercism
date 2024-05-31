using System;
using System.Text.RegularExpressions;

static class LogLine
{
    private static Match CaptureString(string logLine) =>
        Regex.Match(logLine, @"\[(?<logLevel>INFO|WARNING|ERROR)\]:\s(?<message>.*)");
    public static string Message(string logLine) => CaptureString(logLine).Groups["message"].ToString().Trim();

    public static string LogLevel(string logLine) => CaptureString(logLine).Groups["logLevel"].ToString().ToLower();

    public static string Reformat(string logLine) => $"{Message(logLine)} ({LogLevel(logLine)})";
}
