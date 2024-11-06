# haunted-rapids
## Haunted Rapids Overview:
Haunted Rapids is a survival-based, top-down endless runner where the player navigates a boat down a haunted river. The goal is to avoid obstacles, collect fuel and health power-ups, and survive as long as possible while being chased by a ghostly entity. If the boat’s fuel depletes, or if it sustains too much damage, the game ends. The ghost draws closer if the fuel runs out, and the player must navigate to keep the boat going and avoid the approaching entity.

## Game Mechanics

### Controls
- Movement: Use the left and right arrow keys (or 'A' and 'D' keys) to steer the boat along the river.
- Power-Up Activation: Fuel and health power-ups are activated automatically upon collection.
  
### Game Objectives
- Survival: The primary objective is to survive as long as possible, dodging obstacles and collecting power-ups to maintain fuel and health levels.

### Power-Ups
- Fuel Pickups: Represented by a gasoline icon, these increase the boat’s fuel level, allowing the player to extend gameplay.
- Health Pickups: Represented by a green potion icon, these restore the boat’s health, giving the player more resilience against obstacle collisions.

### Obstacles
- Negative Obstacles: Various objects (like skeletons and other spooky items) appear randomly along the river. Colliding with these obstacles reduces the boat’s health.

### Game Over Conditions
- Out of Fuel: If the boat runs out of fuel, the ghostly entity will quickly catch up, resulting in game over.
- Health Depletion: Colliding with obstacles will reduce the boat's health. If health reaches zero, the game ends.
- Ghost Chase: When the boat’s fuel is depleted, the ghost starts chasing at an increased speed. If it catches the boat, the game ends.

### Scoring and High Score Tracking
- Time Survived: The game tracks the time the player survives, which serves as the score.
- High Score: The highest survival time is saved between sessions, allowing players to compete against their best time.

## Key Features
- Endless Scrolling Background: The river background scrolls continuously to simulate a moving river.
- Obstacle Spawner: Obstacles are spawned randomly along the river, ensuring dynamic and unpredictable gameplay.
- Audio: Sound effects enhance the gameplay experience, including spooky sounds for the ghost’s approach and sounds for collecting power-ups.
- UI: Sliders display fuel and health levels, with real-time text updates showing the remaining percentage.

## Deviations from Original Proposal
- Ghost Chase Mechanic: Originally proposed as a passive background element, the ghost chase mechanic became an active gameplay element that accelerates if fuel runs out, adding urgency to the survival aspect.
- Power-Up Behavior: Instead of allowing players to manually activate power-ups, fuel and health are automatically applied upon collection for a smoother gameplay experience.
- Scoring System: The high score tracking was enhanced to store the best survival time between sessions, encouraging replayability.

## How to Play
- Start the game from the main menu by clicking “Play.”
- Steer the boat left and right to dodge obstacles and collect power-ups.
- Keep an eye on the fuel and health bars; collecting fuel keeps the boat moving, while health keeps it from breaking down.
- Survive as long as possible! Once fuel runs out, the ghost entity will begin its chase. When health depletes or the ghost catches up, the game ends.
- After a game-over, review your survival time and high score on the end screen.
