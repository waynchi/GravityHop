# GravityHop
Our gravity based game

# 02-04-10-14AM Xuechao
Load the project, hit 'left' to release, and hit 'up' or 'down' to tune the orbit.

# 02-04-10-14AM Alex Wang
The powerups and obstacles are in Week4Obstacles folder. All the assets used for powerups and obstacles are located in "Obstacle" folder.
A few things:
- All of the obstacles provided have been implemented.
- Some of the power-ups are implemented, others are ideas that need physics system to work.
- "Player" has a "CollisionScript" attached. It is IMPORTANT to make sure that the obstacles' and powerups' NAMES match one of the cases provided in the script to work.
- "ScoreSystem" is attached to UI Text
- Rest of the scripts are for obstacles

List of Implementation:
- Asteroid: destroys or bounce the ship depending on angle of deflection (added "Bouncy")
- Black Hole: detroys ship
- Drone: Patrols back and forth, can destroy ship
- Laser: a wall that turns on and off, can destroy ship
- Wall (Ice): wall that reflects the ship (added "Bouncy")
- Invincibility: Allows ship to pierce object one-time only
- Coin: Gives player more points
- Star: Adds on to score multiplier
 
Ideas yet to be implmented (Need physics system to work)
- Gravity Boost: Increase gravity field of all planets temporarily
- Homing: Allows player to home to the closest planet (on input)

