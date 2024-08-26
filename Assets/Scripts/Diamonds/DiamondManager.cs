using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DiamondManager : MonoBehaviour
{
    [SerializeField] Transform[] diamondTransforms;
    [SerializeField] ObjectPool diamondObjectPool;



    private void Start()
    {
        for (int i = 0; i < diamondTransforms.Length; i++)
        {
            GameObject diamondObject = diamondObjectPool.GetPooledObject();
            diamondObject.transform.position = diamondTransforms[i].position;
            diamondObject.SetActive(true);
        }
    }

}
