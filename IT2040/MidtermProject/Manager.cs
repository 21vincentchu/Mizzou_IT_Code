namespace MidtermProject
{
    class Manager : Employee
    {
        private string department;
        private string region;
        

        public Manager(string firstName, string lastName, string id, string department, string region) : base (firstName, lastName, id, EmployeeType.Manger)
        {
            this.department = department;
            this.region = region;
        }

       

        public string getDepartment()
        {
            return department;
        }

        public void setDepartment(string newDepartment)
        {
            department = newDepartment;
        }

        public string getRegion()
        {
            return region;
        }

        public void setRegion(string newRegion)
        {
            region = newRegion;
        }

    }
}