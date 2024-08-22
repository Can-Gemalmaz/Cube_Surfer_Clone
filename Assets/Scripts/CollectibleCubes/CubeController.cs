using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] float maxRayDistance = 1.0f;


    PlayerCubeManager cubeManager;
    Vector3 direction = Vector3.back;
    bool isStacked = false;
    RaycastHit hit;


    void Start()
    {
        cubeManager = PlayerCubeManager.Instance;
        //cubeManager = GameObject.FindWithTag("Player").GetComponent<PlayerCubeManager>();
    }

    private void FixedUpdate()
    {
        CubeRaycast();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStacked && gameObject.tag != "Obstacle")
        {
            isStacked = true;
            cubeManager.IncreaseHeigtByCube(gameObject);
        }
    }

    private void CubeRaycast()
    {
        
        //if (Physics.Raycast(transform.position, direction, out RaycastHit hit, maxRayDistance))
        if (Physics.BoxCast(transform.position, transform.localScale / 2f, direction, out hit, Quaternion.identity, maxRayDistance))
        {
            if(gameObject.tag == "Obstacle")
            {
                // Decrase The list
                cubeManager.DecreaseHeightByCube(hit.collider.gameObject);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 center = transform.position;
        Vector3 size = new Vector3(transform.localScale.x , transform.localScale.y, -transform.localScale.z -  maxRayDistance);
        Color color = Color.white;

        Gizmos.color = color;
        Gizmos.DrawWireCube(center, size);
    }


}
