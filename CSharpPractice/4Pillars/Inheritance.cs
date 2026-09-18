namespace CSharpPractice._4Pillars
{
    public class A
    {
        public int _a;
    }

    // B inherits from A
    // B has access to its own members + members of A
    public class B : A
    {
        public int _b;
    }

    // C inherits from B
    // C has access to its own members + B members + A members
    public class C : B
    {
        public int _c;
    }

    public class Inheritance
    {
        public static void Run()
        {
            // A
            // Reference type A, Object type A
            A aa = new A();
            aa._a = 1;          // A can access its own member
            //aa._b = 1;        // ❌ A does not have access to B members
            //aa._c = 1;        // ❌ A does not have access to C members

            // Reference type A, Object type B
            // B IS-A A, so this is valid
            A ab = new B();
            ab._a = 1;          // ✅ A member is accessible
            //ab._b = 1;        // ❌ Reference type is A
            //ab._c = 1;        // ❌ Reference type is A

            // Reference type A, Object type C
            A ac = new C();
            ac._a = 1;          // ✅ Inherited from A
            //ac._b = 1;        // ❌
            //ac._c = 1;        // ❌

            // B
            // B cannot hold an A object
            // B ba = new A();  // ❌ A is a parent of B

            // Reference type B, Object type B
            B bb = new B();
            bb._a = 1;          // ✅ Inherited from A
            bb._b = 1;          // ✅ B's own member
            //bb._c = 1;        // ❌ B does not have access to C members

            // Reference type B, Object type C
            // C IS-A B, so this is valid
            B bc = new C();
            bc._a = 1;          // ✅ Inherited from A
            bc._b = 1;          // ✅ B's own member
            //bc._c = 1;        // ❌ Reference type is B

            // C
            // C cannot hold an A object
            //C ca = new A();   // ❌ A is a parent of C

            // C cannot hold a B object
            //C cb = new B();   // ❌ B is a parent of C

            // Reference type C, Object type C
            C cc = new C();
            cc._a = 1;          // ✅ Inherited from A
            cc._b = 1;          // ✅ Inherited from B
            cc._c = 1;          // ✅ C's own member
        }
    }
}