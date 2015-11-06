# Simple Pattern Matching in C# [![Build status](https://ci.appveyor.com/api/projects/status/gybnmgw6fj7mheex?svg=true)](https://ci.appveyor.com/project/baks/patternmatching)

### Usage

Example for matching with actions:

```csharp
var action = new MatchAction<string>
{
	{"a", s => Console.WriteLine("pattern a")},
	{s => s.StartsWith("d"), s => Console.WriteLine("pattern for string which starts with d ")},
	{ Match.Default, s => Console.WriteLine("default action") },
	{ Match.Null, s => Console.WriteLine("action for null") }
}.Action;
			
action("dummy");
```

Example for matching with funcs:

```csharp
var func = new MatchAction<string>
{
	{"a", s => "pattern a")},
	{s => s.StartsWith("d"), s => "pattern for string which starts with d "},
	{ Match.Default, s => "default action" },
	{ Match.Null, s => "action for null" }
}.Func;
			
var result = func("dummy").Single();
```
