using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnPoint : MonoBehaviour,IInteractable
{
    [SerializeField]
    private Transform _spawnPosition;
    public Transform SpawnPosition => _spawnPosition;
    public SpriteRenderer _image;
    public TMP_Text _name;
    public Color32 gizmoColor;
    public Vector3 scaleGizmo = new Vector3(1f,1f,1f);
    private PlayerController _playerController;

    private void Start(){
        _playerController = FindObjectOfType<PlayerController>();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(transform.position,scaleGizmo);

    }

    public void SetUI(Sprite sprite, string name)
    {
        this._image.sprite = sprite;
        this._name.text = name;

    }

    public void Interact(){
        _playerController.SetWalkAnimationAnimation(false);
        _playerController.SetGrabAnimation();
    }

    public Vector3 GetObjectPosition() => transform.position;
}
