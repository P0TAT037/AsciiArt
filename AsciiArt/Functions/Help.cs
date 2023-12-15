using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Functions
{
    public class Help
    {
        public static void PrintInstructions() {
            Console.WriteLine(@"[] => argument
{} => optional argument
=========================================
=>Prints these info
	--help
	OR
	-h
=========================================
=>Draw an image
	-i [image path] {image width}
=========================================

=========================================
=>Draw a video
	-v [path] {width} {sleep}
=========================================

=========================================
=>Live Capture
	-l {width}
	OR
	--live {width}
=========================================

=========================================
=>Draw Text
	-t [text] {fontname} 
		======> new fonts can be added and provided by providing it's path in the {fontname}
		======> download fonts here [https://github.com/xero/figlet-fonts/tree/master]
	--fonts ======> all font names
	-t -r [text] ======> text with random font
	-t -d [text] ======> text with the default decoration
	-t --decorate [text] ======> text with custom decoration
=========================================");
        }
    }
}
