namespace opr5;

public record Model(int MaxWeight, List<int> Weights, List<int> Profits)
{
    public static Model FromFile(string path)
    {
        var text = File.ReadAllLines(path);
        var maxWeight = int.Parse(text[0]);
        var weights = text[1].Split(' ').Select(int.Parse).ToList();
        var profits = text[2].Split(' ').Select(int.Parse).ToList();
        return new Model(maxWeight, weights, profits);
    }
}