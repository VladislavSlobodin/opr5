using opr5;

var model = Model.FromFile(@"D:\opr5.txt");
var result = Solver.Solve(model);
Console.WriteLine($"""
    Max profit: {result.Profit}
    {Enumerable.Range(0, result.Coefficients.Count).Select(i => $"Cargo #{i + 1} is taken {result.Coefficients[i]} time{(result.Coefficients[i] != 1 ? "s" : string.Empty)}").Join("\n")}
    """);