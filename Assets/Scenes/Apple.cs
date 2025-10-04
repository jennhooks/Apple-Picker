using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Get reference to ApplePicker script.
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            
            // Call the public AppleMissed() method.
            apScript.AppleMissed();
        }
    }
}
