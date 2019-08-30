using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BothHandsWeapon : BothHandsCarriable, WeaponInterface // A long weapon
{
    public bool isMeleeWeapon; // Is the weapon a melee weapon ?
    public bool isAutomatic; // Is the weapon automatic ?
    public int clipCapacity; // The maximum capacity of the weapon clip/magazine
    public float rateOfFire; // The rate of fire of the weapon (time between everyShot)
    [HideInInspector] public int currentClipAmmo; // The current capacityt of the weapon clip/magazine
    [HideInInspector] public float lastFire; // The time between the last shot and now

    public abstract void Reload(Humanoid humanoid);
}
