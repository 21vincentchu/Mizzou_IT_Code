namespace SalesDataAnalyzerProject2;
class Program
{
    static void Main(string[] args)
    {
        //welcome user
        Console.WriteLine("Welcome to sales data analyzer");
        try
        {
            //check if console argument is right
            if (args.Length == 2)
            {
                string salesFile = args[0];
                string reportFile = args[1];
                try
                {
                    List<Sale> salesList = SalesDataLoader.loadFile(salesFile);
                    StreamWriter fileWriter = new StreamWriter(reportFile);
                    try
                    {
                        //1. ****Calculate total sales in the data set****
                        decimal totalSales = (from sales in salesList
                                              select sales.getUnitPrice() * sales.getQuantity()).Sum();

                        fileWriter.WriteLine(printALine() + "Total Sales in data set" + printALine() + $"total sales: {totalSales:c2}");

                        //2. ****Show the unique product lines in the data set****
                        var uniqueProductLines = (from sales in salesList
                                                  select sales.getProductLine()).Distinct(); //Check references

                        fileWriter.WriteLine(printALine() + "Unique product lines" + printALine());
                        foreach (var productLine in uniqueProductLines)
                        {
                            fileWriter.WriteLine(productLine);
                        }

                        //3. ****Calculate the total sales for EACH product line. List product line and total****
                        var totalSalesForEachProduct = from sales in salesList
                                                       group sales by sales.getProductLine() into productGroup
                                                       orderby productGroup.Key
                                                       select new
                                                       {
                                                           product = productGroup.Key,
                                                           productTotal = productGroup.Sum(sales => sales.getUnitPrice() * sales.getQuantity())
                                                       };

                        fileWriter.WriteLine(printALine() + "Total Sales Per Product Line" + printALine());
                        foreach (var productTotal in totalSalesForEachProduct)
                        {
                            fileWriter.WriteLine($"{productTotal.product}: {productTotal.productTotal:c2}");
                        }

                        //4. ****Calculate the total sales per city. List city name and total sales****
                        var totalSalesForEachCity = from sales in salesList
                                                    group sales by sales.getCity() into cityGroup
                                                    orderby cityGroup.Key
                                                    select new
                                                    {
                                                        city = cityGroup.Key,
                                                        cityTotal = cityGroup.Sum(sales => sales.getUnitPrice() * sales.getQuantity())
                                                    };

                        fileWriter.WriteLine(printALine() + "Total Sales Per City" + printALine());
                        foreach (var cityTotal in totalSalesForEachCity)
                        {
                            fileWriter.WriteLine($"{cityTotal.city}: {cityTotal.cityTotal:c2}");
                        }

                        //5. ****Which product lines have the value with the highest unit price? List the product line and the price****
                        var mostExpensiveUnit = from unit in salesList
                                                let highestPrice = salesList.Max(unit => unit.getUnitPrice() * unit.getQuantity())
                                                where unit.getUnitPrice() == highestPrice
                                                select unit;

                        fileWriter.WriteLine(printALine() + "Most expensive product line unit (s)" + printALine());
                        foreach (var unit in mostExpensiveUnit)
                        {
                            fileWriter.WriteLine($"{unit.getProductLine()}: {unit.getUnitPrice():c2}");
                        }

                        //6. ****Calculate the total sales per month in the data set. List the city, month and total sales****
                        var monthlySales = from sale in salesList
                                           group sale by new
                                           {
                                               city = sale.getCity(),
                                               month = DateTime.Parse(sale.getDate()).Month,
                                               year = DateTime.Parse(sale.getDate()).Year,
                                           } 
                                           into groupingOfSales
                                           orderby groupingOfSales.Key.city, groupingOfSales.Key.month, groupingOfSales.Key.year
                                           select new
                                           {
                                               groupingOfSales.Key.city,
                                               groupingOfSales.Key.month,
                                               groupingOfSales.Key.year,
                                               salesTotal = groupingOfSales.Sum(sale => sale.getUnitPrice() * sale.getQuantity())
                                           };
                                           
                        fileWriter.WriteLine(printALine() + "Total sales per month" + printALine());
                        string currentCity= null!;
                        foreach (var monthgroup in monthlySales)
                        {
                            if (monthgroup.city != currentCity)
                            {
                                fileWriter.WriteLine($"\n**********{monthgroup.city}**********\n");
                                currentCity = monthgroup.city;
                            }
                            fileWriter.WriteLine($"{monthgroup.month}/{monthgroup.year}: {monthgroup.city} - Total: {monthgroup.salesTotal:c2} ");
                        }

                        //7. ****calculate the total sales per payment type. List the payment type and total sales****
                        var paymentTypeTotals = from sale in salesList
                                                group sale by sale.getPaymentType() into paymentGroup
                                                orderby paymentGroup.Key
                                                select new
                                                {
                                                    paymentType = paymentGroup.Key,
                                                    productTotal = paymentGroup.Sum(sales => sales.getUnitPrice() * sales.getQuantity())
                                                };

                        fileWriter.WriteLine(printALine() + "Totals by payment type" + printALine());
                        foreach (var paymentTotal in paymentTypeTotals)
                        {
                            fileWriter.WriteLine($"{paymentTotal.paymentType}: {paymentTotal.productTotal:c2}");
                        }

                        //8. ****Calculate the number of sales transaction per member type. List the member type and number of transaction****
                        var memberTypeTransactions = from sale in salesList
                                                     group sale by sale.getCustomerType() into customerGroup
                                                     orderby customerGroup.Key
                                                     select new
                                                     {
                                                         customerType = customerGroup.Key,
                                                         TotalTransactions = customerGroup.Count()
                                                     };

                        fileWriter.WriteLine(printALine() + "Sales Transactions per member type" + printALine());
                        foreach (var paymentTotal in memberTypeTransactions)
                        {
                            fileWriter.WriteLine($"{paymentTotal.customerType}: {paymentTotal.TotalTransactions}");
                        }

                        //9. ****Calculate the AVERAGE rating per product line. List the product line and the average rating****
                        var avgRatingPerProductLine = from sale in salesList
                                                      group sale by sale.getProductLine() into productGroup
                                                      orderby productGroup.Key
                                                      select new
                                                      {
                                                          productType = productGroup.Key,
                                                          averageRating = productGroup.Average(sales => sales.getRating())
                                                      };

                        fileWriter.WriteLine(printALine() + "Average Rating For Each Product Line" + printALine());
                        foreach (var rate in avgRatingPerProductLine)
                        {
                            fileWriter.WriteLine($"{rate.productType}: {rate.averageRating:n2}");
                        }

                        //10.****Caulate the total number of transactions per payment type. List the payment type and number of transactions****
                        var transactionsPerPaymentType = from sale in salesList
                                                         group sale by sale.getPaymentType() into paymentGroup
                                                         orderby paymentGroup.Key
                                                         select new
                                                         {
                                                             paymentType = paymentGroup.Key,
                                                             transactionTotal = paymentGroup.Count()
                                                         };

                        fileWriter.WriteLine(printALine() + "Transaction Totals per payment type" + printALine());
                        foreach (var transactionTotal in transactionsPerPaymentType)
                        {
                            fileWriter.WriteLine($"{transactionTotal.paymentType}: {transactionTotal.transactionTotal}");
                        }

                        //11.****Calculate the total quanntity of products sold per city. List the city and number of products sold.****
                        var quantityPerCity = from sale in salesList
                                              group sale by sale.getCity() into cityGroup
                                              orderby cityGroup.Key
                                              select new
                                              {
                                                  city = cityGroup.Key,
                                                  quantity = cityGroup.Sum(sales => sales.getQuantity())
                                              };

                        fileWriter.WriteLine(printALine() + "Products sold per city" + printALine());
                        foreach (var cityTotal in quantityPerCity)
                        {
                            fileWriter.WriteLine($"{cityTotal.city}: {cityTotal.quantity}");
                        }

                        //12.****Using a 5% sales tax, calculate the tax for EACH sales transaction in EACH product line. List the invoice number, total sales for the transaction, and the tax amomunt of the transaction, ordered by the product line.****
                        var tax = from sale in salesList
                                  group sale by sale.getProductLine() into productGroup
                                  from eachSale in productGroup
                                  select new
                                  {
                                      productLine = eachSale.getProductLine(),
                                      invoiceID = eachSale.getInvoiceID(),
                                      taxAmount = eachSale.getUnitPrice() * eachSale.getQuantity() * 0.05m,
                                      totalWithTax = eachSale.getUnitPrice() * eachSale.getQuantity() * 1.05m,
                                  };

                        fileWriter.WriteLine(printALine() + "Each transaction by product type with a 5% sales tax" + printALine());
                        string currectProductLine = null!;
                        foreach (var taxTotal in tax)
                        {
                            if (taxTotal.productLine != currectProductLine)
                            {
                                fileWriter.WriteLine($"\n***************{taxTotal.productLine}***************\n");
                                currectProductLine = taxTotal.productLine;
                            }

                            fileWriter.WriteLine($"Invoice ID: {taxTotal.invoiceID} - Total: {taxTotal.totalWithTax:c2} - Tax: {taxTotal.taxAmount:c2}");
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine($"Exception: {err.Message}");
                    }
                    finally
                    {
                        fileWriter?.Close();
                    }
                }
                catch (Exception)
                {
                    Console.Write("Enter a valid file path for both the data and report");
                }
            }
            else
            {
                throw new Exception("You did not enter the correct filepath or declare a txt name file. Rerun the program with the correcet file path (supermarket_sales.csv report.txt) ");
            }
        }
        catch (Exception ex) //gets the error message thrown by the if else statement
        {
            Console.WriteLine(ex.Message);
        }
    }
    static string printALine()
    {
        return "\n_____________________________________\n";
    }
}
/*
References: 
- Line 30. .distinct method https://www.simplilearn.com/tutorials/asp-dot-net-tutorial/c-hash-linq-distinct#:~:text=C%23%20Linq%20Distinct()%20method,Structured%20Query%20Language%20(SQL).
- parsing the date https://learn.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=net-7.0
- used on line 158, learned what .select is and what it does, and how to retrieve directly from the methods if we're not doing a calculation https://www.educba.com/linq-select/
*/