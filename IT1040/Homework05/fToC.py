def f_to_c(f):
    if f < -459.67:
        print("Invalid input: A Fahrenheit temperature must not be lower than -459.67. Please try again.")
    else:
        c = (f-32) * 5 / 9
        print(str(f) + "F = " + str(c) + "C")

def main():
    user_input = input("Enter a Fahrenheit temperature: ")
    while user_input != "Done":
        f = float(user_input)
        f_to_c(f)
        user_input = input("Enter a Fahrenheit temperature: ")
    
main()

