Feature: Create Error from ErrorRecord

Scenario: Standard ErrorRecord
	Given an ErrorRecord
	When I call ToError
	Then the result should be an ELMAH Error
	And all public ErrorRecord properties are copied to Error
