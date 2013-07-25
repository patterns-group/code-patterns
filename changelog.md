## Patterns Changelog ##

**3.9.0**

- Added `Patterns.Collections.ConfigurableEqualityComparer<TValue>` (Issue #66)
- Fixed type casting error in `Patterns.Testing.Autofac.Moq.AutofacMoqContainer` (Issue #67)
- Fixed issue with up-front service type inspection in `Patterns.Testing.Autofac.Moq.MoqRegistrationSource` (Issue #68)
- Added `IRegexEvaluator` and `RegexEvaluator` to the `Patterns.Text.RegularExpressions` namespace (Issue #69)
- Added `Evaluator` and `EvaluatorAccessor` to `System.Text.RegularExpressions.CompiledRegex` (Issue #70)
- Added `Patterns.Runtime.TemporaryScope`
- Added `ActionValueStrategies<TValue>`
- Added `FuncValueStrategies<TValue, TOut>`

**3.8.1** - Expanded capabilities of `Patterns.Mapping.IMappingServices` (issue #65)

**3.8.0**

- Renamed `Patterns.Autofac.Sources.ResolveAnythingSource` to `Patterns.Autofac.Sources.ResolveCreatableSource` (issue #43)
- Moved Moq-related components from `Patterns.Testing.Autofac` to `Patterns.Testing.Autofac.Moq` (issue #58)
- Added the "strategy dictionary" pattern to the `Patterns.Collections.Strategies` namespace (issue #59)
- Added a short-circuit `Map<TSource,TDestination>` method to `Patterns.Mapping.IMappingServices` (issue #61)

**3.7.2**

**3.7.1**

**3.7.0**

**3.6.0-beta**

**3.5.1-beta**

**3.5.0-beta**

**3.4.0-beta**

**3.3.1-beta**
