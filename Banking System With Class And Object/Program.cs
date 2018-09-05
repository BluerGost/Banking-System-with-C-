using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banking_System_With_Class_And_Object
{
    class Account
    {
        //Properties and Fields
        private static int count;//counts the number of object/account has been created
        private int accountNo;
        public string accountHolderName { get; private set; }//only can be set from inside this class
        private double balance;//the backing field of the property accountBalance.
        public double accountBalance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value >= 2000.00)
                    balance = value;
                else
                    Console.WriteLine("Balance have to be greater/equal to 2000.00");
            }
        }
        public double interestBalance { get; private set; }

        //Constructors
        static Account()
        {
            count = 0;
        }

        public Account()
        {
            accountNo = nextAccountID();
            accountHolderName = "N/A";
            accountBalance = 2000.00;//account opening minimum balance
            interestBalance = calcInterest();
        }

        public Account(string accountHolderName, double accountBalance)
        {
            accountNo = nextAccountID();
            this.accountHolderName = accountHolderName;
            this.accountBalance = accountBalance;
            interestBalance = calcInterest();
        }

        //Methods
        private int nextAccountID()
        {
            return ++count;//increment by 1 and then return the value
        }
        public void showAccountInfo()
        {
            Console.WriteLine("Account No => {0}", accountNo);
            Console.WriteLine("Account Holder Name => {0}", accountHolderName);
            Console.WriteLine("Account Balance => {0:F2}", accountBalance);
            Console.WriteLine("Account Interest => {0:F2}", interestBalance);
        }

        private double calcInterest()
        {
            return ((5 * accountBalance) / 100);
        }

        private void updateInterest()
        {
            interestBalance = calcInterest();
        }

        private void updateAccountHolderName()
        {
            Console.WriteLine("Account No. => {0}", accountNo);
            Console.WriteLine("Account Holder Name(Old) => {0}", accountHolderName);
            Console.Write("Account Holder Name(New) => ");
            accountHolderName = Console.ReadLine();
        }

        private void updateAccountBalance()
        {
            Console.WriteLine("Account No. => {0}", accountNo);
            Console.WriteLine("Account Balance(Old) => {0}", accountBalance);
            Console.Write("Account Balance(New)[Need To be Greater or Equal to 2000.00] => ");
            accountBalance = Convert.ToDouble(Console.ReadLine());
            updateInterest();//to recalculate the interest for the new balance
        }
        public double totalBalance()//accountBalance+interestBalance
        {
            return (accountBalance + interestBalance);
        }


        private void withdrawMoney()
        {

            while (true)
            {
                Console.WriteLine("Account No. => {0}", accountNo);
                Console.WriteLine("Account Balance => {0}", accountBalance);
                Console.WriteLine("Enter the Ammount You want to Withdraw =>");

                double withdrawAmmount = Convert.ToDouble(Console.ReadLine());

                if (withdrawAmmount >= 0)
                {
                    if (accountBalance >= withdrawAmmount)
                    {
                        balance = balance - withdrawAmmount;//if we use accountBalance property we always have to keep 2000 in the account
                        updateInterest();
                        break;//withdraw successfull so break out of loop
                    }
                    else
                    {
                        Console.WriteLine("You dont have sufficient balance in your account for this withdrawal ");
                        Console.WriteLine("Re-Enter the Withdraw ammount");
                    }
                }
                else
                {
                    Console.WriteLine("Withdraw Ammount Need to Be Positive(+ve)");
                    Console.WriteLine("Re-Enter the Withdraw ammount");
                }
            }
        }

        private void depostMoney()
        {
            Console.WriteLine("Account No. => {0}", accountNo);
            Console.WriteLine("Account Balance => {0}", accountBalance);
            Console.WriteLine("Enter the Ammount You want to Withdraw =>");

            double depositAmmount = Convert.ToDouble(Console.ReadLine());

            while (true)
            {
                if (depositAmmount >= 0)
                {
                    accountBalance = accountBalance + depositAmmount;
                    updateInterest();
                    break;//withdraw successfull so break out of loop                                   
                }
                else
                {
                    Console.WriteLine("Deposit Ammount Need to Be Positive(+ve)");
                    Console.WriteLine("Re-Enter the Deposit ammount");
                }
            }
        }
        public void updateAccountInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Account Holder Name");
                Console.WriteLine("Press 2: To Change the Account Balance");
                Console.WriteLine("Press 3: To Withdraw Money");
                Console.WriteLine("Press 4: To Deposit Money");
                Console.WriteLine("Press 5: To See Total Account Balance");
                Console.WriteLine("Press 6: To See Account Information");
                Console.WriteLine("Press 7: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateAccountHolderName();
                }
                else if (updateInfo == 2)
                {
                    updateAccountBalance();
                }
                else if (updateInfo == 3)
                {
                    withdrawMoney();
                }
                else if (updateInfo == 4)
                {
                    depostMoney();
                }
                else if (updateInfo == 5)
                {
                    Console.WriteLine("Total balance of the Account => {0}", totalBalance()); ;
                }
                else if (updateInfo == 6)
                {
                    showAccountInfo();
                }
                else if (updateInfo == 7)
                {
                    Console.WriteLine("You have exited the Account Update Control.");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }
            }
        }

    }

    class Accountant
    {
        private static int count;

        private int actID;
        public string actName { get; private set; }
        private double salary;//monthly salary
        public double actSalary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value >= 0)
                    salary = value;
                else
                    Console.WriteLine("Accountant Salary have to be Positive(+ve)");
            }
        }
        static Accountant()
        {
            count = 0;
        }

        public Accountant()
        {
            actID = nextAccountantID();
            actName = "N/A";
            actSalary = 0.0;
        }

        public Accountant(string actName, double actSalary)
        {
            actID = nextAccountantID();
            this.actName = actName;
            this.actSalary = actSalary;
        }

        private int nextAccountantID()
        {
            return ++count;
        }


        private void updateAccountantName()
        {
            Console.WriteLine("Accountant ID. => {0}", actID);
            Console.WriteLine("Accountant Name(Old) => {0}", actName);
            Console.Write("Accountant Name(New) => ");
            actName = Console.ReadLine();
        }

        private void updateAccountantSalary()
        {
            Console.WriteLine("Account ID. => {0}", actID);
            Console.WriteLine("Account Salary(Old) => {0}", actSalary);
            Console.Write("Account Balance(New) => ");
            actSalary = Convert.ToDouble(Console.ReadLine());
        }
        private void showAccountantInfo()
        {
            Console.WriteLine("Accountant ID => {0}", actID);
            Console.WriteLine("Accountant Name => {0}", actName);
            Console.WriteLine("Accountant Salary => {0:F2}", actSalary);
        }

        public void updateAccountantInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Accountant Name");
                Console.WriteLine("Press 2: To Change the Accountant Salary");
                Console.WriteLine("Press 3: To Show Accountant Informtion");
                Console.WriteLine("Press 4: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateAccountantName();
                }
                else if (updateInfo == 2)
                {
                    updateAccountantSalary();
                }
                else if (updateInfo == 3)
                {
                    showAccountantInfo();
                }
                else if (updateInfo == 4)
                {
                    Console.WriteLine("You have exited the Accountant Update Control.");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }
            }
        }

    }


    class Manager
    {
        private static int count;

        private int managerID;
        public string managerName { get; private set; }
        private double salary;
        public double managerSalary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value >= 0)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Salary have to be Positive(+ve) Value");
                }
            }
        }

        static Manager()
        {
            count = 0;
        }

        public Manager()
        {
            managerID = nextManagerID();
            managerName = "N/A";
            managerSalary = 0.0;

        }

        public Manager(string managerName, double managerSalary, string managerAddress)
        {
            managerID = nextManagerID();
            this.managerName = managerName;
            this.managerSalary = managerSalary;

        }

        private int nextManagerID()
        {
            return ++count;
        }

        public void showManagerInfo()
        {
            Console.WriteLine("Manager ID => {0}", managerID);
            Console.WriteLine("Manager Name => {0}", managerName);
            Console.WriteLine("Manager Salary => {0:F2}", managerSalary);
        }

        private void updateManagerName()
        {
            Console.WriteLine("Manager ID. => {0}", managerID);
            Console.WriteLine("Manager Name(Old) => {0}", managerID);
            Console.Write("Manager Name(New) => ");
            managerName = Console.ReadLine();
        }

        private void updateManagerSalary()
        {
            Console.WriteLine("Manager ID. => {0}", managerID);
            Console.WriteLine("Manager Salary(Old) => {0}", managerSalary);
            Console.Write("Manager Balance(New) => ");
            managerSalary = Convert.ToDouble(Console.ReadLine());
        }
        private void showAccountantInfo()
        {
            Console.WriteLine("Manager ID => {0}", managerID);
            Console.WriteLine("Manager Name => {0}", managerName);
            Console.WriteLine("Manager Salary => {0:F2}", managerSalary);
        }

        public void updateManagerInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Manager Name");
                Console.WriteLine("Press 2: To Change the Manager Salary");
                Console.WriteLine("Press 3: To Show Manager Informtion");
                Console.WriteLine("Press 4: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateManagerName();
                }
                else if (updateInfo == 2)
                {
                    updateManagerSalary();
                }
                else if (updateInfo == 3)
                {
                    showManagerInfo();
                }
                else if (updateInfo == 4)
                {
                    Console.WriteLine("You have exited the Manager Update Control.");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Accountant a1 = new Accountant();
            a1.updateAccountantInfo();
            Console.ReadKey();
        }
    }

}