namespace TAAS.Units;

public class Idefix
{
    public Board Board;

    public Idefix(Board board)
    {
        Board = board;
    }

    public List<(int, int)> FindRightmostTargets()
    {
        var targets = new List<(int, int)>();
        for (var col = Board.Width - 1; col >= 0; col--)
        {
            var columnTargets = new List<(int, int)>();
            for (var row = 0; row < Board.Height; row++)
            {
                var tileEntry = Board.Tiles[row, col];
                if (tileEntry.unit != null && !UnitUtils.IsGaulish(tileEntry.unit)) columnTargets.Add((row, col));
            }

            if (columnTargets.Count > 0)
            {
                targets = columnTargets;
                break;
            }
        }

        return targets;
    }

    private double EuclideanDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }

    public (int, int) PickClosestTarget(List<(int, int)> units, int h, int w)
    {
        var closestCouple = (0, 0);
        var minDist = double.MaxValue;
        foreach (var (hC, wC) in units)
        {
            var tempDist = EuclideanDistance(hC, wC, h, w);
            if (tempDist < minDist)
            {
                minDist = tempDist;
                closestCouple = (hC, wC);
            }
        }

        return closestCouple;
    }

    public bool IsValidTile(int h, int w)
    {
        var unit = Board.Tiles[h, w].unit;
        if (  Board.Tiles[h, w].tile == Tile.River || (unit != null && UnitUtils.IsGaulish(unit))) return false;
        return true;
    }

    public bool Update(int h, int w)
    {
        bool win = false;
        // Step 1: Find the rightmost targets
        var targets = FindRightmostTargets();
        if (targets.Count == 0) return false; // No targets found, no movement

        // Step 2: Pick the closest target
        var (targetH, targetW) = PickClosestTarget(targets, h, w);

        // Step 3: Determine movement direction
        if ((targetH < h && IsValidTile(h - 1, w))) // Move up
        {
            if (Board.Tiles[h - 1, w].unit is Caesar)
            {
                 win = true;
            }
            h--;
            Board.Tiles[h, w].unit = this;
            Board.Tiles[h + 1, w].unit = null;
            
            
        }
        else if (targetH > h && IsValidTile(h + 1, w)) // Move down
        {
            if (Board.Tiles[h + 1, w].unit is Caesar)
            {
                win = true;
            }
            h++;
            Board.Tiles[h, w].unit = this;
            Board.Tiles[h - 1, w].unit = null;
        }
        else if (targetW > w) // Move right
        {
            var step = targetW - w > 1 ? 2 : 1;
            if (IsValidTile(h, w + step))
            {
                if (Board.Tiles[h , w+ step].unit is Caesar)
                {
                    win = true;
                }
                w += step;
                Board.Tiles[h, w].unit = this;
                Board.Tiles[h, w - step].unit = null;
            }
            else if (step == 2 && IsValidTile(h, w + 2))
            {
                if (Board.Tiles[h , w+step].unit is Caesar)
                {
                    win = true;
                }
                w += 2;
                Board.Tiles[h, w].unit = this;
                Board.Tiles[h, w - 2].unit = null;
            }
            else if (IsValidTile(h, w + 1))
            {
                if (Board.Tiles[h , w+1].unit is Caesar)
                {
                    win = true;
                }
                w++;
                Board.Tiles[h, w].unit = this;
                Board.Tiles[h, w - 1].unit = null;
            }
        }
        else if (targetW < w && IsValidTile(h, w - 1))
        {
            if (Board.Tiles[h , w-1].unit is Caesar)
            {
                win = true;
            }
            w--;
            Board.Tiles[h, w].unit = this;
            Board.Tiles[h, w + 1].unit = null;
        }

        return win;
    }
}