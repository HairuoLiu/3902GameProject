Tennison Gray, Caleb Lehman, Sean Zhang, Hairuo Liu

Notes on Specific Code Analysis Warnings:

-We suppressed a "CA1823: Avoid unused private fields" warning by GlobalSuppressions.cs.
-We suppressed "CA1030: Use events where appropriate" warning


General Notes:

-Team did not have a way of testing gamepad functionality so it is untested

-R still resets the scene, and M toggles the mouse control on and off

-Behavior after mario died was not specified in the sprint discription, so it wasn't worried about specifically (i.e., mario still moves and interacts once dead)

-It was not specified whether or not Mario should pass through enemies; we have implemented it so that mario does not interact with dead enemies (flattened goomba and shell)

-Hitting blocks from below is part collision-based and part velocity-based in our implementation (mario must be moving up to trigger the 'hitting block from below').
Since the set-and-fix-based mouse movement doesn't have well-defined veloicty, mario is not able to hit blocks from below when controller by mouse.

-If mario is in the fire state and picks up a 'big mushroom', he will remain in the fire state, since it is a stronger powerup.