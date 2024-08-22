using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI diamondCountText;


    private void Start()
    {
        
    }

    private void Update()
    {
        PlayerDiamondManager playerDiamondManager = PlayerCubeManager.Instance.GetComponent<PlayerDiamondManager>();

        if(playerDiamondManager != null)
        {
            diamondCountText.text = ("Diamond Count: " + playerDiamondManager.GetDiamondCount());
        }

    }

}
