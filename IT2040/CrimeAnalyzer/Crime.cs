namespace CrimeAnalyzer;
public class Crime
{
    private int year, population, violentCrime, murder, rape, robbery, aggravatedAssault, propertyCrime, burglary, theft, motorVehicleTheft;
 
    public Crime(int year, int population, int violentCrime, int murder, int rape, int robbery, int aggravatedAssault, int propertyCrime, int burglary, int theft, int motorVehicleTheft)
    {
        this.year = year;
        this.population = population;
        this.violentCrime = violentCrime;
        this.murder = murder;
        this.rape = rape;
        this.robbery = robbery;
        this.aggravatedAssault = aggravatedAssault;
        this.propertyCrime = propertyCrime;
        this.burglary = burglary;
        this.theft = theft;
        this.motorVehicleTheft = motorVehicleTheft;
    }
    public int getYear(){
        return year;
    }
    public int getPopulation(){
        return population;
    }
    public int getViolentCrime(){
        return violentCrime;
    }
    public int getMurder(){
        return murder;
    }
    public int getRape(){
        return rape;
    }
    public int getRobbery(){
        return robbery;
    }
    public int getAggravatedAssult(){
        return aggravatedAssault;
    }
    public int getPropertyCrime(){
        return propertyCrime;
    }
    public int getBurglary(){
        return burglary;
    }
    public int getTheft(){
        return theft;
    }
    public int getMotorVehicleThieft()
    {
        return this.motorVehicleTheft;
    }
}