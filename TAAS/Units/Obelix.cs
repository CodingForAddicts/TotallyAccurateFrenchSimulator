
using TAAS.Units;
namespace TAAS.Units;

public class Obelix
{
    public Board Board;

    public Obelix(Board board)
    {
        Board = board;
    }
    
   public (int, int) CheckSurroundings(int h, int w)
   {
       // Define the bounds for the 5x5 square
       int startRow = Math.Max(0, h - 2);
       int endRow = Math.Min(Board.Height - 1, h + 2);
       int startCol = Math.Max(0, w - 2);
       int endCol = Math.Min(Board.Width - 1, w + 2);
       
       for (int row = startRow; row <= endRow; row++)
       {
           for (int col = startCol; col <= endCol; col++)
           {
               var tileEntry = Board.Tiles[row, col];
               
               if (tileEntry.unit != null &&
                   (tileEntry.unit is Roman || tileEntry.unit is RomanCamp || tileEntry.unit is Caesar))
               {
                   return (row, col);
               }
           }
       }
       
       return (-1, -1);
   }

    public static (int, int) LookForCaesarPosition(Board board)
    {
        for (int w = 0; w < Board.Width; w++)
        {
            for (int h = 0; h < Board.Height; h++)
            {
                if (board.Tiles[h, w].unit is Caesar)
                {
                    return (h, w);
                }
            }
        }

        return (-1, -1);
    }
    
    
    
    private void MoveObelix(int newH, int newW)
    {
        // Clear current position
        for (int h = 0; h < Board.Height; h++)
        {
            for (int w = 0; w < Board.Width; w++)
            {
                if (Board.Tiles[h, w].unit is Obelix)
                {
                    Board.Tiles[h, w].unit = null;
                    break;
                }
            }
        }
        
        Board.Tiles[newH, newW].unit = this;
    }
    
    private bool IsValidTile(int h, int w)
    {
        var unit = Board.Tiles[h, w].unit;
        if ((unit != null && UnitUtils.IsGaulish(unit))) return false;
        return true;
    }
    public bool Update(int h, int w)
    {
        var opponentPosition = CheckSurroundings(h, w);

        if (opponentPosition != (-1, -1))
        {
            (int targetH, int targetW) = opponentPosition;
            var targetUnit = Board.Tiles[targetH, targetW].unit;

            Board.Tiles[targetH, targetW].unit = this;
            Board.Tiles[h, w].unit = null;
            
            return targetUnit is Caesar;
        }
        
        var caesarPosition = LookForCaesarPosition(Board);

        if (caesarPosition != (-1, -1))
        {
            (int caesarH, int caesarW) = caesarPosition;

            if (w > 0 && IsValidTile(h, w - 1))
            {
                Board.Tiles[h, w].unit = null;
                Board.Tiles[h, w - 1].unit = this;
            }
            else
            {
                if (h > caesarH && h > 0 && IsValidTile(h - 1, w))
                {
                    Board.Tiles[h, w].unit = null;
                    Board.Tiles[h - 1, w].unit = this;
                }
                else if (h < caesarH && h < Board.Height - 1 && IsValidTile(h + 1, w))
                {
                    Board.Tiles[h, w].unit = null;
                    Board.Tiles[h + 1, w].unit = this;
                }
            }
        }
        else if (w > 0 && IsValidTile(h, w - 1))
        {
            // Pas de César trouvé, mais Obelix va encore à gauche s'il peut
            Board.Tiles[h, w].unit = null;
            Board.Tiles[h, w - 1].unit = this;
        }

        return false;
    }


}