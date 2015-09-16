Feature: Get pages of errors from the repository
	As a developer
	I want to get a 'page' of saved ELMAH errors

Scenario Outline: Get a page of errors
	Given an error log has been created
	And the error log has <totalErrorCount> errors
	And the pageIndex is <pageIndex>
	And the pageSize is <pageSize>
	And the errorEntryList is empty
	And the expectedErrorCount is <expectedErrorCount>
	When GetErrors(<pageIndex>, <pageSize>, errorEntryList) is called
	Then repository.GetErrorsAsync(pageIndex, pageSize, errors) should be called
	And <totalErrorCount> should be returned
	And errorEntryList should be updated with <expectedErrorCount> ErrorLogEntry items
	Examples:
	| totalErrorCount | pageIndex | pageSize | expectedErrorCount |
	| 15              | 0         | 10       | 10                 |
	| 15              | 1         | 10       | 5                  |