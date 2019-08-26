﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCarriable : Carriable
{
    // Start is called before the first frame update
    override public void Interact(Humanoid humanoid)
    {
        Debug.Log("Interacted with object");
    }
    
    void Update()
    {
        if(carried)
            this.GetComponent<Renderer>().material.SetColor("_Albedo", Color.green);
        else
            this.GetComponent<Renderer>().material.SetColor("_Albedo", Color.white);
    }
}
