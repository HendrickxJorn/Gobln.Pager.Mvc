[defaultCssImage]: images/defaultCssImage.png "With Css image"
[defaultBootstrapImage]: images/defaultBootstrapImage.png "With Bootstrap image"
[parameterCssImage]: images/ParameterCssImage.png "With Css image"
[parameterBootstrapImage]: images/ParameterBootstrapImage.png "With Bootstrap image"
[ex001]: images/ex001.jpg "Example 001"
[ex002]: images/ex002.jpg "Example 002"

# Gobln.Pager.Mvc

Gobln.Pager.Mvc is an easy to use dynamic .Net pager libery for Mvc 4 and up, written in C#.
The libery is compatible with bootstrap 3 and 4, or you can use a custom css file to display the pager.

## Features

* Support 4.0 and higher
* Support Core 2.0 and higher
* Support Core 3.0 and higher
* Support Mvc 4.0 and higher

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
        //Change text of the first page link
        LabelFirstPageItem = "Begin",
        //Change text of the last page link
        LabelLastPageItem = "End",
        //Change text of the next page link
        LabelNextPageItem = "Next",
        //Change text of the previous page link
        LabelPreviousPageItem = "Prev",
        //The order the links will be displayed
        ItemShowOrder = new[] { ItemShow.FirstItem, ItemShow.PreviousItem, ItemShow.PagesItems, ItemShow.NextItem, ItemShow.LastItem },
        //Howmany items will be displayed to the left and right of the current page
        VisableItemsPerSide = 10
    })

```

Results in

With css stylesheet

![Can not display image][parameterCssImage]

With Bootstrap

![Can not display image][parameterBootstrapImage]

Taghelper can be used with core 2.0, and will work the same as @Html.Pager()

```csharp

<pager page="Model.ToPage(1, 2)"
       pager-options="@(new PagerOptions()
                {
                    DataIndexName="TestNamePageIndex"
                })" />

```

Change the order of items of the pager

```csharp

@Html.Pager(Model.ToPage(1, 2), new PagerOptions()
   {
       ItemShowOrder = new ItemShow[] { ItemShow.FirstItem, ItemShow.LastItem }
   })

```

![Can not display image][ex001]

```csharp

@Html.Pager(Model.ToPage(1, 2), new PagerOptions()
    {
        ItemShowOrder = new ItemShow[] { ItemShow.FirstItem, ItemShow.PagesItemsRange, ItemShow.LastItem }
    })

```

![Can not display image][ex002]

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