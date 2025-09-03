def get_data_from_file(filename, prices, quantities):
    f = open(filename)
    for line in f:
        tokens = line.strip().split(",")
        name = tokens[0].strip()
        prices[name] = float(tokens[1])
        quantities[name] = int(tokens[2])
    f.close()


def write_data_to_file(filename, prices, quantities):
    f = open(filename, "w")
    total = 0
    for name in prices:
        temp = prices[name] * quantities[name]
        f.write(f"{name},{temp}\n")
        total += temp
    f.write(f"total,{total}")
    f.close()

def main():
    prices = {}
    quantities = {}
    read_file = "shoppingCart.txt"
    get_data_from_file(read_file, prices, quantities)
    
    print("---prices dictionary---")
    print(prices)
    print()
    print("---quantities dictionary---")
    print(quantities)
    print()
    
    write_file = "prices.txt"
    write_data_to_file(write_file, prices, quantities)

main()