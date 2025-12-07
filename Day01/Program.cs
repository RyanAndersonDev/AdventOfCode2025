using System;
using System.IO;

class Program {
    static void Main() 
    {
        Run(50);
    }

    static void Run(int startingNum) 
    {
        // int answer1 = SolvePartOne(startingNum);
        // Console.WriteLine(answer1);
        int answer2 = SolvePartTwo(startingNum);
        Console.WriteLine(answer2);
    }

    static int SolvePartOne(int startingNum, bool isPartTwo = false) 
    {        
        int zeroCounter = 0;
        int currentNum = startingNum;
        int lineCounter = 0;

        foreach (string line in File.ReadAllLines("C:/Users/ryana/source/repos/AdventOfCode2025/Day01/input.txt")) 
        {
            Console.WriteLine();
            Console.WriteLine($@"Parsed {++lineCounter} rows. Current Number: {currentNum}, changing by {line}.");

            int numToMove = PartOne.FormatRawString(line);
            (int currentNum, int zeroInstances) results = PartOne.SpinTheDialToNewNum(numToMove, currentNum);
            currentNum = results.currentNum;

            if (isPartTwo)
            {
                zeroCounter += results.zeroInstances;
                Console.WriteLine($@"{results.zeroInstances} added during this spin.");
            }

            Console.WriteLine($@"New number is {currentNum}");
            if (currentNum < 0 || currentNum > 99)
            {
                Console.WriteLine("problem!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            } 
            Console.WriteLine($@"Updated spin count: {zeroCounter}");
        }

        return zeroCounter;
    }

    static int SolvePartTwo(int startingNum)
    {
        return SolvePartOne(startingNum, true);
    }
}