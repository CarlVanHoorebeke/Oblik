using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform currentPlaform;
    [SerializeField] GameObject deathPlatPrefab;
    [SerializeField] Transform deathPlatform;
    [SerializeField] int startingPlatformCount;

    int nextPlatformDirection;

    public static PlatformGen instance;

    private void OnEnable()
    {
        instance = this;
    }
    void Start()
    {
        
        GenerateStartingPlatforms();
    }
    void GenerateStartingPlatforms()
    {
        deathPlatform = Instantiate(deathPlatPrefab, currentPlaform.position + Vector3.left * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
        currentPlaform = Instantiate(platformPrefab, currentPlaform.position + Vector3.right * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;

        for (int i = 0; i < startingPlatformCount; i++)
        {
            nextPlatformDirection = Random.Range(0, 2);

            if (nextPlatformDirection == 0)
            {
                deathPlatform = Instantiate(deathPlatPrefab, currentPlaform.position + Vector3.left * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
                currentPlaform = Instantiate(platformPrefab, currentPlaform.position + Vector3.right * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
            }
            else
            {
                deathPlatform = Instantiate(deathPlatPrefab, currentPlaform.position + Vector3.right * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
                currentPlaform = Instantiate(platformPrefab, currentPlaform.position + Vector3.left * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
            }
        }
    }

    public void NextPlatform()
    {
        nextPlatformDirection = Random.Range(0, 2);

        
        if (nextPlatformDirection == 0)
        {
            deathPlatform = Instantiate(deathPlatPrefab, currentPlaform.position + Vector3.left * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
            currentPlaform = Instantiate(platformPrefab, currentPlaform.position + Vector3.right * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
        }
        else
        {
            deathPlatform = Instantiate(deathPlatPrefab, currentPlaform.position + Vector3.right * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
            currentPlaform = Instantiate(platformPrefab, currentPlaform.position + Vector3.left * 0.75f + Vector3.up * 0.375f, Quaternion.identity).transform;
        }
    }
}
