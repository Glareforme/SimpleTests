@dbTests
Feature: 3.1.Create employee in base

As a service user 
To add employees to database 
I want user sql queries 

@dbTests @deleteAfter
Scenario: When user add employee in database, then he is displayed in employees table
	Given Database is already exist 
	When user add new employee in table 
	Then employee displayed in database table 
