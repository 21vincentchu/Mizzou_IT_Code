namespace MidtermProject
{
    class Associate : Employee
    {
        private string department;
        private float sales;

        public Associate(string firstName, string lastName, string id, string department, float sales) : base(firstName, lastName, id, EmployeeType.Associate)
        {
            this.department = department;
            this.sales = sales;
        }
        
        public string getDepartment()
        {
            return department;
        }

        public void setDepartment(string newDepartment)
        {
            department = newDepartment;
        }
        public float getSales()
        {
            return sales;
        }
        public void updateSales(float newSale)
        {
            sales += newSale;
        }

        public SalesLevel GetSalesLevel()
        {
            if(getSales() < 10000)
            {
                return SalesLevel.Bronze;
            }
            else if(getSales() < 20000)
            {
                return SalesLevel.Silver;
            }
            else if(getSales() < 30000)
            {
                return SalesLevel.Gold;
            }
            else if(getSales() < 40000)
            {
                return SalesLevel.Diamond;
            }
            else
            {
                return SalesLevel.Platinum;
            }
        }
    }
}