using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Input_Data_Formatter
{
    public static class Program
    {
        private static bool interactiveConsoleMode = false;
        [STAThread]
        private static void Main(string[] args)
        {
            string userChoice;
            int itemsPerRow;
            if (args.Length == 2)
            {
                userChoice = args[0];
                itemsPerRow = int.Parse(args[1]);
            }
            else
            {
                Console.WriteLine("Format output as: ");
                Console.WriteLine("  1. [S]tring");
                Console.WriteLine("  2. [I]ntegers");
                Console.Write("---> ");
                userChoice = Console.ReadLine();

                Console.WriteLine("Items per row: ");
                Console.Write("---> ");
                itemsPerRow = int.Parse(Console.ReadLine());
            }

            string inputData = Clipboard.GetText();
            inputData = Regex.Replace(inputData, @"\r\n", "|");

            switch (userChoice.ToLower())
            {
                case "1":
                case "s":
                    Clipboard.SetText(GetFormattedData(inputData, itemsPerRow, true));
                    break;
                case "2":
                case "i":
                    Clipboard.SetText(GetFormattedData(inputData, itemsPerRow, false));
                    break;
            }

            if (!interactiveConsoleMode)
            {
                Console.Clear();
                Console.WriteLine("Formatted data copied to clipboard.");
            }
        }

        private static List<string> ParseRawInput(string inputString) =>
            inputString.Replace("\"", "")
                .Split(new[] { '|' })
                .Select(input => input.TrimStart())
                .ToList();

        private static string GetFormattedData(string inputString, int itemsPerRow, bool formatAsStrings)
        {
            List<string> inputStrings = ParseRawInput(inputString);
            string lineBuffer = "            "; // 3 "tabs" worth of spaces
            string outputString = string.Empty;
            int currentRowItemCount = 0;

            if (formatAsStrings)
            {
                foreach (string inputItem in inputStrings)
                {
                    currentRowItemCount++;

                    outputString += $"\"{inputItem}\", ";
                    if (currentRowItemCount == itemsPerRow)
                    {
                        outputString = outputString.TrimEnd(' ');
                        outputString += Environment.NewLine;
                        outputString += lineBuffer;
                        currentRowItemCount = 0;
                    }
                }
            }
            else
            {
                foreach (string inputItem in inputStrings)
                {
                    currentRowItemCount++;

                    outputString += $"{inputItem}, ";
                    if (currentRowItemCount == itemsPerRow)
                    {
                        outputString = outputString.TrimEnd(' ');
                        outputString += Environment.NewLine;
                        outputString += lineBuffer;
                        currentRowItemCount = 0;
                    }
                }
            }

            outputString.Trim();

            return outputString;
        }

        public static void GetFormattedData(int format, int maxItemsPerRow)
        {
            string[] args = { format.ToString(), maxItemsPerRow.ToString() };
            interactiveConsoleMode = true;
            Main(args);
        }
    }
}
