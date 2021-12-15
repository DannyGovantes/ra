using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool _clicked;
    public bool Clicked => _clicked;
    private Vector3 _mousePosition;
    public Vector3 MousePosition => _mousePosition;

    private void Update(){
        _clicked = Input.GetButtonDown("Fire1");
        _mousePosition = Input.mousePosition;
    }
}
