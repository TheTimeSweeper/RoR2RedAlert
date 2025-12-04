## Changelog
`3.3.7`
- oops uploaded with language printing

`3.3.6`
- hack fix chrono softlocking by disappearing solus wing

`3.3.5`
- added tesla trooper compat with faulty conductor :smiling_imp:

`3.3.4`
- fix for Alloyed Collective the best DLC with 0 bias whatosever
- WIP updated sounds for Desolator. feedback welcome

`3.3.3`
- fixed loading damagetypes async like a fool (huge thanks to Walu and Missy for helping me debug this)
- fixed desolator m2 not applying radation stacks

`3.3.2`
- fixed a bug with special in networking ( thanks score and hifu for finding the errors c: )

`3.3.1`
- fixed skins in lobby
- fixed recolors (which fixes boosted m2 not working in multiplayer)
- added white recolors to commemorate the occasion

`3.3.0`
- hotfix for memop update, still few bugs to fix in the coming days
- *custom recolors are broken. enjoy the secret white recolor for now*
- *skins are broken in lobby*

`3.2.3`
- disabled driver compat weapons for now

`3.2.2`
- added Bubble VFX Limit config for Desolator's default special, allowing you to reduce the max amount of bubble visuals are created (does not affect gameplay or damage

`3.2.1`
- fix tesla breaking with custom skins

`3.2.0`
- Fixed starstorm 2 shock drone breaking when this mod is installed
- Brought Conscript to beta, still behind config. give him a try!
    - gameplay design iterated, working and networked
    - added sexy model from skeletor but no animations
- Added temp model for G.I.

`3.1.2`
- damagesource update

`3.1.1`
- fixed guillotine fix not actually fixing

`3.1.0`
- updated tesla trooper tracking code to be slightly more optimized
- reduced the amount that the tesla trooper tracking reticle jumps around enemy hurtboxes
    - *just where the indicator shows up. actual aim target accuracy has not changed.*
- re-replaced chrono bomb with instant placed version
- updated chrono bomb placing to use tesla's tracking instead
    - *this improves detection distance on large enemies like bosses and parents*
    - *likely more work still to be done on this*
- moved thrown bomb to config
    - *will combine these versions of the bomb in the future*
- Added Driver mod compat: adds 3 weapons based on the guys.
- fixed guillotine increasing chrono vanish threshold on all enemies
- fixed chronosphere not teleporting

`3.0.12`
- readded previous chrono bomb under cursed config

