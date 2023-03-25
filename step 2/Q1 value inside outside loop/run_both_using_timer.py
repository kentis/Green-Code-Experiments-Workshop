import time

# Initialize variable inside the loop
start_time = time.time()
y=0
for i in range(10_000_000):
    x = 1 + 1
    y = y + x
end_time = time.time()
print(f"Time taken when initializing variable inside the loop: {end_time - start_time} seconds")
print(f"Result when initializing variable inside the loop: {y}")



# Initialize variable outside the loop
start_time = time.time()
y = 0
x = 1 + 1
for i in range(10_000_000):
    y = y + x
end_time = time.time()
print(f"Time taken when initializing variable outside the loop: {end_time - start_time} seconds")
print(f"Result when initializing variable outside the loop: {y}")

