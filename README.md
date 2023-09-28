## GreenHorn.NameParser
Parses name strings using Western-English naming conventions for human names and identifies organizational names. 

## Motivation
Work-related experieneces has brought to my attention many legacy systems utilze code intended to accomplish the same task but may be written in different ways even if the code base is written in the same programming language.
As such, I was in need of a name parsing library written by an approved developer that can be used within my organization with the ability to parse human names into their respective elments  and identify organizational names based on specific criteria (`Prefix`, `First`, `Middle`, `Last`, `Suffix`, `IsOrganization`). 


## Build status
 


## Code style
[![js-standard-style](https://img.shields.io/badge/code%20style-standard-brightgreen.svg?style=flat)](https://github.com/feross/standard)
 
## Screenshots


## Tech/framework used

<b>Built with</b>
-C# 
-.Net Framework 4.6.1

## Features
This library is intended to be extendable by providing access to a NameConfiguration class. Multiple configurations components have the ability to add, remove, and/or replace portions or entire configuration elements.

```csharp
public class Configuration
{
    ...
    public List<string> Prefix { get; set; };
    public List<string> Suffix { get; set; };
    public List<string> CompoundName { get; set; };
    public List<string> BusinessIndicator { get; set; };
}
```
## Code Example
usage: 

`C#`

```csharp
NameParser parser = new NameParser();
var parsedName = parser.Parse("Foo Bar");

var parsedName = new NameParser().Parse("Mr. Foo P. Bar");
```
`VB.Net`

```vb
Dim parser as NameParser = new NameParser()
Dim parsedName = parser.Parse("Foo Bar")

Dim parsedName as Name = new NameParser().Parse("Mr. Foo P. Bar");
```

[//]: # (## Installation)
[//]: # (Provide step by step series of examples and explanations about how to get a development env running.)

[//]: # (## API Reference)

[//]: # (Depending on the size of the project, if it is small and simple enough the reference docs can be added to the README. For medium size to larger projects it is important to at least provide a link to where the API reference docs live.)

## Tests
Tests have been created as part of the GreenHorn.NameParser project using the Microsoft Testing Framework.

Example: 
```csharp
public const string E = "";

[DataTestMethod]
[DataRow("Foo", E, "Foo", E, E, E, false)]
[DataRow("Foo Bar", E, "Foo", E, "Bar", E, false)]
[DataRow("Foo Bar Jr", E, "Foo", E, "Bar", "Jr", false)]
[DataRow("Foo Bar Jr.", E, "Foo", E, "Bar", "Jr.", false)]
[DataRow("Foo P. Bar", E, "Foo", "P.", "Bar", E, false)]
[DataRow("Mr Foo Bar", "Mr", "Foo", E, "Bar", E, false)]
[DataRow("Mr. Foo Bar", "Mr.", "Foo", E, "Bar", E, false)]
[DataRow("Mr Foo P. Bar III Phd.", "Mr", "Foo", "P.", "Bar", "III Phd.", false)]
[DataRow("Mr. Foo P. Bar III Phd.", "Mr.", "Foo", "P.", "Bar", "III Phd.", false)]
[DataRow("Mr Foo P. Bar III Phd", "Mr", "Foo", "P.", "Bar", "III Phd", false)]
[DataRow("Mr. Foo P. Bar III Phd", "Mr.", "Foo", "P.", "Bar", "III Phd", false)]
[DataRow("Foo della Bar", E, "Foo", E, "della Bar", E, false)]
[DataRow("Foo della Bar", E, "Foo", E, "della Bar", E, false)]
[DataRow("Mr Foo della Bar", "Mr", "Foo", E, "della Bar", E, false)]
[DataRow("Mr. Foo della Bar", "Mr.", "Foo", E, "della Bar", E, false)]
[DataRow("fr Foo Bar", "fr", "Foo", E, "Bar", E, false)]
[DataRow("Fr Foo Bar", "Fr", "Foo", E, "Bar", E, false)]
[DataRow("fr. Foo Bar", "fr.", "Foo", E, "Bar", E, false)]
[DataRow("Fr. Foo Bar", "Fr.", "Foo", E, "Bar", E, false)]
public void NameParser_Parse_correctly_returns_parses_human_name(
    string fullName,
    string prefix,
    string firstName,
    string middleName,
    string lastName,
    string suffix,
    bool isBusinessName
    )
{
    Name expectedResult = new Name() {
        Prefix = prefix, 
        First = firstName, 
        Middle = middleName, 
        Last = lastName, 
        Suffix = suffix,
        IsOrganization = isBusinessName
    };
    var parser = new NameParser();
    var results = parser.Parse(fullName);

    Assert.AreEqual(
        expected: expectedResult,
        actual: results);
}
```


## How to use?

1. Start by cloning this project into Visual Studio. 
2. Build the project. 
3. Copy the resulting GreenHorn.NameParser into your client prject. 
4. Add a reference to the GreenHorn.NameParser.dll.
5. Implment name parsing logic based on above `Code Example`.

## Contribute

Contributions are always welcome!
 
### Contribution Guidelines
Please ensure your pull request adheres to the following guidelines:

- Alphabetize your entry.
- Search previous suggestions before making a new one, as yours may be a duplicate.
- Suggested READMEs should be beautiful or stand out in some way.
- Make an individual pull request for each suggestion.
- New categories, or improvements to the existing categorization are welcome.
- Keep descriptions short and simple, but descriptive.
- Start the description with a capital and end with a full stop/period.
- Check your spelling and grammar.
- Make sure your text editor is set to remove trailing whitespace.

Thank you for your suggestions!

## Credits
Yes, there are several libraries availble that accomplish the same task as this library and this library has been deviation of the following: 

**Similar logic, more languages**

* [Name Parser in Java](https://github.com/gkhays/NameParser)
* [Name Parser in JavaScript](https://github.com/joshfraser/JavaScript-Name-Parser)
* [Name Parser in CSharp](https://github.com/ianlee74/CSharp-Name-Parser)

#### Anything else that seems useful

## License
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/GreenHornSoftware/GreenHorn.NameParser/blob/master/LICENSE)

