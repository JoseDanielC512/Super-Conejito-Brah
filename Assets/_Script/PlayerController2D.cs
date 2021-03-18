/*
Descripcion: Clase base para definir el comportamiento de los actores del juego
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2D : GameActorController
{

    #region Private Properties
    
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        // Implementar el movimiento del personaje

        //1. obtener el input en x
        _vx = Input.GetAxisRaw("Horizontal");
        

        //2. obtener el input en y
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isJumping = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (_vy > 0)
                _vy = 0;
            _isJumping = false;        
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.UpdateLives(-1);
        }
    }
}
