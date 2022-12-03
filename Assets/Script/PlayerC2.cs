using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC2 : MonoBehaviour
{
    private Shot _shot;
    public Shot shot => _shot;

    private void Awake()
    {
        _shot = GetComponent<Shot>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && _shot.remainBullet>0)
        {
         
        }
    }
}
