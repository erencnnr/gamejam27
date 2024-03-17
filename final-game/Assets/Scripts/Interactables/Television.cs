using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        this.promptMessage = "Televizyonu kapat";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        Destroy(GameObject.Find("Image"));
        
        
    }

}
