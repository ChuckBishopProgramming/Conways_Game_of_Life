public class Neighbors
{
    static public int GetNeighborCountArray(string[,] array, int[] x, int[] y)
    {
        int neighborCount = 0;
        int currentX = 0;
        int currentY = 0;

        int numberOfCells = x.Length;

        for (int i = 0; i < numberOfCells; i++)
        {
            neighborCount = 0;

            bool nSkip = false;
            bool neSkip = false;
            bool eSkip = false;
            bool seSkip = false;
            bool sSkip = false;
            bool swSkip = false;
            bool wSkip = false;
            bool nwSkip = false;

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


        if (currentX <= 1)
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
        if (currentY <= 1)
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
            if (array[currentX +1 , currentY - 1] == Program.fillingAlive)
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
            if (array[currentX + 1, currentY +1] == Program.fillingAlive)
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
    //Get neighbor cell count for 1st cell in tracking array
    //apply liveordie logic
    //update bufferGrid array
    public static bool LiveOrDieLogic(int neighborCount)
    {
        bool cellAlive = true;

        //UNDERPOP
        if (neighborCount < 2)
        {
            cellAlive = false;
        }

        //LIFE
        else if (neighborCount == 2 || neighborCount == 3)
        {
            cellAlive = true;
        }

        //OVERPOP
        else if (neighborCount > 3)
        {
            cellAlive = false;
        }

        //REPRO
        else if (neighborCount == 3)
        {
            cellAlive = true;
        }

        else
        {
            cellAlive = true;
        }
        return cellAlive;
    }
}