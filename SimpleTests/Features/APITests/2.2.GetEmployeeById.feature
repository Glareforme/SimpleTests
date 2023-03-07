@apiTests
Feature: 2.2.GetEmployeeById

As a user web service 
To get employee data 
I want send requesr with employee id

@apiTests
Scenario Outline: 2.2.1.When user requests employee data with correct id, then OK response with expected data is received
	Given employees created in database
	When user send request to get user by <id>
	Then response with status code 200 is received
	And responsed employee data is correct
		| name   | salary   | age   |
		| <name> | <salary> | <age> |

Examples:
	| id | name          | salary | age |
	| 1  | Tiger Nixon   | 320800 | 61  |
	| 3  | Ashton Cox    | 86000  | 66  |
	| 9  | Colleen Hurst | 205500 | 39  |

@apiTests
Scenario: 2.2.2.When user requests employee data with id 0, then error response with message is received
	Given employees created in database
	When user send request to get user by 0
	Then response with status code 400 is received
	And responsed error massages is received
		| status | message          | code | errors      |
		| error  | Not found record | 400  | id is empty |

@apiTests
Scenario: 2.2.3.When user requested employee data with non-existed id, then error response with message is received
	Given employees created in database
	When user send request to get user by 123
	Then response with status code 200 is received
	And the response does not contain data about the employee

@apiTests
Scenario: 2.2.4.When user requested employee data without id, then error response with message is received
	Given employees created in database
	When user send request to get user without id
	Then response with status code 404 is received
	And returned correct message in response


	
