using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    // ============================================================
    // 1. BASIC SINGLETON
    //
    // Simple eager initialization.
    // CLR static initialization guarantees that the instance
    // initialization is thread-safe.
    // ============================================================

    public sealed class SingletonBasic
    {
        private static readonly SingletonBasic _instance = new SingletonBasic();

        private SingletonBasic()
        {
            Console.WriteLine("SingletonBasic created");
        }

        public static SingletonBasic Instance => _instance;

        public void DoWork()
        {
            Console.WriteLine("SingletonBasic working...");
        }
    }


    // ============================================================
    // 2. LOCK-BASED LAZY SINGLETON
    //
    // Thread-safe, but lock is taken EVERY time Instance is called.
    // ============================================================

    public sealed class SingletonWithLock
    {
        private static SingletonWithLock? _instance;

        private static readonly object _lock = new object();

        private SingletonWithLock()
        {
            Console.WriteLine("SingletonWithLock created");
        }

        public static SingletonWithLock Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonWithLock();
                    }

                    return _instance;
                }
            }
        }

        public void DoWork()
        {
            Console.WriteLine("SingletonWithLock working...");
        }
    }


    // ============================================================
    // 3. DOUBLE-CHECK LOCKING SINGLETON
    //
    // First check:
    // Avoid lock after Singleton has already been created.
    //
    // Second check:
    // Another thread may have created the object while
    // this thread was waiting for the lock.
    // ============================================================

    public sealed class SingletonThreadSafe
    {
        private static SingletonThreadSafe? _instance;

        private static readonly object _lock = new object();

        private SingletonThreadSafe()
        {
            Console.WriteLine(
                $"SingletonThreadSafe created by Thread {Environment.CurrentManagedThreadId}"
            );
        }

        public static SingletonThreadSafe Instance
        {
            get
            {
                // ------------------------------------------------
                // FIRST CHECK
                //
                // After initialization, normally we return here
                // without acquiring the lock.
                // ------------------------------------------------

                if (_instance == null)
                {
                    lock (_lock)
                    {
                        // ----------------------------------------
                        // SECOND CHECK
                        //
                        // Another thread could have created the
                        // Singleton while we were waiting.
                        // ----------------------------------------

                        if (_instance == null)
                        {
                            _instance = new SingletonThreadSafe();
                        }
                    }
                }

                return _instance;
            }
        }

        public void DoWork()
        {
            Console.WriteLine(
                "SingletonThreadSafe working..."
            );
        }
    }


    // ============================================================
    // 4. Lazy<T> SINGLETON
    //
    // Recommended when you specifically want lazy initialization.
    //
    // Lazy<T>:
    // - Creates Singleton only when .Value is first accessed
    // - Is thread-safe by default
    // - Removes manual lock logic
    // ============================================================

    public sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>(() => new SingletonLazy());

        private SingletonLazy()
        {
            Console.WriteLine($"SingletonLazy created by Thread {Environment.CurrentManagedThreadId}");
        }

        public static SingletonLazy Instance => _instance.Value;

        public void DoWork()
        {
            Console.WriteLine("SingletonLazy working...");
        }
    }


    // ============================================================
    // DEMO
    // ============================================================

    public static class DesignPatterns_Singleton
    {
        public static void Run()
        {
            Console.WriteLine(
                "========== SINGLETON DESIGN PATTERN =========="
            );


            // ====================================================
            // 1. BASIC SINGLETON
            // ====================================================

            Console.WriteLine();
            Console.WriteLine(
                "========== 1. BASIC SINGLETON =========="
            );

            var basic1 = SingletonBasic.Instance;
            var basic2 = SingletonBasic.Instance;

            Console.WriteLine(
                $"Same instance: {ReferenceEquals(basic1, basic2)}"
            );

            basic1.DoWork();


            // ====================================================
            // 2. LOCK SINGLETON
            // ====================================================

            Console.WriteLine();
            Console.WriteLine(
                "========== 2. LOCK SINGLETON =========="
            );

            var lock1 = SingletonWithLock.Instance;
            var lock2 = SingletonWithLock.Instance;

            Console.WriteLine(
                $"Same instance: {ReferenceEquals(lock1, lock2)}"
            );

            lock1.DoWork();


            // ====================================================
            // 3. DOUBLE-CHECK LOCKING
            // ====================================================

            Console.WriteLine();
            Console.WriteLine(
                "========== 3. DOUBLE-CHECK LOCKING =========="
            );

            var threadSafe1 = SingletonThreadSafe.Instance;
            var threadSafe2 = SingletonThreadSafe.Instance;

            Console.WriteLine(
                $"Same instance: {ReferenceEquals(threadSafe1, threadSafe2)}"
            );

            threadSafe1.DoWork();


            // ====================================================
            // 4. LAZY<T>
            // ====================================================

            Console.WriteLine();
            Console.WriteLine(
                "========== 4. LAZY<T> SINGLETON =========="
            );

            Console.WriteLine(
                "SingletonLazy has NOT been requested yet."
            );

            Console.WriteLine(
                "Requesting SingletonLazy.Instance..."
            );

            var lazy1 = SingletonLazy.Instance;

            Console.WriteLine(
                "Requesting SingletonLazy.Instance again..."
            );

            var lazy2 = SingletonLazy.Instance;

            Console.WriteLine(
                $"Same instance: {ReferenceEquals(lazy1, lazy2)}"
            );

            lazy1.DoWork();


            // ====================================================
            // 5. MULTITHREAD TEST
            // ====================================================

            Console.WriteLine();
            Console.WriteLine(
                "========== 5. MULTITHREAD TEST =========="
            );

            TestLazySingletonWithMultipleThreads();


            // ====================================================
            // SUMMARY
            // ====================================================

            Console.WriteLine();
            Console.WriteLine(
                "========== SUMMARY =========="
            );

            Console.WriteLine(
                """
                SingletonBasic
                    -> Eager initialization
                    -> Simple
                    -> Thread-safe CLR initialization

                SingletonWithLock
                    -> Lazy initialization
                    -> Thread-safe
                    -> Lock taken on every access

                SingletonThreadSafe
                    -> Lazy initialization
                    -> Double-check locking
                    -> Avoids lock after initialization

                SingletonLazy
                    -> Lazy initialization
                    -> Thread-safe by default
                    -> Clean and easy to maintain
                """
            );
        }


        // ========================================================
        // MULTITHREADED TEST
        // ========================================================

        private static void TestLazySingletonWithMultipleThreads()
        {
            const int numberOfThreads = 10;

            SingletonLazy?[] instances = new SingletonLazy[numberOfThreads];

            Parallel.For(
                0,
                numberOfThreads,
                i =>
                {
                    instances[i] = SingletonLazy.Instance;

                    Console.WriteLine(
                        $"Thread {Environment.CurrentManagedThreadId} " +
                        $"received SingletonLazy"
                    );
                }
            );


            // ----------------------------------------------------
            // Verify every thread received the SAME object.
            // ----------------------------------------------------

            bool allSame = true;

            for (int i = 1; i < instances.Length; i++)
            {
                if (!ReferenceEquals(
                        instances[0],
                        instances[i]))
                {
                    allSame = false;
                    break;
                }
            }

            Console.WriteLine();

            Console.WriteLine(
                $"All threads received same instance: {allSame}"
            );
        }
    }
}