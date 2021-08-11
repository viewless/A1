using System;

namespace Calculator
{
    public class Calculator
    {
        private const decimal SmsCountLessThan50Tax = 0.18M;
        private const decimal SmsCountBetween50And100Tax = 0.16M;
        private const decimal SmsCountMoreThan100Tax = 0.11M;
    
        private const decimal MmsCountLessThan50Tax = 0.25M;
        private const decimal MmsCountBetween50And100Tax = 0.23M;
        private const decimal MmsCountMoreThan100Tax = 0.18M;
      

        private const decimal A1TaxMinutes = 0.03M;
        private const decimal OtherOperatorsTaxMinutes = 0.09M;
        private const decimal RoumingTaxMinutes = 0.15M;
       
        private const decimal InCountryMBTax = 0.02M;
        private const decimal InEuMBTax = 0.05M;
        private const decimal OutEuMBTax = 0.20M;



        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Месечна такса: ");
            decimal monthlyFee = decimal.Parse(Console.ReadLine());

            Console.Write("Брой изпратени СМС-и: ");
            int smsCount = int.Parse(Console.ReadLine());

            Console.Write("Брой изпратени ММС-и: ");
            int mmsCount = int.Parse(Console.ReadLine());

            Console.Write("Минути към А1 извън включените в пакета: ");
            int a1Minutes = int.Parse(Console.ReadLine());

            Console.Write("Минути към Теленор извън включените в пакета: ");
            int telenorMinutes = int.Parse(Console.ReadLine());

            Console.Write("Минути към Виваком извън включените в пакета: ");
            int vivacomMinutes = int.Parse(Console.ReadLine());

            Console.Write("Минути в роуминг: ");
            int roumingMinutes = int.Parse(Console.ReadLine());

            Console.Write("Използвани МБ в страната извън включените в пакета: ");
            int inCountryMB = int.Parse(Console.ReadLine());

            Console.Write("Използвани МБ в ЕС извън включените в пакета: ");
            int inEuMB = int.Parse(Console.ReadLine());

            Console.Write("Използвани МБ извън ЕС извън включените в пакета: ");
            int outEuMB = int.Parse(Console.ReadLine());

            Console.Write("Други такси: ");
            decimal taxes = decimal.Parse(Console.ReadLine());

            Console.Write("Отстъпки: ");
            decimal discount = decimal.Parse(Console.ReadLine());



            int otherOperatorMinutesCount = telenorMinutes + vivacomMinutes;


            Console.WriteLine("\nРезултат: " + TotalAmountDue(monthlyFee, smsCount, mmsCount, a1Minutes, otherOperatorMinutesCount, roumingMinutes, inCountryMB, inEuMB, outEuMB, taxes, discount));

        }

        private static decimal TotalAmountDue(decimal monthlyFee, int smsCount, int mmsCount, int a1Minutes, int otherOperatorMinutesCount, int roumingMinutes, int inCountryMB, int inEuMB, int outEuMB, decimal taxes, decimal discount)
        {
            decimal total = monthlyFee;

            total += SmsAndMmsSum(smsCount, mmsCount);

            total += OuthOfPackegMinutesSum(a1Minutes, otherOperatorMinutesCount, roumingMinutes);

            total += MBSum(inCountryMB, inEuMB, outEuMB);

            total += taxes - discount;

            return total;
        }

        private static decimal MBSum(int inCountryMB, int inEuMB, int outEuMB)
        {
            return (inCountryMB * InCountryMBTax) + (inEuMB * InEuMBTax) + (outEuMB * OutEuMBTax);
        }

        private static decimal OuthOfPackegMinutesSum(int a1Minutes, int otherOperatorMinutesCount, int roumingMinutes)
        {
            return (a1Minutes * A1TaxMinutes) + (otherOperatorMinutesCount * OtherOperatorsTaxMinutes) + (roumingMinutes * RoumingTaxMinutes);
        }

       
        private static decimal SmsAndMmsSum(int smsCount, int mmsCount)
        {
            decimal total = 0.0M;

            if (smsCount < 50)
            {
                total += smsCount * SmsCountLessThan50Tax + mmsCount * MmsCountLessThan50Tax;
            }
            else if (smsCount >= 50 && smsCount <= 100)
            {
                total += smsCount * SmsCountBetween50And100Tax + mmsCount * MmsCountBetween50And100Tax;
            }
            else if (smsCount > 100)
            {
                total += smsCount * SmsCountMoreThan100Tax + mmsCount * MmsCountMoreThan100Tax; 
            }

            return total;
        }

    }
}
