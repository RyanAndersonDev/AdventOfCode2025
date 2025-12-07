using System.Security.AccessControl;

public static class PartOne 
{
    public static int FormatRawString(string inputString) 
    {
        // I think we can assume it will always start with L or R, followed immediately by numbers
        string intString = inputString.Substring(1);

        if (int.TryParse(intString, out int trueNum)) 
        {
            if (inputString.StartsWith("L")) 
            {
                trueNum *= -1;
            }

            return trueNum;
        }

        return 0;
    }

    public static (int newNum, int zeroInstances) SpinTheDialToNewNum(int changeNum, int currentNum)
    {
        int tracking = changeNum + currentNum;
        int fullSpins = Math.Abs(tracking / 100);
        int amtOfZeros = 0;

        if (tracking == 0)
        {
            amtOfZeros = 1;
        }
        else if (tracking < 0)
        {
            if (fullSpins == 0 && currentNum != 0)
            {
                amtOfZeros = 1;
            }
            else
            {
                amtOfZeros = fullSpins;
            }

            do
            {
                tracking += 100;
                changeNum += 100;
            } 
            while (tracking < 0 && changeNum < 0);
        }
        else if (tracking > 99)
        {
            if (fullSpins == 0 && currentNum != 0)
            {
                amtOfZeros = 1;
            }
            else
            {
                amtOfZeros = fullSpins;
            }

            do
            {
                tracking -= 100;
                changeNum -= 100;

                fullSpins--;
            }
            while (/*tracking > 0 && changeNum > 0*/fullSpins > 0);
        }

        return (tracking, amtOfZeros);        
    }
}