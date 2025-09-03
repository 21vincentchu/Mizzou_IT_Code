def open_email_archive():
    filename = input("Enter the filename for the email archive: ")
    #filename = "archive-08-05-2030.txt"
    while True:
        try:
            f = open(filename)
        except:
            print(f"File {filename} does not exist. Please try again.")
            filename = input("Enter the filename for the email archive: ")
        else:
            return f


def count_domain(f, domain):
    result = 0
    for line in f:
        if line.startswith("From:"):
            d = line.split("@")[1].strip()
            if d == domain:
                result += 1
    return result


def main():
    f = open_email_archive()
    domain = input("Enter the domain: ")
    count = count_domain(f, domain)
    print(f"There are {count} emails from {domain}.")

main()