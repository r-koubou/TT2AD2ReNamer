/*
   Copyright 2015 (C)R-Koubou

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace org.rkoubou.tt2adrenamer
{
    class ConvertionInfo
    {
        public string from;
        public string to;
    }

    public class TT2ADReNamer
    {

        static readonly string JSON_KEY_PREFIX   = "prefix";
        static readonly string JSON_KEY_CATEGORY = "category";

        string jsonFileName;
        string category;
        string prefix;

        string rootDirName;
        string outputDirName;
        string outputDirFullName;

        /**
         * Ctor.
         */
        public TT2ADReNamer( string confJsonFileName, string basetDir, string destDir )
        {
            jsonFileName  = confJsonFileName;
            rootDirName   = basetDir;
            outputDirName = destDir;
        }

        /**
         * Execute
         */
        public void Execute()
        {
            string jsonString = "";

            using( StreamReader sr = new StreamReader( jsonFileName, new UTF8Encoding( false ) ) )
            {
                jsonString = sr.ReadToEnd();
            }

            Dictionary<string, object> json = MiniJSON.Json.Deserialize( jsonString ) as Dictionary<string, object>;
            foreach( string key in json.Keys )
            {
                if( json[ key ] is double )
                {
                    json[ key ] = (int)( (double)json[ key ] );
                }
            }


            prefix    = json[ JSON_KEY_PREFIX ].ToString();
            category  = json[ JSON_KEY_CATEGORY ].ToString();
            string outputDir = Path.Combine( outputDirName, prefix );

            outputDir         = Path.GetFullPath( outputDir );
            outputDirFullName = outputDir;

            System.Environment.CurrentDirectory = Path.GetFullPath( rootDirName );

            List<ConvertionInfo> copyList = new List<ConvertionInfo>( 2000 );

            collectItems( copyList, ".", 0 );

            int total    = copyList.Count;
            int progress = 0;

            foreach( ConvertionInfo i in copyList )
            {
                if( !Directory.Exists( Path.GetDirectoryName( i.to ) ) )
                {
                    Directory.CreateDirectory( Path.GetDirectoryName( i.to ) );
                }

                File.Copy( i.from, i.to, true );
                progress++;

                Console.Clear();
                Console.WriteLine( string.Format( "Rename & Copy {0}/{1} : {2}", progress, total, Path.GetFileName( i.from ) ) );
            }

        }

        bool collectItems( List<ConvertionInfo> dest, string dir, int depth )
        {
            string[] subDirs = Directory.GetDirectories( dir );
            foreach( string d in subDirs )
            {
                collectItems( dest, d, depth + 1 );
            }

            string[] files = Directory.GetFiles( dir, "*.mid" );
            if( files.Length == 0 )
            {
                return false;
            }

            bool toAmpersand = depth > 0;

            foreach( string f in files )
            {
                ConvertionInfo info  = new ConvertionInfo();
                string newOutputDir  = replaceDirName( dir );
                newOutputDir = Path.Combine( outputDirFullName, newOutputDir );

                string variantName2 = makeVariantName( replaceDirName( dir, toAmpersand ) );

                string name          = Path.GetFileNameWithoutExtension( f );
                string fn            = string.Format( "{0}_V_{1}_C_{2}.mid", variantName2, makeVariantName( replaceFileName( name ) ), category );
                fn = fn.Replace( "" + Path.DirectorySeparatorChar, "" );

                string srcFulliPath  = Path.GetFullPath( f );
                string destFulliPath = Path.GetFullPath( Path.Combine( newOutputDir, fn ) );

                info.from = srcFulliPath;
                info.to   = destFulliPath;
                dest.Add( info );
            }

            return true;
        }

        static string replaceDirName( string src, bool toAmpersand = true )
        {
            const string REGEX = @"([0-9|a-z|A-Z]+)@(.*)";
            //src = Regex.Replace( src, REGEX1, "$1 $2$3" );
            //const string REGEX = @"[[0-9|a-z|A-Z]+@(.*)";
            src = Regex.Replace( src, REGEX, "$2" );
            src = src.Replace( "._", " " );
            src = src.Replace( "_", " " );
            src = src.Replace( "@", " " );
            src = src.Replace( "#", toAmpersand ? "&" : "-" );
            return src;
        }

        static string replaceFileName( string src )
        {
            const string REGEX = @"[0-9|a-z|A-Z]+@(.*)";
            src = Regex.Replace( src, REGEX, "$1" );
            src = src.Replace( "#", "&" );
            src = src.Replace( "._", " " );
            src = src.Replace( "_", " " );
            return src;
        }

        static string getDirectoryName( string src )
        {
            if( Path.DirectorySeparatorChar == '\\' )
            {
                // Windows (\)
                src = Regex.Replace( src, @".*?\\(.*)", "$1" );
            }
            else
            {
                // Mac OSX, Unix, etc ( "/" )
                src = Regex.Replace( src, @".*?\/(.*)", "$1" );
            }
            return src;
        }

        static string makeVariantName( string src )
        {
            if( Path.DirectorySeparatorChar == '\\' )
            {
                // Windows (\)
                src = Regex.Replace( src, @".*?\\(.*)", "$1" );
            }
            else
            {
                // Mac OSX, Unix, etc ( "/" )
                src = Regex.Replace( src, @".*?\/(.*)", "$1" );
            }
            return src;
        }

        /**
         * Application Entry point.
         */
        static public void Main( string[] argv )
        {
            if( argv.Length < 3 )
            {
                usage();
                return;
            }
            TT2ADReNamer p = new TT2ADReNamer( argv[ 0 ], argv[ 1 ], argv[ 2 ] );
            p.Execute();

        }

        /**
         * Show Usage
         */
        static void usage()
        {
            string[] text =
            {
                "usage",
                "   TT2ADReNamer <config jsonfilename> <source dir> <dest dir>",
            };

            foreach( string i in text )
                Console.WriteLine( i );
        }
    }
}
