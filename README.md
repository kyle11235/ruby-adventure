


- guide

        https://learn.unity.com/project/ruby-s-2d-rpg

- get started

        - setup
        Install Unity 2021.2.7f1c1
        Create a new 2D Template project

        - import assets
        download Tutorial Resources in the Unity Asset Store
        https://assetstore.unity.com/packages/templates/tutorials/2d-beginner-tutorial-resources-140167?_ga=2.137348979.2108523444.1640881014-566125505.1640428876

        - Install the 2D Tilemap Editor package
        window -> package manager

        - Creating a new Scene
        use the default sample scene
        or create a new 2D Scene, save as Scenes/MainScene

        - Import ruby image
        Project/Assets/Art -> Sprites -> import new asset -> select ruby image

        - Use a Sprite to create a GameObject
        click arrow of Ruby image -> drag into scene

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

        - add 2 metalcube into scene
        try move ruby

        - draw Sprites based on their position on the y-axis
        Edit > Project Settings -> Graphics -> Custom Axis -> x=0,y=1,z=0

        try move ruby again

        - Pivot, the point represents a game object
        set ruby's point from center to Pivot
        Sprite Sort Point -> pivot

        - change pivot of metalcube/ruby & their game boject
        Project window, go to Assets > Art > Sprites > Environment

        - Change Pivots Using the Sprite Editor
        change ruby

        - change by prefabs
        sprite = class
        prefab = custom class
        gameobject = object

        assets > create Prefabs folder
        Drag the MetalCube GameObject from the Hierarchy to the new Prefab folder.
        
        then you can use this prefab to create object has the same settings
        try to change color of this prefab, it changes all related objects in the scene

- World Interactions - Blocking Movement

        - add Rigidbody 2D component to ruby's prefab
        ruby will fall out of scene

        - set ruby's Gravity Scale property and set it to 0
        ruby will not fall

        - apply change to all ruby including existing object in scene
        set ruby's prefab -> ruby gameobject's prefab field -> overrides -> apply to all

        - Collider
        tell the physics system(Rigidbody 2D component) which part of the GameObject is “solid”

        add Box Collider 2D to ruby's prefab -> the green line around ruby is its physics shape

        - fix ruby's rotate issue
        ruby's prefab -> Rigidbody 2D component -> constraints -> freeze rotation Z

        - fix ruby's shaking
        update ruby controller

        Rigidbody2D rigidbody2d
        Vector2 position = rigidbody2d.position;

        - resize the Collider
        Edit Collider of metalbox's prefab

        - add Tilemap Collider 2D conponent to tilemap
        Hierarchy/Grid/tilemap -> add component

        project/assets/art/tiles -> select all tiles except water -> Collider Type -> none, so only water left with collider

        - optimize
        select Hierarchy/Tilemap -> add component -> Composite Collider 2D (auto add rigid 2d com)
        In the Tilemap Collider 2D component, enable the Used By Composite checkbox. 
        In the Rigidbody 2D component, set the Rigidbody Body Type property to Static. 

- World Interactions - Collectibles






















        













        
        


