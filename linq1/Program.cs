using LINQ.DataSources;

namespace linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var productlist = Source.ProductList;

            // Q1
            var q1 = productlist.Where(p => p.Category == "Seafood");

            foreach (var p in q1)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            }

            // Q2
            var q2 = productlist.Select(p => p.ProductName);

            foreach (var name in q2)
            {
                Console.WriteLine(name);
            }

            // Q3
            var q3 = productlist.OrderBy(p => p.UnitPrice);

            foreach (var p in q3)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            }

            // Q4
            var q4 = productlist.Where(p =>
                p.UnitPrice >= 10 && p.UnitPrice <= 30);

            foreach (var p in q4)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            }

            // Q5
            var q5 = productlist.Where(p =>
                p.UnitsInStock > 0 && p.Category == "Condiments");

            foreach (var p in q5)
            {
                Console.WriteLine(p.ProductName);
            }

            // Q6
            var q6 = productlist.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0
                    ? "Available"
                    : "Out of Stock"
            });

            foreach (var p in q6)
            {
                Console.WriteLine($"{p.Name} - {p.Price} - {p.StockStatus}");
            }

            // Q7
            var q7 = productlist.Select((p, index) =>
                $"{index + 1}. {p.ProductName}");

            foreach (var item in q7)
            {
                Console.WriteLine(item);
            }

            // Q8
            var q8 = productlist
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var p in q8)
            {
                Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");
            }

            // Q9
            var q9 = productlist
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in q9)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");
            }

            // Q10
            var q10 =
                from c in Source.CustomerList
                from o in c.Orders
                where o.OrderDate >= new DateTime(1997, 1, 1)
                select new
                {
                    c.CustomerID,
                    o.OrderDate
                };

            foreach (var order in q10)
            {
                Console.WriteLine($"{order.CustomerID} - {order.OrderDate}");
            }

            // Q11
            var q11 = productlist.Select((p, index) => new
            {
                Position = index + 1,
                p.ProductName
            });

            foreach (var p in q11)
            {
                Console.WriteLine($"{p.Position}. {p.ProductName}");
            }

            // Q12
            string[] Arr =
            {
    "aPPLE", "AbAcUs", "bRaNcH",
    "BlUeBeRrY", "ClOvEr", "cHeRry"
};

            var q12 = Arr
                .OrderBy(s => s.Length)
                .ThenBy(s => s, StringComparer.OrdinalIgnoreCase);

            foreach (var word in q12)
            {
                Console.WriteLine(word);
            }

            // Q13
            var q13 = Arr
                .Where(s => s.Length > 1 &&
                            char.ToLowerInvariant(s[1]) == 'i')
                .Reverse()
                .ToList();

            foreach (var word in q13)
            {
                Console.WriteLine(word);
            }
        }
    }
}
