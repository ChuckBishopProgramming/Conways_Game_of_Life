public class GameState
{   
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
