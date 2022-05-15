# OpenRack PatchBay
3D Web Visualiser for Designing Rack Mountable Systems and Network Cabinets for Critical Infrastructure

### Demo: https://themindvirus.github.io/openrack/patchbay

![screenshot](/patchbay/screenshot.png)

https://github.com/TheMindVirus/openrack/blob/2b455aabc9fa14f656c3f279bd63018f5c048655/patchbay/Source/Assets/PatchBay.cs#L43

https://github.com/TheMindVirus/openrack/blob/2b455aabc9fa14f656c3f279bd63018f5c048655/patchbay/index.html#L67

# CUID
In the context of OpenRack PatchBay, a CUID stands for **Constant Unique IDentifier**. \
The principle of uniqueness is shared with UUID and GUID but instead of Universal or Global uniqueness, \
CUID focusses on keeping a constant interface that remains invariant (doesn't change) between versions.

This helps maintain backwards/forwards compatibility for serialisation (loading/saving) and is tagged on \
to the Unity GameObject/Transform's name because `m_LocalIdentfierInFile` was mis-spelt and `GetInstanceID()` \
by design kept changing on every playback or edit mode launch.

A simple 32-bit signed integer CUID uses 16 bits to store a positive identifier. \
0 is considered to be Global/Unknown and negative identifiers are considered as errors. \
It takes the form of a label with a hashtag (e.g.: `MyCustomGameObject#92569`) as seen previously on many apps.

If a CUID is already present, it should not be changed where possible. If a hash (`#`) is already present, append to it. \
If there are errors then either the global scope of 0 should be used or a new CUID can be generated which will break versions. \
The use of a CUID<->CUID translater is recommended for the eventuality that CUID's become complex to manage, \
but ideally CUID's should be set once, checked for uniqueness in the domain and then kept constant for as long as possible.
