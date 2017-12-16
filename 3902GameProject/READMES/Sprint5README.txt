Tennison Gray, Caleb Lehman, Sean Zhang, Hairuo Liu

Notes on Specific Code Analysis Warnings:

-We suppressed a "CA1823: Avoid unused private fields" warning by GlobalSuppressions.cs.
-We suppressed "CA1030: Use events where appropriate" warning
-We suppressed warnings suggesting making things 'events', since we are not using events in the course
-We suppressed a warning about excessive cyclomatic complexity in LevelLoader, since the large swith case is easily understandable
-We suppressed a lot of "CA2211:NonConstantFieldsShouldNotBeVisible" warnings by GlobalSuppressions.cs.
-We suppressed a "CA1822:MarkMembersAsStatic" warning by GlobalSuppressions.cs.
-We suppressed a lot of "CA1823:AvoidUnusedPrivateFields" warnings by GlobalSuppressions.cs.
-We suppresed 3 CA1812, for actionScreen, PLayScreen, and StartScreen, because the code exists but is not implemented but will be in the next sprint.


General Notes:

-Team did not have a way of testing gamepad functionality so it is untested
-Menus are incomplete, they appear for winning, and on final death, but when you fully die, since we have no main menu to return too, the game exits before it displays. This will be fixed
-R still resets the scene
-P pauses the game
-Q still quits


-Arrow keys move mario and z jumps where holding x makes you sprint and tapping x while in fire mode shoots a fireball

-Once Mario dies the level resets

-It was not specified whether or not Mario should pass through enemies; we have implemented it so that mario does not interact with dead enemies (flattened goomba and shell)

-Hitting blocks from below is part collision-based and part velocity-based in our implementation (mario must be moving up to trigger the 'hitting block from below').
Since the set-and-fix-based mouse movement doesn't have well-defined veloicty, mario is not able to hit blocks from below when controller by mouse.

-If mario is in the fire state and picks up a 'big mushroom', he will remain in the fire state, since it is a stronger powerup.

-If Mario has 1 life or more after death, the game will be reset, or it will quit.