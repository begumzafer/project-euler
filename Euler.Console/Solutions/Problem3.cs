namespace Euler.Console.Solutions;

public class Problem3
{
    public static ProblemResponseModel<dynamic> GetAnswer()
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
}