using static LinqLab.ListGenerators;
using static LinqLab.Customer;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System;
using System.Diagnostics.CodeAnalysis;

namespace LinqLab
{
    public class Case_Insensitive_Comparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class CustomComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            return SortString(x) == SortString(y);
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return SortString(obj).GetHashCode();
        }

         string SortString(string x)
        {
            char[] chars = x.ToCharArray();
            Array.Sort(chars);

            return new string(chars);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators

            //1. Find all products that are out of stock.

            //var result = ProductList.Where(product => product.UnitsInStock == 0);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //2. Find all products that are in stock and cost more than 3.00 per unit.

            //var result = ProductList.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //3. Returns digits whose name is shorter than their value.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var result = Arr.Where((digit, index) => digit.Length < index);
            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region LINQ - Element Operators

            // 1. Get first Product out of Stock

            //var result = ProductList.Where(p => p.UnitsInStock == 0).FirstOrDefault();
            //Console.WriteLine(result);



            //2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            //var result = ProductList.Where(p => p.UnitPrice > 1000).FirstOrDefault();
            //Console.WriteLine(result);



            //3. Retrieve the second number greater than 5 

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = Arr.Where(x => x > 5).ElementAt(1);
            //var result = Arr.Where(x => x > 5).Skip(1).FirstOrDefault();
            //Console.WriteLine(result);

            #endregion

            #region LINQ - Set Operators

            // 1. Find the unique Category names from Product 

            //var result = ProductList.Select(p => p.Category).Distinct();
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //2. Produce a Sequence containing the unique first letter from both product and customer names.

            //var result = ProductList.Select(p => p.ProductName.First()).Union(CustomerList.Select(c => c.CustomerName.First()));
            //foreach (var item in result)
            //    Console.Write(item + ", ");



            //3. Create one sequence that contains the common first letter from both product and customer names.

            //var result = ProductList.Select(p => p.ProductName.First()).Intersect(CustomerList.Select(c => c.CustomerName.First()));
            //foreach (var item in result)
            //    Console.Write(item + ", ");



            //4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            //var result = ProductList.Select(p => p.ProductName.First()).Except(CustomerList.Select(c => c.CustomerName.First()));
            //foreach (var item in result)
            //    Console.Write(item + ", ");



            //5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates

            //var result = ProductList.Select(product => product.ProductName.TakeLast(3)).Concat(CustomerList.Select(customer => customer.CustomerName.TakeLast(3)));
            //foreach (var item in result)
            //{
            //    foreach (var letter in item)
            //        Console.Write(letter+", ");
            //    Console.WriteLine();
            //}

            #endregion

            #region LINQ - Aggregate Operators
            //1. Uses Count to get the number of odd numbers in the array

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = Arr.Count(x => x % 2 != 0);
            //Console.WriteLine(result);



            //2. Return a list of customers and how many orders each has.

            //var result = CustomerList.Select(c => new { c.CustomerName, orderCount = c.Orders.Length });
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //3. Return a list of categories and how many products each has

            //List<string> result = new List<string>();
            //ProductList.ForEach(c =>
            //{
            //    string productCat = $"{c.Category} => {ProductList.Count(cat => cat.Category == c.Category)}";
            //    if (!result.Contains(productCat))
            //        result.Add(productCat);
            //});

            //foreach(var item in result)
            //    Console.WriteLine(item);

            //var result = ProductList.GroupBy(p => p.Category).Select(c => new { CategoryName = c.Key, ProductNo = c.Count() });
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //4.Get the total of the numbers in an array.

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = Arr.Sum();
            //Console.WriteLine(result);



            //5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var result = words.Sum(w => w.Length);
            //Console.WriteLine(result);



            //6. Get the total units in stock for each product category.

            //var result = ProductList.GroupBy(product => product.Category)
            //                        .Select(categoryProductsCount => new
            //                        {
            //                            Category = categoryProductsCount.Key,
            //                            TotalUnitsInStock = categoryProductsCount.Sum(product => product.UnitsInStock)
            //                        });

            //var result = from p in ProductList
            //         group p by p.Category into temp
            //         select new
            //         {
            //             category = temp.Key,
            //             TotalUnitInStock = temp.Sum(product => product.UnitsInStock)
            //         };
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var result = words.Min(w => w.Length);
            //Console.WriteLine(result);



            //8.Get the cheapest price among each category's products

            //var result = ProductList.GroupBy(p => p.Category)
            //                        .Select(p => new
            //                        {
            //                            Category = p.Key,
            //                            CheapestPrice_Product = p.Min(p => p.UnitPrice)
            //                        });

            //var result = from p in ProductList
            //             group p by p.Category into temp
            //             select new
            //             {
            //                 category = temp.Key,
            //                 cheapestPrice = temp.Min(product => product.UnitsInStock)
            //             };

            //foreach (var item in result)
            //    Console.WriteLine(item);



            //9.Get the products with the cheapest price in each category(Use Let)

            //var result = from product in ProductList
            //             group product by product.Category into GroupCategory
            //             let CheapestProduct = GroupCategory.Where(p => p.UnitPrice == GroupCategory.Min(p => p.UnitPrice))
            //             select CheapestProduct;

            //foreach (var item in result)
            //{
            //    foreach (var product in item)
            //    {
            //        Console.WriteLine($"Product Name : {product.ProductName} :: Category {product.Category} :: {product.UnitPrice}");
            //    }
            //}




            //10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var result = words.Max(w => w.Count());
            //Console.WriteLine(result);



            //11. Get the most expensive price among each category's products.

            //var result = ProductList.GroupBy(p => p.Category)
            //                        .Select(p => new
            //                        {
            //                            Category = p.Key,
            //                            MostExpensivePrice = p.Max(p => p.UnitPrice)
            //                        });
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //12. Get the products with the most expensive price in each category.

            //var result = ProductList.GroupBy(p => p.Category)
            //                        .Select(p => new
            //                        {
            //                            Category = p.Key, 
            //                            MostExpensiveProduct = p.MaxBy(p => p.UnitPrice) 
            //                        });
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //13. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var result = (int)words.Average(w => w.Length);
            //Console.WriteLine(result);



            //14. Get the average price of each category's products.

            //var result = ProductList.GroupBy(p => p.Category)
            //                        .Select(p => new
            //                        {
            //                            Category = p.Key,
            //                            AveragePrice = p.Average(p => p.UnitPrice)
            //                        });
            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region LINQ - Ordering Operators

            //1. Sort a list of products by name

            //var result = ProductList.OrderBy(product => product.ProductName);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //2. Uses a custom comparer to do a case-insensitive sort of the words in an array.

            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var result = Arr.OrderBy(a => a,new Case_Insensitive_Comparer());
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //3. Sort a list of products by units in stock from highest to lowest.

            //var result = ProductList.OrderByDescending(p => p.UnitsInStock);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var result = Arr.OrderBy(x => x.Length).ThenBy(x => x);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //5. Sort first by word length and then by a case-insensitive sort of the words in an array.

            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var result = words.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            //foreach (string word in result)
            //    Console.WriteLine(word);



            //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.

            //var result = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.

            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var result = Arr.OrderBy(word => word.Length).ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var digits = Arr.Where(d => d[1] == 'i').Reverse().ToList();
            //foreach (var item in digits)
            //    Console.WriteLine(item);


            #endregion

            #region LINQ - Partitioning Operators
            // 1.Get the first 3 orders from customers in Washington

            //var result = CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Take(3);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //2.Get all but the first 2 orders from customers in Washington.

            //var result = CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Skip(2);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = numbers.TakeWhile((num, index) => num >= index);
            //foreach (int num in result)
            //    Console.WriteLine(num);



            //4.Get the elements of the array starting from the first element divisible by 3.

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = numbers.SkipWhile(num => num % 3 != 0);
            //foreach (int num in result)
            //    Console.WriteLine(num);

            //5.Get the elements of the array starting from the first element less than its position.

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = numbers.SkipWhile((num, index) => num >= index);
            //foreach (var i in result)
            //    Console.WriteLine(i);

            #endregion

            #region LINQ - Projection Operators
            //1. Return a sequence of just the names of a list of products.

            //var result = ProductList.Select(p => p.ProductName);
            //foreach (var item in result)
            //    Console.WriteLine(item);


            //2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //var result = words.Select(word => new { LowerCase = word.ToLower(), UpperCase = word.ToUpper() });
            //foreach (var word in result)
            //    Console.WriteLine(word);



            //3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            //var result = ProductList.Select(product => new { ProductName = product.ProductName, Count = product.UnitsInStock, price = product.UnitPrice });
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //4. Determine if the value of ints in an array match their position in the array.

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = Arr.Select((num, index) => new { Number = num, IsEqual = num == index });
            //foreach (var i in result)
            //    Console.WriteLine(i.Number + " : " + i.IsEqual);



            // 5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var result = numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => new { a, b });
            //var result = from a in numbersA
            //             from b in numbersB
            //             where a < b
            //             select new { a, b };


            //Console.WriteLine("Pairs where a < b:");
            //foreach (var item in result)
            //    Console.WriteLine(item.a + " is less than " + item.b);



            //6. Select all orders where the order total is less than 500.00.

            //var result = CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            //7.Select all orders where the order was made in 1998 or later.

            //var result = CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
            //foreach (var item in result)
            //    Console.WriteLine(item);



            #endregion

            #region LINQ - Quantifiers
            //1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var result = words.Any(word => word.Contains("ei"));
            //Console.WriteLine(result);



            //2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            //var result = ProductList.GroupBy(c => c.Category)
            //                        .Where(products => products.Any(p => p.UnitsInStock == 0))
            //                        .Select(product => new { Category = product.Key, Products = product });
            //foreach (var category in result)
            //{
            //    Console.WriteLine(category.Category);
            //    foreach (var product in category.Products)
            //        Console.WriteLine(product);
            //}



            //3. Return a grouped a list of products only for categories that have all of their products in stock.

            //var result = ProductList.GroupBy(c => c.Category)
            //                        .Where(products => products.All(p=> p.UnitsInStock > 0))
            //                        .Select(Product => new { Category = Product.Key, products = Product});
            //foreach (var Category in result)
            //{
            //    Console.WriteLine(Category.Category);
            //    foreach (var Product in Category.products)
            //    {
            //        Console.WriteLine(Product);
            //    }
            //}

            #endregion

            #region LINQ – Grouping Operators
            //1. Use group by to partition a list of numbers by their remainder when divided by 5

            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //var result = numbers.GroupBy(num => num % 5);
            //foreach (var item in result)
            //{
            //    Console.WriteLine("Number with a remainder of " + item.Key + " divided by 5" );
            //    foreach (var number in item)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}



            //2. Uses group by to partition a list of words by their first letter.Use dictionary_english.txt for Input

            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var result = words.GroupBy(word => word.First());
            //foreach (var c in result)
            //{
            //    Console.WriteLine("Words Starts With Character : " + c.Key);
            //    foreach (var word in c)
            //    {
            //        Console.WriteLine(word);
            //    }
            //}



            //3. Consider this Array as an Input
            //Use Group By with a custom comparer that matches words that are consists of the same Characters Together

            //string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
            ////var result = Arr.GroupBy(word => new string(word.OrderBy(character => character).ToArray()));

            //var result = Arr.GroupBy(w => w, new CustomComparer());
            //foreach (var group in result)
            //{
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine(word);
            //    }
            //    Console.WriteLine(".....");
            //}

            #endregion


            //Search

            #region Zip Operator
            //List<string> Names = new List<string> { "Ahmed", "Ali", "Osama", "Aya", "Dina" };
            //List<int> Numbers = Enumerable.Range(1, 10).ToList();
            //var result = Names.Zip(Numbers, (name, index) => new { Index = index, Name = name });
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Grouping operator
            //var result = ProductList.Where(product => product.UnitsInStock > 0)
            //                        .GroupBy(product => product.Category)
            //                        .Where(productGroup => productGroup.Count() > 10)
            //                        .OrderByDescending(productGroup => productGroup.Count())
            //                        .Select(productGroup => new { Category = productGroup.Key, Count = productGroup.Count() });

            //var result = from product in ProductList
            //             where product.UnitsInStock > 0
            //             group product by product.Category into ProductGroup
            //             where ProductGroup.Count() > 10
            //             orderby ProductGroup.Count() descending
            //             select new { Category = ProductGroup.Key, Count = ProductGroup.Count() };
            //foreach (var group in result) 
            //{
            //Console.WriteLine(group.Key);
            //foreach (var item in group)
            //    Console.WriteLine($"======{item}");
            //    Console.WriteLine(group);

            //}
            #endregion

            #region Let - Into
            //List<string> Names = new List<string> { "Ahmed", "Ali", "Osama", "Aya", "Dina", "Sally", "Mohsen", "Mohamed" };
            //var result = from name in Names
            //             select Regex.Replace(name, "[aeoiuAEOIU]",string.Empty)
            //             into newName
            //             where newName.Length >= 3
            //             select newName;

            //result = from name in Names
            //         let newName = Regex.Replace(name, "[aeoiuAEOIU]", string.Empty)
            //         where newName.Length >= 3
            //         select newName;

            //foreach (var name in result)
            //{
            //    Console.WriteLine(name);
            //}

            //var DiscountProducts = from p in ProductList
            //                       let newProduct = new
            //                       {
            //                           Id = p.ProductID,
            //                           Name = p.ProductName,
            //                           Category = p.Category,
            //                           Count = p.UnitsInStock,
            //                           NewPrice = p.UnitPrice * 0.8m
            //                       }
            //                       where newProduct.Count > 10
            //                       select newProduct;
            //foreach (var item in DiscountProducts)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Quantifier Operators => Return bolean Value
            //var result = ProductList.Any();
            //var result = ProductList.Any(product => product.UnitPrice == 19);
            //var result = ProductList.All(product => product.UnitPrice == 0 );

            //var seq01 = Enumerable.Range(0, 100); //0 => 99
            //var seq02 = Enumerable.Range(0, 100); //50 => 199

            //var result = seq01.SequenceEqual(seq02);

            //Console.WriteLine(result); 
            //Console.WriteLine(seq01.Count()); 
            //Console.WriteLine(seq02.Count());  

            #endregion


        }
    }
}
