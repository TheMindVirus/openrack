# OpenRack
3D Web Visualiser for Designing Rack Mountable Systems and Network Cabinets for Critical Infrastructure

### Demo: https://themindvirus.github.io/openrack

![screenshot](/img/DOCS/screenshot.png)

The textures included in this visualiser are replaceable with PNG image textures of around 500x500px. \
Visualising Systems is considerably less expensive, more environmentally friendly and less error-prone \
compared to building the real life equivalent of such a system - that also requires more effort and resources.

Each manufacturer designs their ideal rack mountable system for themselves once in real life and then again \
in a 3D virtual space. An entirely theoretical dream architecture is also possible to design with OpenRack, \
removing the hard requirement to manufacture it in the real world.

Integrating these systems together in the form of imaginary models and image textures results in a composition \
which would otherwise be either impossible or difficult to achieve for one person alone with limited resources.

# Cabinets

While choosing textures in OpenRack, the following 6 classes of server were derived:
```
Cabinet 1 - The Pro-Tools Starter Kit [ENTRY]
Cabinet 2 - Edgecore and Architectural [EDGE]
Cabinet 3 - Specialist Monitoring Equipment [SPECIALIST]
Cabinet 4 - Realistic Industrial Economy Class [ECONOMY]
Cabinet 5 - Top-End Super-Rich Class [PERFORMANCE]
Cabinet 6 - Mission Critical Robustness Class [CRITICAL]
```
These Categories can further be split into 2 groups of 3 subcategories:
```
Specification Levels: [ENTR], [EDGE], [SPEC]
Infrastructure Levels: [ECON], [PERF], [CRIT]
```
Server Equipment can take many forms depending on the application and subcategory it falls into.

![screenshot2](/img/DOCS/screenshot2.png)

# Wedges

The equipment used in OpenRack is not limited to 19" racks with fine statistical tolerances. \
Instead, it is open to accept any texture specified - which can then be self-limited at a later stage. \
Some rack-mountable devices take the form of wedge consoles with rack-ears as optional accessories.

![wedge](/img/DOCS/wedgecomputing.png)

# Blades

A relatively new addition to the Server space is the inclusion of Games Consoles as Cloud Server Blades \
for Online Multiplayer and Immersive Virtual Reality Experiences which are custom built, \
especially for those who wouldn't normally have access to this kind of equipment.

![openrack](/img/DOCS/openrack.png)

The above image shows an Open Rack 2U server built by Microsoft containing several cloud Xbox consoles \
with networking and power distribution in one box. OpenRack can be extended in Unity to add in models for \
custom equipment such as GPU's, ARM-based DPU's as Plug-In Cards and Open Rack units with modular architecture.

# Trade Shows

In times before global pandemics, manufacturers of especially the computing and networking spaces used to \
showcase their newest equipment at trade shows. The show floor would be filled with the most diverse variety \
of new technology, gadgets and showcases, with great focus on magical things that seemingly couldn't be done before.

![showfloor](/img/DOCS/showfloor.png)

OpenRack could become a game similar to PC Building Simulator, with the aim of innovating new hardware \
to showcase at virtual (or otherwise augmented reality) trade show events orchestrated by anyone with \
an Edge Server that can run 3D Applications, especially the manufacturers who can sponsor and built it.

# Firmware

While it is possible to use Unity C# and ShaderLab Scripting to fully emulate virtual systems in a closed environment, \
OpenRack leaves this fully open to expansion in future builds of the engine. The simplicity of being able to dynamically \
set a texture should provide enough functionality for a variety of Graphical User Interfaces. More complex isn't necessarily better.
