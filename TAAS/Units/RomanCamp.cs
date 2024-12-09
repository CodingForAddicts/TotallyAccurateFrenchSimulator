namespace TAAS.Units;

public class RomanCamp
{
    public Board Board;
    private const int turntosummon = 8;

    public RomanCamp(Board board)
    {
        Board = board;
    }

    public bool Update(int w)
    {
        int rh = 0; 
        bool summoned = false;
        int iterations = Board.Height;
        
        if (Board.TurnCount % 2 == 1 && (Board.TurnCount - 1)/2 % turntosummon == 0 && Board.TurnCount != 1)
        {
            Console.WriteLine($"RomanCamp trying to summon on Turn {Board.TurnCount}...");
        
            while (!summoned && iterations > 0)
            {
                if (Board.Random != null) rh = Board.Random.Next(Board.Height - 1);
                var summonTile = Board.Tiles[rh, w + 1];

                Console.WriteLine($"Trying to summon at ({rh}, {w + 1}) - Tile: {summonTile.tile}, Unit: {summonTile.unit}");
                
                if (summonTile.tile != Tile.River && summonTile.unit == null)
                {
                    Board.Tiles[rh, w + 1].unit = new Roman(Board);
                    summoned = true;
                    Console.WriteLine($"Roman summoned at ({rh}, {w + 1})");
                }
                else
                {
                    Console.WriteLine($"Tile ({rh}, {w + 1}) is invalid for summoning.");
                }

                iterations--;
            }

            if (!summoned)
            {
                Console.WriteLine("Failed to summon a Roman after all attempts.");
            }
        }
        else
        {
            Console.WriteLine($"Not a Roman turn or not time to summon on Turn {Board.TurnCount}.");
        }
        
        if (summoned && w == Board.Width - 2)
        {
            Console.WriteLine("Winning move achieved!");
            return true; // Winning move
        }

        return false; // Not a winning move
    }
}