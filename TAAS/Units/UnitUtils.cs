namespace TAAS.Units;

public class UnitUtils
{
    public static bool PositionInBounds(int h, int w)
    {
        return h < Board.Height && w < Board.Width && h >= 0 && w >= 0;
    }

    public static bool IsGaulish(object unit)
    {
        switch (unit)
        {
            case Asterix:
                return true;
            
            case Obelix:
                return true;
            
            case Idefix:
                return true;
                
            default:
                return false;
        }
    }


}