using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Humanoid : MonoBehaviour
{
    // Start is called before the first frame update

    public string group; // The group which the person belongs to (Citizen, Guard, VIP, Spy, etc ...)
    public GameObject[] inventory; // The inventory of the person, can be size 8 in maximum;

    protected GameObject leftHandObject; // The object held in the left hand
    protected GameObject rightHandObject; // The object held in the right hand
    protected GameObject bothHandsObject; // The object held by both hands (A long weapon for example)

    protected void Start()
    {
        inventory = new GameObject[8];
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }
}
