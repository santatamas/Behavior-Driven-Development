Feature: SimpleCalculatorAcceptanceTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add numbers
	Given I have a calculator
	When I call Add with <input>
	Then the result should be <result>

Examples:
| input   | result |
| "1,2"   | 3      |
| "5,5,5" | 15     |
| "10,10" | 20	   |

@mytag
Scenario: Add exact numbers
	Given I have a calculator
	When I call Add with "3,4"
	Then the result should be the sum of the numbers

@mytag
Scenario: Empty input
	Given I have a calculator
	When I call Add with ""
	Then the result should be 0
