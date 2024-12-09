namespace TAAS;

public class Move
{
    private int startH;
    private int startW;
    private int endH;
    private int endW;
    private object? movedUnit;

    public Move(int startH, int startW, int endH, int endW, object? movedUnit)
    {
        this.startH = startH;
        this.startW = startW;
        this.endH = endH;
        this.endW = endW;
        this.movedUnit = movedUnit;

    }

    public Move()
    {
        this.movedUnit = null;
    }

    public void UndoMove(Board b)
    {
        if (movedUnit == null)
        {
            return;
        }

        b.Tiles[startH, startW].unit = movedUnit;
        b.Tiles[endH, endW].unit = null;
    }
}