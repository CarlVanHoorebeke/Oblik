using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlat : MonoBehaviour
{
    GameObject playerPos;

    private void Start()
    {
        playerPos = GameObject.Find("player");
    }
    private void Update()
    {
        if ( transform.position.y < playerPos.transform.position.y - 3)
        {
            Destroy(this.gameObject);
        }
    }
}
