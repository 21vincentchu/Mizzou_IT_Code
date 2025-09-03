namespace MidtermProject
{
    class Employee
    {
        private string firstName;
        private string lastName;
        private string id;
        private EmployeeType empType;

        public Employee(string firstName, string lastName, string id, EmployeeType empType)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.empType = empType;
        }

        

        public string getFirstName()
        {
            return firstName;
        }

        public void setFirstName(string newName)
        {
            firstName = newName;
        }
        public string getlastName()
        {
            return lastName;
        }

        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }
        public string getID()
        {
            return id;
        }

        public EmployeeType getEmpType()
        {
            return empType;
        }

        public void setEmpType(EmployeeType newEmpType)
        {
            empType = newEmpType;
        }

        public void getEmployeeInfo()
        {
            Console.WriteLine($"Name: {firstName} {lastName}\nID: {id}\nType: {empType}");
        }
    }
}