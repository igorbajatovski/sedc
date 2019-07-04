using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using CompanyApp_Dappper.Models;

namespace CompanyApp_Dappper
{
    class Program
    {
        private static string _connection = "Data Source=.;Initial Catalog=CompanyDatabase;User ID=sa;Password=Password1";

        static void Main(string[] args)
        {
            PrintLoginMenu();
            int option = ReadOption();
            if (option == 2)
            {
                Console.WriteLine("You will exit...");
                Console.ReadLine();
                return;
            }

            Account account = null;
            while (true)
            {
                Console.Write("Enter acccount number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("Enter account pin: ");
                string pin = Console.ReadLine();
                if ( (account = VerifyAccount(accountNumber, pin) ) != null)
                {
                    Console.WriteLine("You are logged in!");
                    break;
                }
            }

            Console.WriteLine(ShowBalance(account.AccountNumber) + " den.");
            Console.WriteLine(WithDraw(account.AccountNumber, 500) + " den.");
            Console.WriteLine(ShowBalance(account.AccountNumber) + " den.");

            Console.ReadLine();
        }

        public static void PrintLoginMenu()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.WriteLine("---------------------------------------");
        }

        public static int ReadOption()
        {
            int option;
            string value = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(value, out option))
                {
                    if (option == 1 || option == 2)
                        break;
                }
                
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                value = Console.ReadLine();
            }

            return option;
        }

        public static Account VerifyAccount(string accountNumber, string pin)
        {   
            using (var conn = new SqlConnection(_connection))
            {
                string sql = "select * from Account where AccountNumber = @accountNum and PIN = @pin";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@accountNum", accountNumber, DbType.String);
                parameters.Add("@pin", pin, DbType.String);
                var accountsList = conn.Query<Account>(sql, parameters).AsList();
                if(accountsList.Count == 1)
                {
                    return accountsList[0];
                }
                else
                {
                    return null;
                }
            };
        }

        public static double ShowBalance(string accountNumber)
        {
            double balance;
            using (var conn = new SqlConnection(_connection))
            {
                string sql = "select Balance from Account where AccountNumber = @accountNum";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@accountNum", accountNumber, DbType.String);
                balance = conn.ExecuteScalar<double>(sql, parameters);
            }
            return balance;
        }

        public static double WithDraw(string accountNumber, double ammount)
        {   
            double balance;
            using (var conn = new SqlConnection(_connection))
            {
                string sql1 = "select Balance from Account where AccountNumber = @accountNum";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@accountNum", accountNumber, DbType.String);
                balance = conn.ExecuteScalar<double>(sql1, parameters);

                if (ammount < balance)
                {
                    string sql2 = "update Account set Balance = Balance - @ammount where AccountNumber = @accountNum";
                    parameters = new DynamicParameters();
                    parameters.Add("@ammount", ammount, DbType.Double);
                    parameters.Add("@accountNum", accountNumber, DbType.String);
                    conn.Open();
                    var transaction = conn.BeginTransaction();
                    balance = conn.Execute(sql2, parameters, transaction);
                    transaction.Commit();
                }
                else
                {
                    return -1;
                }
            }

            return ammount;
        }
    }
}
