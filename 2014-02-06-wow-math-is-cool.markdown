---
layout: post
title: "Wow, math is cool... as long as I don't have to code it"
date: 2014-02-06 12:49:41 -0600
comments: true
categories: 
---

**TL;DR**: [MathNet.Numerics][numerics] is really awesome!

I just coded out a couple of new extension methods in response to [an issue][152] I created recently: `EmptyIfNull` and `Compact`. Both of them operate on enumerable sets of items. `EmptyIfNull` converts a null set into an empty one, preventing repetitive or lengthy null checks in LINQ queries. `Compact` attaches a new `Where` clause to the set, filtering out null items. The net effect is that you'll be able to run queries against sets of objects while maintaining null safety, without sacrificing the gracefulness of the call flow. Here's an example:

```csharp
Func<IEnumerable<string>, IEnumerable<int>> extractor = set => set
  .EmptyIfNull().Compact().Select(item => item.Length); // too easy!
  
string[] set1 = new[]{ "thing0", null, "thing25", null };
string[] set2 = null;
IEnumerable<int> lengths1 = extractor(set1); // 6,7
IEnumerable<int> lengths2 = extractor(set2); // empty
```

This works, but every new thing we do in code-patterns is supposed to be done in a BDD workflow... I should know; it was my rule! There are a few considerations I had to make in order to be sure I was testing what I thought I was testing. As always, the testing logic is several orders of magnitude harder to grok than the logic under test, but hey whatever! This is fun stuff!

The first weird spot I hit was mathematical in nature, and the second was all about SpecFlow bindings. I'll write up a separate article about the SpecFlow bits, so that this article can just focus on what a math nerd I'm not. The math-nerdy method is `Compact`. It's not obvious why at first (the implementation is one line of code!) but bear with me. I don't want the nulls in my set to show up in predictable locations within the set. If they are always at the beginning, middle, or end of the set, then an algorithm that simply trims the ends of the set, or eliminates nulls when they are in a sequence would generate a false positive. If I have an evenly distributed random sort of the items in that set, then the nulls will always be in unpredictable locations, and the algorithm will only be able to consistently pass by doing exactly what it's meant to: remove all nulls, regardless of location. This isn't about the fact that there's just a simple `Where` clause under the covers. It's about the fact that this new extension promises to do something to your data without leaking any details about how it did so to the consumer. That means the only valid way to test is by making zero assumptions. So... hopefully I haven't made myself sound too crazy here... anyway, on to the math in all this:

Let's say I have a set of 100 strings. I know that 5% (so, 5) of these strings need to have a null value. I can easily get 95 other randomly generated values as well, and each of them needs to have the same even-but-random distribution as each of the 5 nulls I need. The problem: I need to generate a random distribution of all 100 items. It won't do to have them show up in a sequence OR a regular pattern in the set. I knew there was a known algorithm that handles this, but Spaghetti Monster help me if I have to implement any of it myself. I'd just punt the ball and go with `Random.Next`!

Luckily for me, [MathNet.Numerics][numerics] exists. This set of libraries is amazingly cool, and gives the world access to math functions that I'll probably never completely understand... all the better that it's been done for me and is considered to be in a working state. After doing a little research, it turns out the distribution I needed was the first 100 distinct items from a [Discrete Uniform][discrete] distribution of a [Mersenne Twister][twister] sequence. I chose the Mersenne Twister PRNG because of its wide level of acceptance as the superior algorithm. Let's start with the generation of positional values using this distribution. This is so easy it's scary:

```csharp
var random = new MersenneTwister();
var positions = DiscreteUniform.Samples(random, 0, count - 1)
  .Distinct().Take(count);
```

Now I have a pseudo-random list of positional indexes that can be used to randomize the sequence of a set of items of known size. All I have to do to apply that set of indexes is:

```csharp
var sortedValues = positions.Select(position => values[position]);
```

How great is that? Here's the full method signature that I ended up with in my test code:

```csharp
public IEnumerable<string> CreateStringSet(int count, int nullCount)
{
  IEnumerable<string> nulls = Enumerable.Range(0, nullCount)
    .Select(_ => (string) null);

  IEnumerable<string> nonNulls = Enumerable.Range(0, count)
    .Skip(nullCount).Select(_ => _generator.Phrase(20));

  var values = new List<string>(nulls.Concat(nonNulls));

  return DiscreteUniform.Samples(new MersenneTwister(), 0, count - 1)
    .Distinct().Take(count)
    .Select(position => values[position]);
}
```

BTW, the `_generator.Phrase` call is using [NBuilder][nbuilder]'s `RandomGenerator` class&mdash;another cool little OSS tool you should know about.

So that's it. That was a really long explanation for using something that's exponentially more complex than I can explain to test something that's exponentially less complex than this blog post would seem to indicate... yeah. I love being a nerd.

  [152]: https://github.com/TheTribe/code-patterns/issues/152
  [numerics]: https://github.com/mathnet/mathnet-numerics
  [discrete]: http://en.wikipedia.org/wiki/Uniform_distribution_%28discrete%29
  [twister]: http://en.wikipedia.org/wiki/Mersenne_twister
  [nbuilder]: https://github.com/garethdown44/nbuilder/