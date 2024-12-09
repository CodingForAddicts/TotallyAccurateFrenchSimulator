namespace TAAS.Units;

public class Roman
{
    public Board Board;

    public Roman(Board board)
    {
        Board = board;
    }

    private bool isTileAvailable(int h, int w)
    {
        var unit = Board.Tiles[h, w].unit;
        if ( (Board.Tiles[h, w].tile != Tile.Field && Board.Tiles[h, w].tile != Tile.Forest) || (unit != null && !UnitUtils.IsGaulish(unit)))
        {
            Console.WriteLine("FALSE");
            return false;
        }
        return true;
    }
    public bool Update(int h, int w)
    {
        if (UnitUtils.PositionInBounds(h,w+1) && isTileAvailable(h, w + 1)  )
        {
            Board.Tiles[h, w + 1].unit = this;
            Console.WriteLine("MOVE RIGHT 1");
            Board.Tiles[h, w].unit = null;
            if (w + 1 == 19) return true;

        } else if (UnitUtils.PositionInBounds(h + 1, w + 1) && isTileAvailable(h + 1, w + 1))
        {
            Board.Tiles[h + 1, w + 1].unit = this;
            Board.Tiles[h, w].unit = null;
            if (w + 1 == 19) return true;
            
        } else if (UnitUtils.PositionInBounds(h - 1, w + 1) && isTileAvailable(h - 1, w + 1))
        {
             Board.Tiles[h - 1, w + 1].unit = this;
             Board.Tiles[h, w].unit = null;
            if (w + 1 == 19) return true;
        }

        return false;

    }
}