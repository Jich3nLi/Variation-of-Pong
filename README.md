# Variation-of-Pong
Introduction:

This project involved developing a two-player paddle-and-ball game using the Unity game engine. The primary goal was to create an interactive game that combines physics-based movement, player input, and a scoring system. Throughout the development process, I focused on implementing core gameplay mechanics while gradually adding user interface elements and rule-based systems to enhance player experience.

Game Design and Implementation:

The game was designed with two paddles controlled by separate keyboard inputs and a ball that launches with a randomized initial force. Players interact with the ball through collisions, and the ball’s direction changes based on the surface it hits. A system was implemented to track which paddle last hit the ball in order to determine scoring and penalties.

To increase strategic depth, I introduced a paddle speed penalty mechanic. When a player hits the ball consecutively or triggers a scoring condition, that player’s paddle speed is reduced, while the opposing paddle regains normal speed. This encourages players to vary their playstyle and avoid repeated mistakes. Paddle speed therefore becomes part of the game’s challenge rather than remaining constant.

A centralized GameManager script controls the overall game state, including player lives, round resets, and win conditions. Each player is given three lives, which are visually represented using heart icons in the user interface. When a player loses a life, one heart disappears. When a player’s lives reach zero, the game enters a game-over state and announces the winner.

In addition, I designed reset and end-game UI elements that allow players to restart the game or exit after a match concludes. These UI features improve usability and provide clear feedback about the game’s progression and outcome.

Challenges Encountered:

After implementing the main game mechanics and user interface, one of the major challenges was the limited time available for playtesting and refining gameplay. Although the core features were functional, I found that the game still required further adjustments to improve balance and player experience.

Through brief testing, I identified several key issues that need to be addressed. First, the game currently lacks a clear visual or conceptual theme. A possible improvement would be to redesign the game around a recognizable theme such as squash or ping pong, which would enhance immersion and make the game more visually coherent.

Second, the game is currently too difficult and fast-paced. The ball moves at a high speed, and players have very little time to react, which can make gameplay frustrating rather than enjoyable. This could be improved by slowing down the ball, adding mass to the ball’s Rigidbody to create more realistic motion, and limiting the movement range of the paddles so that players are not required to cover an overly large area.

These challenges highlighted the importance of playtesting as part of the game development process. Implementing features alone is not sufficient; evaluating how the game feels to play is equally important. Time constraints prevented extensive iteration, but the issues identified provide a clear direction for future improvements.

Reflection and Learning Outcomes:

This project helped me better understand how to structure a game using multiple interacting scripts and how to manage game state through a central controller. I learned how gameplay mechanics such as speed penalties and life systems can significantly affect player strategy and experience.

More importantly, I realized that game development is an iterative process that depends heavily on testing and refinement. Even when a game is technically complete, adjustments to difficulty, pacing, and theme are necessary to create a more polished and engaging product. This project strengthened my understanding of object-oriented programming, physics-based interaction, and user interface integration within Unity.
