using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    List<int> collectedCollectibles;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        collectedCollectibles = new List<int>();
    }

    public void addCollectible(int collectNum)
    {
        collectedCollectibles.Add(collectNum);
    }

    public void CorrectCollectibles()
    {
        Collectible[] allCollectibles = FindObjectsOfType<Collectible>();
        foreach (Collectible collectible in allCollectibles)
        {
            if (collectedCollectibles.Contains(collectible.collectibleNum))
            {
                Destroy(collectible.gameObject);
            }
        }
    }
}
