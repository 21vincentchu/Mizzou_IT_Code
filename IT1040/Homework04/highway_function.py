def get_direction(highway):
    if highway % 2 == 0:
        return "east/west"
    return "north/south"

def main():
    highway = int(input("Please enter a primary highway number: "))
    direction = get_direction(highway)
    print("Primary highway " + str(highway) + " goes " + direction)   

main()