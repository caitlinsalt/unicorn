# In-progress notes

## Publishing test coverage

Run `dotnet test` against the solution

```
cd src
dotnet test --collect:"XPlat code coverage"
```

Run `reportgenerator` against all code coverage output

```
reportgenerator "-reports:Unicorn.FontTools.Tests.Unit/TestResults/{GUID}/coverage.cobertura.xml;Unicorn.Base.Tests.Unit/TestResults/{GUID}/coverage.cobertura.xml;Unicorn.Tests.Unit/TestResults/{GUID}/coverage.cobertura.xml" -targetdir:TestCoverage -reporttypes:Html
```

There is a GitHub action available called `ReportGenerator-GitHub-Action`.  [See here](https://github.com/danielpalme/ReportGenerator/wiki/Integration).

## To do

- Find out how to either drop the `coverage.cobertura.xml` files into a known location or record what the GUID is.  Could potentially be avoided using globbing
- Find out how to publish the results.
