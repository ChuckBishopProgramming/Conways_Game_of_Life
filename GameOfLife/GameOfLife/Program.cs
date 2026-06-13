//   Notes: Working MVP
//          
//          
//          

public class Program
{
    //these are 0-29 and 0-119
    public static string[,] grid = new string[30, 120];
    public static string[,] currentGrid = new string[30, 120];
    public static string[,] futureGrid = new string[30, 120];

    public static int cycleCount = 0;

    const string HEADER = "CONWAY'S GAME OF LIFE";
    public const string fillingDead = ".";
    public const string fillingAlive = "O";

    const string lineDecor = "------------------------------------------------------------------------------------------------------------------------";

    static void Main(string[] args)
    {
        //GREETING
        Console.WriteLine("WELCOME, It's Alive!!!!");
        Line();

        //FILL GRID W DEAD CELLS
        Fill(grid, fillingDead);
        Fill(currentGrid, fillingDead);

        //GIVE OPTION FOR PREMADE 
        //Select premade shape
        //Enter your own cells

        //PROMPT FOR CELL #
        int noOfCells = PromptForCellNumber();
        Line();

        //CREATE INITIAL ARRAY
        Storage.CreateInitialArrays(noOfCells);

        //PLACE CELLS & FILL ARRAYS
        PromptAndPlaceCells(noOfCells, currentGrid);
        Line();

        //PRINT GRID
        Print2DString(currentGrid);
        Line();

        //TESTING


        //START 
        ReadyToStart();

        //UPDATE BUFFER
        string generationsQuery = "How many generations do you want to simulate?";
        string generationsQueryFail = "can't fail - not true";
        int gen = GetNumberFromUser(generationsQuery, generationsQueryFail, 30);

        if (gen < 0)
        {
            Console.WriteLine($"negative number not allowed, setting to 1 generation");
            gen = 1;
        }

        Console.WriteLine($"(M)anual or (A)uto?");
        string manualAuto = Console.ReadLine();
        
        if (manualAuto.Trim().ToUpper() == "M")
        {
            ManualAdvance(gen);
        }
        else if (manualAuto.Trim().ToUpper() == "A")
        {
            AutoAdvance(gen);
        }
              


    }

    //CORE MECHANICS
    //++++++++++++++++++++++++++++++++++
    static public void PromptAndPlaceCells(int numberOfCells, string[,] arr)
    {
        for (int i = 0; i < numberOfCells; i++)
        {
            int x = GetXPos(i + 1);
            int y = GetYPos(i + 1);

            //fill initial arrays
            AddXYToArray(i, x, y);

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
        //GetLength returns the number of elements
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = filling;
            }
        }
    }
    static public string[,] UpdateGrid()
    {
        bool cellAlive = false;
        Fill(futureGrid, fillingDead);

        for (int i = 0; i < currentGrid.GetLength(0); i++)
        {
            for (int j = 0; j < currentGrid.GetLength(1); j++)
            {
                int x = i;
                int y = j;

                int neighborCount = Neighbors.GetNeighborCountCell(currentGrid, i, j);
                cellAlive = Logic.LiveOrDieLogic(neighborCount, currentGrid, i, j);

                if (cellAlive)
                {
                    futureGrid[i, j] = fillingAlive;
                }
            }
        }

        //INSTEAD
        Array.Copy(futureGrid, currentGrid, futureGrid.Length);
        return currentGrid;
    }
    static public void ManualAdvance(int generations)
    {
        for (int i = 0; i < generations; i++)
        {            
            Console.Clear();
            Console.WriteLine($"Generation {i}");
            Line();
            GameState.OneGenerationManual();
        }
    }
    static public void AutoAdvance(int generations)
    {
        for (int i = 0; i < generations; i++)
        {
            Console.Clear();
            Console.WriteLine($"Generation {i}");
            Line();
            GameState.OneGenerationAuto();
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
    static public void IncrementCycleCount()
    {
        //SUS
        cycleCount++;
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

