﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using TMPro;
using System;

[RequireComponent(typeof(CharacterController))]
[DisallowMultipleComponent]
public class Player : Entity, IDamageable, IHealable
{

    private float MoveSpeed => 10f;
    private float StrafeSpeed => 7f;
    private float JumpHeight => 8f;
    private float Gravity => 20f;

    public bool EnableDebug;

    private Vector3 velocity;
    private CharacterController Controller => GetComponent<CharacterController>();

    private bool IsMoving => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

    public Vector2 mouseSensitivity;
    float verticalLookRotation;
    private Transform PCam => transform.GetChild(0);

    //UI
    public ProceduralImage healthUI;
    public ProceduralImage armorUI;
    public TextMeshProUGUI healthTxt;

    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Health = maxHealth;

    }

    private void Update()
    {
        Camera();
        Movement();

        healthUI.fillAmount = Mathf.Lerp(healthUI.fillAmount, Health / maxHealth, Time.deltaTime * 3);
        armorUI.fillAmount = Mathf.Lerp(armorUI.fillAmount, Armor / maxArmor, Time.deltaTime * 3);
        healthTxt.text = Health.ToString("000");

        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.PageDown))
                TakeDamage(5);
            else if (Input.GetKeyDown(KeyCode.PageUp))
                AddHealth(5);
        }

    }

    private void Camera()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity.x);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity.y;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        PCam.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    private void Movement()
    {

        float v = Input.GetAxis("Vertical") * MoveSpeed;
        float h = Input.GetAxis("Horizontal") * StrafeSpeed;

        velocity = new Vector3(h, velocity.y, v);

        velocity = transform.TransformDirection(velocity);
        
        if (Input.GetButtonDown("Jump") && Controller.isGrounded)
            Jump();

        velocity.y -= Gravity * Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime);

    }

    private void Jump()
    {
        velocity.y = JumpHeight;
    }

    private void OnGUI()
    {

        GUIStyle style = new GUIStyle();
        style.fontSize = 15;
        style.normal.textColor = Color.white;

        if (EnableDebug)
        {
            GUI.Label(new Rect(10, 5, 100, 20), "Player Debug Stats", style);

            var vel = new Vector3(velocity.x / MoveSpeed, 0, velocity.z / StrafeSpeed);
            float horiSpeed = vel.magnitude;
            GUI.Label(new Rect(10, 25, 100, 20), "XZ Speed: " + Mathf.RoundToInt(horiSpeed).ToString() + " m/s", style);

            GUI.Label(new Rect(10, 65, 100, 20), "Y Speed: " + Mathf.RoundToInt(velocity.y).ToString(), style);

            GUI.Label(new Rect(10, 45, 100, 20), "Position: " + transform.position.ToString(), style);


        }
    }

    public void TakeDamage(float d)
    {
        
        if(Armor > 0)
        {
            if (Armor < d)
            {
                float diff = d - Armor;
                Armor = 0;
                Health -= diff;
            }
            else
                Armor -= d;
        }
        else
        {
            Health -= d;
        }

    }

    public void AddHealth(float h)
    {
        Health += h;
    }

    public void AddArmor(float a)
    {
        Armor += a;
    }
}