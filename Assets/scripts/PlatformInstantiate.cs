using System.Collections.Generic;
using UnityEngine;

public class PlatformInstantiate : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms;
    [SerializeField]
    private List<GameObject> safePlatforms;
    private Transform platformsPosition;
    [SerializeField]
    private float distanceBetweenPlatforms = 2f;
    [SerializeField]
    private int initialPlatforms = 10;
    private float offsetPositionX = 0f;
    private int platformIndex = 0;

    public void Start()
    {
        platformIndex = 0;
        offsetPositionX = 0;
        InstantiatePlatforms(initialPlatforms);  
    }

    public void InstantiatePlatforms(int amount)
    {
        
        for (int i = 0; i < amount; i++)
        {
            List<GameObject> platformsToUse = platformIndex < 2 ? safePlatforms : this.platforms;
            int randomIndex = Random.Range(0, platformsToUse.Count);
            if (offsetPositionX != 0) 
            {
                offsetPositionX += platformsToUse[randomIndex].GetComponent<BoxCollider>().size.x * 0.5f;
            }
                GameObject platform = Instantiate(platformsToUse[randomIndex], Vector3.zero, Quaternion.identity);
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
            Destroy(child.gameObject);
        }
        Start();
    }
}
