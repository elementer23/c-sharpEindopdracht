
# Binding of Zelda

Startdocument of **Victor Peters, Nick Buisman** and **Robin van Dijk**.

## Game Description

The game we are making is called the Binding of Zelda. The game will be a dungeon crawler inspired by the original Legend of Zelda and games like the Binding of Isaac and Enter the Gungeon. The game will have four areas. The levels within the areas are procedurally generated. Each area will have different enemies based on the overall theme of the area (a forest area will have animal-inspired enemies and a death-inspired area will have skeleton-based enemies).

The engines we will be using for the development of this game is **monogame** and the UI Framework we will be using is .NET Maui.
Monogame: https://www.monogame.net/.
Maui: https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui.

## Planning

Week 1: Making a startdocument.

Week 2 + 3: Class diagram and learning how to use the library and engine.

Week 4 - 7: Programming and testing the game.

Week 8: Testing the full game and preparing a presentation.

Week 9: Presenting our game to the teachers.

## Screens
Below is a list of screens that will be in the game.

## Start menu
![mainmenu](screens/mainmenu.jpeg)

## Level select
![LevelSelect](screens/LevelSelect.png)

## Options menu
![optionsmenu](screens/optionsmenu.png)

## The first level
![beginningarea](screens/beginningarea.jpeg)

## The second level
![deathlands](screens/deathlands.jpeg)

## The third level
![scorchedregion](screens/scorchedregion.jpeg)

## The fourth level
![mountdoom](screens/mountdoom.jpeg)

## Test cases:

Player interactive cases:

|Input| Expected result | Actual result |
|--|--|--|
| Input `w` | Player character moves forward | ... |
| Input `a` | Player character moves left | ... |
| Input `s` | Player character moves backwards | ... |
| Input `d` | Player character moves right | ... |
| Player walks against wall | Player walks into the wall | ... |
| Input `spacebar` | Player shoots projectile | ... |
| Player is hit with projectile | Player loses health | ... |
| Player touches item | Item is picked up by player | ... |

Level cases:

| Input | Expected result | Actual result |
|--|--|--|
| Level is opened | User can see levels on a map | ... |
| User switches between levels | Level selected is updated | ... |
| User chooses level | Loading screen is shown | ... |
| User is past loading screen | Level is loaded in | ... |

Enemy cases:

| Input | Expected result | Actual result |
|--|--|--|
| Enemy hits the player | Player takes damage | ... |
| Enemy is hit | Enemy is despawned | ... | 
| Enemy walks against wall | Enemy walks into wall | ... |
