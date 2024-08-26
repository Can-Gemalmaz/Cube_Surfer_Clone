using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeManager : MonoBehaviour
{
    //public static PlayerCubeManager Instance;

    public event Action OnPlayerDead;

    [SerializeField] float cubeHeight;


    List<GameObject> cubeList = new List<GameObject>();

    GameObject lastCubeObject;

    /*private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }*/

    void Start()
    {
        cubeList.Add(gameObject);
        UpdateLastCubeObject();
    }

    
    void Update()
    {
        
    }


    public void IncreaseHeigtByCube(GameObject cubeGameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + cubeHeight, transform.position.z);
        cubeGameObject.transform.position = new Vector3(lastCubeObject.transform.position.x, lastCubeObject.transform.position.y - cubeHeight, lastCubeObject.transform.position.z);
        cubeGameObject.transform.SetParent(transform);
        cubeList.Add(cubeGameObject);
        UpdateLastCubeObject();
    }

    public void DecreaseHeightByCube(GameObject cubeGameObject)
    {
        cubeGameObject.transform.parent = null;
        if (cubeGameObject == gameObject)
        {
            //PayerDead
            OnPlayerDead?.Invoke();
            return;
        }
        cubeList.Remove(cubeGameObject);
        UpdateLastCubeObject();
    }

    private void UpdateLastCubeObject()
    {
        lastCubeObject = cubeList[cubeList.Count - 1];
    }


}
