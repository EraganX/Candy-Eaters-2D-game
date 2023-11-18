using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxBoundary = 5f;
    [SerializeField] private float _speed = 5f;
    float _possitionX;
    public bool canmove = true;

    private void Start()
    {
       
    }
    private void Update()
    {
        if (canmove)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += Vector3.right * _speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        _possitionX = Mathf.Clamp(transform.position.x, -_maxBoundary, _maxBoundary);
        transform.position = new Vector3(_possitionX, transform.position.y, transform.position.z);
    }
}
