////Credit Brackeys
//Link: https://www.youtube.com/watch?v=dwcT-Dch0bA
//This is not the original from th video. It has been modified to work with new movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    PlayerControls controls;

    public CharacterController2D controller;
    //public Animator animate;

    public float speed = 0f;
    public float time = 0f;
    private float current;
    private float move;

    float horizontalmove = 0f;

    bool jump = false;
    bool crouch = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        current = time;

        controls.Player.Left.performed += ctx => Left();
        controls.Player.Left.canceled += ctx => Off();
        controls.Player.Right.performed += ctx => Right();
        controls.Player.Right.canceled += ctx => Off();
        //controls.Gameplay.Run.performed += ctx => RunOn();
        //controls.Gameplay.Run.canceled += ctx => RunOff();
        controls.Player.Jump.performed += ctx => Jump();
        //controls.Gameplay.Esc.performed += ctx => Pause();
        controls.Player.Down.started += ctx => CrouchOn();
        controls.Player.Down.canceled += ctx => CrouchOff();
    }

    void Off()
    {
        horizontalmove = 0;
        //animate.SetBool("Move", false);
    }

    void Left()
    {
        horizontalmove = -1 * speed;
        debug.log("Left");
        //animate.SetBool("Move", true);
    }

    void Right()
    {
        horizontalmove = 1 * speed;
        console.writeline("Right");
        //animate.SetBool("Move", true);
    }

    void RunOn()
    {
        move = horizontalmove;
        horizontalmove = horizontalmove * 2f;
        //animate.SetBool("Move", true);
    }

    void RunOff()
    {
        horizontalmove = move;
    }

    void Jump()
    {
        jump = true;
    }

    void CrouchOn()
    {
        crouch = true;
    }

    void CrouchOff()
    {
        crouch = false;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Pause()
    {
        //SceneManager.LoadScene("Game-Over");
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}