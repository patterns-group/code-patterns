Feature: Convert a stream to a byte array
	As a developer, I want to easily convert a stream to a byte array
	the same way MemoryStream.ToArray() works even when I don't know
	what kind of stream I have

@stream
Scenario: Conversion preserve data
	Given I have a memory stream of "This is data"
	When I call ToArray on the memory stream
	Then the result byte array should be "This is data"