`3.0.11`
- Chrono: 
    - special damage ticks faster (overall damage and debuff stacks unchanged)
    - special range increased and added to config
    - bomb is no longer lock-on. throws a short distance and magically floats in the air because I didn't have time to polish this
    - bomb detonation time lowered from 3 to 2 seconds
    - bomb textured
    - made sprint teleport on release the default
    - alt util now halts enemies in the air
    - fixed alt util sound ending early
    - fixed scepter sprint breaking in multiplayer
    - added a debug config to be actionable while in teleport disabled state (but still can't move)
- Tesla Trooper: re-added ability to command Starstorm 2 Shock Drones

`3.0.10`
- removed log spam on all damage instances. woopsies

`3.0.9`
- fixed desolator utility for real, effect is back
- adjusted desolator m1 from from 100% + 156% in 2 stacks of radiation -> 80% + 201% in 3 stacks of radiation
    - configs coming eventually
- reworded desolator's irradiating tooltips so you dont have to pull out a calculator to know what damage it does lol
    - nah you'll still probably need a calculator what with all the dots and ticks
    - will probably do the same for the base move descriptions later
    - not applied to other languages
- fixed desolator m1 tracer being missing
- fixed chrono m1 tracer being missing
- changed ukranian folder from UA to UK as I heard that is the thing to do now

`3.0.8`
- added safety checks for desolator's utility to work in multiplayer
    - visual is still bugged until I can fully figure this out but the move will hopefully always work, gameplay-wise

`3.0.7`
- added Chrono item displays
- fixed achievements on disabled characters destroying the mod. happy I didn't get any reports of this.

`3.0.6`
- split up Chrono's special into 3 charges
- added stock display to crosshair for special charges
- made scepter teleport purple to distinguish you got scepter
- made chrono scepter disable-able in config if you don't like it
- added temp chrono icons

`3.0.5`
- fixed all deployables (desolator irradiators, engi mines, everything) being set to the laws of tesla trooper's towers

`3.0.4`
- added AI for chrono (goobo and vengeance)
- fixed tesla and deso goobo and vengeance being broken
- temporarily removed deployable restriction on desolator glow sticks
    - *couldn't figure out how to fix it right so for now grab some brain stalks and go crazy*

`3.0.3`
- fixed tesla trooper (and some other moves I think) not scaling with attack speed

`3.0.2`
- illegally forced compat with autosprint for chrono
- fix error with m2 bombs when deputy was installed

`3.0.1`
- fixed conflict with riskytweaks removing something from frost relic that I was cloning
- fixed some issues with scepter even though it's not working yet

`3.0.0` new mod new us
- fixed for sots. please reach out if you find any more issues
- added Chrono Legionnaire, still Beta but all working and multiplayer compatible
- added G.I., still alpha but all working and multiplayer compatible (afaik)
- added Conscript, not even alpha lol, but hey if you're curious
- Completely revamped code behind the scenes. some things may be improved some things may still be missing.
- Character creation and some assets are now loaded async. this should improve load times by probably 0.0001%
- Risk of options support for configs
- I spent like months on this update there's no way it's like 5 lines

`2.2.4`
- fixed desolator scepter forever
    - completely removed the troublesome part of desolator's special code and replaced it with jank
    - but jank that shouldn't fail anymore

`2.2.3`
- fixed desolator scepter resetting when zetaspects is installed
  - *skill will still reset if a buff is lost while in special because of code jank on scepter's end. full fix to completely workaround all this coming at some point.*
- fixed desolator rad cannon not spinning when deployed

`2.2.2`
- fixed Tesla Trooper Surging Forward while rooted locking you in purgatory 
- fixed Tesla Trooper M2 conflict with autosprint, only a year after it was reported
- Desolator passive now counts stacks from SS2U Nucleator dot

`2.2.1`
- forgot to update text to the changes of last patch woops

`2.2.0`
- tesla trooper
  - passive: ally buff multiplier 1.3 -> 1.1
  - passive: ally buff shock duration 1 - 3.5
  - secondary (empowered): 1200% -> 1500%  
    - *He gets a lot of feedback that he's very strong, this may surprise you, because he also gets a lot of feedback that he's weak.*  
    - *I suspect a giant culprit is those people don't know to buff the tower before using secondary, missing out on a lot of his potential damage (1200% * 1.3 = 1560%)*  
    - *These changes remove this aspect from being a necessity, in exchange buffing a bit of its utility when you do decide to use it*  
    - *If you liked that aspect, configs will come at some point so you can revert these changes*
  - primary: animation plays on each bolt  
    - *as well as the tower aspect, I suspect the people are also missing out on tripling close-range primary damage. more feedback on doing multiple hits should help with this.*
  - Utility: sound now plays when absorbing damage, increasing in pitch based on damage absorbed  
    - *thanks rob for the suggestion. I agree with all your others as well so they'll come at some point*
    - *except except when you said it does a whole lot of nothing. late game it's a free 1800% with a giant aoe ya goon*
  - secondary (empowered): now commands Starstorm 2 Shock Drones as well
  - fix potential nullref spam on tracking component
- Desolator
  - ~~fixed a bug where sceptered special reverts to regular special after using it~~
    - ~~*I assume. I could not reproduce it so if it still happens to you, let me know and give a log*~~
  - he'll get some more love I promise

`2.1.6`
- added failsafe fix for current incompatiblility with Shaman (must play default skin until he pulls my fix)
- added simplified chinese translation (thanks Rody and FallenTroop!)
- fixed Desolator scepter skills multiplayer issues
- fixed Desolator scepter alt special description displaying wrong damage

`2.1.5`
- added Brazilian Portuguese translation (thanks Kauzok!)
- added mastery skin for Desolator (thanks again, Mr.Bones)
  - google translated the name for other languages, sorry if something's wrong!
- haven't touched this project in several months so I hope nothing broke making this update!

`2.1.4`
 - added french translation (thanks Fyrebw!)

`2.1.3`
 - added russian translation (thanks Nikto0o!)
 - attempt to optimized desolator's big-ass specials by simplifying the hitboxes
   - *this makes the cube hitbox wildly inaccurate to the sphere visual so enjoy the extra range I suppose* 
 - removed joe

`2.1.2`
 - r2api split ass(emblies)
 - now that colorsapi is real, added a color to communicate tesla trooper charged ally attacks
 - added some missing text to language file

`2.1.1`
 - added Ukrainian translation (thanks Damglador!)
 - added Spanish translation (thanks Juhnter!)
 - fixed desolator disable config breaking both characters
 - fixed desolator irradiator projectile collisions being inconsistent
 - added buff icon for desolator deployed state
 - lowered desolator sounds
 - adjusted sound for desolator utility

`2.1.0`
 - added sit emotes for both men
 - added language support. thanks to Damglador for pushing for it, and thanks to Moffein and Anreol for the code
   - if you'd like to translate to your language, check out the [language folder on Github](https://github.com/TheTimeSweeper/the/tree/master/JoeMod/Release/plugins/Language)
 - made desolator back pack tube thing change color with recolors
 - fixed "voice line in css" config for playing wrong voice lines for desolator
 - fixed not being able to play voice lines while using certain abliites
 - finally came out of the past and separated assetbundles and soundbank from dll

`2.0.1`
 - fixed utility broken

`2.0.0`
 - released new character Desolator!
 - added new alt secondary skill for tesla trooper, expanding on alt m1 in cursed config 
 - added achievement for alt m1. still in cursed for now
 - config has been reorganized. you should probably just delete existing
 - finished tower item displays for sotv items
 - fixed level growth stats not being to the vanilla standard
 - lowered distance scaling on sounds
 - added head hurtbox proper
 - small tweaks to the russion section of lore (thanks Damglador)

`1.3.2`
 - fixed eclipse not saving progress
 - attempt fix to targeting just not wanting to target sometimes

`1.3.1`
 - fixed emoteapi rig

`1.3.0`
 - added rig for EmoteAPI. happy now?
 - freed alt Util from cursed config and added as a proper skill variant
   - improved reticle targeting, separate from m1 targeting
   - icon and sound
   - unlockable by achievement
   - *haven't tested much in multiplayer but I'm pretty sure it should work fine?*
 - added additional property for scepter: tower now zaps multiple enemies at once
   - *kept multiple towers by the rule of cool*
   - *it's probably way overtuned now, so I'll maybe dial it back in the future. for now, have fun c:*
 - finally fixed malachite aspect destroying his and his towers' bones
 - adjusted m1 reticle to help more clearly read the 3 different tiers of range
 - added secret beta config

`1.2.1`
 - fixed conflict with ttgl mod and vrapi

`1.2.0`
 - new Grand Mastery skin! Thanks as always to the lovely SkeletorChampion
   - comes with a unique tower
   - comes with a few custom effects
 - holy shit VR
   - zaps with right hand, build tower with left hand
   - all skins supported
 - Added Lore by Jaysian, thanks!
 - bumped up damage of cursed config alt primary
   - *if it's not gonna make sense may as well be strong*
 - Added new heavy WIP Alt Utility in cursed config: Surging Forward
   - *not really sure where I was going with this one but turned out kinda fun so y not*
 - fixed tower blocking its own projectiles, mainly ATG missiles

`1.1.1` buncha tweaks
- ally zap no longer does damage, fixing pennies exploit
- zapping allies with m1 now ends the move earlier
  - *so accidentally hitting allies doesn't eat up a full duration m1*
- m1 zap now travels instantly
- slightly lowered m1 attack duration
  - *not enough to affect any balance concerns, just to hopefully feel a little smoother*
- fixed m1 not blooming crosshair for clients
- lowered lingering m2 cast time
- added very WIP m1 alt skill under cursed config

`1.1.0`
- Added proper Mastery skin, complete with a unique tower
  - *thanks Mr.Bones!*
- Added Scepter Upgrade
  - ~~*but by accident I did exactly lysate cell, so I'm open to any better ideas*~~
- Limited lysate cell to 1 additional tower, similar to engi
  - *stacking simultaneous towers turned out way too strong for a green rarity item*  
  - *truthfully it should be 0 but I want the opportunity for multiple towers in some capacity*  
  - *unlimited stacking behavior can be reverted in config*
- Fixed Utility's cooldown to start after the move is done
- Fixed missing tower sounds in multiplayer
- lowered sound distance so they don't dominate the battlefield
  - *let me know if they're too quiet now*
- Removed dependency on FixPluginTypesSerialization

`1.0.2`
- accidentally cranked up m1 distance way too high woops

`1.0.1`
- fixed tower getting taken by void infestors
- bumped up tracking range to help deal with xi construct
- adjusted m1 visual to make separate arcs a little more visible
- added config to disable tower item displays if you find them too silly
- added Aetherium item displays
- added item displays just for Tinker's Satchel mustaches 

`1.0.0`
- c:
  