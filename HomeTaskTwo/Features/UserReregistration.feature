Feature: User registration
  In order to buy products
  As an customer
  I want to create an account

@UserRegistrationFeature
Scenario: Try to create account with duplicate email id
    Given create account page is opened
    When user enters duplicate email id and submits it
    Then validation message should be displayed

  Scenario: Try to create account with unique email id
    Given create account page is opened
    When user enters unique email id and submits it
    Then account creation form should be displayed
                                                                
  Scenario: Try to create account without mandatory fields
    Given create account page is opened
    When user enters unique email id and submits it
    And user clicks on register button
    Then validation message should be displayed for mandatory fields


  Scenario: Create account with unique email id
    Given create account page is opened
    When user enters unique email id and submits it
    And user enters data in account creation form and submits it
    Then account should be created

