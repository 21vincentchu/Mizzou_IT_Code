namespace AutomobileChallenge
{

    public enum AutoType
    {
        Sedan, Truck, Van, SUV
    }
    class Automobile
    {
        private string make, model, vin, color;
        private int year;
        private AutoType type;
        public Automobile(string make, string model, int year, string vin, string color, AutoType AutoType)
        {
            this.make = make;
            this.model = model;
            this.vin = vin;
            this.color = color;
            this.year = year;
            this.type = AutoType;
        }

        public string getMake() { return make; }
        public string getModel() { return model; }
        public string getVin() { return vin; }
        public string getColor() { return color; }
        public int getYear() { return year; }
        public AutoType getType() { return type; }
        public void setColor(string color)
        {
            this.color = color;
        }
        public int getAutoAge()
        {
            int autoAge = 2023 - this.getYear();
            return autoAge;
        }
    }
}