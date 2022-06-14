
 <h1>Picker 3D Zynga Clone via Unity</h1>

<br>
Click, Watch the video

<br>

[![Watch the video](http://img.youtube.com/vi/mWul0e3snUE/0.jpg)](https://youtu.be/mWul0e3snUE)

<div>
 <img marign=10px width=200px height=200px src="img/1.jpg" alt="Project logo"></a>
<br><br>

### Hello, I'm Turgay. I am studying computer engineering in Turkey. I will graduate in about a month. This project is my first step towards becoming a game developer.

 <br>

 ### I completed this project in 1 week for the technical interview of Level-UP Bootcamp. Therefore, it may contain visual differences and missing levels from the original.


</div>

<br>
<h2>Gameplay Screenshot</h2>
<br>

 <img width=auto height=400px src="img/2.jpg"></a>

 <h2>Game UI Screenshot</h2>
<br>
<img width=auto height=400px src="img/3.jpg"></a>
<br>
<br>

---
---

<br>

## :bulb: Universal Render Pipline

<br>

<img width=auto height=200px src="img/4.png"></a>

<br>

I created the project using the Universal Render Pipeline template.

<br>

## :video_game: New Input System

<br>

<img width=auto height=400px src="img/5.png"></a>

I used the new input system in the project. I just created one Action Map. The Actins in the game are Move and Pause. You can move the character using both the A and D keys and the direction arrows. You can also pause the game by pressing the ESC key.

<br>

## :movie_camera: Cinemachine

<br>

<img width=auto height=400px src="img/6.png"></a>

<br>

I used virtual camera in game.

<br>

## :running: DOTween (HOTween v2)

<br>

<img width=auto height=100px src="img/7.png"></a>

<br>

I used Dotween to manage animations in the game with code. This is how I managed the movements of the Helicopter and the Platform (the new platform that comes over the pit when you level up).

<br>

<img width=auto height=400px src="img/8.png"></a>

<br>


## :floppy_disk: Save System via PlayerPrefs

<br>

<img width=auto height=400px src="img/9.png"></a>

<br>

I used the PlayerPrefs method to save the game. When you exit the game or start again, you will continue from the level you left, but your score information will be reset. You can change it in your own way if you want.

<br>

## :computer: Scriptable Objects

<br>

<img width=auto height=200px src="img/10.png"></a>

<br>
When you log in to the game, you will see the character selection screen. I just sorted out the character variations by size and color. I used Scriptable Objects while doing this. You can create and add as many objects as you want from the Scriptable Objects array I created in the Inspector window.
<br>

<br>

<img width=auto height=400px src="img/11.png"></a>

<br>

## :8ball: Object Pooling

<br>

<img width=auto height=400px src="img/12.png"></a>

<br>

After completing the first 3 levels in the game, you go back to the beginning, but you continue to play as if the next level has come. When you go back to the beginning, instead of creating new objects, we deactivate and reactivate after using the old ones. This also benefits us in terms of performance. So I used Object Pooling.

<br>

