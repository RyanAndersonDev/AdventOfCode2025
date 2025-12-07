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

    public static int SpinTheDialToNewNum(int changeNum, int currentNum)
    {
        int tracking = changeNum + currentNum;
        int fullSpins = Math.Abs(tracking / 100);

        if (tracking < 0)
        {
            for (int i = 0; i <= fullSpins; i++)
            {
                if (i + 1 == fullSpins)
                {
                    tracking += 100;
                    break;
                }

                tracking += 100;
                changeNum += 100;
            }
        }
        else if (tracking > 99)
        {
            for (int i = 0; i <= fullSpins; i++)
            {
                if (i + 1 == fullSpins)
                {
                    tracking -= 100;
                    break;
                }

                tracking -= 100;
                changeNum -= 100;
            }
        }

        return tracking;        
    }
}