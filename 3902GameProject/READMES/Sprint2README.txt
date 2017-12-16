Tennison Gray, Caleb Lehman, Sean Zhang, Hairuo Liu

General Notes:

-Non-movement controls are documented in-game on the right-hand side of the screen. WASD/Arrow keys are used to change mario's movement state.

-Mario State Changes:
    -Left/A and Right/D move mario through the states (left running <-> left walking <-> left idle <-> right idle <-> right walking <-> right running)
    -Up/W and Down/S move mario through the states (jumping <-> idle <-> crouching)
    -Y, U, I, and O make mario Small, Big, Fire, and Dead, respectively. When mario transitions between Small, Big, and Fire, he maintains other state properties,
    such as whether or not he is jumping, running, walking, etc.

-The game will only trigger commands on the first frame/update cycle that the key is pressed. That is, keys that continue to be held down do not have
their associated command re-executed.

-In the original game, 'crouching' small mario has the same sprite as idle mario. We utilized the "mario sliding down flagpole" sprite so that it was
visible when small mario was crouching.
