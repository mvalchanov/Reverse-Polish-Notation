# Reverse-Polish-Notation
also known as Polish postfix notation or simply postfix notation

Source: https://en.wikipedia.org/wiki/Reverse_Polish_notation

Explanation

Note: Most of what follows is about binary operators. An example of a unary operator whose standard notation may be interpreted as reverse Polish notation is the factorial, "n!".

In reverse Polish notation, the operators follow their operands; for instance, to add 3 and 4, one would write 3 4 + rather than 3 + 4. If there are multiple operations, operators are given immediately after their second operands; so the expression written 3 − 4 + 5 in conventional notation would be written 3 4 − 5 + in reverse Polish notation: 4 is first subtracted from 3, then 5 is added to it. An advantage of reverse Polish notation is that it removes the need for parentheses that are required by infix notation. While 3 − 4 × 5 can also be written 3 − (4 × 5), that means something quite different from (3 − 4) × 5. In reverse Polish notation, the former could be written 3 4 5 × −, which unambiguously means 3 (4 5 ×) − which reduces to 3 20 −; the latter could be written 3 4 − 5 × (or 5 3 4 − ×, if keeping similar formatting), which unambiguously means (3 4 −) 5 ×.
Practical implications

In comparison testing of reverse Polish notation with algebraic notation, reverse Polish has been found to lead to faster calculations, for two reasons. Because reverse Polish calculators do not need expressions to be parenthesized, fewer operations need to be entered to perform typical calculations. Additionally, users of reverse Polish calculators made fewer mistakes than for other types of calculator.[9][10] Later research clarified that the increased speed from reverse Polish notation may be attributed to the smaller number of keystrokes needed to enter this notation, rather than to a smaller cognitive load on its users.[11] However, anecdotal evidence suggests that reverse Polish notation is more difficult for users to learn than algebraic notation.[10]
Postfix evaluation algorithm
	
This section possibly contains original research. Please improve it by verifying the claims made and adding inline citations. Statements consisting only of original research should be removed. (January 2019) (Learn how and when to remove this template message)

The following algorithm evaluates postfix expressions using a stack, with the expression processed from left to right:

for each token in the postfix expression:
  if token is an operator:
    operand_2 ← pop from the stack
    operand_1 ← pop from the stack
    result ← evaluate token with operand_1 and operand_2
    push result back onto the stack
  else if token is an operand:
    push token onto the stack
result ← pop from the stack

The following algorithm produces the same results of the previous one, but the expression is processed from right to left:

for each token in the reversed postfix expression:
  if token is an operator:
    push token onto the operator stack
    pending_operand ← False
  else if token is an operand:
    operand ← token
    if pending_operand is True:
      while the operand stack is not empty:
        operand_1 ← pop from the operand stack
        operator ← pop from the operator stack
        operand ← evaluate operator with operand_1 and operand
    push operand onto the operand stack
    pending_operand ← True
result ← pop from the operand stack

Example

The infix expression ((15 ÷ (7 − (1 + 1))) × 3) − (2 + (1 + 1)) can be written like this in reverse Polish notation:

    15 7 1 1 + − ÷ 3 × 2 1 1 + + −

    Evaluating this postfix expression with the above left-to-right algorithm yields (red items are the stack contents, bold is the current token):

		15 7 1 1 + − ÷ 3 × 2 1 1 + + − =
		15 7 1 1 + − ÷ 3 × 2 1 1 + + − =
		15 7 1 1 + − ÷ 3 × 2 1 1 + + − =
		15 7 1 1 + − ÷ 3 × 2 1 1 + + − =
		15 7 1 1 + − ÷ 3 × 2 1 1 + + − =
		15 7     2 − ÷ 3 × 2 1 1 + + − =
		15         5 ÷ 3 × 2 1 1 + + − =
		             3 3 × 2 1 1 + + − =
		             3 3 × 2 1 1 + + − =
		                 9 2 1 1 + + − =
		                 9 2 1 1 + + − =
		                 9 2 1 1 + + − =
		                 9 2 1 1 + + − =
		                 9 2     2 + − =
		                 9         4 − =
		                             5 =
		                             5
		
    Evaluating this postfix expression with the above right-to-left algorithm yields:

		15 7 1 1 + − ÷ 3 × 2 1 1 + + − =
		15 7 1 1 + − ÷ 3 × 2     2 + − =
		15 7 1 1 + − ÷ 3 ×         4 − =
		15 7     2 − ÷ 3 ×         4 − =
		15         5 ÷ 3 ×         4 − =
		             3 3 ×         4 − =
		                 9         4 − =
		                             5

The following table shows the state of the operand stack at each stage of the above left-to-right algorithm:
Token 	Type 	Stack 	Actions
15 	Operand 	15 	Push onto stack.
7 	Operand 	15 7 	Push onto stack.
1 	Operand 	15 7 1 	Push onto stack.
1 	Operand 	15 7 1 1 	Push onto stack.
+ 	Operator 	15 7 2 	Pop from stack twice (1, 1), calculate (1 + 1 = 2) and push onto stack.
− 	Operator 	15 5 	Pop from stack twice (7, 2), calculate (7 − 2 = 5) and push onto stack.
÷ 	Operator 	3 	Pop from stack twice (15, 5), calculate (15 ÷ 5 = 3) and push onto stack.
3 	Operand 	3 3 	Push onto stack.
× 	Operator 	9 	Pop from stack twice (3, 3), calculate (3 × 3 = 9) and push onto stack.
2 	Operand 	9 2 	Push onto stack.
1 	Operand 	9 2 1 	Push onto stack.
1 	Operand 	9 2 1 1 	Push onto stack.
+ 	Operator 	9 2 2 	Pop from stack twice (1, 1), calculate (1 + 1 = 2) and push onto stack.
+ 	Operator 	9 4 	Pop from stack twice (2, 2), calculate (2 + 2 = 4) and push onto stack.
− 	Operator 	5 	Pop from stack twice (9, 4), calculate (9 − 4 = 5) and push onto stack.

The above example could be rewritten by following the "chain calculation" method described by HP for their series of reverse Polish notation calculators:[12]

    As was demonstrated in the Algebraic mode, it is usually easier (fewer keystrokes) in working a problem like this to begin with the arithmetic operations inside the parentheses first.

        1 2 + 4 × 5 + 3 −

