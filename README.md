# Storm

Automagically generates C# database layers for stored procedures. Generation can be done via a T4 template, a command line tool or by referencing the library directly.

Storm currently works for SQL Server only.

## Features

* Turns stored procedures into typed methods, contained within mockable C# classes
* Generates classes for user defined types and passes them as IEnumerable&lt;T&gt; to table valued parameters
* Presents OUT and INOUT parameters as ref-type parameters and updates them automatically
* Each layer in the system can be customized using custom interface implementations

## Project Info

* Documentation: [https://github.com/FlyingPie/Storm/wiki](https://github.com/FlyingPie/Storm/wiki)
* Bugs and changes: [https://github.com/FlyingPie/Storm/issues](https://github.com/FlyingPie/Storm/issues)

## Build Status

* Nightly: ![alt text](http://mbuild.cloudapp.net/app/rest/builds/buildType:Tessler_Nightly/statusIcon "Nightly Build Status")

## Example

### Code generation

Using T4

```
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

### Code usage

```csharp
// Construct a sql executor
var executor = DapperSqlExecutor.FromConnectionString("server=localhost;database=Storm;integrated security=true;");

// Construct an accessor class, ProductCatalog is the name of the schema
var catalog = new ProductCatalog(executor);

// Retrieve some data
var result = catalog.GetProducts<SqlResponse<Product>>(2004, "Furniture", null);

// Profit
var productNames = result.Items.Select(p => p.Name);
```

## Architecture

![alt tag](/Docs/Storm_Architecture.png)

## License

[MIT License](https://github.com/FlyingPie/Storm/blob/master/LICENSE)
