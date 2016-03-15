#0.3.2 (03/15/2016)
- adding another exif alias

#0.3.1 (03/14/2016)
- add an alias for some of the exif groups to try and improve hit rate

#0.3.0 (03/14/2016)
- try to improve the parser by looking for types more specifically, based on the group they belong to  
- fallback for number types to see if we can parse a double where we might otherwise expect whole numbers

#0.2.1 (03/13/2016)
- wrap filename in quotes to allow spaces in file paths

#0.2.0 (02/22/2016)
- add new enum like types based on documentation on the exiftool page, and return these more specific values when parsing 

#0.1.0 (02/07/2016)
- initial release
