public class Cell
{
    private int _xPos;
    private int _yPos;
    private int neighborCount;
    private bool isLiving;

    static public int GetNeighborCount(int xCenter, int yCenter, string[,] array)
    {
        int neighborCount = 0;

        //North
        if (array[xCenter - 1, yCenter] == "O")
        {
            neighborCount++;
        }

        //NorthWest
        if (array[xCenter - 1, yCenter - 1] == "O")
        {
            neighborCount++;
        }

        //West
        if (array[xCenter, yCenter - 1] == "O")
        {
            neighborCount++;
        }

        //SouthWest
        if (array[xCenter + 1, yCenter - 1] == "O")
        {
            neighborCount++;
        }

        //South
        if (array[xCenter + 1, yCenter] == "O")
        {
            neighborCount++;
        }

        //SouthEast
        if (array[xCenter + 1, yCenter + 1] == "O")
        {
            neighborCount++;
        }

        //East
        if (array[xCenter, yCenter + 1] == "O")
        {
            neighborCount++;
        }

        //NorthEast
        if (array[xCenter - 1, yCenter + 1] == "O")
        {
            neighborCount++;
        }
        return neighborCount;
    }

}



