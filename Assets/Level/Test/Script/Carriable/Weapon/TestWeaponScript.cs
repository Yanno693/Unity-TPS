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

            // Unactivating colliders to shoot through the shooter
            foreach(Collider c in humanoid.GetComponents<Collider>())
                c.enabled = false;

            if(humanoid is Player)
            {
                Player player = (Player)humanoid;
                Vector3 rayCastStart = player.gameObject.GetComponent<testPlayerMovementScript>().currentCamera.transform.position;

                //int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));

                RaycastHit hit;
                if(Physics.Raycast(rayCastStart, player.gameObject.GetComponent<testPlayerMovementScript>().currentCamera.transform.forward, out hit, 100f))
                {
                    Debug.DrawLine(player.transform.Find("Nose").gameObject.transform.position, hit.point, Color.magenta, 0.1f);
                    Debug.Log(hit.collider.gameObject);
                }
            }

            foreach(Collider c in humanoid.GetComponents<Collider>())
                c.enabled = true;
        }
    }

    override public void Reload(Humanoid humanoid)
    {
        Debug.Log("Weapon reloaded");
        currentClipAmmo = clipCapacity;
    }
}
