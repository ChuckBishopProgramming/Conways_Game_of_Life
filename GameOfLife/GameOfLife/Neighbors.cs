public class Neighbors
{
    static public int GetNeighborCount(string[,] array, int[] x, int[] y)
    {
        int neighborCount = 0;
        int xCenter = 0;
        int yCenter = 0;

        //North
        //if ()
        //{

        //}
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