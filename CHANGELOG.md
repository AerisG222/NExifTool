# 0.12.0 (02/02/2024)

- remove support for netfx 4.5 as it is now EOL and move to netstandard2.0
- replace newtonsoft.json with system.text.json
- update dependencies

# 0.11.0 (03/18/2022)

- introduce `EscapeTagValues` option to pass `-E` to exiftool to help with character encoding

# 0.10.0 (03/14/2022)

- introduce flag to control how files are overwritten (thanks to @bagsergen)

# 0.9.0 (01/02/2019)

- improved capabilities for writing tags
- specify ConfigureAwait to improve async usage in full framework
- add more tests

# 0.8.0 (10/30/2017)

- add initial support for writing tags

# 0.7.0 (10/17/2017)

- minor updates and start to leverage MedallionShell for process handling

# 0.6.1 (07/22/2016)

- add support for getting tags from a stream w/o requiring writing a file to disk (see https://github.com/AerisG222/NExifTool/issues/2)

# 0.6.0 (06/28/2016)

- update to rtm

# 0.5.1 (05/21/2016)

- updates to reference rc2 dependencies

# 0.5.0 (05/10/2016)

- initial attempt at supporting both .net full framework and .net core

# 0.4.2 (03/17/2016)

- allow the parser to be silent

# 0.4.1 (03/17/2016)

- retain the raw numbervalue for a tag so it may be used as a fallback

# 0.4.0 (03/17/2016)

- improve the generator and parser to provide more accurate results

# 0.3.4 (03/16/2016)

- fix dumb error in my last fix... let's see how many more of these will come ;)

# 0.3.3 (03/16/2016)

- fix what I broke (constructor to complex)

# 0.3.2 (03/15/2016)

- adding another exif alias

# 0.3.1 (03/14/2016)

- add an alias for some of the exif groups to try and improve hit rate

# 0.3.0 (03/14/2016)

- try to improve the parser by looking for types more specifically, based on the group they belong to
- fallback for number types to see if we can parse a double where we might otherwise expect whole numbers

# 0.2.1 (03/13/2016)

- wrap filename in quotes to allow spaces in file paths

# 0.2.0 (02/22/2016)

- add new enum like types based on documentation on the exiftool page, and return these more specific values when parsing

# 0.1.0 (02/07/2016)

- initial release
