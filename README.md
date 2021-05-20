<html>
<body>
<p><b>Name:</b>Marcus Gleeson<br>
<b>Student Number:</b>D19124543<br>
<b>Class Group:</b>DT508
</P>
<h2> Project Information</h2>
<p>
This Project was built with unity 2019.4.1f1
</p>

<h1>Description of the project</h1>
<h2> There are 4 different scenes in the project.  The Title Scene,  The Cutscene, The Sample Scene and The End Scene. The cutscene starts with the Title Scene.</h2>

<p>
This space battle scene is based off the star wars game, star wars the old republic. Where the empire fights against the eternal throne.
In this space battle, we will have the perspective of both the empires and the eternal thrones fleet.
</p>

<h2>Sequences of Events/Story Summary:</h2>
<p><b>General Outline:</b>The story starts off with the Empire searching the unknown regions of space, for their Emperor, that has not been heard from, for decades.  As the Empires fleet moves through the unknown regions, they are ambushed by an unknown fleet of ships. In the end, the Empires fleet is destroyed.
<ol>
<li><b>The Title Scene: </b>The cut scene starts off with the Title Scene. This scene gives a general outline of the story before the start of the cut scene, such as why the Empire is going into the unknown regions of space. </li>

<li><b>The Cut Scene:</b> The cut scene plays a cut scene from the game, Star Wars The Old Republic. This shows the point of view of the Eternal Empire, and the Emperor himself, further expanding on the story. </li>

<li><b>The Sample Scene:</b> The sample scene takes up exactly after the cut scene, where we follow the Empires fleet as they make their way through the unknown regions of space. This is the cut scene that I built. </li>
<li><b>The End Scene:</b>When the cut scene is finished, it fades to black and moves on to the end scene. This just shows that the cut scene is finished. </li>
</ol>
</p>

<h1>Video Of Cut Scene</h1>

