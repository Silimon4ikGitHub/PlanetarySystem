using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;
using TMPro;
using UnityEngine.UI;

public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{
    public double MaxSystemMass;
    public List<GameObject> MassClasses = new List<GameObject>();

    [SerializeField] private int systemsCount = 3;

    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private Vector3 firstPosition;
    [SerializeField] private GameObject systemExample;
    [SerializeField] private List<GameObject> planetarySystems = new List<GameObject>();

    public void Create(double mass)
    {
        for (int i = 0; i < systemsCount; i++)
        {
            var newSystem = Instantiate(systemExample, transform.position, transform.rotation);
            planetarySystems.Add(newSystem);
            TakeNextPosition();
        }
        gameObject.GetComponent<ISimulationController>().TakeAllPlanets();
    }

    public void CreateAll()
    {
        firstPosition = transform.position;

        for (int i = 0; i < planetarySystems.Count; i++)
        {
            Destroy(planetarySystems[i]);
        }

        planetarySystems.Clear();
        Create(MaxSystemMass);

        transform.position = firstPosition;
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
