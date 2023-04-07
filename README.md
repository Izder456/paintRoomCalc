# Paint Room Calc

i have a math/geometry problem, and it want to solve it algorithmically.

its a program that takes user input for the dimensions of a room in US imperial, as well as the average paint layer thickness in mils (which is a really obscure measurement thats 1/1000 of an inch).

the question is how many layers of paint can one put in this room until the entire volume of the room is filled with layers of dried paint?

## Appproaches
* approach #1 uses linear division and treats the volume of the room in slices upon xy plane acting on the z axis.
* approach #2 recursively subtracts the volume taken up by each subsequent layer of paint, and adds to an iterable, until the volume of the room reaches a zero or negative value, it then spits out the iterable value, which would be the total amount of layers.
