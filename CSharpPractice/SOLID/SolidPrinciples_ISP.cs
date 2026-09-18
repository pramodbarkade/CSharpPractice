using System;

namespace CSharpPractice.SOLID
{
    public class SolidPrinciples_ISP
    {
        public static void Run()
        {
            Console.WriteLine("===== WITHOUT ISP =====");

            var oldPrinter = new OldPrinter();

            oldPrinter.Print();
            oldPrinter.Scan();
            oldPrinter.Fax();


            Console.WriteLine();
            Console.WriteLine("===== WITH ISP =====");

            IPrinter printer = new SimplePrinter();
            printer.Print();

            IScanner scanner = new MultiFunctionPrinter();
            scanner.Scan();

            IFax fax = new MultiFunctionPrinter();
            fax.Fax();
        }
    }


    // =========================================================
    // ❌ WITHOUT ISP
    // =========================================================

    // One BIG interface containing
    // multiple unrelated responsibilities.
    public interface IMachine
    {
        void Print();

        void Scan();

        void Fax();
    }


    public class OldPrinter : IMachine
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public void Scan()
        {
            // ❌ Old printer cannot scan.
            throw new NotSupportedException(
                "This printer cannot scan."
            );
        }

        public void Fax()
        {
            // ❌ Old printer cannot fax.
            throw new NotSupportedException(
                "This printer cannot fax."
            );
        }
    }


    // =========================================================
    // Problem:
    //
    // OldPrinter only needs Print().
    //
    // But IMachine forces it to implement:
    //
    //     Print()
    //     Scan()
    //     Fax()
    //
    // OldPrinter is forced to depend on
    // methods it doesn't need.
    //
    // ❌ ISP violation
    // =========================================================



    // =========================================================
    // ✅ WITH ISP
    // =========================================================

    // Small, focused interfaces.

    public interface IPrinter
    {
        void Print();
    }


    public interface IScanner
    {
        void Scan();
    }


    public interface IFax
    {
        void Fax();
    }


    // Simple printer only needs printing.
    public class SimplePrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Simple printer is printing...");
        }
    }


    // Multi-function printer supports
    // all three capabilities.
    public class MultiFunctionPrinter
        : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning...");
        }

        public void Fax()
        {
            Console.WriteLine("Faxing...");
        }
    }
}