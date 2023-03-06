@apiTests
Feature: 2.1. Get all employees 

As a user web service 
To get all employees data
I want send api request


@apiTests
Scenario: 2.1.1.When user requests  data about all empolees, then returned response with status code OK and expected data
	Given employees created in database
	When user send GET request with valid data
	Then response with status code 200 is received 
	And response contained all expected data
