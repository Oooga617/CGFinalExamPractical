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

#
