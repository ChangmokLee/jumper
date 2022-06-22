using System;


namespace jumper
{
    public class TerminalService
    {
        public TerminalService()
        {
        }

        public string ReadGuess(string prompt)
        {
            string rawValue = ReadText(prompt);
            return rawValue;
        }

        public string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }
    }
}