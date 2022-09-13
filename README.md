# TagEditorValidators

This is an example solution to the interview assignment for balancing parentesis used by Shoppa AB for C# developer interviews.
The assigment, as presented to the applicant is found below.

The purpose of this repo is to present an alternative solution to applicants _after_ they have presented their own solution,
to compare and discuss the different architectural decisions and their pros and cons.

# Interview Assignment

We have a fictious C# application called TagEditor. As part of its validation process, it needs to use a helper class that validates if a string of arbitrary length has balanced parentheses or not.
Your task is to build the helper class. 

Write the code as if it was production grade.
We will then have another meeting where you get to present your code and discuss feedback.

Here are the current business rules for validating balanced parentheses:
	*	The TagEditor considers the following pairs as parentheses: “()”, “[]” and “{}”. 
	*	Parentheses must always close in reverse order they were opened. 
	*	Each opened parentheses must have a matching closed parenthesis, and vice versa.
	*	Before, between, inside and after the parentheses, there can be arbitrary other characters. Those characters shall just be ignored for the sake of validation.
	*	The string is in standard UTF16, like all strings in C#.
	*	The validation only needs to return whether the string is balanced or not.

Following are examples of valid strings:
	1.	“”
	2.	“NOP”
	3.	“{[()]}”
	4.	“calc(1+3)”
	5.	“repeat[sentence_count, calc(2*word_count{sentence})]”
	6.	“calc(1+3)*mean(1..1000)”

Following are examples of invalid strings:
	a.	“[“
	b.	“()()]”
	c.	“({[(]}))”
