using System;
using System.IO;
//A.Cox
//SD-613-Final-Project
//10.20.19

    // Title: Fit-Status-Tracker v1.0
    /************
     *
     *         The Fit-Status Tracker application will allows members of a fitness club
     *        to track their input information to keep an accurate record and update
     *        their membership status as needed. It will display data for various
     *        records selected, such as their city, full name, gender, membership status,
     *        and monthly payment amount. The program will have a feature that allows
     *        their membership tier to be stored as an integer value, yet when called upon by the
     *        user it will display their Member-Tier-Type status.
     *
     *        It will also allow accounting for health-club record keeping by calculating the average
     *        monthly payments for all members and also for members of a specific tier or membership status.
     *        This will allow management to track fluxes in member status, and keep
     *        an accurate record of their membership population.   
     *        
     *
     *   Technical(Object-Array, static methods, array calculations, constructors, object class, BubbleSort)
     *   v1.1 will adjust user input to accept capital or lower case letters to find a valid input.
     * 
     ***********/

namespace FitnallClubFinalRedux
{
    class Program
    {

        static void printMembers(Member[] MemberInfo, int counter)
        {
            Console.WriteLine("\n Here is the Full-Membership-List at this time: \n");

            Console.WriteLine("{0, 1} {1, 2} {2, 3} {3, 4} {4, 10} {5, 6} {6, 1} {7, 2}", "Account#", "FirstName", "LastName", "     City   ", "Gender", "MonthlyDues", "MembershipValue", "MembershipStatus");
            Console.WriteLine("{0, 1} {1, 2} {2, 3} {3, 4} {4, 10} {5, 6} {6, 1} {7, 2}", "--------", "---------", "--------", "     ----   ", "------", "-----------", "---------------", "----------------");

            for (int i = 0; i < counter; i++)
            {
               Console.WriteLine(string.Format("{0, 5} {1, 10} {2, 9} {3, 12} {4, 10} {5, 10:C} {6, 9} {7, 20}", MemberInfo[i].AccountNumber, MemberInfo[i].MemberFirstName, MemberInfo[i].MemberLastName,
                                 MemberInfo[i].MemberCity, MemberInfo[i].genderTypeText(), MemberInfo[i].MonthlyPayment, MemberInfo[i].MembershipType, MemberInfo[i].memberTypeText()));
            }
        }

        static void calcMemAvgMonthlyPayments(Member[] MemberInfo, int counter)
        {
            double total =0;
            double totalAvg = 0;
            int addCount = 0;

            Console.WriteLine("\n The average monthly payment for all members is: ");

            for (int i = 0; i < counter; i++)
            {
                if (true)
                {
                    total += MemberInfo[i].MonthlyPayment;
                    addCount ++;

                    totalAvg = total / addCount;              
                     
                }            

            } 
            Console.WriteLine(string.Format("{0, 1:C}", totalAvg) + "\n");     

        }

        static void calcTierAvgMonthlyPayments(Member[] MemberInfo, int counter)
        {
            //local variables + flag
            double calcMonthlyPayment = 0;
            int addCount = 0;
            double tierAvgPayment = 0;
            int whichTier;
            string input;
            string output ="";

            bool found = false;

            Console.WriteLine("\n Please enter a 2-digit Membership-Value \n to view the average monthly payments of that Tier: ");
            input = Console.ReadLine();
            whichTier = Convert.ToInt32(input);

            for (int i = 0; i < counter; i++)
            {
                if (whichTier == MemberInfo[i].MembershipType)
                {
                    if (true)
                    {
                        calcMonthlyPayment += MemberInfo[i].MonthlyPayment;
                        addCount++;

                        tierAvgPayment = calcMonthlyPayment / addCount;

                        output = MemberInfo[i].memberTypeText();                        
                    }
                    
                    found = true;
                }
                
            }            
            Console.WriteLine(string.Format("\n {0, 1} {1, 1:C} {2, 1} {3, 1}", "Average payement is:", tierAvgPayment, " for Tier-Type:", output));

            if (!found)
            {
                Console.WriteLine("Sorry that MemberShip-Tier-Entry does not match our membership records. \n Error: Average Tier Total = $0");
            }
         
        }

        static void printmembersinCity(Member[] MemberInfo, int counter)
        {
            //local variables + flag
            string whichCity = "";
            Console.WriteLine("\n Please enter a city to find the members living there: ");
            whichCity = Console.ReadLine();

            //flag
            bool found = false;

            for (int i = 0; i < counter; i++)
            {
                if(whichCity == MemberInfo[i].MemberCity)
                    {
                        Console.WriteLine("City Name: " + MemberInfo[i].MemberCity +
                                          ", Member Last Name: " + MemberInfo[i].MemberLastName);
                        found = true;
                    }              

            }

            if (!found)
            {
                Console.WriteLine("Sorry that city input does not match our membership records.");
            }

         }       

