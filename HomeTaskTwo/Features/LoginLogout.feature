Feature: Login and logout in the system

@UserLoginFeature
  Scenario: Login with invalid credentials
    Given login page is opened
    And user is not logged in
    When user enters invalid credentials
    Then validation message should be displayed for invalid credentials

  Scenario: Login with empty fields
    Given login page is opened
    When user doesn't enter credentials
    Then validation message should be displayed for invalid credentials

  Scenario: Login with valid credentials
    Given login page is opened
    When user enters valid credentials
    Then user should be logged in

  Scenario: user logout
    Given login page is opened
    And user is not logged in
    When user enters valid credentials
    And use clicks logout button
    Then user should be logged out
