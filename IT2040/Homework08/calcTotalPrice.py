def main():
    f = open("shoppingCart.txt")
    total = 0
    for line in f:
        tokens = line.split(",")
        unit = float(tokens[1].strip())
        quantity = int(tokens[2].strip())
        total += unit * quantity
    f.close()
    print(f"Total Price: ${total}")


main()