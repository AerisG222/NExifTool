[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/AerisG222/NExifTool/blob/master/LICENSE.md)
[![NuGet](https://buildstats.info/nuget/NExifTool)](https://www.nuget.org/packages/NExifTool/)
[![Travis](https://img.shields.io/travis/AerisG222/NExifTool.svg)](https://travis-ci.org/AerisG222/NExifTool)
[![Coverity Scan](https://img.shields.io/coverity/scan/7994.svg)](https://scan.coverity.com/projects/aerisg222-nexiftool)

# NExifTool
A .NET library to wrap the functionality of ExifTool.

## Motivation
To create a simple wrapper around this excellent program to allow
.NET programs to easily access exif data for images.

## Installation
- NExifTool depends on ExifTool from https://www.sno.phy.queensu.ca/~phil/exiftool/ in order to work, therefore, ExifTool must be installed.
- NExifTool can then be added to your project via the NuGet package.

## Usage

```csharp
using System.Threading.Tasks;
using NExifTool;

namespace Test
{
    public class Example
    {
        public async Task Test(string srcFilename)
        {
            var et = new ExifTool(new ExifToolOptions());
            var list = await et.GetTagsAsync(srcFilename);
            
            // use list...
        }
    }
}
```

- View the tests for more examples

## Developing
The exiftool.xml file was produced using the latest ExifTool on my system,
using the command: `exiftool -listx`.  This file is then processed to produce
a lookup table of tags / english descriptions, which is then used when
parsing out the results.  This xml file is the input to the XSLT that 
generates the TagMetadata.cs file.

## Contributing
I'm happy to accept pull requests.  By submitting a pull request, you
must be the original author of code, and must not be breaking
any laws or contracts.

Otherwise, if you have comments, questions, or complaints, please file
issues to this project on the github repo.

## Todo
I hope to make many improvements to the library as time permits.
- Ability to read/write specific tag(s)
- Add tests
  
## License
NExifTool is licensed under the MIT license.  See LICENSE.md for more
information.

## Dependencies
- ExifTool: http://www.sno.phy.queensu.ca/~phil/exiftool/
- MadellionShell: https://github.com/madelson/MedallionShell/
