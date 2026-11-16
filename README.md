### Profiler without pooling:
![](https://github.com/GamTam/Object-Pooling-Test/blob/main/Images/No%20Pooling.png)

### Profiler with pooling:
![](https://github.com/GamTam/Object-Pooling-Test/blob/main/Images/With%20Pooling.png)

<br>

When run, the project will spawn in as many cubes with rigidbodies as it is allowed to and simulates the physics

![](https://github.com/GamTam/Object-Pooling-Test/blob/main/Images/Physic%20Screenshot.png)

<br>

Unsurprisingly, the instance that had object pooling enabled ran at a smoother framerate than the instance without it. One aspect that surprised me when looking at the profiler was that the aspect that consistently took up the most processing time was the rendering, and not updating 400+ rigidbodies simultaneously.
