using System;

namespace CSharpPractice.DesignPatterns
{
    public class DesignPatterns_AbstractFactory
    {
        public static void Run()
        {
            // ============================================
            // ABSTRACT FACTORY
            // ============================================

            Console.WriteLine("=== Abstract Factory ===");

            // SQL Server family
            IDatabaseFactory factory = new SqlServerFactory();

            DatabaseService databaseService = new DatabaseService(factory);

            databaseService.Execute();

            Console.WriteLine();

            // PostgreSQL family
            factory = new PostgreSqlFactory();

            databaseService = new DatabaseService(factory);

            databaseService.Execute();
        }
    }


    // ====================================================
    // ABSTRACT FACTORY
    // ====================================================


    // Abstract Product
    public interface IDbConnection
    {
        void Connect();
    }


    // Abstract Product
    public interface IDbCommand
    {
        void Execute();
    }


    // Concrete Product - SQL Server
    public class SqlServerConnection : IDbConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connected to SQL Server");
        }
    }


    // Concrete Product - SQL Server
    public class SqlServerCommand : IDbCommand
    {
        public void Execute()
        {
            Console.WriteLine("Executing SQL Server command");
        }
    }


    // Concrete Product - PostgreSQL
    public class PostgreSqlConnection : IDbConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connected to PostgreSQL");
        }
    }


    // Concrete Product - PostgreSQL
    public class PostgreSqlCommand : IDbCommand
    {
        public void Execute()
        {
            Console.WriteLine("Executing PostgreSQL command");
        }
    }


    // Abstract Factory
    public interface IDatabaseFactory
    {
        IDbConnection CreateConnection();

        IDbCommand CreateCommand();
    }


    // Concrete Factory - SQL Server
    public class SqlServerFactory : IDatabaseFactory
    {
        public IDbConnection CreateConnection()
        {
            return new SqlServerConnection();
        }

        public IDbCommand CreateCommand()
        {
            return new SqlServerCommand();
        }
    }


    // Concrete Factory - PostgreSQL
    public class PostgreSqlFactory : IDatabaseFactory
    {
        public IDbConnection CreateConnection()
        {
            return new PostgreSqlConnection();
        }

        public IDbCommand CreateCommand()
        {
            return new PostgreSqlCommand();
        }
    }


    // Client
    public class DatabaseService
    {
        private readonly IDatabaseFactory _factory;

        public DatabaseService(IDatabaseFactory factory)
        {
            _factory = factory;
        }

        public void Execute()
        {
            IDbConnection connection = _factory.CreateConnection();

            IDbCommand command = _factory.CreateCommand();

            connection.Connect();

            command.Execute();
        }
    }
}