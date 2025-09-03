daily_hours = float(input("Enter the number of hours worked daily: "))
hourly_wage = float(input("Enter the hourly wage: "))
yearly_wage = daily_hours * 365 * hourly_wage
print("Yearly wage = " + str(yearly_wage))