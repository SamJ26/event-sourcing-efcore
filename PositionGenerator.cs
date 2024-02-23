namespace Project;

public static class PositionGenerator
{
    private const int Min = 0;
    private const int Max = 100;

    private static readonly Random s_random = new Random();

    public static Position Get()
    {
        int x = s_random.Next(Min, Max + 1);
        int y = s_random.Next(Min, Max + 1);
        return new Position(x, y);
    }
}