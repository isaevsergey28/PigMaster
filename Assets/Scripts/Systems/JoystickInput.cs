using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    public float HorizontalInput
    {
        get { return _horizontalInput; }
    }
    public float VerticalInput
    {
        get { return _verticalInput; }
    }

    private float _verticalInput;
    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = _joystick.Horizontal * Time.deltaTime;
        _verticalInput = _joystick.Vertical * Time.deltaTime;
    }
}