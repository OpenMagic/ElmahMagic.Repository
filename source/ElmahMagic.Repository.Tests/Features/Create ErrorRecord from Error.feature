Feature: Create ErrorRecord from Error

Scenario: Standard ELMAH Error
	Given an ELMAH Error
	When I call ToErrorRecord
	Then the result should be an ErrorRecord
	And all public Error properties are copied to ErrorRecord
