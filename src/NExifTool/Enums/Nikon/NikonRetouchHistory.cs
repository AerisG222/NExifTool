using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonRetouchHistory
        : TagEnum<ushort>
    {
        public static readonly NikonRetouchHistory None = new NikonRetouchHistory(0, "None");
        public static readonly NikonRetouchHistory BlackAndWhite = new NikonRetouchHistory(3, "B & W");
        public static readonly NikonRetouchHistory Sepia = new NikonRetouchHistory(4, "Sepia");
        public static readonly NikonRetouchHistory Trim = new NikonRetouchHistory(5, "Trim");
        public static readonly NikonRetouchHistory SmallPicture = new NikonRetouchHistory(6, "Small Picture");
        public static readonly NikonRetouchHistory DLighting = new NikonRetouchHistory(7, "D-Lighting");
        public static readonly NikonRetouchHistory RedEye = new NikonRetouchHistory(8, "Red Eye");
        public static readonly NikonRetouchHistory Cyanotype = new NikonRetouchHistory(9, "Cyanotype");
        public static readonly NikonRetouchHistory SkyLight = new NikonRetouchHistory(10, "Sky Light");
        public static readonly NikonRetouchHistory Warmtone = new NikonRetouchHistory(11, "Warm Tone");
        public static readonly NikonRetouchHistory ColorCustom = new NikonRetouchHistory(12, "Color Custom");
        public static readonly NikonRetouchHistory ImageOverlay = new NikonRetouchHistory(13, "Image Overlay");
        public static readonly NikonRetouchHistory RedIntensifier = new NikonRetouchHistory(14, "Red Intensifier");
        public static readonly NikonRetouchHistory GreenIntensifier = new NikonRetouchHistory(15, "Green Intensifier");
        public static readonly NikonRetouchHistory BlueIntensifier = new NikonRetouchHistory(16, "Blue Intensifier");
        public static readonly NikonRetouchHistory CrossScreen = new NikonRetouchHistory(17, "Cross Screen");	   	
        public static readonly NikonRetouchHistory QuickRetouch = new NikonRetouchHistory(18, "Quick Retouch");
        public static readonly NikonRetouchHistory NefProcessing = new NikonRetouchHistory(19, "NEF Processing");
        public static readonly NikonRetouchHistory DistortionControl = new NikonRetouchHistory(23, "Distortion Control");
        public static readonly NikonRetouchHistory Fisheye = new NikonRetouchHistory(25, "Fisheye");
        public static readonly NikonRetouchHistory Straighten = new NikonRetouchHistory(26, "Straighten");
        public static readonly NikonRetouchHistory PerspectiveControl = new NikonRetouchHistory(29, "Perspective Control");
        public static readonly NikonRetouchHistory ColorOutline = new NikonRetouchHistory(30, "Color Outline");
        public static readonly NikonRetouchHistory SoftFilter = new NikonRetouchHistory(31, "Soft Filter");
        public static readonly NikonRetouchHistory Resize = new NikonRetouchHistory(32, "Resize");
        public static readonly NikonRetouchHistory MiniatureEffect = new NikonRetouchHistory(33, "Miniature Effect");
        public static readonly NikonRetouchHistory SkinSoftening = new NikonRetouchHistory(34, "Skin Softening");
        public static readonly NikonRetouchHistory SelectedFrame = new NikonRetouchHistory(35, "Selected Frame");
        public static readonly NikonRetouchHistory ColorSketch = new NikonRetouchHistory(37, "Color Sketch");
        public static readonly NikonRetouchHistory SelectiveColor = new NikonRetouchHistory(38, "Selective Color");
        public static readonly NikonRetouchHistory Drawing = new NikonRetouchHistory(40, "Drawing");

        
        public NikonRetouchHistory(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonRetouchHistory FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return None;
                case 3: return BlackAndWhite;
                case 4: return Sepia;
                case 5: return Trim;
                case 6: return SmallPicture;
                case 7: return DLighting;
                case 8: return RedEye;
                case 9: return Cyanotype;
                case 10: return SkyLight;
                case 11: return Warmtone;
                case 12: return ColorCustom;
                case 13: return ImageOverlay;
                case 14: return RedIntensifier;
                case 15: return GreenIntensifier;
                case 16: return BlueIntensifier;
                case 17: return CrossScreen;	   	
                case 18: return QuickRetouch;
                case 19: return NefProcessing;
                case 23: return DistortionControl;
                case 25: return Fisheye;
                case 26: return Straighten;
                case 29: return PerspectiveControl;
                case 30: return ColorOutline;
                case 31: return SoftFilter;
                case 32: return Resize;
                case 33: return MiniatureEffect;
                case 34: return SkinSoftening;
                case 35: return SelectedFrame;
                case 37: return ColorSketch;
                case 38: return SelectiveColor;
                case 40: return Drawing;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
