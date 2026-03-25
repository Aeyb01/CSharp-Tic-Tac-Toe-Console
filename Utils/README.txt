============================
UTILS/ — Shared Utilities
============================

PURPOSE
-------
This folder contains reusable scripts that do not belong
to any specific business logic.
They are used by multiple other folders.

SCRIPTS
-------
ExitPrompt.cs
  - Displays a "Write Exit to exit" prompt.
  - Redirects to MenuHandler when the player types "exit".
  - Used by Rules.cs and PostGame.cs.

ConsoleWinNotifier.cs
  - Displays result messages (win, loss, draw).
  - Separates UI display from game logic.
  - NotifyResult(): displays a message.
  - RestartTheGame(): displays the restart prompt.

Intro.cs
  - Displays the welcome message at launch.
  - Called once in Program.Main().
