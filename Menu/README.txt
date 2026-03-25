============================
MENU/ — Navigation
============================

PURPOSE
-------
This folder handles all navigation outside the game session:
main menu, rules, leaderboard, save, and post-game.

SCRIPTS
-------
Menu.cs
  - Displays the main menu options in color.
  - Does not read any input — display only.

MenuChoice.cs
  - Reads and validates the player's menu choice.
  - Returns an Options enum (Play, Leaderboard, Rules, Save, Exit).

MenuHandler.cs
  - Menu assembler: calls Menu.DisplayMenu() then MenuChoice.Choice().
  - Single entry point for displaying and navigating the menu.

EnterChoice.cs
  - Switch on Options — redirects to the correct script based on choice.
  - Play        → Launch.Start()
  - Leaderboard → LeaderBoardMenu.ShowLeaderBoard()
  - Rules       → Rules.ShowRules()
  - Save        → SaveMenu.ShowSaveMenu()
  - Exit        → exits the program

Rules.cs
  - Displays the game rules.
  - Calls ExitPrompt at the end to return to the menu.

LeaderBoardMenu.cs
  - Displays current scores.
  - Offers to reset the leaderboard with confirmation.

SaveMenu.cs
  - Prompts the player to save the game.
  - Redirects to SaveGame.Save() if confirmed.

PostGame.cs
  - Displayed after a game ends.
  - Options: Replay / Return / Exit.


ASCII FLOW
----------

Program.Main()
     |
     v
MenuHandler.MenuController()
     |
     +--> Menu.DisplayMenu()        (show options)
     +--> MenuChoice.Choice()       (read choice)
     |
     v
EnterChoice.Entering()
     |
     +--> [Play]        --> Launch.Start()
     +--> [Leaderboard] --> LeaderBoardMenu.ShowLeaderBoard()
     +--> [Rules]       --> Rules.ShowRules()
     +--> [Save]        --> SaveMenu.ShowSaveMenu()
     +--> [Exit]        --> end of program
