using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�d�͂̐ݒ�
public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;


    private float verticalVelocity;

    public Vector3 Movement => Vector3.up * verticalVelocity;
    
    private void Update()
    {
        if (verticalVelocity < 0.0f && controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }
}
