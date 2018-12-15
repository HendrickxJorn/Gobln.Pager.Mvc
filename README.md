[defaultCssImage]: images/defaultCssImage.png "With Css image"
[defaultBootstrapImage]: images/defaultbootstrapImage.png "With Bootstrap image"
[parameterCssImage]: images/parameterCssImage.png "With Css image"
[parameterBootstrapImage]: images/parameterbootstrapImage.png "With Bootstrap image"

# Gobln.Pager.Mvc

Gobln.Pager.Mvc is a .Net pager libery for Mvc 4 and 5, written in C#. The pager is easy to use and is compatible with bootstap 3 and 4.

## Features

* Support 4.0 and higher
* Support Core 2.0 and higher

## How to use

Install Gobln.Pager.Mvc, trough [Nuget](https://nuget.org/) or other means.
Create an page trough the extension .ToPage().
Then add this page to the Html.Pager, and (if needed) add options.

## Examples

```csharp

// Create page object with Gobln.Pager
var page = new List<TestModel1>()
            {
                new TestModel1(){ Id = 1, Name = "Tester1", Date = new DateTime( 2015, 5,1 ) },
                new TestModel1(){ Id = 2, Name = "Tester2", Date = new DateTime( 2015, 5,2 ) },
                new TestModel1(){ Id = 3, Name = "Tester3", Date = new DateTime( 2015, 5,3 ) },
                new TestModel1(){ Id = 4, Name = "Tester4", Date = new DateTime( 2015, 5,4 ) },
                new TestModel1(){ Id = 5, Name = "Tester5", Date = new DateTime( 2015, 5,5 ) },
                new TestModel1(){ Id = 6, Name = "Tester6", Date = new DateTime( 2015, 5,1 ) },
                new TestModel1(){ Id = 7, Name = "Tester7", Date = new DateTime( 2015, 5,2 ) },
                new TestModel1(){ Id = 8, Name = "Tester8", Date = new DateTime( 2015, 5,3 ) },
                new TestModel1(){ Id = 9, Name = "Tester9", Date = new DateTime( 2015, 5,4 ) },
                new TestModel1(){ Id = 10, Name = "Tester10", Date = new DateTime( 2015, 5,5 ) },
                new TestModel1(){ Id = 11, Name = "Tester11", Date = new DateTime( 2015, 5,1 ) },
                new TestModel1(){ Id = 12, Name = "Tester12", Date = new DateTime( 2015, 5,2 ) },
                new TestModel1(){ Id = 13, Name = "Tester13", Date = new DateTime( 2015, 5,3 ) },
                new TestModel1(){ Id = 14, Name = "Tester14", Date = new DateTime( 2015, 5,4 ) },
                new TestModel1(){ Id = 15, Name = "Tester15", Date = new DateTime( 2015, 5,5 ) },
            }.ToPager(1,2);

// In cshtml file

// Create default pager
@Html.Pager(page)

 ```

Results in
With css stylesheet
![Can not display image][defaultCssImage]

With Bootstrap
![Can not display image][defaultBootstrapImage]

```csharp

// Create pager with optional parameters
@Html.Pager(page,
    new PagerOptions
    {
        LabelFirstPageItem = "Begin",
        LabelLastPageItem = "End",
        LabelNextPageItem = "Next",
        LabelPreviousPageItem = "Prev",
        ItemShowOrder = new[] { ItemShow.FirstItem, ItemShow.PreviousItem, ItemShow.PagesItems, ItemShow.NextItem, ItemShow.LastItem },
        VisableItemsPerSide = 10
    })

```

Results in
With css stylesheet
![Can not display image][parameterCssImage]

With Bootstrap
![Can not display image][parameterBootstrapImage]

For more examples, check the test project

## Installing Gobln.Pager.Mvc

The project is on [Nuget](https://www.nuget.org/packages/Gobln.Pager.Mvc/). Install via the NuGet Package Manager.

PM > Install-Package Gobln.Pager.Mvc

## Gobln.Pager

This libery use the libery Gobln.Pager
Check for more details here [Gobln.Pager](https://www.nuget.org/packages/Gobln.Pager/)

## License

[Apache License, Version 2.0](http://opensource.org/licenses/Apache-2.0).

## Documentation and Readme file

I'm going to provide an documentation file, but haven't started on one yet.
As for the Readme file, if there are any inconsitencies or grammatical errors feel free to let me know by an pull request. This also counts for problems in de code.

## Issues and Contributions

* If something is broken and you know how to fix it, send a pull request.
* If you have no idea what is wrong, create an issue.

## Any feedback and contributions are welcome

If you have something you'd like to improve do not hesitate to send a Pull Request