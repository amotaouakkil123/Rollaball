using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private float currentMoveSpeed;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private bool booster = false;
    private float boostTime = 0;
    private bool slowDown = false;
    private float slowTime = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;

    public Collider[] cubes = new Collider[40];
    public int i = 0;

    public LayerMask groundLayers;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        currentMoveSpeed = speed;

        SetCountText();
        winTextObject.SetActive(false);
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() 
    {
        countText.text = "Counter: " + count.ToString();
        if (count >= 32) 
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (booster) {
            boostTime += Time.deltaTime;

            if (boostTime > 1) {
                speed = currentMoveSpeed;
                boostTime = 0;
                booster = false;
            }
        }

        if (slowDown) {
            slowTime += Time.deltaTime;

            if (slowTime > 1) {
                speed = currentMoveSpeed;
                slowTime = 0;
                slowDown = false;
            }
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "PickUp":
                other.gameObject.SetActive(false);
                count++;
                SetCountText();
                cubes[i] = other;
                i++;
                break;

            case "Death":
                count = 0;
                SetCountText();
                for (int k = 0; k<30; k++) {
                    cubes[k].gameObject.SetActive(true);
                }
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                break;

            case "SpeedBoost":
                booster = true;
                speed = 30;
                break;

            case "SlowDown":
                slowDown = true;
                speed = 2;
                break;
        }
    }
}
