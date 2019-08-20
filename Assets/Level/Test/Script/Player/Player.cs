using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    override protected void UseBothHandsObjectSecondary()
    {
        bothHandsObject.SecondaryInteract(this);
    }
}
