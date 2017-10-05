# RealPool AR Game - Final Project for 3D UI and Augmented Reality

a) Team name: Team Rocket
b) Aalhad Patankar (ap3526), Anuraag Advani ( ada2161), Min Fan (mf3084), Tianyu
Yang(ty2345)
c) 5/4/2017
d) Unity 5.51
e) Iphone 7 running iOS 10 (viewing device), MotoX Pure Android 6 (controller
device)
f) Real Pool
g) Directory overview: We have two directories, the gamescene and the tracking scene.
The gamescene has the following items:
1) The camera manager is used for changing to the right camera in the
gamescene.
2) Image target contains the ball the cue and all the other items related to it.
3) AR camera is the camera.
4) Canvas is used for UI elements like scoreboard.
5) Wand is the image target used to interact with the UI.
6) MiniMap is the map in the upper corner.
7) Networking object is for managing the network
8) Toolbar is an image target with virtual buttons for ghost ball, mini map and
help.
In the tracking scene we have the networking object which manages the network
with the main phone.
h) There are two phones: one is the controller and one is the main phone. You
launch the app on both phones, and enter the public ip address of the common wifi being used by both phones on the controller phone where it says “localhost,” and press the “start client” button to establish the connection between the two phones.
i) N/A
j) https://www.youtube.com/watch?v=dA0EWgxua5k&feature=youtu.be
k) For the ground target, use the Tarmac target. For the wand, use the Lego
image target and for the toolbar, use the Acid image target. To deploy, launch the application on both phones. On the controller phone, enter the public IP address of the wifi connection both phones are using, and click on the “start client” button to establish connection. Attach the viewing device to the Google Cardboard and begin playing!
l) N/a
m) One bug is that when we switch from rotation mode to hitting mode, the hit is sometimes performed prematurely. We have to fine tune the sensitivity of the tilting of the controller phone in relation to affecting the rotation and hitting of the cue stick.
n) https://www.assetstore.unity3d.com/en/#!/content/24491

The code was not tracked/versioned with Git.
