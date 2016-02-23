using System;


namespace NExifTool.Enums
{
    public class PixelFormat
        : TagEnum<ushort>
    {
        public static readonly PixelFormat BlackAndWhite = new PixelFormat(0x5, "Black & White");
        public static readonly PixelFormat EightBitGray = new PixelFormat(0x8, "8-bit Gray");
        public static readonly PixelFormat SixteenbitBGR555 = new PixelFormat(0x9, "16-bit BGR555");
        public static readonly PixelFormat SixteenBitBGR565 = new PixelFormat(0xa, "16-bit BGR565");
        public static readonly PixelFormat SixteenBitGray = new PixelFormat(0xb, "16-bit Gray");
        public static readonly PixelFormat TwentyFourBitBGR = new PixelFormat(0xc, "24-bit BGR");
        public static readonly PixelFormat TwentyFourBitRGB = new PixelFormat(0xd, "24-bit RGB");
        public static readonly PixelFormat ThirtyTwoBitBGR = new PixelFormat(0xe, "32-bit BGR");
        public static readonly PixelFormat ThirtyTwoBitBGRA = new PixelFormat(0xf, "32-bit BGRA");
        public static readonly PixelFormat ThirtyTwoBitPBGRA = new PixelFormat(0x10, "32-bit PBGRA");
        public static readonly PixelFormat ThirtyTwoBitGrayFloat = new PixelFormat(0x11, "32-bit Gray Float");
        public static readonly PixelFormat FortyEightBitRGBFixedPoint = new PixelFormat(0x12, "48-bit RGB Fixed Point");
        public static readonly PixelFormat ThirtyTwoBitBGR101010 = new PixelFormat(0x13, "32-bit BGR101010");
        public static readonly PixelFormat FortyEightBitRGB = new PixelFormat(0x15, "48-bit RGB");
        public static readonly PixelFormat SixtyFourBitRGBA = new PixelFormat(0x16, "64-bit RGBA");
        public static readonly PixelFormat SixtyFourBitPRGBA = new PixelFormat(0x17, "64-bit PRGBA");
        public static readonly PixelFormat NinetySixBitRGBFixedPoint = new PixelFormat(0x18, "96-bit RGB Fixed Point");
        public static readonly PixelFormat OneTwentyEightBitRGBAFloat = new PixelFormat(0x19, "128-bit RGBA Float");
        public static readonly PixelFormat OneTwentyEightBitPRGBAFloat = new PixelFormat(0x1a, "128-bit PRGBA Float");
        public static readonly PixelFormat OneTwentyEightBitRGBFloat = new PixelFormat(0x1b, "128-bit RGB Float");
        public static readonly PixelFormat ThirtyTwoBitCMYK = new PixelFormat(0x1c, "32-bit CMYK");
        public static readonly PixelFormat SixtyFourBitRGBAFixedPoint = new PixelFormat(0x1d, "64-bit RGBA Fixed Point");
        public static readonly PixelFormat OneTwentyEightBitRGBAFixedPoint = new PixelFormat(0x1e, "128-bit RGBA Fixed Point");
        public static readonly PixelFormat SixtyFourBitCMYK = new PixelFormat(0x1f, "64-bit CMYK");
        public static readonly PixelFormat TwentyFourBit3Channels = new PixelFormat(0x20, "24-bit 3 Channels");
        public static readonly PixelFormat ThirtyTwoBit4Channels = new PixelFormat(0x21, "32-bit 4 Channels");
        public static readonly PixelFormat FortyBit5Channels = new PixelFormat(0x22, "40-bit 5 Channels");
        public static readonly PixelFormat FortyEightBit6Channels = new PixelFormat(0x23, "48-bit 6 Channels");
        public static readonly PixelFormat FiftySixBit7Channels = new PixelFormat(0x24, "56-bit 7 Channels");
        public static readonly PixelFormat SixtyFourBit8Channels = new PixelFormat(0x25, "64-bit 8 Channels");
        public static readonly PixelFormat FortyEightBit3Channels = new PixelFormat(0x26, "48-bit 3 Channels");
        public static readonly PixelFormat SixtyFourBit4Channels = new PixelFormat(0x27, "64-bit 4 Channels");
        public static readonly PixelFormat EightyBit5Channels = new PixelFormat(0x28, "80-bit 5 Channels");
        public static readonly PixelFormat NinetySixBit6Channels = new PixelFormat(0x29, "96-bit 6 Channels");
        public static readonly PixelFormat OneTwelveBit7Channels = new PixelFormat(0x2a, "112-bit 7 Channels");
        public static readonly PixelFormat OneTwentyEightBit8Channels = new PixelFormat(0x2b, "128-bit 8 Channels");
        public static readonly PixelFormat FortyBitCMYKAlpha = new PixelFormat(0x2c, "40-bit CMYK Alpha");
        public static readonly PixelFormat EightyBitCMYKAlpha = new PixelFormat(0x2d, "80-bit CMYK Alpha");
        public static readonly PixelFormat ThirtyTwoBit3ChannelsAlpha = new PixelFormat(0x2e, "32-bit 3 Channels Alpha");
        public static readonly PixelFormat FortyBit4ChannelsAlpha = new PixelFormat(0x2f, "40-bit 4 Channels Alpha");
        public static readonly PixelFormat FortyEightBit5ChannelsAlpha = new PixelFormat(0x30, "48-bit 5 Channels Alpha");
        public static readonly PixelFormat FiftySixBit6ChannelsAlpha = new PixelFormat(0x31, "56-bit 6 Channels Alpha");
        public static readonly PixelFormat SixtyFourBit7ChannelsAlpha = new PixelFormat(0x32, "64-bit 7 Channels Alpha");
        public static readonly PixelFormat SeventyTwoBit8ChannelsAlpha = new PixelFormat(0x33, "72-bit 8 Channels Alpha");
        public static readonly PixelFormat SixtyFourBit3ChannelsAlpha = new PixelFormat(0x34, "64-bit 3 Channels Alpha");
        public static readonly PixelFormat EightyBit4ChannelsAlpha = new PixelFormat(0x35, "80-bit 4 Channels Alpha");
        public static readonly PixelFormat NinetySixBit5ChannelsAlpha = new PixelFormat(0x36, "96-bit 5 Channels Alpha");
        public static readonly PixelFormat OneTwelveBit6ChannelsAlpha = new PixelFormat(0x37, "112-bit 6 Channels Alpha");
        public static readonly PixelFormat OneTwentyEightBit7ChannelsAlpha = new PixelFormat(0x38, "128-bit 7 Channels Alpha");
        public static readonly PixelFormat OneFortyFourBit8ChannelsAlpha = new PixelFormat(0x39, "144-bit 8 Channels Alpha");
        public static readonly PixelFormat SixtyFourBitRGBAHalf = new PixelFormat(0x3a, "64-bit RGBA Half");
        public static readonly PixelFormat FortyEightBitRGBHalf = new PixelFormat(0x3b, "48-bit RGB Half");
        public static readonly PixelFormat ThirtyTwoBitRGBE = new PixelFormat(0x3d, "32-bit RGBE");
        public static readonly PixelFormat SixteenBitGrayHalf = new PixelFormat(0x3e, "16-bit Gray Half");
        public static readonly PixelFormat ThirtyTwoBitGrayFixedPoint = new PixelFormat(0x3f, "32-bit Gray Fixed Point");
        
        
        public PixelFormat(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static PixelFormat FromKey(ushort key)
        {
            switch(key)
            {
                case 0x5: return BlackAndWhite;
                case 0x8: return EightBitGray;
                case 0x9: return SixteenbitBGR555;
                case 0xa: return SixteenBitBGR565;
                case 0xb: return SixteenBitGray;
                case 0xc: return TwentyFourBitBGR;
                case 0xd: return TwentyFourBitRGB;
                case 0xe: return ThirtyTwoBitBGR;
                case 0xf: return ThirtyTwoBitBGRA;
                case 0x10: return ThirtyTwoBitPBGRA;
                case 0x11: return ThirtyTwoBitGrayFloat;
                case 0x12: return FortyEightBitRGBFixedPoint;
                case 0x13: return ThirtyTwoBitBGR101010;
                case 0x15: return FortyEightBitRGB;
                case 0x16: return SixtyFourBitRGBA;
                case 0x17: return SixtyFourBitPRGBA;
                case 0x18: return NinetySixBitRGBFixedPoint;
                case 0x19: return OneTwentyEightBitRGBAFloat;
                case 0x1a: return OneTwentyEightBitPRGBAFloat;
                case 0x1b: return OneTwentyEightBitRGBFloat;
                case 0x1c: return ThirtyTwoBitCMYK;
                case 0x1d: return SixtyFourBitRGBAFixedPoint;
                case 0x1e: return OneTwentyEightBitRGBAFixedPoint;
                case 0x1f: return SixtyFourBitCMYK;
                case 0x20: return TwentyFourBit3Channels;
                case 0x21: return ThirtyTwoBit4Channels;
                case 0x22: return FortyBit5Channels;
                case 0x23: return FortyEightBit6Channels;
                case 0x24: return FiftySixBit7Channels;
                case 0x25: return SixtyFourBit8Channels;
                case 0x26: return FortyEightBit3Channels;
                case 0x27: return SixtyFourBit4Channels;
                case 0x28: return EightyBit5Channels;
                case 0x29: return NinetySixBit6Channels;
                case 0x2a: return OneTwelveBit7Channels;
                case 0x2b: return OneTwentyEightBit8Channels;
                case 0x2c: return FortyBitCMYKAlpha;
                case 0x2d: return EightyBitCMYKAlpha;
                case 0x2e: return ThirtyTwoBit3ChannelsAlpha;
                case 0x2f: return FortyBit4ChannelsAlpha;
                case 0x30: return FortyEightBit5ChannelsAlpha;
                case 0x31: return FiftySixBit6ChannelsAlpha;
                case 0x32: return SixtyFourBit7ChannelsAlpha;
                case 0x33: return SeventyTwoBit8ChannelsAlpha;
                case 0x34: return SixtyFourBit3ChannelsAlpha;
                case 0x35: return EightyBit4ChannelsAlpha;
                case 0x36: return NinetySixBit5ChannelsAlpha;
                case 0x37: return OneTwelveBit6ChannelsAlpha;
                case 0x38: return OneTwentyEightBit7ChannelsAlpha;
                case 0x39: return OneFortyFourBit8ChannelsAlpha;
                case 0x3a: return SixtyFourBitRGBAHalf;
                case 0x3b: return FortyEightBitRGBHalf;
                case 0x3d: return ThirtyTwoBitRGBE;
                case 0x3e: return SixteenBitGrayHalf;
                case 0x3f: return ThirtyTwoBitGrayFixedPoint;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
