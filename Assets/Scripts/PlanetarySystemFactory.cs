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
    [SerializeField] public double maxSystemMass;
    [SerializeField] private double restMass;
    [SerializeField] private double currnetMass;
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private GameObject systemExample;
    [SerializeField] public List<GameObject> massClasses = new List<GameObject>();
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
                Create(maxSystemMass);
            }
    }
    private void TakeNextPosition()
    {
        transform.position += offsetPosition;
    }

}
