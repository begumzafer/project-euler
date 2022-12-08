namespace Euler.Console.Solutions;

public class Problem2
{
    public static ProblemResponseModel<dynamic> GetAnswer()
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
}