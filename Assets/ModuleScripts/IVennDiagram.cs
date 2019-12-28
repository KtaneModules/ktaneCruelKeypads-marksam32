using System.Collections.Generic;
using System.Linq;

public enum VennDiagram
{
    A = 0,
    B = 1,
    C = 2,
    D = 3,
    E = 4,
    F = 5
}

public interface IVennDiagram
{
    VennDiagram Type { get; }
    bool IsMatch(IList<int> circles);
}

public abstract class AbstractVenDiagram : IVennDiagram
{
    public abstract VennDiagram Type { get;  }
    public abstract bool IsMatch(IList<int> cirecles);

    protected bool IsMatch(IList<IList<int>> solutions, IList<int> circles)
    {
        var orderedCircles = circles.OrderBy(x => x).ToList();
        var count = circles.Count;
        var possibleSolutions = solutions.Where(x => x.Count == count).ToList();

        if (!possibleSolutions.Any())
        {
            return false;
        }

        foreach (var possibleSolution in possibleSolutions)
        {
            var same = true;
            for (var i = 0; i < count; ++i)
            {
                if (orderedCircles[i] != possibleSolution[i])
                {
                    same = false;
                    break;
                }
            }

            if (same)
            {
                return true;
            }
        }

        return false;
    }
}

public class VennDiagramA : AbstractVenDiagram
{
    private readonly IList<IList<int>> Solution = new List<IList<int>>
    {
        new List<int> { 1, 2, 3},
        new List<int> { 1, 2, 4},
        new List<int> { 1, 3, 4}
    };

    public override VennDiagram Type
    {
        get
        {
            return VennDiagram.A;
        }
    }

    public override bool IsMatch(IList<int> circles)
    {
        return IsMatch(Solution, circles);
    }
}

public class VennDiagramB : AbstractVenDiagram
{
    private readonly IList<IList<int>> Solution = new List<IList<int>>
    {
        new List<int>{},
        new List<int>{2},
        new List<int>{3}
    };

    public override VennDiagram Type
    {
        get
        {
            return VennDiagram.B;
        }
    }

    public override bool IsMatch(IList<int> circles)
    {
        return IsMatch(Solution, circles);
    }
}

public class VennDiagramC : AbstractVenDiagram
{
    private readonly IList<IList<int>> Solution = new List<IList<int>>
    {
        new List<int>{1},
        new List<int>{1, 2, 3, 4},
        new List<int>{2, 4}
    };

    public override VennDiagram Type
    {
        get
        {
            return VennDiagram.C;
        }
    }

    public override bool IsMatch(IList<int> circles)
    {
        return IsMatch(Solution, circles);
    }
}

public class VennDiagramD : AbstractVenDiagram
{
    private readonly IList<IList<int>> Solution = new List<IList<int>>
    {
        new List<int>{1, 2},
        new List<int>{3, 4},
        new List<int>{1, 4}
    };

    public override VennDiagram Type
    {
        get
        {
            return VennDiagram.D;
        }
    }

    public override bool IsMatch(IList<int> circles)
    {
        return IsMatch(Solution, circles);
    }
}

public class VennDiagramE : AbstractVenDiagram
{
    private readonly IList<IList<int>> Solution = new List<IList<int>>
    {
        new List<int>{2, 3},
        new List<int>{2, 3, 4}
    };

    public override VennDiagram Type
    {
        get
        {
            return VennDiagram.E;
        }
    }

    public override bool IsMatch(IList<int> circles)
    {
        return IsMatch(Solution, circles);
    }
}

public class VennDiagramF : AbstractVenDiagram
{
    private readonly IList<IList<int>> Solution = new List<IList<int>>
    {
        new List<int>{4},
        new List<int>{1, 3}
    };

    public override VennDiagram Type
    {
        get
        {
            return VennDiagram.F;
        }
    }

    public override bool IsMatch(IList<int> circles)
    {
        return IsMatch(Solution, circles);
    }
}
