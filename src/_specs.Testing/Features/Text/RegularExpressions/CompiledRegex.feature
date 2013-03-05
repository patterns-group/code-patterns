Feature: Compiled Regular Expressions
	As a developer, I want to be able to easily instantiate a regular expression
	that takes full advantage of the .NET runtime.

@compiledRegex
Scenario: All expressions are compiled
	Given I have created a CompiledRegex using a simple, valid pattern string
	When I read the options of the CompiledRegex
	Then the options should include the compiled option

@compiledRegex
Scenario: Build a pattern from a regular string
	Given I have a set of strings with various character patterns
	And I have a sample string that contains a pattern that is common to all strings in the set
	When I use the CompiledRegex.Build method to create a CompiledRegex using the sample string
	And I use the CompiledRegex against each string in the set
	Then each string in the set should have resulted in a positive match against the pattern

@compiledRegex
Scenario: Read a pattern back out of a compiled expression
	Given I have created a CompiledRegex using a valid pattern string
	When I read the pattern string from the CompiledRegex
	Then the pattern string I read from the CompiledRegex should match the pattern string used to create it

@compiledRegex
Scenario Outline: Dictionary Match
	Given I have created a string equal to: <input>
	And I have created a CompiledRegex with the pattern: <pattern>
	When I retrieve a dictionary match of the string using the CompiledRegex
	Then all expected group values (<expected group values>) should be found in the resulting dictionary
Examples:
	| input   | pattern                           | expected group values |
	| abc123  | (?<alpha>[a-z]+)(?<numeric>\d+)   | alpha:abc;numeric:123 |
	| 456.def | (?<numeric>\d+)\.(?<alpha>[a-z]+) | numeric:456;alpha:def |