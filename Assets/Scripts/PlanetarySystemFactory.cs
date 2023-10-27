using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;

public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{
    public double MaxSystemMass;
    public List<GameObject> MassClasses = new List<GameObject>();

    [SerializeField] private double restMass;
    [SerializeField] private double currnetMass;

    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private GameObject systemExample;
    [SerializeField] private List<GameObject> planetarySystems = new List<GameObject>();
    [SerializeField] private enum massClassEnum { Asteroidian = 1, Mercurian = 2, Subterran = 3, Terran = 4, Superterran = 5, Neptunian = 6, Jovian = 7 }
    [SerializeField] massClassEnum massClass;

    private void Awake()
    {
    }

    public void Create(double mass)
    {
        var newSystem = Instantiate(systemExample, transform.position, transform.rotation);
        planetarySystems.Add(newSystem);
        TakeNextPosition();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            {
                Create(100);
            }
    }
    private void TakeNextPosition()
    {
        transform.position += offsetPosition;
    }

}
