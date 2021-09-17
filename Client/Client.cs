namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            string directory = @"C:\Users\gunda\source\repos\TxtParser\originFile.txt";
            if (TxtParser.API.ParseTxtFile(directory))
                System.Console.WriteLine("File converted successfully!");
            else
                System.Console.WriteLine("Something went wrong...");
        }
    }
}
