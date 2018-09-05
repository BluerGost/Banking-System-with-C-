using System;


namespace Banking_System_with_C_Sharp
{

    class Program
    {
        static void Main(string[] args)
        {
            double[,] balance = new double[3, 3];
            double[,] withdraw = new double[3, 3];
            double[,] deposit = new double[3, 3];


            double[,] accountant = new double[3, 2];
            double[] branchManager = new double[3];
            double interest;



            //Inputing Account Balance in Arrays
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {
                    Console.WriteLine("Branch {0} Account No. ===> {1}", i + 1, j + 1);
                    Console.Write("Enter Your Balance:");
                    balance[i, j] = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                }
            }


            //Printing the input Balance
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {

                    Console.WriteLine("Branch {0} Account No.{1} \n BALANCE ===> {2}", i + 1, j + 1, balance[i, j]);

                }
            }



            //Withdrawing Money from Account
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {
                    while (true)
                    {


                        Console.WriteLine("||Branch No - {0}|| Account No - {1}|| Balance - {2} ||", i + 1, j + 1, balance[i, j]);
                        Console.Write("Enter Your Withdraw Amount: ");
                        withdraw[i, j] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();


                        if (balance[i, j] >= withdraw[i, j])
                        {
                            balance[i, j] = balance[i, j] - withdraw[i, j];
                            break;  //breaks out of while loop and goes to Next Iteration.
                        }
                        else
                        {
                            Console.WriteLine("You Dont have {0} amount in your account!!!", withdraw[i, j]);
                            Console.WriteLine("Re-Enter Your Withdraw ammount correctly");
                        }
                    }

                }
            }



            //Printing New Updated  Balance
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {

                    Console.WriteLine("Branch {0} Account No.{1} \n BALANCE ===> {2}", i + 1, j + 1, balance[i, j]);

                }
            }

            //Depositing Money From Account
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {
                    while (true)
                    {


                        Console.WriteLine("||Branch No - {0}|| Account No - {1}|| Balance - {2} ||", i + 1, j + 1, balance[i, j]);
                        Console.Write("Enter Your Deposit Amount: ");
                        deposit[i, j] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();


                        if (deposit[i, j] >= 0)
                        {
                            balance[i, j] = balance[i, j] + deposit[i, j];
                            break;  //breaks out of while loop and goes to Next Iteration.
                        }
                        else
                        {
                            Console.WriteLine("Deposit Amount cant be of Negative Value: {0}", deposit[i, j]);
                            Console.WriteLine("Re-Enter Your Deposit ammount correctly");
                        }
                    }

                }
            }

            //Printing New Updated  Balance
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {

                    Console.WriteLine("Branch {0} Account No.{1} \n BALANCE ===> {2}", i + 1, j + 1, balance[i, j]);

                }
            }

            //Calculating Interest and Updating the Balance 
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {
                    interest = (5 * balance[i, j]) / 100;   //Calculating 5% Interest
                    balance[i, j] = balance[i, j] + interest;   //Adding the Interest to the original balance
                }
            }


            //Printing New Updated  Balance
            for (int i = 0; i < balance.GetLength(0); i++)
            {
                for (int j = 0; j < balance.GetLength(1); j++)
                {

                    Console.WriteLine("Branch {0} Account No.{1} \n BALANCE ===> {2}", i + 1, j + 1, balance[i, j]);

                }
            }


            //Calculating Bonus of the Accountant 
            for (int i = 0; i < balance.GetLength(0); i++)
            {

                for (int j = 0; j < balance.GetLength(1); j++)
                {
                    if (j <= balance.GetLength(1) / 2)
                    {
                        accountant[i, 0] = accountant[i, 0] + ((2 * balance[i, j]) / 100);// 2% of 1st half account is the bonus of 1st Accountant
                    }
                    else
                    {
                        accountant[i, 1] = accountant[i, 1] + ((2 * balance[i, j]) / 100);// 2% of Last half account is the bonus of 1st Accountant
                    }
                }
            }

            //Printing the Bonus of the Accountants
            for (int i = 0; i < accountant.GetLength(0); i++)
            {
                for (int j = 0; j < accountant.GetLength(1); j++)
                {
                    Console.WriteLine("||Branch No - {0}|| Accountant - {1}|| Bonus: {2}||", i + 1, j + 1, accountant[i, j]);
                }
            }


            //Calculating Bonus of the Manager 
            for (int i = 0; i < balance.GetLength(0); i++)
            {

                for (int j = 0; j < balance.GetLength(1); j++)
                {
                    branchManager[i] = branchManager[i] + (4 * balance[i, j]);
                }
            }

            //Printing the Bonus of the Manager
            for (int i = 0; i < accountant.GetLength(0); i++)
            {

                Console.WriteLine("||Branch No - {0}|| Manager's - Bonus: {1}||", i + 1, branchManager[i]);

            }


            Console.ReadKey();
        }
    }
}