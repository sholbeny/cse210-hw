/*
Creativity and Exceeding Requirements:

I added a level system where the player gains a new level for every
500 points earned. When the player reaches a new level, the program
displays a special level-up message.

I also added a badge system. Players can earn badges for recording
their first goal, earning 1,000 points, completing five goals, and
finishing a checklist goal. The player can view earned badges from
the main menu.

The program saves and loads the player's badges, score, completed
events, and goals so progress is not lost.

I also added input validation to help prevent the program from
crashing when invalid menu choices, goal numbers, or point values
are entered.
*/

GoalManager goalManager = new GoalManager();
goalManager.Start();