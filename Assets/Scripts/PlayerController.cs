using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundMask;

    [SerializeField] float speed = 12;
    Vector3 vector;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Pickup")
        {
            hit.gameObject.GetComponent<Pickup>().Picked();
        }
    }

    void PlayerMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit,
            0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
                default:
                    speed = 12;
                    break;

            }
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        vector = transform.right * x + transform.forward * z;

        characterController.Move(vector * speed * Time.deltaTime);

    }
}
