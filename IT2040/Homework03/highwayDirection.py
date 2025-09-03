highway = int(input("Please enter a primary highway number (1-99): "))
if highway % 2 == 0:
    print("Primary highway " + str(highway) + " goes east/west.")
else:
    print("Primary highway " + str(highway) + " goes north/south.")