


- guide

        https://learn.unity.com/project/ruby-s-2d-rpg

- get started

        - setup
        To set up your Unity project:
        1.  Install Unity 2021.2.7f1c1, if you haven’t already done so.
        2.  Create a new Unity project using the 2D Template.
        3.  Go to the 2D Beginner: Tutorial Resources in the Unity Asset Store
        https://assetstore.unity.com/packages/templates/tutorials/2d-beginner-tutorial-resources-140167?_ga=2.137348979.2108523444.1640881014-566125505.1640428876

        4.  Download and import the assets into your Unity project.
        5.  Install the 2D Tilemap Editor package for your project. 
        Now you’re ready to get started with the learning project!

        - Creating a new Scene
        use the default sample scene
        or create a new 2D Scene, save as Scenes/MainScene

        - Import Assets into your Project
        Project/Assets/Art -> Sprites -> import new asset -> select ruby image

        - Use a Sprite to create a GameObject
        click small arrow of Ruby image -> drag into scene

- controller

        - create script
        Project/Assets -> right click create folder -> create C# Script -> class RubyController : MonoBehaviour
        ruby -> add component -> select script RubyController
        
- world design

        - create Tilemap
        GameObject -> 2D object -> Tilemap -> Grid/Tilemap

        - create Tile Palette
        Project/Assets/Art -> create folder Tiles -> create Tile Palette -> click open

        - import image/sprite
        Project/Assets/Art -> Sprites -> import new asset -> select tile image

        - create tile by dragging to Tile Palette
        drag tile sprite into Tile Palette
        it should create tile in Project/Assets/Art/Tiles

        failed with error saving file

                - fix
                do not use 2020.3 LTS, use 2021.2.7
        
        - paint map with brush

        - adjust sprite's unit
        Change the Pixel Per Unit value from 100/unit to 64/unit
        so that the 64x64 tile can fill up 1 unit

        - create Tileset
        Project/Assets/Art/Sprites/FloorBrick...Corner -> click arrow -> change sprite mode from 1 to multiple
        change to 64 pix/unit
        Inspector -> Sprite Editor -> Grid by Cell Count -> 3,3 -> Slice -> Apply

        - drag tileset into Tile Palette

        - paint map with brush

- Decorating the world

        






        
        


