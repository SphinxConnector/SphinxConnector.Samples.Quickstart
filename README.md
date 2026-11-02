# About

Minimal sample application for [ SphinxConnector.NET](https://www.sphinxconnector.net/).

## Usage

The simplest way to run [Sphinxsearch](https://sphinxsearch.com/) is via Docker. Open a terminal in the root folder of the sample and run:

```
docker run -d --name sphinxsearch --rm -p 127.0.0.1:9306:9306 -v ./sphinx/sphinx.conf:/opt/sphinx/conf/sphinx.conf macbre/sphinxsearch:3.9.1
```

Run the project:

```
dotnet run --project src/SphinxConnector.Samples.Quickstart.csproj
```
