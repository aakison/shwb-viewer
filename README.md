# shwb-viewer
Viewer for the now-obsolete SHWB format used by Shared Whiteboard

For Windows 8 I had created a app called Shared Whiteboard for the Windows 8 store.  This was using the new Metro design style and guidance from Microsoft at the time 
and was launched into the store.  This model of programming has been obsoleted by Microsoft and this app is no longer available in the Windows Store.

The application used a proprietary file format for whiteboards which stored not just the image data but also the timestamps of all actions to allow for an animated 
replay of each board.  This file format had an extension of .shwb and was just a json serialization of the internal data structures.

For users that have their original .shwb files, this project uses the models from that original project and reconstructs the rendering using Microsoft's current 
technology stack which works on Windows 10.
