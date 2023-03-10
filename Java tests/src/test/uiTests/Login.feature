@uiFeature
Feature: Login on site


  Scenario Outline: 1.1.1.User can authorize with valid credentials
    When the user enters valid credentials
      | login   | password     |
      | <login> | secret_sauce |
    Then the product page is displayed

    Examples:
      | login         |
      | standard_user |
