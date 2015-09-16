Feature: Convert an IDictionary to a ToKeyValueCollection

Scenario: IDictionary has values
	Given an IDictionary with values
		| Key | Value           |
		| a   | 1               |
		| b   | hello           |
		| c   | SimpleObject    |
		| d   | RecursizeObject |
	When I call ToKeyValueCollection
	Then a read only collection should be returned with KeyValueItem values
		| Key | Value           |
		| a   | 1               |
		| b   | hello           |
		| c   | SimpleObject    |
		| d   | RecursizeObject |

Scenario: IDictionary is empty
	Given an empty IDictionary
	When I call ToKeyValueCollection
	Then an empty read only collection should be returned
