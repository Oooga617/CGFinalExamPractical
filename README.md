# CGFinalExamPractical

# Hologram
The first effect implemented was this hologram shader, where it combines transparency, rim lighting, and scrolling sine waves to convey that of a projected, glowing hologram. How it works is that first a texture is sampled as the base texture, so that the other effects can be overlayed on top of it:

<img width="1276" height="568" alt="image" src="https://github.com/user-attachments/assets/9d2c5f98-e055-4436-8b10-d0181cae2c38" />

From there the Fresnel effect was done using a prebuilt in Fresnel node, but how it works is that the normalized vectors of the view direction and the normals in world space are dot producted to create a light distribution. Said distribution is then subtracting 1 so that the light distribution goes from the middle of the object to the edges, and then it is saturated so that the light values are between 0 and 1 for lighting calculations, along with then being ran through a power node to control the amount of rim lighting is on the object, and then having be multiplied with the base color property and added in the final output:

<img width="1252" height="553" alt="image" src="https://github.com/user-attachments/assets/1088b983-bb03-4b9b-86c2-c9b50375b15b" />

(Note that the Fresnel effect node does a lot of the fresnel light calculations for us for saving time).

The sine wave effect was calculated from using the y-axis value of the UV multiplied with the Line Frequency property (to control how many sinewave lines appaear) and added to the product of Line Speed and the Time node so that the sine waves can scroll by on the Y axis. The sum is plugged into the sine node to actually make the sine waves appear, and it is ran through the step node with a float value of 0.5 so that the sine waves themselves have no gradients which will not look good, and then it is multiplied with the final color and added onto the final output of the shader effect:

<img width="1572" height="701" alt="image" src="https://github.com/user-attachments/assets/fb5a8ba0-0dc8-4a65-bdd5-a3d1b7241d5f" />

I used the hologram effect for the pacman game replica for the power up balls, where once Pacman touches them they can be invincible for a few seconds and be able to eat the ghosts under a limited amount of time. To emphasize the importance of those power ups and making them stand out, the hologram effect is used on them as the glowing and moving lights and waves will grab the player's attention and add a dynamic element in the scene:

<img width="313" height="262" alt="image" src="https://github.com/user-attachments/assets/a650b7da-3b47-4ddc-a8e2-801e28d9849c" />

<img width="317" height="152" alt="image" src="https://github.com/user-attachments/assets/8140149f-8512-43f8-b628-d301c1484c21" />

# Scrolling Textures, Fresnel and attempt of Flat Shading
The next effects I tried to use are Scrolling textures, rim lighting again and Flat shading. I have already covered how Fresnel works, but as for scrolling textures it samples a texture (with the sampler set to have the texture repeat so that no weird issues when offseting/animating the scrolling) and then in the UV port of the texture sampler it is connected to a Tiling and Offset node. That node with the offset port is how the textures will be scrolled, and a product of the 2D vector property to dictate the direction and speed of the scrolling along with the time node to control the scrolling:

<img width="1016" height="392" alt="image" src="https://github.com/user-attachments/assets/bd466709-ed52-44ae-983a-82887c7cab35" />

This was used for the ghosts, add I quickly made a texture in Substance Painter 3D to make it scroll to make it look like an etheral/ghostly presense was there coupled with the rim lighting being bright and making the shader transparent to add a level of transparency given that ghosts are (conventionally anyways) see through. 

<img width="1323" height="767" alt="image" src="https://github.com/user-attachments/assets/c57d308d-4d8a-45b7-a2d4-330db5a07b0e" />

<img width="302" height="246" alt="image" src="https://github.com/user-attachments/assets/bd11379e-a7ff-4639-bd48-29338a477b6b" />

<img width="418" height="268" alt="image" src="https://github.com/user-attachments/assets/713a0982-ba65-47f2-9d1d-2b2450e1e8ab" />

<img width="192" height="173" alt="image" src="https://github.com/user-attachments/assets/1cef5970-1f9a-401b-a176-303abbc74c58" />

<img width="195" height="112" alt="image" src="https://github.com/user-attachments/assets/02fed964-2ef2-4814-a8b3-9bc5348ce200" />


However, because Pacman is a retro game I wanted to give them and Pacman later a low-poly appearence with the use of Flat shading.
With that said, I had issues implementing it. How its meant to work is that the normals are recalculated on the X and Y axises with the use of the DDX and DDY nodes, which they take the difference of pixels next to them and above them for the recalculations, and they are put through a cross product to make the new modified normals. From there they are dot producted with the normalized main light direction vectors and saturated, and then multiplied with the base color of the object:


<img width="1162" height="650" alt="image" src="https://github.com/user-attachments/assets/647d6355-f4c2-4598-8585-3b61e8b0b73b" />

