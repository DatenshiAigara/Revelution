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

    InputAction controls;

    public CharacterController2D controller;
    public Animator animate;

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

        //Left = InputSystem.actions.FindAction("Left");

        current = time;

        /*Left.performed += ctx => Left();
        controls.Gameplay.Left.canceled += ctx => Off();
        controls.Gameplay.Right.performed += ctx => Right();
        controls.Gameplay.Right.canceled += ctx => Off();
        controls.Gameplay.Run.performed += ctx => RunOn();
        controls.Gameplay.Run.canceled += ctx => RunOff();
        controls.Gameplay.Jump.performed += ctx => Jump();
        controls.Gameplay.Esc.performed += ctx => Pause();
        controls.Gameplay.Down.started += ctx => CrouchOn();
        controls.Gameplay.Down.canceled += ctx => CrouchOff();*/
    }

    void Off()
    {
        horizontalmove = 0;
        animate.SetBool("Move", false);
    }

    void Left()
    {
        horizontalmove = -1 * speed;
        animate.SetBool("Move", true);
    }

    void Right()
    {
        horizontalmove = 1 * speed;
        animate.SetBool("Move", true);
    }

    void RunOn()
    {
        move = horizontalmove;
        horizontalmove = horizontalmove * 2f;
        animate.SetBool("Move", true);
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
        SceneManager.LoadScene("Game-Over");
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}