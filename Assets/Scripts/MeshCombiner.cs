using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        Debug.Log(name + " is combining " + filters.Length + " mesh filters");
        Mesh finalMesh = new Mesh();
        CombineInstance[] combiners = new CombineInstance[filters.Length];

        for(int a = 0; a < filters.Length; a++){
            combiners[a].subMeshIndex = 0;
            combiners[a].mesh = filters[a].sharedMesh;
            combiners[a].transform = filters[a].transform.localToWorldMatrix;
        }

        finalMesh.CombineMeshes(combiners);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
