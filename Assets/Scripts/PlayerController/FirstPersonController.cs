using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private float _translation;
    private float _strafe;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        _translation = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        _strafe = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        transform.Translate(_strafe, 0, _translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}