
# Copyright 2015 (C)R-Koubou
# 
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# 
#    http://www.apache.org/licenses/LICENSE-2.0
# 
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

JSON = """
{
    "prefix":       "%s",
    "category":     "%s"
}
"""
DATA = [
    "EZX AMERICANA", "Americana",
    "EZX CLAUSTROPHOBIC", "Dance",
    "EZX DRUM KIT FRON HELL", "Metal",
    "EZX ELECTRONIC", "Electronic ",
    "EZX FUNKMASTERS", "Funk",
    "EZX INDIE FOLK", "Folk",
    "EZX JAZZ", "Jazz",
    "EZX LATAIN PERCUSSION", "Percussion",
    "EZX MADE OF METAL", "Metal",
    "EZX METAL HEADS", "Metal",
    "EZX METAL MACHINE", "Metal",
    "EZX METAL!", "Metal",
    "EZX NASHVILLE", "Country ",
    "EZX NUMBER 1 HITS", "Pop",
    "EZX POP", "Pop",
    "EZX POP ROCK", "Pop Rock",
    "EZX ROCK SOLID", "Rock",
    "EZX ROCK!", "Rock",
    "EZX THE BLUES", "Blues",
    "EZX THE CLASSIC", "Retoro Pop Rock",
    "EZX TWISTED KIT", "Percussion",
    "EZX VINTAGE ROCK", "Rock",

    "S2.0 NY Vol1", "Pop",
    "S2.0 NY Vol2", "Pop",
    "S2.0 NY Vol3", "Pop",
    "SDX MUSIC CITY USA", "Pop",
    "SDX CUSTOM & VINTAGE", "Rock",
    "SDX THE_ROCK_WAREHOUSE", "Rock",
    "SDX THE_METAL_FOUNDRY", "Metal",
    "SDX METAL MACHINERY", "Metal",
]

FILENAMES = [
    "EZX-Americana.json",
    "EZX-Claustrophobic.json",
    "EZX-Drum_Kit_Fron_Hell.json",
    "EZX-Electronic.json",
    "EZX-FunkMasters.json",
    "EZX-Indie_Folk.json",
    "EZX-Jazz.json",
    "EZX-Latain_Percussion.json",
    "EZX-Made_of_Metal.json",
    "EZX-METAL_HEADS.json",
    "EZX-METAL_MACHINE.json",
    "EZX-Metal!.json",
    "EZX-NASHVILLE.json",
    "EZX-Number_1_Hits.json",
    "EZX-Pop.json",
    "EZX-Pop_Rock.json",
    "EZX-ROCK_SOLID.json",
    "EZX-ROCK!.json",
    "EZX-The_Blues.json",
    "EZX-THE_CLASSIC.json",
    "EZX-Twisted_Kit.json",
    "EZX-Vintage_Rock.json",

    "S2.0-NY_Vol1.json",
    "S2.0-NY_Vol2.json",
    "S2.0-NY_Vol3.json",
    "SDX-MUSIC_CITY_USA.json",
    "SDX-CUSTOM_AND_VINTAGE.json",
    "SDX-THE_ROCK_WAREHOUSE.json",
    "SDX-THE_METAL_FOUNDRY.json",
    "SDX-METAL_MACHINERY.json",
]

if __name__ == "__main__":

    j = 0
    for i in range( 0, len( DATA ), 2 ):
        f = open( FILENAMES[ j ], "w" )
        f.write( JSON % ( DATA[ i + 0 ], DATA[ i + 1 ] ) )
        f.close()
        j += 1
