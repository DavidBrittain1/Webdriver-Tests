Feature: Discount Code

Background: 
Given I am logged in

@eCommerce_Cases
Scenario: Applying the Discount Code
	Given I am at the checkout
	When I enter in the discount code
	Then '15'% discount will be applied to the total price
