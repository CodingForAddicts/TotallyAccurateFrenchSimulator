namespace TAAS;

public class MyRandom
{
    private int _seed;
    // TODO DONT FORGET TO MAKE THE SEED PRIVATE AGAIN.
    private int seed
    {
        get
        {
            _seed = (int)(Math.Abs(8944 * Math.Sqrt(_seed + 42)) % 5150757);
            seed = _seed;
            return _seed;
        }
        set => _seed = value;
    }

    public MyRandom(int s)
    {
        _seed = s;
    }

    public int Next(int max = int.MaxValue)
    {
        return seed % max;
    }

    public int NextMin(int min, int max)
    {
        if (min == max) throw new ArgumentException("min cannot be equal to max");
        if (max <= min) throw new ArgumentException("min cannot be superior to max");
        return seed % (max - min) + min;
    }


}