[![YouTube](http://img.youtube.com/vi/dRkpaaMF-CI/0.jpg)](https://www.youtube.com/watch?v=dRkpaaMF-CI) 

<h2>Detailed Technical Description:</h2>
<p><b>What behaviours you used:</b> The behaviours that I used in this assignment where, the Path Following behaviour, the Seek behaviour, the Flocking behaviour and Bezier Curve</p>
<p><b>If you use a FSM or behaviour tree or similar:</b> In this assignment, I did not use any FSM or Behaviour trees. </p>
<p><b>What graphical techniques you used - post processing, trail renderers etc:</b>In this assignment, I used the Light Weight Render Pipeline. I used several particle effects to try and recreate The Empires Fleet traveling through hyperspace at the start of the cut scene. I also used the Emission slider on the Empires Fleet engines colour material, to try and get the engines to glow to make them look like they were running.  I also created an invisibility material using the shader graph as I was going to have the Eternal Fleet move through space invisible. But In the end I decided that I would have the Eternal Fleet Jump out of hyperspace close to the Empires Fleet and start shooting, so I did not use the Invisibility material.  </p>
<p><b>What scripts you got from the course or from other sources. Include references:<b/> 
<ol>
<li> <b>The Scripts that I got from Class where:</b> The Path Following script and the boid script which includes the Seek Behaviour which I used.  </li>
<li> <b>The Scripts that I got from other sources where:</b> Introduction to AUDIO in Unity by Brackeys. The audio manger was used to organise all of the sound effects and music in the game under one point where at any time the audio could be accessed by the other scripts in the game. Link: https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=BrackeysBrackeysVerified  </li>
<li> <b>The Scripts that I got from other sources where:</b> OBJECT POOLING in Unity by Brackeys. This object pooling was used for the Empires Fleet Shooting and the Eternal Fleet Shooting. Link: https://www.youtube.com/watch?v=tdSmKaJvCoA&t=677s&ab_channel=Brackeys </li>
<li> <b>The Scripts that I got from other sources where:</b>Flocking Algorithm in Unity by  Board To Bits Games. This flocking algorithm was used for the Empires Fleet fighters, so that they could flock together in formation. Link to series of videos: https://www.youtube.com/watch?v=mjKINQigAE4&t=1s  </li>
</ol>
</p>

<h1>Modeled Models</h1>
<p>
<img src="/StoryBoard/7.png" style="width:128px;height:128px;"> 
This model is of the eternal fleet, which I modeled in the blender 3D software
</p>

<p>
<img src="/StoryBoard/8.png" style="width:128px;height:128px;"> 
This model is of the empires fighter, which I modeled in the blender 3D software
</p>


<h1>Imported Models</h1>
<p>
<img src="/StoryBoard/6.PNG" style="width:128px;height:128px;"> 
The Harrrower Class Dreadnaught" was modeled by Kalashnikov 3D and is licensed under Creative Commons Attribution-NonCommercial (http://creativecommons.org/licenses/by-nc/4.0/). 
The model can be found on his page here: https://sketchfab.com/kalashnikov</p>

<p>
<img src="/StoryBoard/9.PNG" style="width:128px;height:128px;"> 
DRK-1 Probe Droid by nick.dob is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
The model can be found on his page here: (https://skfb.ly/KPLM) </p>

<h2> Parts of the assignment that I like</h2>
<p>One thing that I like about the assignment is that when one of the Empires Fleet gets destroyed, a copy of that ship gets spawned in its place. But the copy is a broken up version of the ship with a script that randomly moves the parts of the ship in random directions. This makes it look like parts of the broken ship are randomly moving through space. This adds a nice touch to the cut scene. As more of the Empires Fleet gets destroyed, the more that it looks like a ship graveyard. </p>
<p>Another part of the assignment that I like is how I was able to get the audio from the game Start Wars the Old Republic to fit in with the cut scene. I think this enhances the overall quality of the cut scene, and helps tell the story of the cut scene, that’s based off the game. </p>
<p>The last part of the assignment that I like is the Bezier curve, which I got working. This added a whole different way that the cut scene could be viewed or certain assets. At one point in the cut scene, I had linked several Bezier curves together, and I was able to get the camera to follow these curves while looking at the curve. This made the camera look like it was following a track, as it moved through the cut scene moving in and out of the Empires Fleet during the Battle. This in my opinion better portrayed the cut scene instead of static camera's in the scene. </p>

<h1>Story-Boards</h1>
<p>
<ol>
  <li><b>Story Board 1:</b> In the first story board we follow the empires fleet as they come out of hyperspace into the unkown regines of space looking for their emperor, who has not been seen or heard from for some time. 
			    The camera will follow the empire fleet from behind as they exit hyperspace into the unknown regions.
			    After the ships have exited hyperspace, the camera will pan around the lead ship as they move to their waypoints with the path following behaviour.</li>
	<img src="/StoryBoard/1.png" style="width:128px;height:128px;">

 <li><b>Story Board 2:</b> In the second story board, The camera will switch to the other camera that will be following the eternal thrones fleet as they jump out of hyperspace in attack formation, while being invisable. 
			   The Eternal Fleet will start to move closer towards the empires ships using the offset pursue behaviour, while still being invisable. </li>
	<img src="/StoryBoard/2.png" style="width:128px;height:128px;">

 <li><b>Story Board 3:</b> In the third story board, The camera will move towards the guns of the eteranl fleet as they move closer towards the empires fleet. We will watch the eternal fleet ready its guns to fire upon the empires fleet.
			   Just before the eternal fleet fires its guns, the eternal fleet will stop being invisable and we will watch as the eternal fleet fire, volleys of rounds at the empires fleet.</li>
	<img src="/StoryBoard/3.png" style="width:128px;height:128px;">

<li><b>Story Board 4:</b> In the fourth story board, the camera will jump to gun batteries of the empires fleet as the empires returns fire, to engage the eternal fleet. 
			    </li>

 <li><b>Story Board 5:</b> In the fifth story board, the camera will move to the main hanger bay of the empires fleet as the empires fighters exit the hanger, to engage the eternal fleet. 
			   As the camera is following the formation of the fighters which will use the seek behaviour and offset pursue behaviour. We will get a view of the empires fleet taking and deflection the rounds of fire from the eternal fleet.
			    </li>
	<img src="/StoryBoard/4.png" style="width:128px;height:128px;">

 <li><b>Story Board 6:</b> In the sixth story board, the empires fighters will get destroyed as they try to engage the eternal fleet. The camera will switch to empires fleet, as in the last moments of desperation, the lead empires ship will turn and ram the eternal fleet hoping to cause massive damage upon them. 
			   We will follow that empires ship from a distance as it rams the eternal fleet using the seek behaviour.The last scene that we will be left with, is a scene of the last few empires ships being destroyed by the eternal fleet. 
			   We will view this from a distance so that we can view the eternal fleet firing upon the empires fleet, and view the empires fleet being destroyed.</li>
	<img src="/StoryBoard/5.png" style="width:128px;height:128px;">

  
</ol>
</P>


<h1>References</h1>
<p>
<h2>Credits</h2>
<b>Star wars theme: https://www.youtube.com/watch?v=tGsKzZtRwxw&t=28s&ab_channel=Greg <br>
<b>Star wars the old republic cutscene: https://www.youtube.com/watch?v=Tu7lavtmPmA&t=408s&ab_channel=Tamiil%27sAdventures <br>
<b>Star Wars - Tenebrae, The Dark Lord of Many Faces Theme [Extended]: https://www.youtube.com/watch?v=CMZ6g4rESNY&t=119s&ab_channel=TheAdmiral <br>
<br TIE fighter explode" Sound: https://www.soundboard.com/sb/sound/963764</br>
<br>X-Wing explode" Sound: https://www.soundboard.com/sb/sound/963774</br>
<br>Battle alarm" Sound: https://www.soundboard.com/sb/sound/963756</br>
<br>Are we blind? Deploy the Garrison!: https://www.youtube.com/watch?v=2PjCClrO5SA&ab_channel=StarWarsClips</br>
<br></br>
</p>




</body>
</html>
