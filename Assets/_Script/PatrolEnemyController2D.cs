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
       _vx = 0;

       if (stompCheck.IsStomped)
       {
           gameObject.SetActive(false);
       }
    }
}
