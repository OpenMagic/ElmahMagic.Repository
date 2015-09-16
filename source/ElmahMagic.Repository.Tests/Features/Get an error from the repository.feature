Feature: Get an error from the repository
	As a developer
	I want to get a saved ELMAH error

Scenario: Elmah passes known error id
	Given an error log has been created
	And the error log has multiple errors
	And the id of an error in the error log
	When GetError(id) is called
	Then the error for the given id should be returned

Scenario: Elmah passes unknown error id
	Given an error log has been created
	And the error log has multiple errors
	And the id of an error that is not in the error log
	When GetError(id) is called
	Then a null error should be returned
