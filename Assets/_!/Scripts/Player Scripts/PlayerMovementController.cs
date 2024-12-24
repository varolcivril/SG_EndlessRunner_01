using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _strafeSpeed = 5f;

    private float horizontalInput;
    private float strafeMax;

    private void FixedUpdate()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime, Space.Self);

        //horizontalInput = Input.GetAxisRaw("Horizontal");
        //strafeMax = Mathf.Clamp(strafeMax, transform.position.x - 5f, transform.position.x + 5f);

        if ((transform.position.x > -6.9f) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(Vector3.left * _strafeSpeed * Time.deltaTime);
        }
        else if ((transform.position.x < 7.1f) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(Vector3.right * _strafeSpeed * Time.deltaTime);
        }
    }

    
}
