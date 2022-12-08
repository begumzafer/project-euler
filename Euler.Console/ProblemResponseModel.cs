namespace Euler.Console;

public class ProblemResponseModel<T>
{
    public string Defination { get; set; } = null!;
    public string? MyMessage { get; set; }
    public T? Result { get; set; } = default!;
}