/*
Descripcion: Clase base para definir el comportamiento de los actores del juego
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2D : GameActorController
{

    #region Private Properties
    [SerializeField] GameObject BulletPrefab;
    private float LastShoot;
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
        
        //_vx = Input.GetAxisRaw("Horizontal");
        _vx = Mathf.CeilToInt(Mathf.Abs(Input.GetAxisRaw("Horizontal"))) * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
        

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

        if (Input.GetButtonDown("Fire1") && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }else if (Input.GetButtonUp("Fire1")){
            _isShooting = false;
        }
        _animator.SetBool("IsShooting", _isShooting);        
        
    }

    private void Shoot()
    {
        _isShooting = true;
        Vector3 direction;
        if (transform.localScale.x == _vx)
        {
            direction = Vector2.right;
        }else
        {
            direction = Vector2.left;
        }
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.UpdateLives(-1);
        }
    }
}
