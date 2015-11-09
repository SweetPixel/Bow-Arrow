/*
* README
*
* Longbow
* Lylek Games
*
* Thank you for purchasing this asset!
*
* To add the longbow to your scene, simply drag and drop the Character prefab from the
* Prefabs folder into your scene; or use the Longbow prefab, and attach it to your own
* player character.
* 
* LONGBOW-SHOOT SCRIPT
* A LongbowShoot script is attached to the Longbow for animation, as well as to instantiate arrow
* projectiles with use of the Left Mouse Button.
*
* Components:
* Arrow Spawn - the position to spawn the arrow
* Projectile - the arrow to be instantiated
* Draw Sound - the sound the be played when the bow is drawn [sound file not included]
* Shoot Sound - the sound to be played when the arrow is shot [sound file not included]
* Max Power - the maximum allowed force to be applied to the arrow
* Destroy Time - the length of time until the arrow will be destroyed, after instantiation
* Destroy Arrow - whether or not the arrow will be destroyed | if this is unchecked, Destroy Time will have no effect
*
* ARROW-STUCK SCRIPT
* The arrow instantiated by the longbow is the Arrow prefab, found in the Prefabs folder. This prefab also
* contains a script, called ArrowStuck. Any arrows, traveling at a decent velocity, will penetrate
* surfaces and stick in place. Arrows will also perform as if they were top-heavy.
*
* Components:
* Hit Sound - sound to be played when arrows penetrate a surface. [sound file not included]
*
* If you have any questions, please contact:
* Email - support@lylekgames.com
*
* Thank you.
*
*******************************************************************************************
* Longbow
* 
* Update 1.2
*
* - Click-to-shoot script included.
* - The velocity of an arrow is dependent on how long the mouse button is held.
* - Arrows with a decent magnitude will penetrate surfaces.
* - Arrows perform as if they were top-heavy.
* - Longbow is incorporated with Unity's First-Person-Character
* -  Sound variables for drawing back the bow, shooting the bow, and when
* the arrow penetrates an object have been added so you can easily drag and
* drop your sound files onto the bow. [No sound included]
*
* Bow: 312verts / 624tris / 10bones
* Arrow: 140verts / 264tris
* Texture: Diffuse 1024 by 1024 png
* Texture: Normalmap 1024 by 1024 png
*
* Website
* http://www.lylekgames.com/
*
* Email
* support@lylekgames.com
*/
