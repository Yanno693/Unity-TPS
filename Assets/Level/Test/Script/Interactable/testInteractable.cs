using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInteractable : Interactable
{
    private bool state;

    void Start()
    {
        state = false;
    }
    
    void Update()
    {
        if(state)
            this.GetComponent<Renderer>().material.SetColor("_Albedo", Color.yellow);
        else
            this.GetComponent<Renderer>().material.SetColor("_Albedo", Color.white);
    }

    override public void Interact(Humanoid humanoid)
    {
        state = !state;
    }
}
