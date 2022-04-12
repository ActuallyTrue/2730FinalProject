using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int collectibleNum;
    CollectibleManager manager;

    private void Start() {
        manager = FindObjectOfType<CollectibleManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            manager.addCollectible(collectibleNum);
            Destroy(this.gameObject);
        }    
    }
}
