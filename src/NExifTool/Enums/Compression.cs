using System;


namespace NExifTool.Enums
{
    public class Compression
        : TagEnum<ushort>
    {
        public static readonly Compression Uncompressed = new Compression(1, "Uncompressed");
        public static readonly Compression Ccitt1d = new Compression(2, "CCITT 1D");
        public static readonly Compression T4Group3Fax = new Compression(3, "T4/Group 3 Fax");
        public static readonly Compression T6Group4Fax = new Compression(4, "T6/Group 4 Fax");
        public static readonly Compression Lzw = new Compression(5, "LZW");
        public static readonly Compression JpegOld = new Compression(6, "JPEG (old-style)");
        public static readonly Compression Jpeg = new Compression(7, "JPEG");
        public static readonly Compression AdobeDeflate = new Compression(8, "Adobe Deflate");
        public static readonly Compression JbigBW = new Compression(9, "JBIG B&W");
        public static readonly Compression JbigColor = new Compression(10, "JBIG Color");
        public static readonly Compression Jpeg2 = new Compression(99, "JPEG");
        public static readonly Compression Kodak262 = new Compression(262, "Kodak 262");
        public static readonly Compression Next = new Compression(32766, "Next");
        public static readonly Compression SonyArw = new Compression(32767, "Sony ARW Compressed");
        public static readonly Compression PackedRaw = new Compression(32769, "Packed RAW");
        public static readonly Compression SamsungSrw = new Compression(32770, "Samsung SRW Compressed");
        public static readonly Compression Ccirlew = new Compression(32771, "CCIRLEW");
        public static readonly Compression SamsungSrw2 = new Compression(32772, "Samsung SRW Compressed 2");
        public static readonly Compression PackBits = new Compression(32773, "PackBits");
        public static readonly Compression Thunderscan = new Compression(32809, "Thunderscan");
        public static readonly Compression KodacKdc = new Compression(32867, "Kodak KDC Compressed");
        public static readonly Compression It8ctpad = new Compression(32895, "IT8CTPAD");
        public static readonly Compression It8lw = new Compression(32896, "IT8LW");
        public static readonly Compression It8mp = new Compression(32897, "IT8MP");
        public static readonly Compression It8bl = new Compression(32898, "IT8BL");
        public static readonly Compression PixarFilm = new Compression(32908, "PixarFilm");
        public static readonly Compression PixarLog = new Compression(32909, "PixarLog");
        public static readonly Compression Deflate = new Compression(32946, "Deflate");
        public static readonly Compression Dcs = new Compression(32947, "DCS");
        public static readonly Compression Jbig = new Compression(34661, "JBIG");
        public static readonly Compression SgiLog = new Compression(34676, "SGILog");
        public static readonly Compression SgiLog24 = new Compression(34677, "SGILog24");
        public static readonly Compression Jpeg2000 = new Compression(34712, "JPEG 2000");
        public static readonly Compression NikonNef = new Compression(34713, "Nikon NEF Compressed");
        public static readonly Compression Jbig2Tiff = new Compression(34715, "JBIG2 TIFF FX");
        public static readonly Compression MsDocImagingBinary = new Compression(34718, "Microsoft Document Imaging (MDI) Binary Level Codec");
        public static readonly Compression MsDocImagingProgressive = new Compression(34719, "Microsoft Document Imaging (MDI) Progressive Transform Codec");
        public static readonly Compression MsDocImagingVector = new Compression(34720, "Microsoft Document Imaging (MDI) Vector");
        public static readonly Compression JpegLossy = new Compression(34892, "Lossy JPEG");
        public static readonly Compression KodakDcr = new Compression(65000, "Kodak DCR Compressed");
        public static readonly Compression PentaxPef = new Compression(65535, "Pentax PEF Compressed");
        
        
        public Compression(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Compression FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Uncompressed;
                case 2: return Ccitt1d;
                case 3: return T4Group3Fax;
                case 4: return T6Group4Fax;
                case 5: return Lzw;
                case 6: return JpegOld;
                case 7: return Jpeg;
                case 8: return AdobeDeflate;
                case 9: return JbigBW;
                case 10: return JbigColor;
                case 99: return Jpeg2;
                case 262: return Kodak262;
                case 32766: return Next;
                case 32767: return SonyArw;
                case 32769: return PackedRaw;
                case 32770: return SamsungSrw;
                case 32771: return Ccirlew;
                case 32772: return SamsungSrw2;
                case 32773: return PackBits;
                case 32809: return Thunderscan;
                case 32867: return KodacKdc;
                case 32895: return It8ctpad;
                case 32896: return It8lw;
                case 32897: return It8mp;
                case 32898: return It8bl;
                case 32908: return PixarFilm;
                case 32909: return PixarLog;
                case 32946: return Deflate;
                case 32947: return Dcs;
                case 34661: return Jbig;
                case 34676: return SgiLog;
                case 34677: return SgiLog24;
                case 34712: return Jpeg2000;
                case 34713: return NikonNef;
                case 34715: return Jbig2Tiff;
                case 34718: return MsDocImagingBinary;
                case 34719: return MsDocImagingProgressive;
                case 34720: return MsDocImagingVector;
                case 34892: return JpegLossy;
                case 65000: return KodakDcr;
                case 65535: return PentaxPef;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
