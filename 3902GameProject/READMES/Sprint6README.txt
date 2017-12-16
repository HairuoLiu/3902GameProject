Tennison Gray, Caleb Lehman, Sean Zhang, Hairuo Liu

Notes on Specific Code Analysis Warnings:

-We suppressed a "CA1823: Avoid unused private fields" warning by GlobalSuppressions.cs.
-We suppressed "CA1030: Use events where appropriate" warning
-We suppressed warnings suggesting making things 'events', since we are not using events in the course
-We suppressed a warning about excessive cyclomatic complexity in LevelLoader, since the large swith case is easily understandable
-We suppressed a lot of "CA2211:NonConstantFieldsShouldNotBeVisible" warnings by GlobalSuppressions.cs.
-We suppressed a "CA1822:MarkMembersAsStatic" warning by GlobalSuppressions.cs.
-We suppressed a lot of "CA1823:AvoidUnusedPrivateFields" warnings by GlobalSuppressions.cs.


General Notes:

-Team did not have a way of testing gamepad functionality so it is untested
-Arrow keys move mario and z jumps where holding x makes you sprint and tapping x while in fire mode shoots a fireball
-Arrow keys move marth/swordman and x swings sword where z makes you jump. Sword can bounce enemies.
-Portals allow mario to warp from one colored portal to the other.
-If mario is in the fire state and picks up a 'big mushroom', he will remain in the fire state, since it is a stronger powerup.