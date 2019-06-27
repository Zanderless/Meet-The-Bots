using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[DisallowMultipleComponent]
public class Player : Entity, IDamageable, IHealable
{

    private float MoveSpeed => 10f;
    private float StrafeSpeed => 7f;
    private float JumpHeight => 2500;
    private float Gravity => 20f;
    private float MaxVelocityChange => 10f;

    private bool IsGrounded => CheckGrounded();

    public bool showPlayerDebugStats;

    private Vector3 velocity;
    private Rigidbody RB => GetComponent<Rigidbody>();
    private CapsuleCollider Col => GetComponent<CapsuleCollider>();

    private bool IsMoving => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

    public Vector2 mouseSensitivity;
    float verticalLookRotation;
    private Transform PCam => transform.GetChild(0);

    //Amount of times the player can dash, after the first dash starts
    //A short timer will refil the first dash before restarting
    private int dashAmount = 3;
    public GameObject[] dashIcons;
    private float dashForce = 2500f;

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

    private void FixedUpdate()
    {
        Movement();
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

        velocity = new Vector3(h, RB.velocity.y, v);
        velocity = transform.TransformDirection(velocity);

        Vector3 velocityChange = (velocity - RB.velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocityChange, MaxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocityChange, MaxVelocityChange);
        velocityChange.y = 0;
        RB.AddForce(velocityChange, ForceMode.VelocityChange);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            RB.AddForce(transform.up * Mathf.Sqrt(JumpHeight * 2 * Gravity), ForceMode.Acceleration);
        }

        Dash();

    }

    private void Dash()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashAmount > 0 && IsMoving)
        {
            dashAmount--;
            var moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            RB.AddForce(moveDir * dashForce * 2, ForceMode.Acceleration);
            Invoke("RechargeDash", 3);
        }

        dashIcons[0].SetActive(dashAmount > 0);
        dashIcons[1].SetActive(dashAmount > 1);
        dashIcons[2].SetActive(dashAmount > 2);

    }

    private void RechargeDash()
    {
        dashAmount++;
    }

    private bool CheckGrounded()
    {

        float halfHeight = Col.height / 2;
        var bottomPos = new Vector3(transform.position.x, transform.position.y - halfHeight, transform.position.z);

        Collider[] cols = Physics.OverlapBox(bottomPos, new Vector3(0.075f, 0.1f, 0.075f));

        return cols.Length > 1;

    }

    private void OnGUI()
    {

        GUIStyle style = new GUIStyle();
        style.fontSize = 15;
        style.normal.textColor = Color.white;

        if (showPlayerDebugStats)
        {
            GUI.Label(new Rect(10, 5, 100, 20), "Player Debug Stats", style);

            var vel = new Vector3(RB.velocity.x, 0, RB.velocity.z);
            float horiSpeed = vel.magnitude;
            GUI.Label(new Rect(10, 25, 100, 20), "XZ Speed: " + Mathf.RoundToInt(horiSpeed).ToString() + " m/s", style);

            GUI.Label(new Rect(10, 65, 100, 20), "Y Speed: " + Mathf.RoundToInt(RB.velocity.y).ToString(), style);

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
