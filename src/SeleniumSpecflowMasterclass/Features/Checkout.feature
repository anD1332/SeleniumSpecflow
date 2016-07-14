Feature: Checkout
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: I have viewed a product and added it to my basket, when I go to the checkout I will be presented with a set of fields
	Given I have gone to the product page
	And I reserve the product
	And I click the mini basket
	When I press Reserve
	Then the form will have a series of fields

	| expected fields |
	| Destination     |
	| Airline         |
	| Flight Number   |
	| Flight Date     |
	| Flight Time     |
	| Terminal        |
	| First Name      |
	| Last Name       |
	| Email Address   |
	| Mobile Phone    |
