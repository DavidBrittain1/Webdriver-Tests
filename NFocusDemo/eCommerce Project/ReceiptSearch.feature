Feature: ReceiptSearch

A short summary of the feature

Background: 
Given I am logged in

@eCommerce_Cases
Scenario: Receipt number can be found in History
	Given I have made a purchase
	When I go to my purchase history
	Then I will find the most recent receipt number
