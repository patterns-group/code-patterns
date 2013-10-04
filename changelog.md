# Patterns Changelog #

The following log details the outward-facing changes made to code-patterns since its first migration to GitHub.

## 3.10-beta.4 ##

- Fixes for `IMoqContainer` ([issue 114](https://github.com/TheTribe/code-patterns/issues/114))
 - Calls to `Create<TService>` now either return the registered instance, or a mock. No hidden updates.
 - Calls to `Create<TService, TImplementation>` update the container with the implementation type, and return the newly-registered instance.

## 3.10-beta.3 ##

- Extracted `Patterns.Configuration.InMemoryConfigurationSource` from `Patterns.Testing.Configuration.TestConfigurationSource` ([issue 110](https://github.com/TheTribe/code-patterns/issues/110))

## 3.10-beta.2 ##

- Changes made to `Patterns.Runtime.IDateTimeInfo` and `Patterns.Runtime.DefaultDateTimeInfo` ([issue 105](https://github.com/TheTribe/code-patterns/issues/105)):
 - Added `DateTime GetUtcNow()` to `IDateTimeInfo`
 - Updated implementation of `DefaultDateTimeInfo`

## 3.10-beta.1 ##

- Additions / changes made to `Patterns.Logging` and `Patterns.Interception` ([issue 96](https://github.com/TheTribe/code-patterns/issues/96)):
 - New type: `Patterns.Interception.DelegateInterceptor` &rarr; implements `IInterceptor` by allowing interception actions taken at each step to be injected
 - Updated `LoggingInterceptor` to inherit from new `DelegateInterceptor` type

## 3.9.4 ##

- Fixes for `Patterns.Logging` / `Patterns.Autofac.Logging` ([issue 92](https://github.com/TheTribe/code-patterns/issues/92)):
 - Extracted `ILoggingConfig` from `LoggingConfig`
 - Switched to interface usage everywhere
 - Modified `LoggingModule` logic to allow config source to be unregistered / config section to be missing; either case results in a default instance of `LoggingConfig` to be registered
- Changed `MoqRegistrationSource` to only return registrations when creating new Mock-based ones; now returns an empty set in all other cases ([issue 93](https://github.com/TheTribe/code-patterns/issues/93))


## 3.9.3 ##

- Updated out-of-date NuGet references ([issue 73](https://github.com/TheTribe/code-patterns/issues/73))

## 3.9.2 ##

- Changed `AutofacMoqContainer` to defensively call `Create` from within `Mock` using `Try.Get` ([issue 84](https://github.com/TheTribe/code-patterns/issues/84))

## 3.9.1 ##

- Changed `LoggingInterceptor` to use the CLR `JavaScriptSerializer` to format complex values for display ([issue 81](https://github.com/TheTribe/code-patterns/issues/81))

## 3.9.0 ##

- Added `Patterns.Collections.ConfigurableEqualityComparer<TValue>` ([issue 66](https://github.com/TheTribe/code-patterns/issues/66))
- Fixed type casting error in `Patterns.Testing.Autofac.Moq.AutofacMoqContainer` ([issue 67](https://github.com/TheTribe/code-patterns/issues/67))
- Fixed issue with up-front service type inspection in `Patterns.Testing.Autofac.Moq.MoqRegistrationSource` ([issue 68](https://github.com/TheTribe/code-patterns/issues/68))
- Added `IRegexEvaluator` and `RegexEvaluator` to the `Patterns.Text.RegularExpressions` namespace ([issue 69](https://github.com/TheTribe/code-patterns/issues/69))
- Added `Evaluator` and `EvaluatorAccessor` to `System.Text.RegularExpressions.CompiledRegex` ([issue 70](https://github.com/TheTribe/code-patterns/issues/70))
- Added `Patterns.Runtime.TemporaryScope`
- Added `ActionValueStrategies<TValue>`
- Added `FuncValueStrategies<TValue, TOut>`

## 3.8.1 ##

- Expanded capabilities of `Patterns.Mapping.IMappingServices` ([issue 65](https://github.com/TheTribe/code-patterns/issues/65))

## 3.8.0 ##

- Renamed `Patterns.Autofac.Sources.ResolveAnythingSource` to `Patterns.Autofac.Sources.ResolveCreatableSource` ([issue 43](https://github.com/TheTribe/code-patterns/issues/43))
- Moved Moq-related components from `Patterns.Testing.Autofac` to `Patterns.Testing.Autofac.Moq` ([issue 59](https://github.com/TheTribe/code-patterns/issues/59))
- Added the "strategy dictionary" pattern to the `Patterns.Collections.Strategies` namespace ([issue 59](https://github.com/TheTribe/code-patterns/issues/59))
- Added a short-circuit `Map<TSource,TDestination>` method to `Patterns.Mapping.IMappingServices` ([issue 61](https://github.com/TheTribe/code-patterns/issues/61))

## 3.7.2 ##

- Fixed `sectionGroup` bug in `TestConfigurationSource` ([Issue 60](https://github.com/TheTribe/code-patterns/issues/60)) 

## 3.7.1 ##

- Fixes for Autofac ([issue 57](https://github.com/TheTribe/code-patterns/issues/57))
 - Moved/renamed `MoqContainer` to `Patterns.Testing.Autofac.AutofacMoqContainer`
 - Extracted new interface, `Patterns.Testing.Autofac.IAutofacMoqContainer` &rarr; provides access to Autofac-specific features

## 3.7.0 ##

- New component in `Patterns.Testing.Configuration`: `TestConfigurationSource` &rarr; implements `IConfigurationSource` by accepting XML in its constructor and using the in-memory XML as the basis for retrievals of `AppSettings` and `ConnectionStrings` as well as calls to `GetSection` ([issue 35](https://github.com/TheTribe/code-patterns/issues/35))

## 3.6.0-beta ##

- New components in `Patterns.Mapping` (new dependency: [AutoMapper](https://www.nuget.org/packages/AutoMapper/)):
	- `IMappingServices` &rarr; encapsulates `IMappingEngine`, `IConfiguration`, and `IConfigurationProvider` from AutoMapper ([issue 53](https://github.com/TheTribe/code-patterns/issues/53))
	- `MappingServices` &rarr; simplest implementation of `IMappingEngine`; uses constructor injection
- New module in `Patterns.Autofac.Mapping`: `MappingModule` &rarr; registers static AutoMapper assets to facilitate injection into `MappingServices` ([issue 54](https://github.com/TheTribe/code-patterns/issues/54))

## 3.5.1-beta ##

- Changes to `Patterns.Logging`:
 - New type: `LoggingConfig` &rarr; inherits from `ConfigurationSection`; encapsulates the `bool TrapExceptions` option
 - Changed `LoggingInterceptor` to use `LoggingConfig` rather than explicit `bool` option for exception trapping
- Solution-wide refactor: moved components to more appropriate locations

## 3.5.0-beta ##

- Removed `Patterns.Testing.Runtime.TestDateTimeInfo` &rarr; mocks are easier to work with than this type
- New components in `Patterns.Reflection`:
 - `PropertyValue` &rarr; holds metadata and runtime value of a property
 - `IEnumerable<PropertyValue> object.GetPropertyValues()` (extension)

## 3.4.0-beta ##

- New logging components in `Patterns.Logging` (new dependency: [Castle.Core](https://www.nuget.org/packages/Castle.Core/)):
 - `LoggingInterceptor` &rarr; implements `IInterceptor` by calling the appropriate `ILog` methods throughout interception ([issue 12](https://github.com/TheTribe/code-patterns/issues/12))
 - `string Exception.ToFullString()` (extension) &rarr; concatenates exception messages, stack traces and inner exceptions (recursive)
- New Autofac support for `Patterns.Logging` in `Patterns.Autofac.Modules`:
 - `LoggingModule` &rarr; registers `LoggingInterceptor`, as well as attaching to all registrations in order to provide appropriately type-bound instances of `ILog` on-demand
- New Autofac container type for increased accessibility: `Patterns.Autofac.AccessibleContainer`
- New Moq / IoC components in `Patterns.Testing.Moq`:
 - `IMoqContainer` (depends on Microsoft.Practices.ServiceLocation and Moq) &rarr; exposes `IServiceLocator`; provides full IoC container support; provides `Mock{TObject}` creation support
 - `MoqRegistrationSource` &rarr; implements Autofac's `IRegistrationSource` by creating Mocks of services when registrations are missing
 - `MoqContainer` &rarr; implements `IMoqContainer` by using Autofac with `MoqRegistrationSource`

## 3.3.1-beta ##

- New Autofac-based components (new dependencies [Autofac](https://www.nuget.org/packages/Autofac/) and [Autofac.CommonServiceLocator.Indy](https://www.nuget.org/packages/Autofac.CommonServiceLocator.Indy/)):
 - `Patterns.Autofac.Modules.CoreModule` &rarr; registers all non-specialized interface-based components in Patterns
 - `Patterns.Autofac.Modules.ConfigurationModule` &rarr; registers all components needed to support `IConfigurationSource` injection ([issue 3](https://github.com/TheTribe/code-patterns/issues/3))
 - `Patterns.Autofac.Sources.ResolveAnythingSource` &rarr; resolve-anything-creatable implementation of Autofac's `IRegistrationSource` 
- New extensions in `Patterns.Collections`:
 - `void ICollection{TItem}.AddRange(IEnumerable{TItem} newItems)`
 - `void IEnumerable{TItem}.Each(Action{TItem} action[, bool parallel = false])`
- New configuration abstraction types in `Patterns.Configuration`:
 - `IConfiguration` / `ConfigurationWrapper`
 - `IConfigurationManager` / `ConfigurationManagerWrapper`
 - `IConfigurationSource` / `ConfigurationSource`
- New exception-handling delegate runners as well as a default error-handling strategy in `Patterns.ExceptionHandling`:
 - `TValue Try.Get(Func{TValue} valueAccessor[, Func{Exception, ExceptionState} errorHandler = null])`
 - `void Try.Do(Action action[, Func{Exception, ExceptionState} errorHandler = null])`
 - `Func{Exception, ExceptionState} Try.HandleErrors.DefaultStrategy` (new dependency: [Common.Logging](https://www.nuget.org/packages/Common.Logging/)) &rarr; uses self-bound `ILog` instance to log exception; marks exception as "handled"
- New DateTime components for testability in `Patterns.Runtime`:
 - `Patterns.Runtime.IDateTimeInfo` &rarr; `GetNow()` method returns `DateTime`
 - `Patterns.Runtime.DefaultDateTimeInfo` &rarr; proxies `DateTime.Now`
 - `Patterns.Testing.Runtime.TestDateTimeInfo` &rarr; accepts a specific `DateTime` value and always uses that
 - `DateTime DateTime.AccurateToOneSecond()` (extension)
- New ease-of-use type for regular expressions: `Patterns.Text.RegularExpressions.CompiledRegex`

## just after 3.3.0-beta ##

- MOVED TO GITHUB!!