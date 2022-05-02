using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneInstance : MonoBehaviour
{
    public GameObject collectibleController;
    public GameObject paint1;
    public GameObject paint2;
    public GameObject paint3;
    public GameObject paint4;
    public GameObject paint5;
    public GameObject paint6;
    private List<GameObject> paintSlices = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        paintSlices.Add(paint1);
        paintSlices.Add(paint2);
        paintSlices.Add(paint3);
        paintSlices.Add(paint4);
        paintSlices.Add(paint5);
        paintSlices.Add(paint6);
        List<int> collectedCollectibles = collectibleController.GetComponent<CollectibleManager>().collectedCollectibles;
        if(collectedCollectibles.Count > 0 && collectedCollectibles.Count < 6){
            for(int i = 0; i < collectedCollectibles.Count; i++){
                paintSlices[collectedCollectibles[i]].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
    }


}
