Feature: Get all employee

  @testApi
  Scenario: 1.1.1.User can authorize with valid credentials
    When the user enters valid credentials
      | login   | password     |
      | <login> | secret_sauce |
    Then the product page is displayed

  @testAuth
  Scenario: 1.1.2.User can authorize with valid credentials
    When the user enters valid credentials
      | login   | password     |
      | <login> | secret_sauce |
    Then the product page is displayed