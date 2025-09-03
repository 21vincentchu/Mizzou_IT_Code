daily_hours = float(input("Enter the number of hours worked daily: "))
hourly_wage = float(input("Enter the hourly wage: "))
if daily_hours > 8:
    print("You will be compensated for working overtime.")
    yearly_wage = (8 + (daily_hours-8)*2) * 365 * hourly_wage
    # The calculation is equivalent to the following:
    # yearly_wage = 8 * 365 * hourly_wage + (daily_hours-8) * 365 * hourly_wage * 2
else:
    yearly_wage = daily_hours * 365 * hourly_wage
print("Yearly wage = " + str(yearly_wage))
