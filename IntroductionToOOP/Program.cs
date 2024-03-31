using System.Runtime.CompilerServices;

namespace IntroductionToOOP
{
    internal class Program
    {
        private int _count = 0;
        static void Main(string[] args)
        {
            new Program()._count = 0;
            BankAccount account = new BankAccount("Jerry", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
            account.MakeDeposit(100, DateTime.Now, "Fried paid me back");
            Console.WriteLine("Account history");
            Console.WriteLine(account.GetAccountHistory());

            Console.WriteLine("GC Account");
            GiftCardAccount gc = new GiftCardAccount("Michelle", 1000, 200);
            gc.MakeWithdrawal(100, DateTime.Now, "Coffee");
            gc.MakeWithdrawal(500, DateTime.Now, "SM");
            gc.PerformMonthEndTransaction();
            Console.WriteLine(gc.GetAccountHistory());

            Console.WriteLine("Savings Account");
            InterestEarningAccount savings = new InterestEarningAccount("Paula", 10000);
            savings.MakeWithdrawal(5000, DateTime.Now, "Rent");
            savings.MakeDeposit(2000, DateTime.Now, "Bayad utang");
            savings.MakeDeposit(3000, DateTime.Now, "Lotto");
            savings.PerformMonthEndTransaction();
            Console.WriteLine(savings.GetAccountHistory());

            Console.WriteLine("Credit Account");
            LineOfCredit creditAccount = new LineOfCredit("Nina", 0, 4000);
            creditAccount.MakeWithdrawal(100, DateTime.Now, "Coffee break");
            creditAccount.MakeDeposit(100, DateTime.Now, "Bayad coffee");
            creditAccount.MakeWithdrawal(5000, DateTime.Now, "Lazada");
            creditAccount.PerformMonthEndTransaction();
            Console.WriteLine(creditAccount.GetAccountHistory());
           
        }




        interface IStudent
        {
            void DoLearn(string syllabus);
            void Enroll();
            void IsPresent();

        }

        class LocalStudent : IStudent
        {
            public void DoLearn(string syllabus)
            {
                Console.WriteLine("Learned local syllabus");
                throw new NotImplementedException();
            }

            public void Enroll()
            {
                throw new NotImplementedException();
            }

            public void IsPresent()
            {
                throw new NotImplementedException();
            }
        }
        class ForeignStudent : IStudent

        {
            public void DoLearn(string syllabus)
            {
                Console.WriteLine("Learned foreign syllabus");
                throw new NotImplementedException();
            }

            public void Enroll()
            {
                throw new NotImplementedException();
            }

            public void IsPresent()
            {
                throw new NotImplementedException();
            }
        }
    }
}
