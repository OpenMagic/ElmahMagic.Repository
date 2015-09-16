Feature: Add an error to the repository
	As a developer
	I want to save errors captured by Elmah

Scenario: Elmah passes an error to error log
	Given an error log has been created
	When an error is passed to the error log
	Then the error is added to the repository
	And the error id is returned
