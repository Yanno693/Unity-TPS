using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Humanoid : MonoBehaviour
{
    // Start is called before the first frame update

    public int group; // The group which the person belongs to (Citizen, Guard, VIP, Spy, etc ...)
    public List<Carriable> inventory; // The inventory of the person, can be size 8 in maximum;

    protected Carriable leftHandObject; // The object held in the left hand
    protected Carriable rightHandObject; // The object held in the right hand
    protected BothHandsCarriable bothHandsObject; // The object held by both hands (A long weapon for example)

    protected void Start()
    {
        inventory = new List<Carriable>();
        leftHandObject = null;
        rightHandObject = null;
        bothHandsObject = null;
    }

    /*  Pick un an object
     *  toInventory : Is the object put in the inventory ?
     *  hand : the hand in which the Carriable will go, if the object isn't going into the Inventory or isn't a Both Hand Held Carriable
     */
    protected void PickUpObject(Carriable carriable, bool toInventory = false, MyEnum.Hand hand = MyEnum.Hand.None)
    {
        if(toInventory)
        {
            if(inventory.Count < 8 && carriable.hideable)
            {
                carriable.carried = true;
                inventory.Add(carriable);
            }
        }
        else
        {
            if(carriable is BothHandsCarriable)
            {
                BothHandsCarriable cast = (BothHandsCarriable)carriable;
                if(!bothHandsObject && !rightHandObject && !leftHandObject)
                {
                    carriable.carried = true;
                    bothHandsObject = cast;
                }
            } 
            else 
            {
                if(hand == MyEnum.Hand.Left)
                {
                    if(!leftHandObject && !bothHandsObject)
                    {
                        carriable.carried = true;
                        leftHandObject = carriable;
                    }
                }
                else if (hand == MyEnum.Hand.Right)
                {
                    if(!rightHandObject && !bothHandsObject)
                    {
                        carriable.carried = true;
                        rightHandObject = carriable;
                    }
                }
            }
        }
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
