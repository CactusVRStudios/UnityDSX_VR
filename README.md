# UnityDSX_VR

<a href="https://www.cactusvrstudios.com"><img src="https://github.com/CactusVRStudios/UnityDSX_VR/blob/main/VR%20Studios.png?raw=true" width="500" height="auto"/></a>




Use PSVR2 Adaptive Triggers in Unity with Windows and DSX 3.1+

Note: This is a POC and intended for developers!



Requires DSX Version 3.1+

## How does it work?
The little script sends UDP commands to DSX which will execute the commands on the controller. In order for it to work, you need to have the DSX 3.1 or higher installed and running. Make sure your UDP Ports are open. See DSX settings for further assistance. 

Best practice is, to start SteamVR before starting DSX.


## Unity Setup
Drag the PSVR2TriggerController into your first scene. Once started, it connects to the running DSX instance. To make it easier to use, all you need to do is calling the left or right trigger and its effect. No need for checking the controller index.



## PSVR2TriggerController Command Usage

### SetTriggerState Methods

- **`SetTriggerState(Trigger trigger, TriggerMode triggerMode)`**
  - **Usage:**
    ```csharp
    PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Normal);
    ```
  - **Description:** Sets the specified trigger (`Left` or `Right`) to the specified trigger mode.

- **`SetTriggerState(Trigger trigger, TriggerMode triggerMode, int sensitivity)`**
  - **Usage:**
    ```csharp
    PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.VibrateTriggerPulse, 5);
    ```
  - **Description:** Sets the trigger with an additional sensitivity parameter. Useful for custom vibration settings.

- **`SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int strength, int frequency)`**
  - **Usage:**
    ```csharp
    PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.AutomaticGun, 0, 10, 5);
    ```
  - **Description:** Configures the trigger for an automatic gun effect with start position, strength, and frequency parameters.

- **`SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int end, int strengthA, int strengthB, int frequency, int period)`**
  - **Usage:**
    ```csharp
    PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Machine, 0, 100, 10, 20, 5, 2);
    ```
  - **Description:** Configures the trigger for a machine effect with detailed parameters for start, end, strength, frequency, and period.

- **`SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int end, int firstFoot, int secondFoot, int frequency)`**
  - **Usage:**
    ```csharp
    PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Machine, 0, 100, 10, 20, 5);
    ```
  - **Description:** Configures the trigger for a machine effect, with parameters for start, end, and foot-based strength, plus frequency.

- **`SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int force)`**
  - **Usage:**
    ```csharp
    PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Resistance, 0, 50);
    ```
  - **Description:** Sets the trigger to resistance mode with parameters for start position and force.

- **`SetTriggerState(Trigger trigger, TriggerMode triggerMode, CustomTriggerValueMode valueMode, int force1, int force2, int force3, int force4, int force5, int force6, int force7)`**
  - **Usage:**
    ```csharp
    PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.CustomTriggerValue, Shared.CustomTriggerValueMode.Pulse, 10, 20, 30, 40, 50, 60, 70);
    ```
  - **Description:** Customizes the trigger with a sequence of force values, allowing for fine-grained control over the trigger's behavior.

### General Notes

- **Trigger Values:** `Shared.Trigger.Left` and `Shared.Trigger.Right` represent the left and right triggers, respectively.
- **Trigger Modes:** `Shared.TriggerMode` includes various modes like `Normal`, `VibrateTriggerPulse`, `AutomaticGun`, etc.
These commands provide a robust interface for controlling the trigger states of PSVR2 controllers.


## FAQ
**Does this work without DSX?** 

No!


**Will it ever work without DSX?**

Yes!


**I just wanna play. Can I use it to make it work with HL:A $_RandomGame**

No, unless you have the source code for it or are able to mod the game!

**Is there a game I can test it with?**

Yes! [Cactus Cowboy - Desert Warfare](https://store.steampowered.com/app/2554800/Cactus_Cowboy__Desert_Warfare/) on steam has a beta with a working implementation. Go to the Beta tab, and pick the "PSVR2_Special_Ed". Make sure DSX3.1+ is installed and running.


**Can you access the Adaptive Triggers with Unity natively?**

Yes, but that is more complex.


**What about HMD rumble?**

Not working, yet!


**Is a native SDK being worked on?**

Preparations have been made 😎




## DSX (Steam)
<a href="https://store.steampowered.com/app/1812620/DSX/"><img src="https://github.com/Paliverse/DualSenseX/raw/main/imgs/AvailableOnSteam.png" width="300" height="auto"/></a>


## A look into the future
A native Unity implementation for Windows is certainly possible as DSX has proven it. So why this? This can be used as concept for other VR mods, games with no access to its source code, UEVR or direct implementation.


2024 - Cactus VR Studios
