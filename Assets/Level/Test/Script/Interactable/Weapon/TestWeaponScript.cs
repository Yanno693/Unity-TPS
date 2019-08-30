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

            if(humanoid is Player)
            {
                Player player = (Player)humanoid;
                Vector3 rayCastStart = player.gameObject.GetComponent<testPlayerMovementScript>().currentCamera.transform.position;

                int layerMask = ~(1 << LayerMask.NameToLayer("Humanoid"));
                //int layerMask =~ 1;

                RaycastHit hit;
                if(Physics.Raycast(rayCastStart, player.gameObject.GetComponent<testPlayerMovementScript>().currentCamera.transform.forward, out hit, 100f, layerMask)) // First for camera direction
                {
                    
                    RaycastHit hit2;
                    Vector3 newCastDirection = (hit.point - player.transform.Find("Nose").gameObject.transform.position).normalized;
                    if(Physics.Raycast(player.transform.Find("Nose").gameObject.transform.position, newCastDirection, out hit2, 100f))
                    {
                        Debug.DrawLine(player.transform.Find("Nose").gameObject.transform.position, hit2.point, Color.magenta, 0.1f);
                        Debug.Log(hit2.collider.gameObject);
                    }
                }
            }
        }
    }

    override public void Reload(Humanoid humanoid)
    {
        Debug.Log("Weapon reloaded");
        currentClipAmmo = clipCapacity;
    }
}
