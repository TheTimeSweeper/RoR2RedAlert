# Unity Project Thunderkit Setup
0. have [git](https://git-scm.com/) installed
1. open project, necessary packages are in manifest
1. it'll warn you there are compile errors. ignore
1. thunderkit settings window (if it doesn't show up, top toolbar Tools > Thunderkit > Settings) > Import Configuration as follows:  

|Configuration | Set To | Why |
|---|-|---|
|Check Unity Version | On | |
|Disable Assembly Updater | On | |
|Post Processing Unity Package Installer | Off | already done in manifest |
|Assembly Publicizer | On | |
|MMHook Generator | Off | we're not building the mod from the editor so we don't need extra bloat |
|Import assemblies | On |  |
|Import Project Settings | Off | should already be imported but if it's not for you turn this on |
|Set Deferred Shading | On |  |
|Create Game Package | On |  |
|Import Addressable Catalog | On | addressable browser is dope |
|Configure Addressable Graphics Settings | On |  |
|Ensure RoR2 Thunderstore Source | Off | |
|Install BepInEx| Off | already done |
|R2API Submodule Installer | Off | ah yes who wouldn't want 28 packages slowing down compiling, playing, and building? |
|Install RoR2 Compatible Unity Multiplayer HLAPI | Off | we're not weaving in editor so we don't need this |
|Install RoR2 Editor Kit | Off | already done |
|the rest | On |  |

4. Settings > browse exe and import

    i. if it warns you about compile errors again, ignore  
    ii. on my pc a file browsing window opened up during the process, select ror2 exe again

5. All should be well! open Assets/Dev/SceneBarracks to see the men
    i. click canvas in the hierarchy, hit f, and see if the ror2 hud was spawned in with addressables, and our guys crosshairs are on it
