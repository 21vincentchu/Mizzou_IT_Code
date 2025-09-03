namespace SalesDataAnalyzerProject2;
public class Sale
{
    private string invoiceID;

    private char branch;
    
    private string city;

    private string customerType;

    private string gender;

    private string productLine;

    private decimal unitPrice;

    private int quantity;

    private string date;

    private string payment;
    
    private decimal rating;

    public Sale(string InvoiceID, char Branch, string City, string CustomerType, string Gender, string ProductLine, decimal UnitPrice, int Quantity, string Date, string Payment, decimal Rating)
    {
        invoiceID = InvoiceID;
        branch = Branch;
        city = City;
        customerType = CustomerType;
        gender = Gender;
        productLine = ProductLine;
        unitPrice = UnitPrice;
        quantity = Quantity;
        date = Date;
        payment = Payment;
        rating = Rating;
    }

    public string getInvoiceID()
    {
        return invoiceID;
    }
    public char getBranch()
    {
        return branch;
    }
    public string getCity()
    {
        return city;
    }
    public string getCustomerType()
    {
        return customerType;
    }
    public string getGender()
    {
        return gender;
    }
    public string getProductLine()
    {
        return productLine;
    }
    public decimal getUnitPrice()
    {
        return unitPrice;
    }
    public int getQuantity()
    {
        return quantity;
    }
    public string getDate()
    {
        return date;
    }

    public string getPaymentType()
    {
        return payment;
    }
   
    public decimal getRating()
    {
        return rating;
    }
}