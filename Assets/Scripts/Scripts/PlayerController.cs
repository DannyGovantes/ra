using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{ 
    private PlayerInput _playerInput;
    private Animator _animator;
    private readonly int HashHorizontalSpeed = Animator.StringToHash("MoveForward");
    private readonly int HashGrab = Animator.StringToHash("Grab");
    public GameObject message;

    [SerializeField]
    private bool _isInGoal;
    public bool IsInGoal{
        get => _isInGoal;
        set => _isInGoal = value;
    }
    public Vector3 velocity;

    public float speed;

    private void Start()
    {
        if (!TryGetComponent(out _playerInput))
        {
            Debug.LogWarning($"ERROR FALTA EL PLAYER INPUT");
        }
        if (!TryGetComponent(out _animator))
        {
            Debug.LogWarning($"ERROR FALTA EL ANIMATOR");
        }

        _isInGoal = true;

    }

    private void Update(){
        if(!_isInGoal) transform.position += velocity * (speed * Time.deltaTime);
    }

    public void SetWalkAnimationAnimation(bool isMoving)
    {
        _animator.SetBool(HashHorizontalSpeed, isMoving);
    }
    public void SetGrabAnimation()
    {
        _animator.SetTrigger(HashGrab);
    }

    public void PopMessage()
    {
        message.SetActive(true);
        StartCoroutine(RestartScene());

    }

    private IEnumerator RestartScene(){
        yield return  new WaitForSeconds(5.0f);
        LevelLoader.ReloadLevel();
    }


  

}
