Feature: Null-Safe Collections
  In order to avoid null reference errors
  As a developer
  I want to safely query for potentially null items

Scenario Outline: Compact (Remove Nulls)
  Given I have <a set of> strings with <a number of> null items
  When I compact the set of strings
  Then the resulting set of strings should have <the expected number of> items
  And all items in the resulting set of strings should be non-null
Examples:
  | a set of | a number of | the expected number of |
  | 0        | 0           | 0                      |
  | 50       | 0           | 50                     |
  | 50       | 32          | 18                     |

Scenario Outline: Empty Set if Null
  Given I have a set of strings set to <null or non-null>
  When I guarantee that the set of strings is non-null
  Then the result should be a non-null, <empty or non-empty> set of strings
Examples:
  | null or non-null | empty or non-empty |
  | non-null         | non-empty          |
  | null             | empty              |