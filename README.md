


- guide

        https://learn.unity.com/project/ruby-s-2d-rpg

- get started

        - create project
        
                Install Unity 2021.2.7f1c1
                Create a new 2D Template project

        - Asset Store
        
                download Tutorial Resources in the Unity Asset Store & import assets
                https://assetstore.unity.com/packages/templates/tutorials/2d-beginner-tutorial-resources-140167?_ga=2.137348979.2108523444.1640881014-566125505.1640428876

        - Package manager
        
                Install the 2D Tilemap Editor package
                window > package manager

        - Scene
        
                use the default sample scene
                or create a new 2D Scene, save as Scenes/MainScene

        - Sprite
        
                Import ruby image
                Project/Assets/Art > Sprites > import new asset > select ruby image

        - GameObject
        
                click arrow of Ruby image > drag into scene, it creates a GameObject in the scene

- controller / frame rate / script c#

        - create script
        
                Project/Assets > right click create folder > create C# Script > class RubyController : MonoBehaviour
                ruby > add component > select script RubyController
        
- world design

        - Tilemap
        
                GameObject > 2D object > Tilemap > Grid/Tilemap 

        - Tile Palette
        
                Project/Assets/Art > create folder Tiles > create Tile Palette > click open

        - Tile
        
                Project/Assets/Art > Sprites > import new asset > select tile image        
                drag tile sprite into Tile Palette
                it should create tile in Project/Assets/Art/Tiles

                        - error
                        failed with error saving file

                        - fix
                        do not use 2020.3 LTS, use 2021.2.7
                
        - Paint tile into tilemap in the tile palette
        
                adjust sprite's unit
                Change the Pixel Per Unit value from 100/unit to 64/unit
                so that the 64x64 tile can fill up 1 unit

        - Tileset
        
                Project/Assets/Art/Sprites/FloorBrick...Corner > click arrow > change sprite mode from 1 to multiple
                change to 64 pix/unit
                Inspector > Sprite Editor > Grid by Cell Count > 3,3 > Slice > Apply

                drag tileset into Tile Palette
                paint map with brush

- Decorating the world

        - order of gameobject
        
                add 2 metalcube into scene
                try move ruby

                draw Sprites based on their position on the y-axis
                Edit > Project Settings > Graphics > Custom Axis > x=0,y=1,z=0
                try move ruby again, it hides behind cube when its y is greater than cube's y

        - Pivot, the point represents a game object
       
                1. set ruby's prefab's Pivot point from center to Bottom
                2. gameboject > Sprite Sort Point > pivot > apply override to prefab

                change Pivots Using the Sprite Editor
                change pivot of metalcube/ruby & their game boject
                Project window, Assets/Art/Sprites/Environment

                change by prefabs
                sprite = class
                prefab = custom class
                gameobject = object

                assets > create Prefabs folder
                Drag the MetalCube GameObject from the Hierarchy to the new Prefab folder.
                
                then you can use this prefab to create object has the same settings
                try to change color of this prefab, it changes all related objects in the scene

- World Interactions - Blocking Movement

        - Gravity
        
                add Rigidbody2D component to ruby's prefab
                ruby will fall out of scene

                set ruby's Gravity Scale property and set it to 0
                ruby will not fall

                - apply change to all ruby including existing object in scene
                set ruby's prefab > ruby gameobject's prefab field > overrides > apply to all

        - Collider
        
                tell the physics system(Rigidbody2D component) which part of the GameObject is “solid”
                add BoxCollider2D to ruby's prefab > the green line around ruby is its physics shape

                - fix ruby's rotate issue
                ruby's prefab > Rigidbody2D component > constraints > freeze rotation Z

                - fix ruby's shaking
                update ruby controller

                - resize the Collider
                Edit Collider of metalbox's prefab

                - add Tilemap Collider 2D conponent to tilemap
                Hierarchy/Grid/tilemap > add component

                project/assets/art/tiles > select all tiles except water > Collider Type > none, so only water left with collider

                - optimize
                select Hierarchy/Tilemap > add component > Composite Collider 2D (auto add rigid 2d com)
                In the Tilemap Collider 2D component, enable the Used By Composite checkbox. 
                In the Rigidbody2D component, set the Rigidbody Body Type property to Static. 

- World Interactions - Collectibles, + health value

        - Trigger
        
                it's special kind of Collider. 
                It sends you a message when your character enters a Trigger, so you can handle that event

                - add health value
                update ruby's controller

                - add Collectible object
                project/assets/art/sprites/VFX/CollectibleHealth > drag into scene
                add BoxCollider2D to the gameobject
                set Is Trigger, so that ruby can go through it

                - handle event
                assets/scripts create c# HealthCollectible
                add to CollectibleHealth gameobject

- World Interactions - Damage Zones and Enemies, - health value

        - damage zone
        
                Assets/Art/Sprites/Environment/Damageable, add into scene
                add BoxCollider2D
                Is Trigger
                c# DamageZone

                - quick way to create larger damage zone, instead of copy paste
                prefab > Sprite Renderer component > Draw Mode to Tiled > Tile Mode to Adaptive
                sprite > Mesh Type to Full Rect
                now you can use Rect tool to create larger damage zone

        - enemy
        
                import bot image
                add Rigidbody2D and a BoxCollider2D
                set gravity 0
                create c# Rigidbody2D

