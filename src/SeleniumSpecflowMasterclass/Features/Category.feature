@Category
Feature: Category
    As a ecommerce provider 
    I want to provide a category page
    so that customers can view all products for a particular category

Scenario: The category page h1 contains the category name
    Given I am on the Headphones Category Page
    Then the header is Headphones