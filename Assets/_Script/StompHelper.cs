using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StompHelper : MonoBehaviour
{
    
    #region 
    bool _isStomped = false;
    public bool IsStomped { get => _isStomped; }
    #endregion

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag == "Player")
        {
            _isStomped = true;
        }
    }
    
}
