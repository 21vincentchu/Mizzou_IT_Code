def calc_simple_eq(s):
    if "+" in s:
        idx = s.find("+")
        operand1 = float(s[:idx])
        operand2 = float(s[idx+1:])
        return operand1 + operand2
    elif "-" in s:
        idx = s.find("-")
        operand1 = float(s[:idx])
        operand2 = float(s[idx+1:])
        return operand1 - operand2
    elif "*" in s and "**" not in s:
        idx = s.find("*")
        operand1 = float(s[:idx])
        operand2 = float(s[idx+1:])
        return operand1 * operand2
    elif "/" in s:
        idx = s.find("/")
        operand2 = float(s[idx+1:])
        if operand2 == 0:
            print("Cannot divide by 0. Please try again.")
            return None
        else:
            operand1 = float(s[:idx])
            return operand1 / operand2
    elif "**" in s:
        idx = s.find("**")
        operand1 = float(s[:idx])
        operand2 = float(s[idx+2:])
        return operand1 ** operand2


def calc_sub_eq(eq):
    idx1 = eq.find("(")
    idx2 = eq.find(")")
    sub_eq = eq[idx1+1:idx2]
    sub_result = calc_simple_eq(sub_eq)
    if sub_result != None:
        print(sub_eq + " = " + str(sub_result))
        return eq.replace(eq[idx1:idx2+1], str(sub_result))
    else:
        return None


def main():
    eq = input("Equation: ")
    eq = eq.strip()
    while eq != "Done":
        if "(" in eq:
            eq = calc_sub_eq(eq)
        if eq != None:
            result = calc_simple_eq(eq)
            if result != None:
                print(eq + " = " + str(result))
        print()
        eq = input("Equation: ")

main()



