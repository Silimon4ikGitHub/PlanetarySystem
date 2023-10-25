using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class PlanetObject : MonoBehaviour
{
    [SerializeField] private PathCreator orbit;
    [SerializeField] private float myMass;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    void Awake()
    {
        orbit = GetComponentInParent<PathCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        distance += speed * Time.deltaTime;
        transform.position = orbit.path.GetPointAtDistance(distance);
    }

    public PlanetObject(float mass)
    {
        myMass = mass;
    }
        
}
