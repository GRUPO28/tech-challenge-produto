# language: en
Feature: Product

  Scenario: Create product with valid data
    Given the product has valid data
    When I create the product
    Then the product should be created successfully

  Scenario: Create product without name
    Given the product has no name
    When I try to create the product
    Then a domain notification exception should be thrown

  Scenario: Create product without size and price
    Given the product has no size and price
    When I try to create the product
    Then a domain notification exception should be thrown

  Scenario: Create product without description
    Given the product has no description
    When I try to create the product
    Then a domain notification exception should be thrown