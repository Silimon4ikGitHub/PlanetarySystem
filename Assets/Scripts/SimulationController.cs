using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationController : MonoBehaviour, ISimulationController
{
    [SerializeField] private float simulationSpeed = 1.0f;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject[] planetaryObjects;
    
    private List <IPlanetaryObject> planets = new List<IPlanetaryObject>();

    private void FixedUpdate()
    {
        if (planetaryObjects != null)
        MoveAllPlanets();
        simulationSpeed = slider.value;
    }

    public void TakeAllPlanets()
    {
        planetaryObjects = GameObject.FindGameObjectsWithTag("Planet");

        for (int i = 0; i < planetaryObjects.Length; i++)
        {
            planets.Add(planetaryObjects[i].GetComponent<IPlanetaryObject>());
        }
    }

    private void MoveAllPlanets()
    {
        for(int i = 0; i < planets.Count; i++)
        {
            if (planets[i] != null)
                planets[i].Move(simulationSpeed);
        }
    }
}
