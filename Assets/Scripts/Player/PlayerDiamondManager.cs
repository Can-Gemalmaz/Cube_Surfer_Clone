using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiamondManager : MonoBehaviour
{
    int diamondCount = 0;


    private void Start()
    {
        LoadPrefs();
    }

    public void IncreaseDiamondCount()
    {
        diamondCount += 1;
    }


    public int GetDiamondCount()
    {
        return diamondCount;
    }

    public void SetDiamondCount(int count)
    {
        diamondCount = count;
    }

    public void SavePrefs(int diamondCount)
    {
        PlayerPrefs.SetInt("int_diamondCount", diamondCount);
    }

    public void LoadPrefs()
    {
        diamondCount = PlayerPrefs.GetInt("int_diamondCount", 0);
    }


}
