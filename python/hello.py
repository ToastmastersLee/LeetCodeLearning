class Student(object):
    def __init__(self,name,score):
        self.name = name
        self.score = score

lee = Student('Lee.WANG',89)
lee.name
print(lee.name);

names = ["Micheal","Bob","Lee"]
for name in names:
    print(name);

S = [x**2 for x in range(10)]
M = [m for m in S if m % 2 ==0]
print (S); print(M);