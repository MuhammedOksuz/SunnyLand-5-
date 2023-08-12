using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public int collectNumber;
    private void Awake()
    {
        instance = this;
    }
    

}
