namespace opr5;

public static class Solver
{
    private static Model _model = null!;
    private static readonly char BREAKER = '|';

    public static (List<int> Coefficients, int Profit) Solve(Model model)
    {
        _model = model;
        var pathes = Func(0, model.MaxWeight).Select(x => x.Split(BREAKER)).Select(x => x.Select(int.Parse)).ToList();
        var pathValues = pathes.Select(p => _model.Profits.Zip(p, (x, y) => x * y).Sum()).ToList();
        var bestPathValue = pathValues.Max();
        var indexOfBestPath = pathValues.IndexOf(bestPathValue);
        return (pathes[indexOfBestPath].ToList(), bestPathValue);
    }

    private static IEnumerable<string> Func(int index, int weight)
    {
        var count = weight / _model.Weights[index] + 1;
        return index == _model.Weights.Count - 1
            ? Enumerable.Range(0, count).Select(x => x.ToString())
            : Enumerable.Range(0, count).Select(x => Func(index + 1, weight - x * _model.Weights[index]).Select(y => $"{x}{BREAKER}{y}")).SelectMany(x => x);
    }
}