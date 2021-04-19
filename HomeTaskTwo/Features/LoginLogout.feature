Feature: Login and logout in the system

@UserLoginFeature
   Scenario Outline: Register the first time user on the portal
    Given login page is opened
    And verify that Login option is visible on sign in page
    When enter the "<emailId>" inside email address text box
    And enter the "<password>" inside password text box
    Then click on the "Log in" button
    And verify that "<message>" for the given credentials
    Examples:
      | emailId                       | password   | message                    |
      | ahanula-6990@yopmail.com      | hy67ko@Ebn | Authentication failed.     |
      | kupeffico-2496@yopmail.com    | hy67ko@Ebn | Invalid email address.     |
      |                               | hy67ko@Ebn | An email address required. |
      | vesorraddussu-9424@yopmail.com|            | Password is required.      |

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
