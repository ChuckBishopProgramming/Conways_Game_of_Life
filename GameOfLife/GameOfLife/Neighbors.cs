public class Neighbors
{
    static public int GetNeighborCount(string[,] array, int[] x, int[] y)
    {
        int neighborCount = 0;
        int currentX = 0;
        int currentY = 0;

        int numberOfCells = x.Length;

        bool nSkip = false;
        bool neSkip = false;
        bool eSkip = false;
        bool seSkip = false;
        bool sSkip = false;
        bool swSkip = false;
        bool wSkip = false;
        bool nwSkip = false;
        

        for (int i = 0; i < numberOfCells; i++)
        {
            currentX = x[i];
            currentY = y[i];

            if (currentX == 1)
            {
                nwSkip = true;
                nSkip = true;
                neSkip = true;
            }
            if (currentX == 30)
            {
                swSkip = true;
                sSkip = true;
                swSkip = true;
            }
            if (currentY == 1)
            {
                swSkip = true;
                wSkip = true;
                nwSkip = true;
            }
            if (currentY == 120)
            {
                seSkip = true;
                nSkip = true;
                neSkip = true;
            }

            //North
            if (array[currentX - 1, currentY] == "O" && nSkip == false)
            {
                neighborCount++;
            }

            //NorthWest
            if (array[currentX - 1, currentY - 1] == "O" && nwSkip == false)
            {
                neighborCount++;
            }

            //West
            if (array[currentX, currentY - 1] == "O" && wSkip == false)
            {
                neighborCount++;
            }

            //SouthWest
            if (array[currentX + 1, currentY - 1] == "O" && swSkip == false)
            {
                neighborCount++;
            }

            //South
            if (array[currentX + 1, currentY] == "O" && sSkip == false)
            {
                neighborCount++;
            }

            //SouthEast
            if (array[currentX + 1, currentY + 1] == "O" && seSkip == false)
            {
                neighborCount++;
            }

            //East
            if (array[currentX, currentY + 1] == "O" && eSkip == false)
            {
                neighborCount++;
            }

            //NorthEast
            if (array[currentX - 1, currentY + 1] == "O" && neSkip == false)
            {
                neighborCount++;
            }
        }
        return neighborCount;  

    }
}