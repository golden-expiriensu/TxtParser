namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            string directory = @"C:\Users\gunda\source\repos\TxtParser\originFile.txt";
            ParserLibrary.TxtParser.ParseTxtFile(directory);
        }
    }
}
