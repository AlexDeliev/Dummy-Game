# Dummy-Game

## Overview
Welcome to **Cut It**, a thrilling 2D vertical-scrolling arcade game. In this game, you control a saw as it climbs an endlessly growing tree. The goal is to skillfully avoid healthy branches and saw through dry branches, scoring points while the difficulty steadily increases. The combination of hand-drawn art and engaging mechanics makes TreeSaw both challenging and visually captivating.

---

## Game Mechanics

### Core Gameplay
- **Saw Movement**:
  - The saw follows the camera vertically as the tree grows.
  - Players can toggle the saw between the left and right sides of the tree by clicking (or tapping) the screen.
  - A dynamic flipping animation ensures smooth transitions when switching sides.

- **Branch Interaction**:
  - Branches are randomly generated along the tree, with healthy branches on one side and dry branches on the other.
  - **Dry Branches**:
    - Cutting through a dry branch awards 1 point.
    - A satisfying sound effect plays when successfully cut.
    - The branch is destroyed after being cut.
  - **Healthy Branches**:
    - Touching a healthy branch ends the game immediately.
    - A distinct sound effect warns the player of the mistake.

- **Tree Growth**:
  - The tree dynamically grows upward, spawning new segments and branches as the camera progresses.
  - Older segments and branches are automatically removed when out of view, ensuring optimal performance.

---

## Difficulty Progression
- **Camera Speed**:
  - The camera scrolls upward at a constant speed, which increases every 10 seconds to add more challenge.
  - A dedicated `DifficultyManager` script handles this progression by adjusting the camera's movement speed.

- **Branch Spawning**:
  - New branches are spawned on every third tree segment.
  - The placement of healthy and dry branches alternates randomly, requiring quick reflexes and adaptability from the player.

---

## Scripts Overview

### **Branch.cs**
- Manages branch behavior upon interaction with the saw.
- Differentiates between healthy and dry branches and triggers the corresponding effects (point scoring or Game Over).
- Plays appropriate sound effects for each type of branch.

### **TreeGrower.cs**
- Continuously spawns new tree segments and adds them to the game world as the camera moves upward.
- Responsible for removing old tree segments to keep the scene optimized.

### **BranchSpawner.cs**
- Handles the spawning of branches on newly created tree segments.
- Randomly determines the health of branches and positions them on either side of the tree.
- Ensures branches are flipped properly to match their side.

### **SawMovement.cs**
- Controls the movement of the saw.
- Allows toggling between the left and right sides of the tree with smooth animations.
- Ensures the saw stays in sync with the camera's vertical movement.

### **DifficultyManager.cs**
- Periodically increases the game's difficulty by raising the camera's movement speed.
- Creates a sense of escalating tension as the game progresses.

---

## Art and Audio
- **Visual Style**: The game features pixel art graphics to create a rustic, natural atmosphere.
- **Audio**: The sound effects provide immediate feedback to the player:
  - Cutting a dry branch triggers a rewarding sound.
  - Touching a healthy branch plays a warning sound to emphasize the mistake.

---

## How to Play
1. Launch the game.
2. Control the saw using clicks or taps to toggle between the left and right sides of the tree.
3. Cut through dry branches to score points.
4. Avoid healthy branches to keep the game going.
5. Survive as long as possible while the difficulty increases.

---

## Installation
1. Download the game from [your itch.io link].
2. Extract the game files to your desired folder.
3. Run the executable file to start playing.

---

## Credits
- **Game Design & Development**: Alex 
- **Art**: My suffering art
- **Engine**: Unity

---

## Future Plans
- Adding power-ups to enhance gameplay variety.
- Introducing leaderboards for competitive play.
- Creating additional tree environments for aesthetic diversity.


