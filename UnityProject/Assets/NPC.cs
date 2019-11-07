using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string 對話="我沒電了，請幫我充電";
    public float 對話速度 = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(對話);
    }
    
    // Update is called once per frame
    void Update()
    {
        

    }
}
