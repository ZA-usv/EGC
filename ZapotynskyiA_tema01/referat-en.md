# **OpenGL vs Vulkan vs DirectX**

## Table of Contents
* [OpenGL vs Vulkan vs Directx](#OpenGL%20vs%20Vulkan%20vs%20DirectX)
  * [Vulkan](#Vulkan)
  * [DirectX](#DirectX)
  * [OpenGL](#OpenGL)
* [Answer Question](#Answer%20Question)

## OpenGL vs Vulkan vs DirectX
### Vulkan
It was designed to provide a more efficient, lower-level alternative to OpenGL, 
with the goal of minimizing the number of API calls required to draw a frame.    
Another advantage of Vulkan is its support for multiple threads, which allows applications to make use of multiple CPU cores to parallelize their workload. 
This can result in a significant performance boost compared to single-threaded APIs like OpenGL.

### DirectX
DirectX is a proprietary graphics API developed by Microsoft for use on the Windows operating system.

### OpenGL
One of the main advantages of OpenGL is its portability, as it is supported on a wide range of platforms, including Windows, Mac, and Linux.
However, OpenGL is a higher-level API compared to Vulkan, which means it requires more API calls to draw a frame. This can result in less efficient performance, especially on modern hardware with powerful graphics processors.

## Answer Question 
**Question:** Cum explicați modelul de automat cu stări finite al OpenGL și cum
afectează acest lucru procesul de randare al scenei 3D de către
biblioteca grafică/API?

**Answer:** At any given time, OpenGL has a specific "state," which includes things like current colors, textures, or transformations. The developer interacts with OpenGL by issuing instructions (like drawing shapes or transforming objects), which causes the state to change. These state changes occur in discrete steps), leading to the final rendered 3D scene.

In this way, each action in OpenGL—such as drawing or applying a transformation—modifies the system's state. The final 3D scene is the result of the cumulative effect of all these actions, starting from the initial default state when the system is first initialized.




