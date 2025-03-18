# Repo AntiCheat
This mod attempts to patch exploits that cheaters have been using to grief other players. 

### It is client-side:
This means that it only protects your client. It will not protect other players in the lobby from exploits, even if you are the host. Anyone who does not have the anticheat installed will desync whenever someone uses an exploit. This is a limitation of way that the game does multiplayer.

In order for the anti-cheat to work properly, **YOU AND THE HOST NEED THE MOD!!!**

This also won't protect you if the host is cheating.


## Patches

| Patch | Exploit |
| ----------- | ----------- |
| Remove text tags from username and chat | Covering entire screen with bright colors |
| Limit chat message length to vanilla limit (50) | Highly annoying |
| Limit username length to steam name limit (32) | Highly annoying |
| `PlayerAvatar.OutroStartRPC` | Softlocked in a permanent loading screen |
| `PlayerAvatar.SpawnRPC` | Teleporting another player |
| `PlayerAvater.PlayerDeathRPC` | Killing another player |
| `PlayerHealth.UpdateHealthRPC` | Modifying health of another player |
| `PlayerHealth.HurtOtherRPC` | Hurting / killing players |
| `ExtractionPoint.HaulGoalSetRPC` | Changing goal amount |
| `ExtractionPoint.ExtractionPointSurplusRPC` | Completing extraction / giving money |
| `RoundDirector.ExtractionCompletedAllRPC` | Shake Screen repeatedly |

## Issues
- Please report any issues you have with the mod to the [Github Page](https://github.com/Charlese2/RepoAntiCheat/issues)
- If you are a modder and find a new exploit, please let me know.
- Please report any incompatibilities you find with other mods.