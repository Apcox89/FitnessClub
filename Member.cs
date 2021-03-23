using System;
//A.Cox
//SD-613-Final-Project
//10.20.19


namespace FitnallClubFinalRedux
{
    class Member
    {
       // private string memGender; //to mutate accessor method

        public int AccountNumber { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberCity { get; set; }
        public string MemberGender{ get; set; }
        public double MonthlyPayment { get; set; }
        public int MembershipType { get; set; }


        //non-default constructor:
        public Member(int accountNumber, string memberFirstName, string memberLastName, string memberCity,
                   string memberGender, double monthlyPayment, int membershipType)
        {
            AccountNumber = accountNumber;
            MemberFirstName = memberFirstName;
            MemberLastName = memberLastName;
            MemberCity = memberCity;
            MemberGender = memberGender;
            MonthlyPayment = monthlyPayment;
            MembershipType = membershipType;

        }
        
            //+ default constructor
            public Member()
            {
                AccountNumber = 0;
                MemberFirstName = "memberfirst";
                MemberLastName = "memberlast";
                MemberCity = "citylocated";
                MemberGender = "m/f";
                MonthlyPayment = 00.00; //how much their tier of membership costs
                MembershipType = 0; //selection code for membership tier

            }

        //genderTypeText method rather than mutating string method
        public string genderTypeText()
        {
            string gen = "";
            if (MemberGender == "M")
            {
                gen = "Male";
            }
            if (MemberGender == "F")
            {
                gen = "Female";
            }

            return gen;

        }

        //memberTypeText method here to return a string value when converted to int32 input is entered from a user:
        public string memberTypeText()        
         {
            string mem ="";
            if (MembershipType == 10)
            {
                mem = "Individual";
            }

            if (MembershipType == 20)
            {
                mem = "Family";
            }

            if (MembershipType == 35)
            {
                mem = "Senior";
            }

            return mem;
           
        }

        //toString method
        public override string ToString()
        {
            return AccountNumber + " " + MemberFirstName + " " + MemberLastName + " " + MemberCity +
                        " " + MemberGender + " " + MonthlyPayment + " " + MembershipType; 
        }
    }
}
