using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Dokumentum
{
    internal class Program
    {
        class Document
        {
            internal string text;
            internal string format;

            internal virtual void Write()
            {
                Console.WriteLine($"{this.GetType().Name} szövege: {text}");
                Console.WriteLine($"{this.GetType().Name} formázása: {format}");
            }
            internal Document(string text, string format)
            {
                this.text = text;
                this.format = format;
            }
        }

        class HTMLDocument : Document
        {
            internal override void Write()
            {
                Console.WriteLine("<!DOCTYPE html>\n" +
                                  "<head>\n" +
                                  "\t<title>Document</title>\n" +
                                  "</head>\n" +
                                  "<body>\n" +
                                  $"\t{text}\n" +
                                  "</body>\n" +
                                  "</html>");
            }
            internal HTMLDocument(string text, string format) : base(text, format)
            {

            }
        }

        static void Main(string[] args)
        {
        }
    }
}
