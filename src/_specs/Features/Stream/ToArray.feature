Feature: Convert a stream to a byte array
	As a developer, I want to easily convert a stream to a byte array
	the same way MemoryStream.ToArray() works even when I don't know
	what kind of stream I have

@stream
Scenario: Conversion preserves data
	Given I have a memory stream of "This is data"
	When I call ToArray on the memory stream
	Then the result byte array should be "This is data"

@stream
Scenario: Throw exception when stream is unseekable and not at the beginning
	Given I have a DummyUnseekableStream
	And I advance the position
	When I attempt to call ToArray on the DummyUnseekableStream
	Then I get an exception with message "Input stream is not at beginning and cannot seek. Conversion will lose data"

@stream
Scenario: Unseekable stream can be convert when at the beginning
	Given I have a DummyUnseekableStream
	When I call ToArray on the DummyUnseekableStream
	Then I get empty result
