//create a grid
//get starting input
//validate starting input
//plot cells on buffer
//update initial arrays
//count neighbors of those on initial arrays
//
//No logic before start prompt

public class Program
{
    public static string[,] grid = new string[30, 120];
    public static string[,] bufferGrid = new string[30, 120];    

    const string HEADER = "CONWAY'S GAME OF LIFE";
    const string fillingDead = ".";
    const string fillingAlive = "O";

    const string lineDecor = "------------------------------------------------------------------------------------------------------------------------";

    static void Main(string[] args)
    {
        //GREETING
        Console.WriteLine("WELCOME, It's Alive!!!!");
        Line();

        //FILL GRID W DEAD CELLS
        Fill(grid, fillingDead);
        //Fill(bufferGrid, fillingDead);

        //PROMPT FOR CELL #
        int noOfCells = PromptForCellNumber();
        Line();

        //CREATE INITIAL ARRAY
        Storage.CreateInitialArrays(noOfCells);
        Storage.CreateInitialTrackingArray(noOfCells);

        //PLACE CELLS & FILL ARRAYS
        PromptAndPlaceCells(noOfCells, bufferGrid);
        //get x,y, fill tracking
        Line();

        //PRINT GRID
        Print2DString(bufferGrid);
        Print2DString(grid);
        Line();

        //TESTING
        PrintArray(Storage.initialX);
        PrintArray(Storage.initialY);

        //START 
        ReadyToStart();

        //UPDATE BUFFER
        UpdateBuffer();
        Print2DString(bufferGrid);

        //TESTING:
        Console.WriteLine("Storage tracking array");
        Print2DInt(Storage.trackingArray);

        //int neighborCount = Neighbors.GetNeighborCountArray(grid, Storage.initialX, Storage.initialY);
        //Console.WriteLine($"The neighbor Count is: {neighborCount}");

        //START 
        ReadyToStart();


        //foreach skips empty?
    }

    //CORE MECHANICS
    //++++++++++++++++++++++++++++++++++
    static public void PromptAndPlaceCells(int numberOfCells, string[,] arr)
    {
        for (int i = 0; i < numberOfCells; i++)
        {
            int x = GetXPos(i + 1);
            int y = GetYPos(i + 1);

            //fill array
            AddXYToArray(i, x, y);
            FillTracking(Storage.trackingArray, i, x, y);

            if (arr[x - 1, y - 1] == fillingAlive)
            {
                CellFilled();
                i--;                
            }
            else
            {
                arr[x - 1, y - 1] = fillingAlive;
            }
        }
    }
    static public void Fill(string[,] arr, string filling)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = filling;
            }
        }
    }
    static public void FillTracking(int[,] trackingArray, int i,  int x, int y)
    {
        for (int j = 0; j < trackingArray.GetLength(1); j++)
        {
            if (j == 0)
            {
                trackingArray[i, j] = x;
            }
            if (j == 1)
            {
                trackingArray[i, j] = y;
            }
        }
    }
    static public void UpdateBuffer()
    {
        //set cell state to dead
        //if cell is full set to alive
        //iterate over buffer array
        //apply cell logic to each cell
        //if cell logic = false kill cell
        //if cell logic = true birth cell

        bool cellAlive = false;

        for (int i = 0; i < bufferGrid.GetLength(0); i++)
        {
            for (int j = 0; j < bufferGrid.GetLength(1); j++)
            {
                int x = i;
                int y = j;

                int neighborCount = Neighbors.GetNeighborCountCell(bufferGrid, i, j);
                cellAlive = Neighbors.LiveOrDieLogic(neighborCount);

                if (cellAlive)
                {
                    bufferGrid[i, j] = fillingAlive;
                }
                else
                {
                    bufferGrid[i, j] = fillingDead;
                }
            }
        }
    }

    //MECHANICAL HELPERS
    //++++++++++++++++++++++++++++++++++
    static public void AddXYToArray(int i, int x, int y)
    {
        Storage.initialX[i] = x;
        Storage.initialY[i] = y;
    }
    static public void ConsoleReset()
    {
        Console.Clear();
        Console.WriteLine(HEADER);
        Print2DString(grid);
    }

    //DISPLAY
    //++++++++++++++++++++++++++++++++++
    static public void Print2DString(string[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.Write("\n");
        }
    }
    static public void Print2DInt(int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.Write("\n");
        }
    }
    static public void PrintArray(int[] arr)
    {
        foreach (int number in arr)
        {
            Console.WriteLine(number);
        }
    }
    static public void UpdateDisplay()
    {

    }

    //FORMATTING
    //++++++++++++++++++++++++++++++++++
    static public void Line()
    {
        Console.WriteLine(lineDecor);
    }
    static public void Space()
    {
        Console.WriteLine();
    }

    //PROMPT
    //++++++++++++++++++++++++++++++++++
    static public void ReadyToStart()
    {
        //Sketchy
        bool start = false;
        Console.WriteLine("Press Enter to Start or Escape to exit");

        while (!start)
        {
            ConsoleKeyInfo keyPress = Console.ReadKey();
            if (keyPress.Key == ConsoleKey.Enter)
            {
                //start stuff
                start = true;
            }
            else
            {
                if (keyPress.Key == ConsoleKey.Escape)
                {
                    //start stuff
                    start = false;
                    break;
                }
            }
        }
        Console.WriteLine("Starting things");
    }
    static public void CellFilled()
    {
        Console.WriteLine("That cell was already activated, please pick another. Press Enter to Continue");
        Console.ReadKey();
    }
    static public int PromptForCellNumber()
    {
        bool userInputValidNumber = false;
        int number = 0;

        while (!userInputValidNumber)
        {
            Console.Write("How many cells do you want to place? ");
            string userInput = Console.ReadLine();

            userInputValidNumber = int.TryParse(userInput, out number);
        }
        return number;
    }
    static public int GetNumberFromUser(string prompt, string failPrompt, int failPromptLength)
    {
        bool userInputValidNumber = false;

        int number = 0;
        int badInput = 0;

        string msg = prompt;

        while (!userInputValidNumber)
        {
            if (msg.Length > failPromptLength)
            {
                msg = prompt + failPrompt;
            }

            //ConsoleReset();

            Console.Write(msg);

            string userInput = Console.ReadLine();

            userInputValidNumber = int.TryParse(userInput, out number);

            msg += failPrompt;
        }

        return number;
    }
    static public int GetXPos(int cellNo)
    {
        string startingPosPrompt = $"Please enter the x position for cell {cellNo}: (1 to 30): ";
        string startingPosFPrompt = "\nPlease enter a valid number";

        int maxLength = startingPosPrompt.Length + startingPosFPrompt.Length;
        int xPos = 0;

        bool xPosValid = false;

        while (!xPosValid)
        {
            xPos = GetNumberFromUser(startingPosPrompt, startingPosFPrompt, maxLength);
            if (!(xPos < 0 || xPos > 31))
            {
                xPosValid = true;
            }
        }
        return xPos;
    }
    static public int GetYPos(int cellNo)
    {
        string startingPosPrompt = $"Please enter the y position for cell {cellNo}: (1 to 120): ";
        string startingPosFPrompt = "\nPlease enter a valid number";

        int maxLength = startingPosPrompt.Length + startingPosFPrompt.Length;
        int yPos = 0;

        bool yPosValid = false;

        while (!yPosValid)
        {
            yPos = GetNumberFromUser(startingPosPrompt, startingPosFPrompt, maxLength);
            if (!(yPos < 0 || yPos > 121))
            {
                yPosValid = true;
            }
        }
        return yPos;
    }    
}

