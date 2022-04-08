using System;
using YahooFinanceApi;
using System.Threading.Tasks;
using System.Linq;

namespace Historical_stock_data
{
    class Program
    {
        static void Main(string[] args)
        {
            char continueStr = 'y';
            while (continueStr == 'y')
            {
                Console.WriteLine("Enter a stock ticker or market index that you want historical data for :");
                string symbol = Console.ReadLine().ToUpper();

                Console.WriteLine("Enter the type of timespan you want");
                Console.WriteLine("Enter the type of timespan you want 'D' or 'M' or 'Y' ");

                // string type_timespan = Convert.ToChar(Console.ReadLine);
                Console.ReadKey

                string type_timespan = Console.ReadLine();
                type_timespan = Convert.ToChar(type_timespan);

                if (type_timespan == 'M')
                {

                    Console.WriteLine("Enter the amount of months you want to have");
                    int timespan = Convert.ToInt32(Console.ReadLine());
                    DateTime endDate = DateTime.Today;
                    DateTime startDate = DateTime.Today.AddMonths(-timespan);
                }
            }
        }
    }

    class StockData
    {
        public async Task<int> getStockData(string symbol, DateTime startDate, DateTime endDate)
        {
            try 
            {
                var historic_data = await Yahoo.GetHistoricalAsync(symbol, startDate, endDate);
                var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
                // pour extraire le nom de l'entreprise on a besoin d'indexer le dictionnaire
                var ticker = security[symbol];
                var companyName = ticker[Field.LongName];

                for (int i= 0; i < historic_data.Count; i++)
                {
                    //historic_data.Day ne marche pas
                    //Console.WriteLine($"{companyName} closing price on : {historic_data.Day}"); 

                    //Console.WriteLine($"{companyName} session high price : {historic_data[i].High} - session low price {historic_data[i].Low} - session volumes {historic_data[i].Volume} - closing price {historic_data[i].Close}");
                    
                    //using System.Linq
                    Console.WriteLine($"{companyName} closing price on : {historic_data.ElementAt(i).DateTime.Year} - {historic_data.ElementAt(i).DateTime.Month} - {historic_data.ElementAt(i).DateTime.Day} : {Math.Round(historic_data.ElementAt(i).Close,2)} ");   
                }
            }
            catch
            {

            }
            return 0;
        }
    }
}
