using Euler.Console;

int number;

do
{
    Console.WriteLine("\nHello friend, which solution do you want to see? Enter 6666 for exit :) ");
    number = Convert.ToInt32(Console.ReadLine());
    var answer = GetAnswer(number);
    Console.WriteLine("Problem Defination: " + answer.Defination);
    Console.WriteLine(answer.MyMessage);
    Console.WriteLine("Answer Response: " + answer.Result);
} while (number != 6666);


ProblemResponseModel<dynamic> GetAnswer(int problemNo)
{
    var methodName = "GetAnswer" + problemNo;

    var type = typeof(Solution);
    var method = type.GetMethod(methodName);
    if (method == null) return GetNotInitializedAnswer();

    return (ProblemResponseModel<dynamic>) method.Invoke(null, null)!;
}


ProblemResponseModel<dynamic> GetNotInitializedAnswer()
{
    return new ProblemResponseModel<dynamic>
    {
        Defination = "No problem found, for yet :)",
        Result = "no problem no result"
    };
}