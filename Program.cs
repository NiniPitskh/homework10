// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
class Program
{
    static void Main()
    {
        // Task 1
        string filePath = "output.txt";

        //ფაილის შექმნა
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        Console.WriteLine("Enter how many lines you want to write");
        int lineCount = int.Parse(Console.ReadLine());

        //ჩაწერა ფაილში
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < lineCount; i++)
            {
                Console.Write("Enter the line: ");
                string line = Console.ReadLine();
                writer.WriteLine(line);
            }
        }
        string lastLine = File.ReadLines(filePath).Last();
        string[] words = lastLine.Split(' ');
        string lastWord = words[words.Length - 1];
        Console.WriteLine("last line: " + lastWord);

        Console.ReadKey();
    }
}


Task 2

Console.Write("Input Number N: ");
int N = int.Parse(Console.ReadLine());
string filePath = "multiplication_table.txt";

ფაილში ჩაწერა
using (StreamWriter writer = new StreamWriter(filePath))
{
    for (int i = 1; i <= 9; i++)
    {
        string line = "";

        for (int j = 1; j <= N; j++)
        {

            line += $"{j} * {i} = {j * i}";


            if (j < N)
            {
                line += " | ";
            }
        }

        writer.WriteLine(line);
    }
}

Console.WriteLine($"The multiplication table was created in the file '{filePath}'.");

Task 3
using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("input string: ");
        string inputString = Console.ReadLine();

        Console.Write("Enter how many equal strings you want(N): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0 || n >= inputString.Length)
        {
            Console.WriteLine("Please enter a valid number (1 to N though)");
            return;
        }

        // სტრინგის გაყოფა N ტოლ სტრინგად
        int splitLength = inputString.Length / n;
        string[] splitStrings = new string[n];

        for (int i = 0; i < n; i++)
        {
            splitStrings[i] = inputString.Substring(i * splitLength, (i == n - 1) ? inputString.Length - (i * splitLength) : splitLength);
        }

        // XML სტრუქტურის შექმნა
        XElement root = new XElement("Root");

        for (int i = 0; i < splitStrings.Length; i++)
        {
            string nodeName = splitStrings[i];
            XElement node = new XElement(nodeName, $"string {i + 1}");
            root.Add(node);
        }

        // XML ფაილის შენახვა
        string xmlFilePath = "output.xml";
        root.Save(xmlFilePath);

        Console.WriteLine($"XML A file was created with the name {xmlFilePath}.");
    }
}

Task 4
using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace BirthdayCountdown
{
    class Program
    {

        public class DateInfo
        {
            public string currentDate { get; set; }
            public string birthday { get; set; }
        }

        static void Main(string[] args)
        {
            string jsonFilePath = "dates.json";

            string filePath = @"C:\Users\49176\source\repos\HomeWork 10\bin\Debug\net8.0";
            string jsonData = File.ReadAllText(filePath);
            DateInfo dateInfo = JsonConvert.DeserializeObject<DateInfo>(jsonData);

            DateTime currentDate = DateTime.Parse(dateInfo.currentDate);
            DateTime birthdayDate = DateTime.Parse(dateInfo.birthday);
            TimeSpan remainingDays = birthdayDate - currentDate;
            Console.WriteLine("remaining days: " + remainingDays.Days);
        }
    }
}
