using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NigerianFinancials
{
    public class Nuban {
        /**
         * Summary:
         * Predicts possible banks from a supplied System.String object representing a recognised nuban bank account
         * 
         * Parameters: 
         *  nuban: 
         *      Recoginised NUBAN bank account number
         * 
         * Returns:
         *  THis returns a System.Collection.Generic.List of type String representing the predicated Nigerian banks
         * 
         */
        public static List<string> PredictBank(string nuban)
        {
            string result = string.Empty;

            var section = GetBanks();

            List<string> bankNames = section.Where(item => VerifyNubanCheckDigit(item.bankcode, nuban)).Select(item => item.bankname).ToList();
            return bankNames;
        }

        public static List<Bank> GetBanks()
        {
            return new List<Bank>
            {
                new Bank("1","011","FirstBank"),
                new Bank("2","014","Mainstreet"),
                new Bank("3","023","CitiBank"),
                new Bank("4","030","Heritage"),
                new Bank("5","032","Union"),
                new Bank("6","033","UBA"),
                new Bank("7","035","Wema"),
                new Bank("8","044","Access"),
                new Bank("9","050","Ecobank"),
                new Bank("10","057","Zenith"),
                new Bank("11","058","GTB"),
                new Bank("12","063","Access(Diamond)"),
                new Bank("13","068","StanChart"),
                new Bank("14","070","Fidelity"),
                new Bank("15","076","Polaris(Skye)"),
                new Bank("16","082","Keystone"),
                new Bank("17","084","Enterprise"),
                new Bank("18","214","FCMB"),
                new Bank("19","215","Unity"),
                new Bank("20","221","Stanbic"),
                new Bank("21","232","Sterling"),
                new Bank("22","301","Jaiz"),
                new Bank("23","101","Providus"),
                new Bank("24", "608", "Finatrust MFB"),
                new Bank("25", "559", "Coronation Merchant Bank"),
                new Bank("26", "522", "NPF Microfinance Bank"),
                new Bank("27", "501", "Fortis Microfinance Bank"),
                new Bank("28", "401", "ASOSavings"),
                new Bank("30", "402", "JubileeLife"),
                new Bank("31", "526", "Parralex"),
                new Bank("32", "403", "Safetrust Mortgage bank"),
                new Bank("33", "327", "Pagatech"),
                new Bank("34", "102", "Titan Trust Bank"),
            };
        }

        private static bool VerifyNubanCheckDigit(string bankcode, string nuban)
        {
            bool isValidNuban = false;
            nuban = bankcode + nuban.Trim();

            if (nuban.Length != 13)
            {
                return false;
            }
            string nubanAcct = nuban.Substring(0, 12);
            int checkDigitFromAcctNumber = Convert.ToInt16(nuban.Substring(12, 1));
            string magicNumber = "373373373373";
            int totalValue = 0;
            int calculatedCheckDigit = 0;
            for (int i = 0; i < 12; i++)
            {
                totalValue = totalValue + (Convert.ToInt16(magicNumber.Substring(i, 1)) * Convert.ToInt16(nubanAcct.Substring(i, 1)));
            }
            if ((totalValue % 10) == 0)
            {
                calculatedCheckDigit = 0;
            }
            else
            {

                calculatedCheckDigit = 10 - (totalValue % 10);
            }

            if (checkDigitFromAcctNumber == calculatedCheckDigit)
            {
                isValidNuban = true;
            }

            return isValidNuban;
        }
        public class Bank
        {
            public Bank(string id, string bankcode, string bankname)
            {
                this.id = id;
                this.bankcode = bankcode;
                this.bankname = bankname;
            }

            public string id { get; set; }
            public string bankcode { get; set; }
            public string bankname { get; set; }
        }

    }
}