- Sprite Animation

        - Animation Clip
        
                - create run right clip
                select prefabs/bot > Window > Animation > Animation > create clip > select animations folder > BotRunRight
                Art/Sprites/Characters/MrClockworkSheet > click arrow > select MrClockworkWalkSides1-4 > drag into Animation window
                click ... to show sample rates, change from 60 to 4, make it move slow  

                - create run left clip
                in the same window, create another clip called BotRunLeft
                Art/Sprites/Characters/MrClockworkSheet > click arrow > select MrClockworkWalkSides1-4 > drag into Animation window
                add property > sprite > flip x > checkbox it

                - create run up/down clip
                ... 

        - Animator controller, use Clip as its states
       
                project/assets/art/animations > create animator controller, name bot                
                add params, Move X, Move Y

                delete existing states
                create New Blend Tree
                click the blend tree, change to 2D simple directional, move X, move Y

                set params (state machine)
                Left : Pos X = -0.5 Pos Y = 0
                Right: Pos X = 0.5 Pos Y = 0
                Up: Pos X = 0 Pos Y = 0.5
                Down: Pos X = 0 Pos Y = -0.5

        - add Animator controller as object's component
                
                select prefabs/bot or gameobject > add Animator component > select bot

        - use EnemyController to trigger stage change
       
                e.g. animator.SetFloat("Move X", 1);

        - do the same for ruby

                imported assets has existing states for animation for ruby
                arrow between Idle/Moving/Hit means transition, it works upon its conditions(param value)
                update those params in ruby's controller e.g. animator.Setxxx

- World Interactions - bullet

        - create gameobject
        
                Art/Sprites/VFX/CogBullet
                create gameobject > create prefab > name bullet
                Rigidbody2D > gravity 0
                BoxCollider2D
                c# Bullet
                update ruby's controller > add public GameObject bullet; > assign prefab 'bullet' as value to it

                - error
                
                        play but bullet will not appear, cause it collide with ruby itself

                - fix
                
                        ruby > Sorting Layer -> add layer
                        layer8 = Character
                        layer9 = Bullet
                        prefabs/ruby > set layer to 8
                        prefabs/bullet > set layer to 9

                        Edit > Project Settings > Physics 2D and look to the Layer Collision Matrix > uncheck bullet & character

- Camera

        - Cinemachine

                Unity package called Cinemachine to automatically control your camera

                - package manager
                
                        install Cinemachine

                - virtual camera
                
                        the main camera will copy your VC's settings
                        Cinemachine > create 2D camera
                        follow > ruby

                - Orthographic
                
                        relate to perspective view, Orthographic display object in fixed size
                        set VC's Orthographic size to 5, so display 10 units in height

                        camera object > lens > ortho size > 5
                        check game view

                - restrict camera view within map

                        camera object > extension > CinemachineConfiner
                        hierarchy > Create Empty name 'confiner' > add component  > Polygon Collider 2D > Edit Collider > drag to cover the map
                        camera object > CinemachineConfiner > select the confiner object

                        - error

                                now ruby will be out of view

                        - fix

                                right up corner > layer > confiner layer
                                confiner object > select confiner layer
                                Edit > Project Settings > Physics 2D > uncheck confier's conflict with other layers

- Visual Styling - Particles/effect

        - Particles
        
                particles can collectively create effects like smoke, sparks or even fire.

        - slice image
                
                assets/Art/Sprites/VFX/ParticlesSheet

        - create Particle System
                
                hierarchy > right click > effects > Particle System > name smokeEffect
                
                - choose sprite
                enable Texture Sheet Animation > select sprite

                - make it look real
                shape section, update values to have overall shape
                change start lifetime/size/speed to use random range
                
                - make it fade away
                enable Color over Lifetime
                change alpha to 0

                enable Size over lifetime
                change to high to low

                - sorting layer
                renderer section > ordery in layer from 0 to 1

        - add effect to bot
        
                drag smokeEffect object to create prefab, delete the object from scene
                Open your Robot Prefab, then drag your smoke Prefab to make it a child of your Robot

                change simulation space from Local to World, so that smoke not following robot to move

        - control effect

                EnemyController
                
                - error
                
                        public ParticleSystem smokeEffect;
                        smokeEffect.stop() does not work

                - fix

                        ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
                        particles.stop();

        - Instantiating a Particle System
        
                smoke effect > prefab > create by code
                you can store a reference to the Prefab in a public variable > call Instantiate when it should happen.

- Visual Styling - UI

        - Head-Up Display
        
                show current Health Level, interface

        - Canvas
                
                right click > UI > Canvas

                - canvas 3 modes
                        
                        - Screen Space - Overlay
                        - Screen Space - Camera
                        - World Space

                - Canvas Scaler
                
                        - Constant Size
                        - Scale With Screen Size

                - Graphic Raycaster

        - draw UI

                - too much details
                https://learn.unity.com/tutorial/visual-styling-ui-head-up-display?uv=2020.3&projectId=5c6166dbedbc2a0021b1bc7c#5d7f88fcedbc2a001fd3448d

                - adjust for stretch
                health UI > its child bar/portrait > adjust react tranform arrows > to match part of the parent that it wants to cover

- World Interactions

        - Dialog Raycast

- Audio

        - Audio Clips
        
                sound

        - Audio Listener 
        
                where to listen the sound
        
        - Audio Source
        
                component play the sound

        - create BGM
        
                create audio source
                set AudioClip
                set loop

        - control one time sound
        
                create audio source for ruby
                update ruby's controller to have play method
                call play method in healthcollectible's controller
                assign healthcollectible's prefab's audio clip

                - error
                source is null

                - fix
                audioSource = GetComponentInChildren<AudioSource>();


- build, run, distribute

        - build

                edit > project setting > Player
                File > Build Settings
                File > build & Run > build > save

        - publish webgl

                https://play.unity.com/
                zip ./build
                upload build.zip






















                








        

































        













        
        


