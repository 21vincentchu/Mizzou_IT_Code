def main():
    f = float(input("Enter a Fahrenheit temperature: "))
    if f < -459.67:
        print("Invalid input: A Fahrenheit temperature must not be lower than -459.67.")
        quit()
    c = (f-32) * 5 / 9
    print(str(f) + "F = " + str(c) + "C")
    
    
main()
