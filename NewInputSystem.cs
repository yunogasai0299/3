using UnityEngine;

public class NewInputSystem : MotionPlayer
{
    private Controls _controls;

    protected override void Awake()
    {
        base.Awake();
        _controls = new Controls();
        
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Character.Motion.performed += callbackContext => Motion(callbackContext.ReadValue<Vector2>().x, callbackContext.ReadValue<Vector2>().y);
        _controls.Character.Motion.canceled += callbackContext => StopMotion();
        _controls.Character.Jump.started += callbackContext => Jump();
        _controls.Character.Rotation.performed += callbackContext => Rotation(callbackContext.ReadValue<float>());
        _controls.Character.Rotation.canceled += callbackContext => StopRotation();
        
        
       
    }

    private void StopMotion() => _motion.x = _motion.z = 0;

    private void StopRotation() => _rotation = 0;

    private void OnDisable() => _controls.Disable();
}
