using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController2D : GameActorController
{
    #region Inspector Properties
    [SerializeField] StompHelper stompCheck;
        
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
       base.Update();
       _vx = -1;

       if (stompCheck.IsStomped)
       {
           gameObject.SetActive(false);
       }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            if (_vx == -1)
            {
                _vx = 1;
            }else if (_vx == 1)
            {
                _vx = -1;
            }
        }
    }
}
