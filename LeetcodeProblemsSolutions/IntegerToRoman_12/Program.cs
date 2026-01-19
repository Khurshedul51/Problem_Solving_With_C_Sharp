// See https://leetcode.com/problems/integer-to-roman/description/ for problem description

using System.Text;

namespace IntegerToRoman_12;

public class Solution
{
    private static StringBuilder resultSb = new();
    private static int numberTemp;
    private static void StartsWithoutFourAndNine()
    {
        if (numberTemp >= 1000)
        {
            resultSb.Append('M');
            numberTemp -= 1000;
        }
        else if (numberTemp >= 500)
        {
            resultSb.Append('D');
            numberTemp -= 500;
        }
        else if (numberTemp >= 100)
        {
            resultSb.Append('C');
            numberTemp -= 100;
        }
        else if (numberTemp >= 50)
        {
            resultSb.Append('L');
            numberTemp -= 50;
        }
        else if (numberTemp >= 10)
        {
            resultSb.Append('X');
            numberTemp -= 10;
        }
        else if (numberTemp >= 5)
        {
            resultSb.Append('V');
            numberTemp -= 5;
        }
        else
        {
            resultSb.Append('I');
            numberTemp -= 1;
        }
    }
    private static void StartsWithNine()
    {
        if (numberTemp >= 900)
        {
            resultSb.Append("CM");
            numberTemp -= 900;
        }
        else if (numberTemp >= 90)
        {
            resultSb.Append("XC");
            numberTemp -= 90;
        }
        else if(numberTemp >= 9)
        {
            resultSb.Append("IX");
            numberTemp -= 9;
        }
    }
    private static void StartsWithFour()
    {
        if (numberTemp >= 400)
        {
            resultSb.Append("CD");
            numberTemp -= 400;
        }
        else if (numberTemp >= 40)
        {
            resultSb.Append("XL");
            numberTemp -= 40;
        }
        else if (numberTemp >= 4)
        {
            resultSb.Append("IV");
            numberTemp -= 4;
        }
    }
    private static string IntToRoman(int number)
    {
        numberTemp = number;

        while (numberTemp > 0)
        {
            var numberStr = numberTemp.ToString();

            if (numberStr[0] != '4' && numberStr[0] != '9')
            {
                StartsWithoutFourAndNine();
            }
            else if( numberStr[0] == '9')
            {
                StartsWithNine();
            }
            else if (numberStr[0] == '4')
            {
                StartsWithFour();
            }
        }

        return resultSb.ToString();
    }
    public static void Main(string[] args)
    {
        var number = 3749;
        Console.WriteLine(IntToRoman(number));
    }
}