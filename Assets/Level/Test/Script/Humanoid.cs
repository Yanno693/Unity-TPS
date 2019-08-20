using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Humanoid : MonoBehaviour
{
    // Start is called before the first frame update

    public string group; // The group which the person belongs to (Citizen, Guard, VIP, Spy, etc ...)
    public Carriable[] inventory; // The inventory of the person, can be size 8 in maximum;

    protected Carriable leftHandObject; // The object held in the left hand
    protected Carriable rightHandObject; // The object held in the right hand
    protected BothHandsCarriable bothHandsObject; // The object held by both hands (A long weapon for example)

    protected void Start()
    {
        inventory = new Carriable[8];
        leftHandObject = null;
        rightHandObject = null;
        bothHandsObject = null;
    }

    protected void UseLeftHandObject()
    {        
        leftHandObject.Interact(this);
    }

    protected void UseRightHandObject()
    {
        rightHandObject.Interact(this);
    }

    protected void UseBothHandsObjectPrimary()
    {
        bothHandsObject.Interact(this);
    }
    abstract protected void UseBothHandsObjectSecondary();

    protected void Update()
    {
    }
}
