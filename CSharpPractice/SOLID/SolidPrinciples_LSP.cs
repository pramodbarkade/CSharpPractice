using System;

namespace CSharpPractice.SOLID
{
    [PracticeProgram("SOLID", "Liskov Substitution")]
    public class SolidPrinciples_LSP
    {
        public static void Run()
        {
            // =====================================================
            // 🐧 EXAMPLE 1: BIRD / PENGUIN
            // =====================================================

            Console.WriteLine("======================================");
            Console.WriteLine("🐧 EXAMPLE 1: BIRD / PENGUIN");
            Console.WriteLine("======================================");

            Console.WriteLine();
            Console.WriteLine("===== WITHOUT LSP =====");

            Bird_Without_LSP sparrow = new Sparrow_Without_LSP();
            sparrow.Fly();

            Bird_Without_LSP penguin = new Penguin_Without_LSP();

            try
            {
                penguin.Fly();
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"❌ Problem: {ex.Message}");
            }


            Console.WriteLine();
            Console.WriteLine("===== WITH LSP =====");

            Bird sparrowLSP = new Sparrow();
            sparrowLSP.Eat();

            FlyingBird flyingBird = new Sparrow();
            flyingBird.Fly();

            Bird penguinLSP = new Penguin();
            penguinLSP.Eat();

            // ✅ Penguin is a Bird.
            // We can safely replace Bird with Penguin.
            //
            // But Penguin is NOT a FlyingBird,
            // so we don't force it to implement Fly().


            // =====================================================
            // 📐 EXAMPLE 2: RECTANGLE / SQUARE
            // =====================================================

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("📐 EXAMPLE 2: RECTANGLE / SQUARE");
            Console.WriteLine("======================================");

            Console.WriteLine();
            Console.WriteLine("===== WITHOUT LSP =====");

            Rectangle rectangle = new Rectangle();

            rectangle.Width = 10;
            rectangle.Height = 5;

            Console.WriteLine(
                $"Rectangle: Width = {rectangle.Width}, " +
                $"Height = {rectangle.Height}"
            );

            Console.WriteLine(
                $"Area = {rectangle.CalculateArea()}"
            );


            Console.WriteLine();
            Console.WriteLine("Replacing Rectangle with Square...");

            Rectangle square = new Square();

            square.Width = 10;
            square.Height = 5;

            Console.WriteLine(
                $"Square: Width = {square.Width}, " +
                $"Height = {square.Height}"
            );

            Console.WriteLine(
                $"Area = {square.CalculateArea()}"
            );

            // ❌ Problem:
            //
            // We expected:
            //
            // Width  = 10
            // Height = 5
            //
            // But Square forces:
            //
            // Width  = 5
            // Height = 5
            //
            // Square changes the behavior expected from Rectangle.
            //
            // Therefore, LSP is violated.


            Console.WriteLine();
            Console.WriteLine("===== WITH LSP =====");

            IShape rectangleLSP = new RectangleLSP
            {
                Width = 10,
                Height = 5
            };

            IShape squareLSP = new SquareLSP
            {
                Side = 5
            };

            Console.WriteLine(
                $"Rectangle Area = {rectangleLSP.CalculateArea()}"
            );

            Console.WriteLine(
                $"Square Area = {squareLSP.CalculateArea()}"
            );

            // ✅ Both are shapes.
            //
            // We don't force Square to behave
            // like a Rectangle.
            //
            // Both safely implement IShape.


            // =====================================================
            // 💳 EXAMPLE 3: PAYMENT / REFUND
            // =====================================================

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("💳 EXAMPLE 3: PAYMENT / REFUND");
            Console.WriteLine("======================================");

            Console.WriteLine();
            Console.WriteLine("===== WITHOUT LSP =====");

            Payment_Without_LSP payment =
                new CashPayment_Without_LSP();

            payment.Pay();

            try
            {
                payment.Refund();
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"❌ Problem: {ex.Message}");
            }


            Console.WriteLine();
            Console.WriteLine("===== WITH LSP =====");

            IPayment cashPayment = new CashPayment();

            cashPayment.Pay();

            IPayment creditCardPayment =
                new CreditCardPayment();

