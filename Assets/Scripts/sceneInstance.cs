using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneInstance : MonoBehaviour
{

    public GameObject paint1;
    public GameObject paint2;
    public GameObject paint3;
    public GameObject paint4;
    public GameObject paint5;
    public GameObject paint6;
    public GameObject finalPaint;
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
        CollectibleManager reference = FindObjectOfType<CollectibleManager>();
        List<int> collectedCollectibles = reference.collectedCollectibles;
        if(collectedCollectibles.Count > 0 && collectedCollectibles.Count < 6){
            for(int i = 0; i < collectedCollectibles.Count; i++){
                paintSlices[collectedCollectibles[i] - 1].GetComponent<MeshRenderer>().enabled = true;
            }
        }else if(collectedCollectibles.Count == 6){
            finalPaint.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }


}
