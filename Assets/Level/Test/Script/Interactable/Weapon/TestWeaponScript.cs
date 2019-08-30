using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponScript : Weapon
{
    void Start()
    {
        isMeleeWeapon = false;
        isAutomatic = true;
        clipCapacity = 30;
        currentClipAmmo = clipCapacity;
        rateOfFire = 0.3f;
        lastFire = rateOfFire;
    }

    void Update()
    {
        if(lastFire < rateOfFire)
            lastFire += Time.deltaTime;

        if(carried)
            this.GetComponent<Renderer>().material.SetColor("_Albedo", Color.blue);
        else
            this.GetComponent<Renderer>().material.SetColor("_Albedo", Color.white);
    }
    
    override public void Interact(Humanoid humanoid)
    {
        if(lastFire >= rateOfFire && currentClipAmmo > 0)
        {
            Debug.Log("Weapon fired");
            lastFire = 0f;
            currentClipAmmo--;
        }
    }

    override public void Reload(Humanoid humanoid)
    {
        Debug.Log("Weapon reloaded");
        currentClipAmmo = clipCapacity;
    }
}
