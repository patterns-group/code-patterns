---
layout: post
title: "Pre-release builds on MyGet"
date: 2014-02-04 22:03:35 -0600
comments: true
categories: [nuget, myget, CI, semver]
---

**Things are changing again**, but while the frequency of good changes over time may be debatable, it's a good thing this time. I promise.

### What's changing?

We're stabilizing our deployment channels. This is a very good thing, and it's going to make life even easier.

#### Stable Builds Only: [NuGet.org][nuget]

- Only stable (no pre-release) versions get deployed to NuGet
- Existing pre-release packages will remain listed on NuGet to honor all previous offerings

#### Pre-release Builds: [MyGet.org][myget]

- Built against the `next` branch
- (Coming Soon) Uses CI Server-assigned versions

Stay tuned for more information!

  [nuget]: https://www.nuget.org/packages?q=id%3A+Patterns%3B+author%3A+%22The+Tribe%22
  [myget]: https://www.myget.org/gallery/code-patterns