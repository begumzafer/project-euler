using Euler.Console;
using Euler.Console.Solutions;

int number;

do
{
    Console.WriteLine("Hello friend, which solution do you want to see? Enter 6666 for exit :) ");
    number = Convert.ToInt32(Console.ReadLine());
    var answer = GetAnswer(number);
    Console.WriteLine("Problem Defination: " + answer.Defination);
    Console.WriteLine(answer.MyMessage);
    Console.WriteLine("Answer Response: " + answer.Result);
} while (number != 6666);


ProblemResponseModel<dynamic> GetAnswer(int problemNo)
{
    return problemNo switch
    {
        1 => Problem1.GetAnswer(),
        2 => Problem2.GetAnswer(),
        3 => Problem3.GetAnswer(),
        4 => Problem4.GetAnswer(),
        _ => GetNotInitializedAnswer()
    };
}

ProblemResponseModel<dynamic> GetNotInitializedAnswer()
{
    return new ProblemResponseModel<dynamic>
    {
        Defination = "No problem found, for yet :)",
        Result = "no problem no result"
    };
}