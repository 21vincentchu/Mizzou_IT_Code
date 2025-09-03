def welcome(prices):
    print("Welcome to Python Store!")
    print("These are the items we offer, along with their price:")
    for item in prices:
        print(f"\t{item[0]}: ${item[1]}")


def add_to_cart(cart, names):
    name = input("Add to cart: ")
    while name != "Done":
        if name in names:
            cart.append(name)
        else:
            print(f"Sorry, we don't have any {name}s.")
        name = input("Add to cart: ")

def print_cart(cart):
    print("You have added the following items to your cart: ")
    for item in cart:
        print(item)


def get_item_price(prices, name):
    for item in prices:
        if name == item[0]:
            return item[1]

def calc_total_price(cart, prices):
    result = 0
    for item in cart:
        result += get_item_price(prices, item)
    return result


def main():
    desk = ["desk", 129.9]
    computer = ["computer", 1099]
    lamp = ["lamp", 30.5]
    couch = ["couch", 550]
    notebook = ["notebook", 20.9]
    prices = [desk, computer, lamp, couch, notebook]
    names = []
    for item in prices:
        names.append(item[0])
    welcome(prices)
    cart = []
    add_to_cart(cart, names)
    print_cart(cart)
    total_price = calc_total_price(cart, prices)
    print(f"The total price = ${total_price}")



main()
