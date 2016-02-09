#NExifTool

A .Net library to wrap the functionality of ExifTool.

## Motivation
To create a simple wrapper around this excellent program to allow
.Net programs to easily access exif data for images.

## Using
- Install ExifTool
- Add a reference to NExifTool in your project.json
- Bring down the packages for your project via `dnu restore`

```csharp
using NExifTool;

namespace Test
{
    public class Example
    {
        public void Test(string srcFilename)
        {
            var et = new ExifTool();
            var list = et.GetTags(srcFilename);
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

## Reference
- ExifTool: http://www.sno.phy.queensu.ca/~phil/exiftool/
