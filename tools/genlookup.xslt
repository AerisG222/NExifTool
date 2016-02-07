<?xml version="1.0"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:date="http://exslt.org/dates-and-times">
    <xsl:template match="/">
        <xsl:text>// -------------------------------------------------------------------&#xa;</xsl:text>
        <xsl:text>// generated from: exiftool.xml&#xa;</xsl:text>
        <xsl:text>// generated on: </xsl:text> <xsl:value-of  select="date:date-time()"/> <xsl:text>&#xa;</xsl:text>
        <xsl:text>// -------------------------------------------------------------------&#xa;</xsl:text>
        <xsl:text>using System;&#xa;</xsl:text>
        <xsl:text>using System.Collections.Generic;&#xa;</xsl:text>
        <xsl:text>&#xa;</xsl:text>
        <xsl:text>&#xa;</xsl:text>
        <xsl:text>namespace NExifTool&#xa;</xsl:text>
        <xsl:text>{&#xa;</xsl:text>
        <xsl:text>    public class ExifToolTagDetails&#xa;</xsl:text>
        <xsl:text>    {&#xa;</xsl:text>
        <xsl:text>    &#xa;</xsl:text>
        <xsl:text>    }&#xa;</xsl:text>
        <xsl:text>}&#xa;</xsl:text>
    </xsl:template>
</xsl:stylesheet>
