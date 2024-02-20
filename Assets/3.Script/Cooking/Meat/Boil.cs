using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HeneGames.CookingSystem;

public class Boil : MonoBehaviour
{
    public Rigidbody rb;
    public HeatSource heat;
    public GameObject heatsource;
    public float floatingForce =0;
    [Range(0f, 1f)]
    [SerializeField] private float floatingDepth = 0.336f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        heatsource = GameObject.FindWithTag("Liquid");
        heat = heatsource.GetComponent<HeatSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.angularDrag = 10f;
        rb.drag = 6f;

        Vector3 _floatingPos = new Vector3(transform.position.x, heat.oilSurface.position.y, transform.position.z);
        float _surfaceDistanceMultiplier = (_floatingPos.y - transform.position.y) * 100f;
        Vector3 _force = (Vector3.up * floatingForce) * _surfaceDistanceMultiplier;

        float _offsetX = 0.1f;
        float _offsetZ = 0.1f;


        Vector3 _leftPos = transform.TransformPoint(new Vector3(_offsetX, 0f, 0f));
        Vector3 _rightPos = transform.TransformPoint(new Vector3(-_offsetX, 0f, 0f));
        Vector3 _upPos = transform.TransformPoint(new Vector3(0f, 0f, _offsetZ));
        Vector3 _downPos = transform.TransformPoint(new Vector3(0f, 0f, -_offsetZ));

        float _surfacePointYOffset = heat.oilSurface.position.y + floatingDepth;

        AddForceFromPoint(_leftPos, _floatingPos, _surfacePointYOffset, _force);
        AddForceFromPoint(_rightPos, _floatingPos, _surfacePointYOffset, _force);
        AddForceFromPoint(_upPos, _floatingPos, _surfacePointYOffset, _force);
        AddForceFromPoint(_downPos, _floatingPos, _surfacePointYOffset, _force);
    }


    private void AddForceFromPoint(Vector3 _forcePosition, Vector3 _surfacePosition, float _surfaceOffset, Vector3 _force)
    {
        if (_forcePosition.y < _surfacePosition.y)
        {
            Vector3 _surfacePoint = new Vector3(_forcePosition.x, _surfaceOffset, _forcePosition.z);
            float _leftMultiplier = Vector3.Distance(_forcePosition, _surfacePoint);
            rb.AddForceAtPosition(_force * _leftMultiplier, _forcePosition, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Liquid"))
        {
            floatingForce = 6.88f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Liquid"))
        {
            floatingForce = 0f;
        }
    }

}
