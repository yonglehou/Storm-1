# Storm

Automagically generate C# database layers for stored procedures. Generation can be done via a T4 template, a command line tool or referencing the library directly.

## Features

* Turns stored procedures into typed, mockable C# classes
* Generates classes for user defined types and passes them as IEnumerable<T> to table valued parameters
* Presents OUT and INOUT parameters as ref-type parameters and updates them automatically
* Each layer in the system can be customized using custom interface implementations

## Project Info

* *Documentation*: "https://github.com/FlyingPie/Storm/wiki":https://github.com/FlyingPie/Storm/wiki
* *Bugs and changes*: "https://github.com/FlyingPie/Storm/issues":https://github.com/FlyingPie/Storm/issues

## Example

Using T4

```csharp
<#@ assembly name="$(TargetDir)Flyingpie.Storm.dll" #>
<#@ import namespace="Flyingpie.Storm" #>
<#
var generator = Generator.FromConnectionString("server=localhost;database=Storm;integrated security=true;");
Write(generator.Generate());
#>
```

Using command line

```
stormcli.exe --connection-string="server=localhost;database=Storm;integrated security=true;" --output="DB.cs"
```

Using library reference

```csharp
var generator = Generator.FromConnectionString("server=localhost;database=Storm;integrated security=true;");
var code = generator.Generate();
File.WriteAllText("DB.cs", code);
```

## Architecture

![alt tag](/Docs/Storm_Architecture.png)

## License

"MIT License":https://github.com/FlyingPie/Storm/blob/master/LICENSE