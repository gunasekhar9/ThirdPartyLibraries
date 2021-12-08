using System;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ThirdPartyLibraries
{
    public class csvHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = (@"C:\Users\gunas\OneDrive\Documents\Git Problems\ThirdPartyLibraries\ThirdPartyLibraries\ThirdPartyLibraries\Utility\Addresses.csv");
            string exportFilePath = (@"C:\Users\gunas\OneDrive\Documents\Git Problems\ThirdPartyLibraries\ThirdPartyLibraries\ThirdPartyLibraries\Utility\export.csv");

            //reading csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read Data successfully from address csv.");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.Firstname + "\t" + addressData.Lastname + "\t" + addressData.Address + "\t" + addressData.City + "\t" + addressData.State + "\t" + addressData.Code + "\n");
                }
                Console.WriteLine("///// now reading from csv file and write to csv File /////");
                // write csv file
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }

            }
        }
    }
}
