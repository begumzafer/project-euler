using System.Diagnostics;

namespace Euler.Console;

public class Solution
{
    public static ProblemResponseModel<dynamic> GetAnswer1()
    {
        const int max = 1000;
        var sum = 0;

        for (var i = 1; i < max; i++)
            if (i % 3 == 0 || i % 5 == 0)
                sum += i;

        return new ProblemResponseModel<dynamic>
        {
            Defination =
                "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.Find the sum of all the multiples of 3 or 5 below 1000",
            MyMessage = "",
            Result = sum
        };
    }

    public static ProblemResponseModel<dynamic> GetAnswer2()
    {
        var x = 0;
        var y = 1;
        int z;
        var sum = 0;
        do
        {
            z = x + y;
            x = y;
            y = z;
            if (y % 2 == 0) sum += y;
        } while (y <= 4000000);

        return new ProblemResponseModel<dynamic>
        {
            Defination =
                "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.",
            MyMessage = "",
            Result = sum
        };
    }

    public static ProblemResponseModel<dynamic> GetAnswer3()
    {
        var x = 600851475143;
        var i = 2;

        while (true)
        {
            while (x % i == 0)
            {
                if (i == x) break;
                x /= i;
            }

            if (i >= x) break;
            i = i == 2 ? 3 : i + 2;
        }


        return new ProblemResponseModel<dynamic>
        {
            Defination = " What is the largest prime factor of the number 600851475143 ?",
            MyMessage = "",
            Result = x
        };
    }

    public static ProblemResponseModel<dynamic> GetAnswer4()
    {
        var sw = new Stopwatch();
        sw.Start();
        var palindromes = new List<PalindromeModel>();
        for (var i = 999; i >= 900; i--)
        for (var j = 999; j >= 900; j--)
        {
            var num = i * j;
            if (!IsPalindrome(num.ToString())) continue;
            palindromes.Add(new PalindromeModel
            {
                Num1 = i,
                Num2 = j,
                Palindrome = num
            });
        }

        var maxPalindrome = palindromes.OrderByDescending(x => x.Palindrome).First();
        sw.Stop();
        System.Console.WriteLine("Max Palindrome:" + maxPalindrome.Num1 + "*" + maxPalindrome.Num2 + "=" +
                                 maxPalindrome.Palindrome);
        return new ProblemResponseModel<dynamic>
        {
            Defination = "Find the largest palindrome made from the product of two 3-digit numbers.",
            MyMessage = "It takes: " + sw.ElapsedMilliseconds,
            Result = maxPalindrome.Palindrome
        };
    }

    private class PalindromeModel
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Palindrome { get; set; }
    }

    private static bool IsPalindrome(string x)
    {
        var reverted = new string(x.Reverse().ToArray());
        return x.Equals(reverted);
    }

    public static ProblemResponseModel<dynamic> GetAnswer5()
    {
        var sw = new Stopwatch();
        sw.Start();

        int LeastCommonMultiple(int a, int b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }

        int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        int SmallestMultiple(int maxDivisor)
        {
            var lcm = 1;

            for (var i = 2; i <= maxDivisor; i++) lcm = LeastCommonMultiple(lcm, i);

            return lcm;
        }

        var smallestMultiple = SmallestMultiple(20);
        sw.Stop();

        return new ProblemResponseModel<dynamic>
        {
            Defination =
                "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20",
            MyMessage = "It takes: " + sw.ElapsedMilliseconds,
            Result = smallestMultiple
        };
    }
}