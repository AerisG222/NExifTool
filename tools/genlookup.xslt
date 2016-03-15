<?xml version="1.0"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:date="http://exslt.org/dates-and-times">
    <xsl:output method="text"/>
    <xsl:variable name="lowercase" select="'abcdefghijklmnopqrstuvwxyz'" />
    <xsl:variable name="uppercase" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ '" />
    
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
        <xsl:text>    public class ExifToolLookup&#xa;</xsl:text>
        <xsl:text>    {&#xa;</xsl:text>
        <xsl:text>        public static readonly Dictionary&lt;string, TagInfo&gt; Details = new Dictionary&lt;string, TagInfo&gt;();&#xa;</xsl:text>
        <xsl:text>        &#xa;</xsl:text>
        <xsl:text>        &#xa;</xsl:text>
        <xsl:text>        static ExifToolLookup()&#xa;</xsl:text>
        <xsl:text>        {&#xa;</xsl:text>

        <xsl:apply-templates match="table" />

        <xsl:text>        }&#xa;</xsl:text>
        <xsl:text>        &#xa;</xsl:text>
        <xsl:text>        &#xa;</xsl:text>
        <xsl:text>        static void AddInfo(string name, string description, string type)&#xa;</xsl:text>
        <xsl:text>        {&#xa;</xsl:text>
        <xsl:text>            if(!Details.ContainsKey(name))&#xa;</xsl:text>
        <xsl:text>            {&#xa;</xsl:text>
        <xsl:text>                Details.Add(name, new TagInfo { Name = name, Description = description, ValueType = type });&#xa;</xsl:text>
        <xsl:text>            }&#xa;</xsl:text>
        <xsl:text>            //else&#xa;</xsl:text>
        <xsl:text>            //{&#xa;</xsl:text>
        <xsl:text>                //Console.WriteLine($"duplicate: {name}");&#xa;</xsl:text>
        <xsl:text>            //}&#xa;</xsl:text>
        <xsl:text>        }&#xa;</xsl:text>
        <xsl:text>    }&#xa;</xsl:text>
        <xsl:text>}&#xa;</xsl:text>
    </xsl:template>
    
    <xsl:template match="table">
        <xsl:variable name="g0" select="@g0" />
        <xsl:variable name="g1" select="@g1" />
        <xsl:variable name="g2" select="@g2" />
        <xsl:for-each select="tag">
            <xsl:text>            AddInfo("</xsl:text>
                <xsl:value-of select="translate($g0, $uppercase, $lowercase)" />:<xsl:value-of select="translate($g1, $uppercase, $lowercase)" />:<xsl:value-of select="translate($g2, $uppercase, $lowercase)" />::<xsl:value-of select="translate(@name, $uppercase, $lowercase)" /><xsl:text>", "</xsl:text>
                <xsl:value-of select="desc[@lang='en']" /><xsl:text>", "</xsl:text>
                <xsl:value-of select="@type" /><xsl:text>");&#xa;</xsl:text>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
