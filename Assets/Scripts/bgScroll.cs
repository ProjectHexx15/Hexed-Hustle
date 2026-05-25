using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroll : MonoBehaviour
{
    // variables
    public float BGscrollSpeed; // stores the speed that the background object will scroll at
    public Renderer bgRend; // stores the background render object
  

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(BGscrollSpeed * Time.deltaTime, 0f); // background will scroll along the screen continously
    } // end of update

} // end of class
