using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class DataProvider
{
    public class Сargo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //Рядки файлу «Поставки» містять код товару, дату, назву постачальника, обсяг поставок, ціну за одиницю.
    public class Delivery
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int SizeDeliveries { get; set; }
        public int Price { get; set; }
    }

    const string DataDir = @"F:\Labs C#\SampleData\";
    const string errorsFileName = DataDir + "errors.log";

    static Dictionary<string, string> fileNames = new Dictionary<string, string>
    {
        {"items", DataDir + "items.txt" },
        {"deliveries", DataDir + "deliveries.txt" }
    };

    public static Dictionary<int, Сargo> Goods;
    public static List<Delivery> Deliveries;

    public static bool ReadData()
    {
        Goods = new Dictionary<int, Сargo>();
        Deliveries = new List<Delivery>();

        var errorMessages = new StringBuilder();

        foreach (string name in fileNames.Values)
        {
            if (!File.Exists(name))
            {
                errorMessages.AppendLine($"File {name} not found. Data reading process failed");
                File.AppendAllText(errorsFileName, errorMessages.ToString());
                return false;
            }
        }

        var fileName = fileNames["items"];
        using (var reader = new StreamReader(fileName))
        {
            var lineNumber = 0;
            while (!reader.EndOfStream)
            {
                var words = reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                lineNumber++;
                if (words.Length != 2 || !int.TryParse(words[0], out var id) || Goods.ContainsKey(id))
                    errorMessages.AppendLine($"Invalid data in line #{lineNumber} in {fileName}");
                else
                    Goods[id] = new Сargo { Id = id, Name = words[1] };
            }
        }

        fileName = fileNames["deliveries"];
        using (var reader = new StreamReader(fileName))
        {
            var lineNumber = 0;
            while (!reader.EndOfStream)
            {
                var words = reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                lineNumber++;
                if (words.Length != 5 || !int.TryParse(words[0], out var delId) ||
                   !DateTime.TryParse(words[1], out var deliveryDate) || !int.TryParse(words[3], out var size) ||
                   !int.TryParse(words[4], out var price))
                    errorMessages.AppendLine($"Invalid data in line #{lineNumber} in {fileName}");
                else
                    Deliveries.Add(new Delivery { Id = delId, Date = deliveryDate, Name = words[2], SizeDeliveries = size, Price = price });
            }
        }
        if (errorMessages.Length > 0)
        {
            File.AppendAllText(errorsFileName, errorMessages.ToString());
            Console.Error.WriteLine(errorMessages);
            return false;
        }
        return true;

    }

    public static Dictionary<string, string> Users = new Dictionary<string, string>
    {
        {"vlad", "123123" },
        {"admin", "admin" }
    };
}
