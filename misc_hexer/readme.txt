Hexes tf2 models to others.

Drag the files for the source model to "input" folder. Make sure they
all have the same base name! 

For example:

football_helmet.dx80.vtx
football_helmet.dx90.vtx
football_helmet.mdl
football_helmet.phy
football_helmet.sw.vtx
football_helmet.vvd 

Next, list the paths of all models you want to replace in "config.txt". 
The paths should be relative to "models/" and should be in 
quotes. Anything outside of the quotes will be ignored. Have one path
per line. Don't include file extensions, just the base name. 

For example:

"player/items/all_class/ghostly_gibus_demo"

If you don't care about creating the correct file path, just add the name
of the file and it will appear at the root.

For example:

"ghostly_gibus_demo"

The file path should be PC style (with / instead of \). You can 
find a list of all items at the time of this program's creation in 
"modelList.txt". 

Run the program by navigating to the folder "MiscHexer" in the command 
line then type:

java MiscHexer

The new files will appear under "output/MiscHexer_Output_X"

For example:

"MiscHexer/output/MiscHexer_Output_1/models/player/items/all_class/" 

will contain:

ghostly_gibus_demo.dx80.vtx
ghostly_gibus_demo.dx90.vtx
ghostly_gibus_demo.mdl
ghostly_gibus_demo.phy
ghostly_gibus_demo.sw.vtx
ghostly_gibus_demo.vvd

In this case, you can drag MiscHexerOutput_1 into "tf/custom/" and it 
should work. You can rename MiscHexerOutput_1 to anything.

This program only contains basic error checking, so don't mess around 
with it. Don't move the config file, java file, or folders. 
