# WebCrawler
A simple .net core console application which can be used to crwal a web page and to download all links recursively

## Install
Run tests before run console app by the .NET Core command-line interface:
```console
dotnet test
``` 
if all tests passed, then run the console app and wait for crawling and downloading all links of a given url.   
## Usage
You can find all links of a given url and download them to your local directory as html files.

```csharp
   worker.StartUrl = "www.sample.com";
   worker.Do();
```


