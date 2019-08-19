/**
 * @file       : Player.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using TMPro;
using System;

namespace MTB
{

    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]

    public class Player : Entity, IDamageable, IHealable, IMovement
    {

        public bool EnableDebug;

        private Vector3 velocity;
        private CharacterController Controller => GetComponent<CharacterController>();

        private bool IsMoving => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        public Vector2 mouseSensitivity;
        float verticalLookRotation;
        private Transform PCam => transform.GetChild(0);

        public float MoveSpeed { get; set; }
        public float StrafeSpeed { get; set; }
        public float JumpHeight { get; set; }

        /** 
         * @brief   Start is called before the first frame update
         */
        private void Start()
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            MoveSpeed = 10f;
            StrafeSpeed = 7f;
            JumpHeight = 10f;

        }

        /** 
         * @brief   Update is called every frame 
         */
        private void Update()
        {
            Camera();
            Move();

        }

        /** 
         * @brief  
         */
        private void Camera()
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity.x);
            verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity.y;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
            PCam.localEulerAngles = Vector3.left * verticalLookRotation;
        }

        /** 
         * @brief  
         */
        public void Move()
        {

            float v = Input.GetAxis("Vertical") * MoveSpeed;
            float h = Input.GetAxis("Horizontal") * StrafeSpeed;

            velocity = new Vector3(h, velocity.y, v);

            velocity = transform.TransformDirection(velocity);

            if (Input.GetButtonDown("Jump") && Controller.isGrounded)
                Jump();

            velocity.y -= 20f * Time.deltaTime;

            Controller.Move(velocity * Time.deltaTime);

        }

        /** 
         * @brief   jump
         */
        public void Jump()
        {
            velocity.y = JumpHeight;
        }

        /** 
         * @brief   jump
         */
        public void Action()
        {

        }

        /** 
         * @brief   
         */
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

        /** 
         * @brief   
         */
        public void TakeDamage(DamageInfo d)
        {


        }

        /** 
         * @brief   
         */
        public void AddHealth(float h)
        {

        }

        /** 
         * @brief   
         */
        public void AddArmor(float a)
        {

        }
    }
}