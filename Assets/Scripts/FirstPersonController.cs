using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 4.5f;
    public float gravity = -20f;

    [Header("Look")]
    public Transform cameraTransform;
    public float mouseSensitivity = 2.0f;
    public float pitchLimit = 85f;

    [Header("Flashlight")]
    public Light flashlight;
    public KeyCode flashlightKey = KeyCode.F;

    private CharacterController _cc;
    private float _pitch;
    private Vector3 _vel;

    void Awake()
    {
        _cc = GetComponent<CharacterController>();
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Look
        float mx = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float my = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mx, 0f);
        _pitch = Mathf.Clamp(_pitch - my, -pitchLimit, pitchLimit);
        cameraTransform.localEulerAngles = new Vector3(_pitch, 0f, 0f);

        // Move
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 move = (transform.right * h + transform.forward * v);
        move = Vector3.ClampMagnitude(move, 1f) * moveSpeed;

        if (_cc.isGrounded && _vel.y < 0f) _vel.y = -2f;
        _vel.y += gravity * Time.deltaTime;

        _cc.Move((move + _vel) * Time.deltaTime);

        // Flashlight
        if (flashlight != null && Input.GetKeyDown(flashlightKey))
            flashlight.enabled = !flashlight.enabled;
    }
}