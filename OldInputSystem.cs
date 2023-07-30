using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputSystem : MotionPlayer
{
    // Update is called once per frame
    public new void Update()
    {
        Motion(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftCommand))
            SendMessage();

        
    }
}

