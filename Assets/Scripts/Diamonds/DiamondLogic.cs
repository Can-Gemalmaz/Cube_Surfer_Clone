using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondLogic : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerDiamondManager playerDiamondManager = other.gameObject.GetComponentInParent<PlayerDiamondManager>();

            if (playerDiamondManager != null)
            {
                playerDiamondManager.IncreaseDiamondCount();
                gameObject.SetActive(false);
            }

        }
    }

}
