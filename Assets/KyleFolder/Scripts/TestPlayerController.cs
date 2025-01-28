using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] public float speed;
    private float _horizontalInput;
    private float _verticalInput;

    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    
        transform.Translate(Vector2.up * (Time.deltaTime * _verticalInput * speed));
        transform.Translate(Vector2.right * (Time.deltaTime * _horizontalInput * speed));
    }
}
