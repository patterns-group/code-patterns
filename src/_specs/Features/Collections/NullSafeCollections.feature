Feature: Null-Safe Collections
  In order to avoid null reference errors
  As an object querier
  I want to query for items without worrying as much about nulls

Scenario: Empty set when set is null - positive test
  Given I have a null set of strings
  When I make the set of strings null-safe
  Then the result should be a non-null, empty set of strings

Scenario: Empty set when set is null - negative test
  Given I have a non-null set of strings
  When I make the set of strings null-safe
  Then the result should be the same as my original set of strings

Scenario: Squash null items - positive test
  Given I have a set of strings with one or more null items
  When I squash null items from the set of strings
  Then the result should be a set of strings with no null items

Scenario: Squash null items - negative test
  Given I have a set of strings with no null items
  When I squash null items from the set of strings
  Then the result should be the same as my original set of strings