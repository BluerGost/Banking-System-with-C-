//Here I will Implement Inherienace in the Banking Project.
//accountant and manager will Derive from a base class called Employee



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

    }//end of Account Class


    class Employee
    {
        public static int totalEmpCount { get; protected set; }//counts total employee number in the bank

        protected int empID;
        public string empName { get; protected set; }
        private double salary;
        protected double empSalary
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
                    Console.WriteLine("Employe Salary Have to be Positive(+ve) value");
            }
        }
        static Employee()
        {
            totalEmpCount = 0;
        }

        protected Employee()
        {
            empID = nextEmpID();
            empName = "N/A";
            empSalary = 0.0;
            totalEmpCount++;
        }

        protected Employee(string empName, double empSalary)
        {
            empID = nextEmpID();
            this.empName = empName;
            this.empSalary = empSalary;
            totalEmpCount++;
        }



        //methods
        protected virtual int nextEmpID()
        {
            return -1;//this method will not be used and always will be overriden 
        }

        protected virtual void updateEmployeeName()
        {
            Console.WriteLine("Employee ID. => {0}", empID);
            Console.WriteLine("Employee Name(Old) => {0}", empName);
            Console.Write("Employee Name(New) => ");
            empName = Console.ReadLine();
        }

        protected virtual void updateEmployeeSalary()
        {
            Console.WriteLine("Employee ID. => {0}", empID);
            Console.WriteLine("Employee Salary(Old) => {0}", empSalary);
            Console.Write("Employee Balance(New) => ");
            empSalary = Convert.ToDouble(Console.ReadLine());
        }
        protected virtual void showEmployeeInfo()
        {
            Console.WriteLine("Employee ID => {0}", empID);
            Console.WriteLine("Employee Name => {0}", empName);
            Console.WriteLine("Employee Salary => {0:F2}", empSalary);
        }

        public virtual void updateEmployeeInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Employee Name");
                Console.WriteLine("Press 2: To Change the Employee Salary");
                Console.WriteLine("Press 3: To Show Employee Informtion");
                Console.WriteLine("Press 4: To Exit the Employee Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateEmployeeName();
                }
                else if (updateInfo == 2)
                {
                    updateEmployeeSalary();
                }
                else if (updateInfo == 3)
                {
                    showEmployeeInfo();
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
    }//end of Employee(Base) class
    class Accountant : Employee
    {
        private static int actCount;
       
        
        static Accountant()
        {
            actCount = 0;
        }

        public Accountant():base()//if i dont include base() compiler will call default constructor of base class
        {
                   //nothing here 
        }

        public Accountant(string actName, double actSalary):base(actName,actSalary)
        {
                //nothing here
        }

        protected override int nextEmpID()
        {
            return ++actCount;
        }


        protected override void updateEmployeeName()
        {
            Console.WriteLine("Accountant ID. => {0}", empID);
            Console.WriteLine("Accountant Name(Old) => {0}", empName);
            Console.Write("Accountant Name(New) => ");
            empName = Console.ReadLine();
        }

        protected override void updateEmployeeSalary()
        {
            Console.WriteLine("Account ID. => {0}", empID);
            Console.WriteLine("Account Salary(Old) => {0}", empName);
            Console.Write("Account Balance(New) => ");
            empSalary = Convert.ToDouble(Console.ReadLine());
        }
        protected override void showEmployeeInfo()
        {
            Console.WriteLine("Accountant ID => {0}", empID);
            Console.WriteLine("Accountant Name => {0}", empName);
            Console.WriteLine("Accountant Salary => {0:F2}", empSalary);
        }

        public override void updateEmployeeInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Accountant Name");
                Console.WriteLine("Press 2: To Change the Accountant Salary");
                Console.WriteLine("Press 3: To Show Accountant Informtion");
                Console.WriteLine("Press 4: To Show Total Employee Number");
                Console.WriteLine("Press 5: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateEmployeeName();
                }
                else if (updateInfo == 2)
                {
                    updateEmployeeSalary();
                }
                else if (updateInfo == 3)
                {
                    showEmployeeInfo();
                }
                else if (updateInfo == 4)
                {
                    Console.WriteLine("Total Employee Number=>{0}",totalEmpCount); ;
                }
                else if (updateInfo == 5)
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
    }//end of Accountant Class
    class Manager : Employee
    {
        private static int managerCount;


        static Manager()
        {
            managerCount = 0;
        }

        public Manager():base()//if i dont include base() compiler will call default constructor of base class
        {
            //nothing here 
        }

        public Manager(string actName, double actSalary):base(actName,actSalary)
        {
            //nothing here
        }

        protected override int nextEmpID()
        {
            return ++managerCount;
        }


        protected override void updateEmployeeName()
        {
            Console.WriteLine("Manager ID. => {0}", empID);
            Console.WriteLine("Manager Name(Old) => {0}", empName);
            Console.Write("Manager Name(New) => ");
            empName = Console.ReadLine();
        }

        protected override void updateEmployeeSalary()
        {
            Console.WriteLine("Manager ID. => {0}", empID);
            Console.WriteLine("Manager Salary(Old) => {0}", empName);
            Console.Write("Manager Balance(New) => ");
            empSalary = Convert.ToDouble(Console.ReadLine());
        }
        protected override void showEmployeeInfo()
        {
            Console.WriteLine("Manager ID => {0}", empID);
            Console.WriteLine("Manager Name => {0}", empName);
            Console.WriteLine("Manager Salary => {0:F2}", empSalary);
        }

        public override void updateEmployeeInfo()
        {
            while (true)
            {
                Console.WriteLine("Press 1: To Change the Manager Name");
                Console.WriteLine("Press 2: To Change the Manager Salary");
                Console.WriteLine("Press 3: To Show Manager Informtion");
                Console.WriteLine("Press 4: To Show Total Employee Number");
                Console.WriteLine("Press 5: To Exit the Update Control");

                int updateInfo = Convert.ToInt16(Console.ReadLine());

                if (updateInfo == 1)
                {
                    updateEmployeeName();
                }
                else if (updateInfo == 2)
                {
                    updateEmployeeSalary();
                }
                else if (updateInfo == 3)
                {
                    showEmployeeInfo();
                }
                else if (updateInfo == 4)
                {
                    Console.WriteLine("Total Employee Number=>{0}", totalEmpCount); ;
                }
                else if (updateInfo == 5)
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
    }//end of Manager Class

    class Program
    {
        static void Main(string[] args)
        {

            Accountant a1 = new Accountant();
            a1.updateEmployeeInfo();

            Accountant a2 = new Accountant();
            a2.updateEmployeeInfo();
            Employee e1 = a1;
            Employee e2 = a2;
            e1.updateEmployeeInfo();
            e2.updateEmployeeInfo();
            Manager m1 = new Manager();
            m1.updateEmployeeInfo();

            Accountant a3 = new Accountant();
            a3.updateEmployeeInfo();

            Manager m2 = new Manager();
            m2.updateEmployeeInfo();

            Console.ReadKey();
        }
    }

}
