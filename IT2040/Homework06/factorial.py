def factorial(n):
    result = 1
    for i in range(1, n+1):
        result *= i
    return result

def main():
    n = int(input("Please enter a positive integer: "))
    while n <= 0:
        print("Invalid input.")
        n = int(input("Please enter a positive integer: "))
    
    print(str(n) + "! = " + str(factorial(n)))
    
main()