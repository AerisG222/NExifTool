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

        <xsl:apply-templates />

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
        <xsl:variable name="g0" select="translate(@g0, $uppercase, $lowercase)" />
        <xsl:variable name="g1" select="translate(@g1, $uppercase, $lowercase)" />
        <xsl:variable name="g2" select="translate(@g2, $uppercase, $lowercase)" />
        
        <xsl:for-each select="tag">
            <xsl:variable name="name" select="translate(@name, $uppercase, $lowercase)" />
            
            <xsl:text>            AddInfo("</xsl:text>
                <xsl:value-of select="$g0" />:<xsl:value-of select="$g1" />:<xsl:value-of select="$g2" />::<xsl:value-of select="$name" /><xsl:text>", "</xsl:text>
                <xsl:value-of select="desc[@lang='en']" /><xsl:text>", "</xsl:text>
                <xsl:value-of select="@type" /><xsl:text>");&#xa;</xsl:text>
            
            <!-- exif:ifd0 looks like it is coming back as exif:subifd1, so add this too -->
            <xsl:if test="$g0 = 'exif' and $g1 = 'ifd0'">
                <xsl:text>            AddInfo("</xsl:text>
                    <xsl:value-of select="$g0" />:subifd1:<xsl:value-of select="$g2" />::<xsl:value-of select="$name" /><xsl:text>", "</xsl:text>
                    <xsl:value-of select="desc[@lang='en']" /><xsl:text>", "</xsl:text>
                    <xsl:value-of select="@type" /><xsl:text>");&#xa;</xsl:text>
            </xsl:if>
            <xsl:if test="$g0 = 'exif' and $g1 = 'ifd0'">
                <xsl:text>            AddInfo("</xsl:text>
                    <xsl:value-of select="$g0" />:exififd:<xsl:value-of select="$g2" />::<xsl:value-of select="$name" /><xsl:text>", "</xsl:text>
                    <xsl:value-of select="desc[@lang='en']" /><xsl:text>", "</xsl:text>
                    <xsl:value-of select="@type" /><xsl:text>");&#xa;</xsl:text>
            </xsl:if>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
