Feature: UITests

Scenario: User can log in with valid credentials
	Given User is on Spotify homepage
    When User clicks the Log in button in the top-right corner
    Then Login Page should be opened
        And UserName and Password Inputs should be visible
    When User enters a valid username and password
        And User clicks the Log in button
    Then User should be successfully logged in
