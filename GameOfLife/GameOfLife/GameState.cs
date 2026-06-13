public class GameState
{   

    // PREP
    //lots of prompts
    //create tracking array/list/ll
    //add prompted cells to buffer AND tracking array


    // RUNNING
    // a loop, never ending except for prompt
    // Exit on esc, or Q

    // PAUSED

    // STOP
    public static void OneGenerationManual()
    {
        Program.currentGrid = Program.UpdateGrid();
        Program.Print2DString(Program.currentGrid);
        Console.ReadKey();
    }
    public static void OneGenerationAuto()
    {
        Program.currentGrid = Program.UpdateGrid();
        Program.Print2DString(Program.currentGrid);
        Thread.Sleep(1500);
    }
}
