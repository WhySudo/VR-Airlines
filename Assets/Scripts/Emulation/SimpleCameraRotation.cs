using UnityEngine;

namespace Test
{
    public class SimpleCameraRotation : MonoBehaviour
    {
        [Header("Vertical")] 
        [SerializeField] private KeyCode lookDown;
        [SerializeField] private KeyCode lookUp;
        [SerializeField] private Vector3 verticalAxis;
        [SerializeField] private float verticalSpeed;
        
        [Header("Horizontal")] 
        [SerializeField] private KeyCode lookLeft;
        [SerializeField] private KeyCode lookRight;
        [SerializeField] private Vector3 horizontalAxis;
        [SerializeField] private float horizontalSpeed;

        private void Update()
        {
            var horizontalRot = 0f;
            var verticalRot = 0f;
            if (Input.GetKey(lookLeft))
            {
                horizontalRot -= 1;
            }

            if (Input.GetKey(lookRight))
            {
                horizontalRot += 1;
            }
            if (Input.GetKey(lookUp))
            {
                verticalRot -= 1;
            }

            if (Input.GetKey(lookDown))
            {
                verticalRot += 1;
            }
            transform.Rotate(horizontalAxis, horizontalSpeed*Time.deltaTime*horizontalRot);
            transform.Rotate(verticalAxis, verticalSpeed*Time.deltaTime*verticalRot);
        }
    }
}