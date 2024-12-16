Feature: APITests

Scenario Outline: Get Artist by Id
	Given I have a valid API token for authentication
	When I perform a GET request for Artist with id <id>
	Then Response status code should be <StatusCode>
		And Response should contain artist details (<id>, <name>)

Examples:
    | id                       | name     | StatusCode |
    | 0TnOYISbd1XYRBk9myaseg   | Pitbull  | 200        |