            creditCardPayment.Pay();

            IRefundable refundablePayment =
                new CreditCardPayment();

            refundablePayment.Refund();

            // ✅ CashPayment only promises Pay().
            //
            // CreditCardPayment supports both:
            //
            //     Pay()
            //     Refund()
            //
            // We don't force CashPayment to implement
            // functionality that it cannot support.
        }
    }


    // ============================================================
    // 🐧 EXAMPLE 1: BIRD / PENGUIN
    // ============================================================


    // ❌ WITHOUT LSP

    public class Bird_Without_LSP
    {
        public virtual void Eat()
        {
            Console.WriteLine("Bird is eating...");
        }

        public virtual void Fly()
        {
            Console.WriteLine("Bird is flying...");
        }
    }


    public class Sparrow_Without_LSP : Bird_Without_LSP
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying...");
        }
    }


    public class Penguin_Without_LSP : Bird_Without_LSP
    {
        public override void Fly()
        {
            throw new NotSupportedException(
                "Penguins cannot fly."
            );
        }
    }


    // ✅ WITH LSP

    public abstract class Bird
    {
        public virtual void Eat()
        {
            Console.WriteLine("Bird is eating...");
        }
    }


    public abstract class FlyingBird : Bird
    {
        public abstract void Fly();
    }


    public class Sparrow : FlyingBird
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying...");
        }
    }


    public class Penguin : Bird
    {
        // Penguin can Eat.
        //
        // Penguin does NOT implement Fly().
    }



    // ============================================================
    // 📐 EXAMPLE 2: RECTANGLE / SQUARE
    // ============================================================


    // ❌ WITHOUT LSP

    public class Rectangle
    {
        public virtual int Width { get; set; }

        public virtual int Height { get; set; }

        public int CalculateArea()
        {
            return Width * Height;
        }
    }


    public class Square : Rectangle
    {
        public override int Width
        {
            get => base.Width;

            set
            {
                base.Width = value;
                base.Height = value;
            }
        }


        public override int Height
        {
            get => base.Height;

            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }


    // ❌ Problem:
    //
    // Rectangle allows:
    //
    //     Width  = 10
    //     Height = 5
    //
    // But Square forces:
    //
    //     Width  = Height
    //
    // Therefore Square changes the expected behavior
    // of Rectangle.
    //
    // LSP violation.



    // ✅ WITH LSP

    public interface IShape
    {
        double CalculateArea();
    }


    public class RectangleLSP : IShape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }


    public class SquareLSP : IShape
    {
        public double Side { get; set; }

        public double CalculateArea()
        {
            return Side * Side;
        }
    }


    // Both satisfy IShape.
    //
    // Neither one changes the other's rules.
    //
    // ✅ LSP respected.



    // ============================================================
    // 💳 EXAMPLE 3: PAYMENT / REFUND
    // ============================================================


    // ❌ WITHOUT LSP

    public class Payment_Without_LSP
    {
        public virtual void Pay()
        {
            Console.WriteLine("Payment completed.");
        }

        public virtual void Refund()
        {
            Console.WriteLine("Payment refunded.");
        }
    }


    public class CashPayment_Without_LSP
        : Payment_Without_LSP
    {
        public override void Refund()
        {
            throw new NotSupportedException(
                "Cash payment cannot be refunded through this system."
            );
        }
    }


    // ❌ Problem:
    //
    // Payment promises:
    //
    //     Pay()
    //     Refund()
    //
    // But CashPayment cannot fulfill Refund().
    //
    // Therefore:
    //
    // Payment payment = new CashPayment();
    //
    // payment.Refund();
    //
    // breaks expected behavior.
    //
    // LSP violation.



    // ✅ WITH LSP

    public interface IPayment
    {
        void Pay();
    }


    public interface IRefundable
    {
        void Refund();
    }


    public class CashPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Cash payment completed.");
        }
    }


    public class CreditCardPayment
        : IPayment, IRefundable
    {
        public void Pay()
        {
            Console.WriteLine(
                "Credit card payment completed."
            );
        }


        public void Refund()
        {
            Console.WriteLine(
                "Credit card payment refunded."
            );
        }
    }
}