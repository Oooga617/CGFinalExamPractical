# CGFinalExamPractical

# Hologram
The first effect implemented was this hologram shader, where it combines transparency, rim lighting, and scrolling sine waves to convey that of a projected, glowing hologram. How it works is that first a texture is sampled as the base texture, so that the other effects can be overlayed on top of it:

<img width="1276" height="568" alt="image" src="https://github.com/user-attachments/assets/9d2c5f98-e055-4436-8b10-d0181cae2c38" />

From there the Fresnel effect was done using a prebuilt in Fresnel node, but how it works is that the normalized vectors of the view direction and the normals in world space are dot producted to create a light distribution. Said distribution is then subtracting 1 so that the light distribution goes from the middle of the object to the edges, and then it is saturated so that the light values are between 0 and 1 for lighting calculations, along with then being ran through a power node to control the amount of rim lighting is on the object, and then having be multiplied with the base color property and added in the final output:

basically what is happening with the light distriubtion with the view direction, normals, and substracting one:

<img width="712" height="285" alt="image" src="https://github.com/user-attachments/assets/81604607-34be-4247-af44-6130369199f2" />

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

<img width="838" height="758" alt="image" src="https://github.com/user-attachments/assets/d2291d66-3e42-46ff-bf35-47c3bf89bc0c" />

This is what I wanted for the balls representing the ghosts:

<img width="417" height="138" alt="image" src="https://github.com/user-attachments/assets/fc7179b1-5564-4c36-80d1-20ac1c02303a" />

What ends up happening is that the results for the ghosts look like this:

<img width="416" height="312" alt="image" src="https://github.com/user-attachments/assets/72b1ec22-e207-4b07-b9b5-19e7353577a2" />

I tried looking into it, but I couldnt figure out how to work around it and (as of writing) really needed to move on
<img width="1162" height="650" alt="image" src="https://github.com/user-attachments/assets/647d6355-f4c2-4598-8585-3b61e8b0b73b" />

I even downloaded the shaderlab script for flat shading and noticed there were bugs when I tried to apply it onto Pacman:

<img width="1406" height="567" alt="image" src="https://github.com/user-attachments/assets/b4d8ef0c-8ce4-4909-b213-d3a67d1a941d" />

<img width="788" height="561" alt="image" src="https://github.com/user-attachments/assets/f640f28e-f09b-4e46-9b17-d769ae193fb9" />

# Transparency
The third effect used in this is transparency, which what it does is that for a transparent texture, it is isolated from the background because of the 4th channel which is the alpha channel. There is not much to explain other than the texture is sampled in the shader graph code, and that the final result is plugged into the final color port of the fragment shader along with the alpha channel of the sampler is plugged into the alpha port of the fragment shader:

<img width="1018" height="610" alt="image" src="https://github.com/user-attachments/assets/3a2bbfb9-45de-4a73-acf3-0503d1e91a20" />

The shader settings though need to be set to allow alpha clipping though, along with the transparent texture needing to be set as a transparent texture in order for it work:

<img width="505" height="506" alt="image" src="https://github.com/user-attachments/assets/10dd0d6e-cd69-4fc2-b355-cbfe44dfd0b3" />

<img width="1063" height="573" alt="image" src="https://github.com/user-attachments/assets/7e1a889f-8b11-49c0-bbc2-53a1a51db903" />

I used this to make a cherry sprite pick up, where in the actual Pac-man game the player can go over to touch fruits to earn more points. I specifically used this because time constraints (I do not want to spend 30 minutes modeling a cherry and trying to use flat shading when I have issues implementing it as previously stated), but also that I quickly made a 2D sprite of the cherry in aseprite, and that to convey more of a retro theme for the game I wanted to use a 2D, pixelated sprite just for that:

<img width="287" height="266" alt="image" src="https://github.com/user-attachments/assets/37272833-b9b5-4222-8ce8-01aec1a0f6b6" />

(Its also appearing on a cube just so that Pacman as an easier time colliding with it compared if it was just a flat, quad or plane). 

# Metallic and bump mapping attempt
Finally, I tried using both bump mapping and a metallic shine for the walls of the maze, and this was done to add a bit more detail than just amking them a flat, beveled wall. Admitedly I used the shader graph code for the bump mapping on canvas, but to explain how it works: two textures are sampled, the base texture and a normal map. The normal map has encoded data for modifying the normals of the mesh within the RBG values of the texture, and on the x and y axises from the r and g ports of the samplier they are multiplied with a property that dictates the bump amount to control how much of it can be applied. From there those x and y values along with the z value from the b port are compiled into a 3D vector for lighting calculations, but first it needs to be transformed using the transform node to convert the normals and tangents into world space, and then get normalized so it can be dot producted with the normnalized main light direction. The result is then saturated, multiplied by negative 1, and then multiplied with the sampeld texture to apply the bump mapping on:

<img width="1203" height="570" alt="image" src="https://github.com/user-attachments/assets/6e36b658-bab2-4259-b95b-1aa724435981" />

<img width="1140" height="752" alt="image" src="https://github.com/user-attachments/assets/134c4d40-77a9-4eab-aa9f-ce3683c25409" />

Now admitedly the details of the walls are subtle, so here are the textures for the walls I quickly made in Substance Painter 3D to give an idea on how the walls are supposed to look:

<img width="513" height="512" alt="image" src="https://github.com/user-attachments/assets/4e65b053-8870-4908-8a20-e89604e2c0ce" />

<img width="508" height="507" alt="image" src="https://github.com/user-attachments/assets/6c59fbe3-d0f2-4fef-889c-b8fcd8507284" />

I used this for the walls, as in Pacman they do not look that interesting at all. There are just bevelled, dark blue outlines for where the barriers of the maze are positioned at, and I wanted to enhance the detail of the sense by trying to interpret them as metallic because I thought that would fit better for what was supposed to be retro, I also loosely think of things like arcade cabinents or smooth surfaces when I think of retro games, so that thought process translated into the textures.

Now I tried to further convey that these walls are meant to be metallic with the attempt of a metallic shine effect, and how that worked was that 
