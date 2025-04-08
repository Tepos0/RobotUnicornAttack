using System.Collections.Generic;
using UnityEngine;

public class PlatformInstantiate : MonoBehaviour
{
    [SerializeField]
    private List<InstantiateObject> platformsPools;
    [SerializeField]
    private List<InstantiateObject> safePlatformsPools;
    private Transform platformsPosition;
    [SerializeField]
    private float distanceBetweenPlatforms = 2f;
    [SerializeField]
    private int _InitialPlatforms = 10;
    private float offsetPositionX = 0f;
    private int platformIndex = 0;


    public void Start()
    {
        platformIndex = 0;
        offsetPositionX = 0;
        InstantiatePlatforms(_InitialPlatforms);  
    }

    public void InstantiatePlatforms(int amount)
    {
        
        for (int i = 0; i < amount; i++)
        {
            List<InstantiateObject> platformsToUse = platformIndex < 2 ? safePlatformsPools : this.platformsPools;
            int randomIndex = Random.Range(0, platformsToUse.Count);
            if (offsetPositionX != 0) 
            {
                offsetPositionX += platformsToUse[randomIndex].ObjectToInstantiate.GetComponent<BoxCollider>().size.x * 0.5f;
            }
            GameObject platform = platformsToUse[randomIndex].CreateInstance();
            offsetPositionX += distanceBetweenPlatforms + platform.GetComponent<BoxCollider>().size.x * 0.5f;
            platform.transform.SetParent(transform);
            platform.transform.localPosition = new Vector3(offsetPositionX, 0,0);
            platformIndex++;
        }
    }

    public void Restart()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        Start();
    }
}
