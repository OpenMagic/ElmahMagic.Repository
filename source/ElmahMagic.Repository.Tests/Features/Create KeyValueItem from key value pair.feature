Feature: Create KeyValueItem from key value pair

Scenario Outline: Create KeyValueItem using all type codes
	Given key is dummy
	And value type code is <typeCode> 
	And value is <value>
	When I call new KeyValueItem(key, value)
	Then the result should be a KeyValueItem object
	And result.Key should be dummy
	And result.Value type code should be <typeCode>
	And result.Value should be <value>
	Examples: 
	| typeCode | value                | comments are not used just handy when create test values                                                                                                                       |
	| Boolean  | true                 | A simple type representing Boolean values of true or false.                                                                                                                    |
	| Boolean  | false                | A simple type representing Boolean values of true or false.                                                                                                                    |
	| Byte     | 123                  | An integral type representing unsigned 8-bit integers with values between 0 and 255.                                                                                           |
	| Char     | 64000                | An integral type representing unsigned 16-bit integers with values between 0 and 65535. The set of possible values for the Char type corresponds to the Unicode character set. |
	| DateTime | 8 Sep 2015 04:13:00  | A type representing a date and time value.                                                                                                                                     |
	| DBNull   | <DBNull>             | A database null (column) value.                                                                                                                                                |
	| Decimal  | 456911.1664          | A simple type representing values ranging from 1.0 x 10 -28 to approximately 7.9 x 10 28 with 28-29 significant digits.                                                        |
	| Double   | -664599.44456        | A floating point type representing values ranging from approximately 5.0 x 10 -324 to 1.7 x 10 308 with a precision of 15-16 digits.                                           |
	| Empty    | <null>               | A null reference.                                                                                                                                                              |
	| Int16    | -13                  | An integral type representing signed 16-bit integers with values between -32768 and 32767.                                                                                     |
	| Int32    | 24667891             | An integral type representing signed 32-bit integers with values between -2147483648 and 2147483647.                                                                           |
	| Int64    | -9223372036854775808 | An integral type representing signed 64-bit integers with values between -9223372036854775808 and 9223372036854775807.                                                         |
	| Object   | SimpleObject         | A general type representing any reference or value type not explicitly represented by another TypeCode.                                                                        |
	| Object   | RecursiveObject      | A general type representing any reference or value type not explicitly represented by another TypeCode.                                                                        |
	| SByte    | -121                 | An integral type representing signed 8-bit integers with values between -128 and 127.                                                                                          |
	| Single   | 156788.4456997       | A floating point type representing values ranging from approximately 1.5 x 10 -45 to 3.4 x 10 38 with a precision of 7 digits.                                                 |
	| String   | a simple string      | A sealed class type representing Unicode character strings.                                                                                                                    |
	| UInt16   | 65535                | An integral type representing unsigned 16-bit integers with values between 0 and 65535.                                                                                        |
	| UInt32   | 4294967295           | An integral type representing unsigned 32-bit integers with values between 0 and 4294967295.                                                                                   |
	| UInt64   | 0                    | An integral type representing unsigned 64-bit integers with values between 0 and 18446744073709551615.                                                                         |
