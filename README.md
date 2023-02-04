Hello, my name is Kar Seng. I've taken around 6 hours to solve this code test. I've written a console app to solve the expressions using C#.

Solution:
1. Create 2 stacks, one is to store operators and second is to store numbers.
2. Loop thru the equation by each character and store the value into its respective stack.
3. If end of bracket is detected, the values will be poped from stacks and resolved first until the beginning of bracket.
4. Before a new operator is saved into the stack, it will check if the precedence operator is a multiply or divide, if so, the previous stacked expression will be solved first
5. After finished looping the equation, the code will loop thru the stack operators and solve all the expression.

User Guide:
1. Run the console app
2. Enter "1" to calculate all the mathematic expressions in the code test or enter your custom expression.
3. Result will be displayed in console. After that, user can enter "1" to reset the calculator.
