using System;

namespace Full_GRASP_And_SOLID
{
    /// <summary>
    /// This class represents an `ITextRedirector` which redirects text to the console.
    /// </summary>
    public class ConsolePrinter: ITextRedirector
    {
        void ITextRedirector.InsertText(string text)
        {
            Console.Write(text);
        }
    }
}