        static void printMemberInfo(Member[] MemberInfo, int counter)
        {
            //local variables + flag
            int whatAcctNumber;
            string input;

            bool found = false;

            Console.WriteLine("\n Please enter the 5-digit account number for the account holder's full name: ");
            input = Console.ReadLine();
            whatAcctNumber = Convert.ToInt32(input);

            for (int i = 0; i < counter; i++)
            {
                if (whatAcctNumber == MemberInfo[i].AccountNumber)
                {
                    Console.WriteLine("\n The member's full name of account number " + MemberInfo[i].AccountNumber + " is " + MemberInfo[i].MemberFirstName +
                                      " " + MemberInfo[i].MemberLastName + ". \n");
                    found = true;
                }
               
            }

            if (!found)
            {
                Console.WriteLine("Sorry that account number input does not match our membership records.");
            }


        }

        static void printMemberFamilies(Member[] MemberInfo, int counter)
         {
              //local variables + flag
              string whatLastName;
              int whatMemberTier; 
              string input;

             bool found = false;

            //recalled for cross-referencing for the next prompt:            
            printMembers(MemberInfo, counter);

            //descriptive title for this method:
            Console.WriteLine("\n >>> Proceeding to find a specific membership status >>> \n");

             Console.WriteLine("Please enter the last name for the account: ");
             whatLastName = Console.ReadLine();

             Console.WriteLine("Please enter this member's tier-value to find their tier-status: (^refer to list above if needed^) ");            
             input = Console.ReadLine();
             whatMemberTier = Convert.ToInt32(input);
            

             for (int i =0; i < counter; i++)
             {
                 if (whatLastName == MemberInfo[i].MemberLastName && whatMemberTier == MemberInfo[i].MembershipType)
                {
                    Console.WriteLine("The member " + MemberInfo[i].MemberFirstName + " " + MemberInfo[i].MemberLastName + " has a tier-status of: " +
                                          MemberInfo[i].memberTypeText());

                    found = true;
                 }             
                            
             }

            if (!found)
            {
                Console.WriteLine("Sorry that input does not match our membership records.");
            }

        } 

        static void BubbleSortOnMemType(Member[] MemberArray, int counter)
        {
            Console.WriteLine("\n Now the members will be sorted according to their Tier-Type, \n and display the equivalent Tier-Status with their Last-Name: \n");

            Member temp;            

            for (int j = 0; j < counter; j++)
            {
                for (int i = 0; i < counter - 1; i++)
                {
                    if (MemberArray[i].MembershipType > MemberArray[i + 1].MembershipType)
                    {
                        temp = MemberArray[i + 1];
                        MemberArray[i + 1] = MemberArray[i];
                        MemberArray[i] = temp;
                        
                    }
                    
                }
               
            }

            //descriptive headings for the sort:
            Console.WriteLine(string.Format("{0, 1} {1, 2} {2, 4}", "TierType", " TierStatus ", "LastName"));
            Console.WriteLine(string.Format("{0, 1} {1, 2} {2, 4}", "--------", " ---------- ", "--------"));

            //to display the sort method when called upon in Main rather than printMembers method again:
            for (int z = 0; z < counter; z++)
            {                
                Console.WriteLine(string.Format("{0, 4} {1, 15} {2, 8}", MemberArray[z].MembershipType, MemberArray[z].memberTypeText(), MemberArray[z].MemberLastName));
            } 

        }         

        static void Main(string[] args)
        {
            //local variables:
            int memberAcctNumber;
            string memberFirstName;
            string memberLastName;
            string memberHomeCity;
            string memberGender;
            double monthlyPayment;
            int membershipType;

            string input;

            //using an object-array
            Member[] MemberInfo = new Member[50];

            int counter = 0;

            StreamReader inputFile = new StreamReader("members.txt");

            input = inputFile.ReadLine();
            while (input != null)
            {
                memberAcctNumber = Convert.ToInt32(input);                
                memberFirstName = inputFile.ReadLine();
                memberLastName = inputFile.ReadLine();
                memberHomeCity = inputFile.ReadLine();
                memberGender = inputFile.ReadLine();
                input = inputFile.ReadLine();
                monthlyPayment = Convert.ToDouble(input);
                input = inputFile.ReadLine();
                membershipType = Convert.ToInt32(input);

                MemberInfo[counter] = new Member(memberAcctNumber, memberFirstName, memberLastName, memberHomeCity, memberGender,
                                                   monthlyPayment, membershipType);

                counter++;
                input = inputFile.ReadLine();

            }

            //static method calls next:

             printMembers(MemberInfo, counter);

             calcMemAvgMonthlyPayments(MemberInfo, counter);

             calcTierAvgMonthlyPayments(MemberInfo, counter);

             printmembersinCity(MemberInfo, counter);

             printMemberInfo(MemberInfo, counter);

             printMemberFamilies(MemberInfo, counter);            

             BubbleSortOnMemType(MemberInfo, counter);               


        }
    }
}
