def get_month_expenses(f):
	expenses = {}
	for line in f:
		tokens = line.split(",")
		amount = float(tokens[1])
		cat = tokens[2].strip()
		if cat in expenses:
			expenses[cat] += amount
		else:
			expenses[cat] = amount
	return expenses


def get_expenses():
	all_expenses = {}
	months = input("Which months' expenses should be used to plan the budget: ").split(",")
	for month in months:
		filename = month + "_expenses.txt"
		try:
			f = open(filename)
		except:
			print(f"You do not have the expenses record for {month}.")
		else:
			all_expenses[month] = get_month_expenses(f)
			f.close()
	return all_expenses


def plan_budget(used_expenses, budget, sinking_fund_cats):
	total_expenses = {}
	cat_occurrences = {}
	for month in used_expenses:
		expenses = used_expenses[month]
		for cat in expenses:
			if cat in cat_occurrences:
				cat_occurrences[cat] += 1
				total_expenses[cat] += expenses[cat]
			else:
				cat_occurrences[cat] = 1
				total_expenses[cat] = expenses[cat]
	
	num_months = len(used_expenses)
	sinking_total = 0
	for cat in total_expenses:
		if cat_occurrences[cat] == 1:
			sinking_fund_cats.append(cat)
			sinking_total += total_expenses[cat]
		else:
			budget[cat] = total_expenses[cat] / num_months
	budget["sink fund"] = sinking_total / num_months


def print_budget(budget, sinking_fund_cats):
	print("Based on the analysis of your expenses for the selected months, your budget is calculated as follows:")
	for cat in budget:
		if cat != "sink fund":
			print(f"{cat}: ${budget[cat]}")
	print()
	if len(sinking_fund_cats) > 0:
		print(f"Finally, you should leave ${budget[cat]} as sinking fund for occasional spending, such as things in the categories of:")
		for cat in sinking_fund_cats:
			print(f"\t{cat}")
		print()



def main():
	used_expenses = get_expenses()
	if len(used_expenses) <= 1:
		print("Insufficient data to calculate the budget. You select more than one month.")
		return
	budget = {}
	sinking_fund_cats = []
	plan_budget(used_expenses, budget, sinking_fund_cats)

	print_budget(budget, sinking_fund_cats)


main()
