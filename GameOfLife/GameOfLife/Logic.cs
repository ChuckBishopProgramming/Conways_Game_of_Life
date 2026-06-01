public class Logic
{    public static bool LiveOrDieLogic(int neighborCount, string[,] arr, int x, int y)
    {
        bool cellAlive = false;

        //UNDERPOP
        if (neighborCount < 2)
        {
            cellAlive = false;
        }

        //LIFE //LIVE ON
        if (arr[x, y] == Program.fillingAlive && (neighborCount == 2 || neighborCount == 3))
        {
            cellAlive = true;
        }

        //OVERPOP
        if (neighborCount > 3)
        {
            cellAlive = false;
        }

        //REPRO
        if (neighborCount == 3)
        {
            cellAlive = true;
        }
        return cellAlive;
    }
}
