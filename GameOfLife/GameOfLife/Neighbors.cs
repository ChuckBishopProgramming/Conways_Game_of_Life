public class Neighbors
{
    static public int GetNeighborCountCell(string[,] array, int x, int y)
    {
        int neighborCount = 0;
        int currentX = x;
        int currentY = y;

        bool nSkip = false;
        bool neSkip = false;
        bool eSkip = false;
        bool seSkip = false;
        bool sSkip = false;
        bool swSkip = false;
        bool wSkip = false;
        bool nwSkip = false;


        if (currentX <= 0)
        {
            nwSkip = true;
            nSkip = true;
            neSkip = true;
        }
        if (currentX >= 29)
        {
            swSkip = true;
            sSkip = true;
            seSkip = true;
        }
        if (currentY <= 0)
        {
            swSkip = true;
            wSkip = true;
            nwSkip = true;
        }
        if (currentY >= 119)
        {
            seSkip = true;
            eSkip = true;
            neSkip = true;
        }

        //North   
        if (!nSkip)
        {
            if (array[currentX - 1, currentY] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }

        //NorthWest        
        if (!nwSkip)
        {
            if (array[currentX - 1, currentY - 1] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }

        //West
        if (!wSkip)
        {
            if (array[currentX, currentY - 1] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }

        //SouthWest
        if (!swSkip)
        {
            if (array[currentX + 1, currentY - 1] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }

        //South
        if (!sSkip)
        {
            if (array[currentX + 1, currentY] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }

        //SouthEast
        if (!seSkip)
        {
            if (array[currentX + 1, currentY + 1] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }

        //East
        if (!eSkip)
        {
            if (array[currentX, currentY + 1] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }

        //NorthEast
        if (!neSkip)
        {
            if (array[currentX - 1, currentY + 1] == Program.fillingAlive)
            {
                neighborCount++;
            }
        }
        return neighborCount;
    }
}