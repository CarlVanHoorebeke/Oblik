using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    bool hasBeenTouched;
    Transform playerPos;


    private void Update()
    {
        if (hasBeenTouched && transform.position.y < playerPos.transform.position.y - 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.tag == "Player")
        {
            playerPos = collision.transform;
            if (!hasBeenTouched)
            {
                PlatformGen.instance.NextPlatform();
                hasBeenTouched = true;
            }
        }
    }
}
