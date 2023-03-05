@uiFeature
Feature: Authorize on website

For buy products on website
As a website user 
I want authorize 

@uiTest
Scenario Outline: User can authorize with valid credentials
	When the user enters valid credentials
		| login   | password     |
		| <login> | secret_sauce |
	Then the product page is displayed

Examples:
	| login           |
	| standard_user   |
	| locked_out_user |

@uiTest
Scenario Outline: User can't authorize with invalid credentials
	When the user enters invalid credentials
		| login   | password       |
		| <login> | <secret_sauce> |
	Then returned expection with message

Examples:
	| login  | password |
	|        |          |
	| dsadas |          |
	|        | bvxcbx   |
	| bvcxb  | bvbcxc   |
