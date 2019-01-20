# catmas
Dev platform: Unity 2018.2.14f, Visual Studio 2017 Community version 15.9.3, Windows 10. Scripting Runtime Version .NET4.x Equivalent, API compatibility Lvel .NET Standard 2.0; 
Targest platform: WebGL (Referenz resolution: 1024 * 768)

The catmas game is a simple 2D game inspired by the 10 min challange to practice 2D game development. 
The cat has to open presents in the right color order. The order is shown on the left bottom. 
The cat character is moved by the keys arrow left and right and can be turned by the keys arrow up/down. 
To open the presents sit in front of the present and wait. First the cat cat is excited (moving up/down) in front of the present.
If it's the right present the cat destroys the present. 

Shuffle List
https://stackoverflow.com/questions/273313/randomize-a-listt 
https://jamesshinevar.com/2017/05/28/shuffle-a-list-c-fisher-yates-shuffle/

Sound: Cat miow, lick, purr : 
+ https://freesound.org/people/Trautwein/sounds/260881/ (purr)
+ https://freesound.org/people/Hamface/sounds/98671/ (miow)
+ https://freesound.org/people/Hamface/sounds/98672/ (lick)

Open issues: 
+ add particles to open presents
+ adapt sound
+ adapt animations
+ add timer
+ add highscore
+ adapt game flow: e.g., additional timer, randomly changing colors during game, falling down staff etc. 

Topics Covered:
+ Singelton pattern
+ Using lists
+ Scenemanagement
+ Audio: at least 2 different AudioSources for playOneshot respectively play
+ Change sprite properties from script
+ Using TextMeshPro and access compontent from script to change text
+ Using Horizontal axis as input, using arrow keys up and down as input
