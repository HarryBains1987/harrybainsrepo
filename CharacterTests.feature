Feature: CharacterTests
	


Scenario Outline: Check all Character records include all properties
		Given I make a get call to the Characters API
		| Limit | Offset        | ApiKey                           | Hash                             |
		| 100   | <offsetValue> | 7c293d204a400b5b800082b24556f517 | cf0c222786270002e62ccbc2ebf1ed86 |
		Then  I receive a success response
		And verify every record includes all JSON properties
	Examples: 
		| offsetValue |
		| 0           |
		| 100         |
		| 200         |
		| 300         |
		| 400         |
		| 500         |
		| 600         |
		| 700         |
		| 800         |
		| 900         |
		| 1000        |
		| 1100        |
		| 1200        |
		| 1300        |
		| 1400        |


Scenario Outline: Negative tests authorisation validation
	Given I make a get call to the Characters API
		| Limit | Offset | ApiKey   | Hash   |
		| 100   | 0      | <ApiKey> | <Hash> |
	Then  I receive a <ErrorResponse> response with <Code> and Error <Message>
	Examples: 
		| ApiKey                           | Hash                             | ErrorResponse | Code               | Message                                              |
		| 7c293d204a400b5b8082b7           | cf0c222786270002e62ccbc2ebf1ed86 | Unauthorized  | InvalidCredentials | The passed API key is invalid.                       |
		| 7c293d204a400b5b800082b24556f517 | cf0c2227862700022ccbc2ebf1ed86   | Unauthorized  | InvalidCredentials | That hash, timestamp and key combination is invalid. |


Scenario Outline: Negative tests pagination validation
	Given I make a get call to the Characters API
		| Limit        | Offset | ApiKey                           | Hash                             |
		| <limitValue> | 0      | 7c293d204a400b5b800082b24556f517 | cf0c222786270002e62ccbc2ebf1ed86 |
	Then  I receive a <ErrorResponse> response with <Code> and Status Message <Status>
	Examples: 
		| limitValue | ErrorResponse | Code | Status                                 |
		| 0          | Conflict      | 409  | You must pass an integer limit greater |