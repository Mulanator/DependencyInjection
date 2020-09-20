using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var cw = new ConsoleWriter();
            var fw = new FileWriter();
            var cr = new ConsoleReader();

            Copy(cw, cr);

        }

        static void Copy(IWriter writer, IReader reader)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            
            bool machWeiter = true;

            while (machWeiter == true)
            {
                var eingabe = reader.Read(true);
                if (eingabe.Key == ConsoleKey.Escape)
                {
                    machWeiter = false;
                    continue;
                }

                writer.Write(eingabe.KeyChar);
            }
        }
    }
}


//Konkrete Implementierungen der Abstraktionslayer 
public class ConsoleWriter : IWriter
{

    public void Write(char c)
    {
        Console.Write(c);
    }
}


public class FileWriter : IWriter
{

    public void Write(char c)
    {
        //Console.Write(c); write to file by using filestream
    }
}


public class ConsoleReader : IReader
{
    public ConsoleKeyInfo Read(bool intercept)
    {
        return Console.ReadKey(intercept);
    }
}



//Abstraktionslayer
public interface IWriter
{
    void Write(char c);
}

public interface IReader
{
    ConsoleKeyInfo Read(bool intercept);
}