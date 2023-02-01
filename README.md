To run the programme -> run "run Mr.Gold" (Unix Executable file, won't run on Windows natively)

Written in C#                                                                                                                
Source code is in the "SourceCode" folder. -> SourceCode/Program.cs

The programme generates a 2d array that is "centrally dense". The array has a size of 10*10 and holds a random value at a random location, and this is going to be the greatest value of the array. The values get smaller when it gets further away from the location("centre") holding the biggest value. The deduction of each "layer" away from the "centre" location is random but within a range. (See source code method "Generate()")

The game will ask users to input two values each time, X and Y, to represent to row and column of the 2d array. The value of the input location will be shown to the user each time after input. If the user successfully guesses the correct location holding the greatest value within 10 attempts, the user wins the game. Else, the user loses.
