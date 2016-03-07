# GravityHop
Our gravity based game

#03-06 1:03AM Xuechao
- Combo System Added
- Display when there is combo, and disappear when there isn't


#03-06 12:10AM Xuechao
- Button touching won't be caught by DetectInput() anymore.
- The player will surround on the surface of the planet unless tap is detected.
- Tap will let the player fly out on the perpendicular direction. 




# 02-04-10-14AM Xuechao
Load the project, hit 'left' to release, and hit 'up' or 'down' to tune the orbit.

# 02-04-10-14AM Alex Wang
<<<<<<< HEAD
Changes are under branch "Tracker".
=======
>>>>>>> Tracker
Gravity fields and offscreen indicators are implemented. Here's how they work:

GRAVITY FIELD
- Circle.png is created and moved offscreen
- Circle is assigned with tag name "Field". This tag is used to identify the gameobject for the script "Planet".
- The script "Planet" is modified to generate the fields using the circle
- Circle is assigned to layer "Background". Use it for "SORTING LAYERS" to place circle behind layer "Default"
 
OFFSCREEN BUBBLES
- Bubble.png is indicated by the yellow circle. There should be TWO COPIES under ScoreCanvas.
- The TWO images must be given "Bubble" tag for the script "OffscreenTracker" to work
- Another script called "OffscreenTracker" is attached to ScoreCanvas. It basically finds two closest, OFFSCREEN planets and sets the yellow trackers in their directions.
- There should be two trackers.
