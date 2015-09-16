Feature: Add KeyValueCollection to NameValueCollection

Scenario: KeyValueCollection has values
	Given a KeyValueCollection with values:
		| Key | Value           |
		| a   | 1               |
		| b   | hello           |
		| c   | SimpleObject    |
		| d   | RecursizeObject |
	When I call AddKeyValueCollection
	Then the NameValueCollection should be:
		| Key | Value           |
		| a   | 1               |
		| b   | hello           |
		| c   | SimpleObject    |
		| d   | RecursizeObject |

Scenario: KeyValueCollection is empty
	Given an empty KeyValueCollection
	When I call AddKeyValueCollection
	Then the NameValueCollection should be empty
