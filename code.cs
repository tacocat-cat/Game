
1
Here is a simple FPS code in Unreal Engine:
C++
#include "CoreMinimal.h"
#include "GameFramework/PlayerController.h"
#include "GameFramework/Pawn.h"
#include "Engine/World.h"

UCLASS()
class AFPSPlayerController : public APlayerController
{
    GENERATED_BODY()

public:
    // Called when the game starts or when spawned
    virtual void BeginPlay() override
    {
        Super::BeginPlay();

        // Get the player pawn
        APawn* PlayerPawn = GetPawn();

        // Check if the player pawn is valid
        if (PlayerPawn != nullptr)
        {
            // Set the player pawn's input delegate
            PlayerPawn->InputComponent->BindAxis("MoveForward", this, &AFPSPlayerController::MoveForward);
            PlayerPawn->InputComponent->BindAxis("MoveRight", this, &AFPSPlayerController::MoveRight);
            PlayerPawn->InputComponent->BindAxis("Turn", this, &AFPSPlayerController::Turn);
            PlayerPawn->InputComponent->BindAxis("LookUp", this, &AFPSPlayerController::LookUp);

            // Set the player pawn's fire delegate
            PlayerPawn->InputComponent->BindAction("Fire", IE_Pressed, this, &AFPSPlayerController::Fire);
        }
    }

private:
    // Called when the player moves forward
    void MoveForward(float Value)
    {
        APawn* PlayerPawn = GetPawn();

        if (PlayerPawn != nullptr)
        {
            PlayerPawn->AddMovementInput(GetControlRotation().ForwardVector * Value);
        }
    }

    // Called when the player moves right
    void MoveRight(float Value)
    {
        APawn* PlayerPawn = GetPawn();

        if (PlayerPawn != nullptr)
        {
            PlayerPawn->AddMovementInput(GetControlRotation().RightVector * Value);
        }
    }

    // Called when the player turns
    void Turn(float Value)
    {
        AddYawInput(Value);
    }

    // Called when the player looks up
    void LookUp(float Value)
    {
        AddPitchInput(Value);
    }

    // Called when the player fires
    void Fire()
    {
        APawn* PlayerPawn = GetPawn();

        if (PlayerPawn != nullptr)
        {
            // Fire the player pawn's weapon
            PlayerPawn->FireWeapon();
        }
    }
};




To use this code, create a new C++ class and add the AFPSPlayerController header file to it. Then, copy and paste the code above into the class.
Next, create a new GameObject in your scene and add the AFPSPlayerController class to it. Then, set the GameObject's Player Controller class to AFPSPlayerController.
Finally, you can add a Camera component to the GameObject, but this is not necessary. If you don't add a Camera component, the player will be able to see through their own eyes.
Once you have added the script and component to the GameObject, you can play the game and control the player using the WASD keys and the mouse.
You can add more features to your FPS game, such as different types of weapons, enemies, and levels, by adding additional scripts and components to the GameObjects in your scene.
Here are some additional tips for creating an FPS game in Unreal Engine:
Use a variety of different terrain assets to create interesting and varied levels.
Add different types of weapons and enemies to keep the game challenging and exciting.
Use Unreal Engine's particle system to create realistic effects for explosions, gunfire, and other events.
Use Unreal Engine's audio system to add sound effects and music to your game.
You can also use Unreal Engine's networking features to create multiplayer FPS games.
