def calc_total(tokens):
    total = 0
    for i in range(len(tokens)):
        if i % 2 == 1:
            n = float(tokens[i])
            total += n
    return total

def main():
    print("Welcome! The program calculates the sum of the numbers at odd indices.")
    while True:
        user_input = input("Please enter a squence of numbers separated by comma: ")
        tokens = user_input.split(",")
        total = calc_total(tokens)
        print("Sum = " + str(total))
        
        again = input("Do you want to try again? (Y/N)")
        if again == "N":
            break
    

main()