import re
import time

# Les innholdet i emails.txt
with open('emails.txt', 'r') as file:
    content = file.read()

# Definer det regulære uttrykket for å matche e-postadresser
pattern = r'[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}'

# Mål tiden det tar å finne alle matchene
start_time = time.time()
matches = re.findall(pattern, content)
end_time = time.time()

elapsed_time = end_time - start_time

print(f"Found {len(matches)} email addresses")
print(f"Elapsed time: {elapsed_time} seconds")

