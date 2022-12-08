using System.Diagnostics;

namespace Euler.Console.Solutions;

public static class Problem4
{
    private class PalindromeModel
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Palindrome { get; set; }
    }

    public static ProblemResponseModel<dynamic> GetAnswer()
    {
        var sw = new Stopwatch();
        sw.Start();
        var palindromes = new List<PalindromeModel>();
        for (var i = 999; i >= 900; i--)
        {
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

    private static bool IsPalindrome(string x)
    {
        var reverted = new string(x.Reverse().ToArray());
        return x.Equals(reverted);
    }
}