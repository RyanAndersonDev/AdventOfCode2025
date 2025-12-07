using System;
using System.IO;

class Program {
    static void Main() 
    {
        Run(50);
    }

    static void Run(int startingNum) 
    {
        int answer = SolvePartOne(startingNum);
        Console.WriteLine(answer);
    }

    static int SolvePartOne(int startingNum) 
    {        
        int zeroCounter = 0;
        int currentNum = startingNum;
        int lineCounter = 0;

        foreach (string line in File.ReadAllLines("C:/Users/ryana/source/repos/AdventOfCode2025/Day01/input.txt")) 
        {
            Console.WriteLine($@"Parsed {++lineCounter} rows. Current Number: {currentNum}, changing by {line}.");

            int numToMove = PartOne.FormatRawString(line);
            currentNum = PartOne.SpinTheDialToNewNum(numToMove, currentNum);

            if (currentNum == 0)
            {
                zeroCounter++;
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!! FOUND A ZERO !!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

            Console.WriteLine($@"New number is {currentNum}");
        }

        return zeroCounter;
    }
}