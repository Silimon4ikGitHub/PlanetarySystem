using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;

public class PlanetSystemFactory : MonoBehaviour, IPlanetSystemFactory
{
    [SerializeField] private double maxSystemMass;
    [SerializeField] private double restMass;
    [SerializeField] private double currnetMass;
    [SerializeField] private PlanetSystem myPlanetSystem;
    [SerializeField] private List<GameObject> planets = new List<GameObject>();
    [SerializeField] private List<GameObject> orbits = new List<GameObject>();
    [SerializeField] enum massClassEnum { Asteroidian = 1, Mercurian = 2, Subterran = 3, Terran = 4, Superterran = 5, Neptunian = 6, Jovian = 7 }
    [SerializeField] massClassEnum massClass;

    private void Awake()
    {
        myPlanetSystem = GetComponent<PlanetSystem>();
        planets = myPlanetSystem.MassClasses;
        orbits = myPlanetSystem.orbits;
        
    }
    public void CreateSystem(double mass)
    {
        restMass = mass;
        while (restMass > 0)
            {
            GameObject randomOrbit = GetRandomOrbit(orbits);
            GameObject randomPlanet = GetRandomPlanet(planets);
            var newPlanet = Instantiate(randomPlanet, randomOrbit.transform, true);
            newPlanet.GetComponent<PlanetObject>().orbit = randomOrbit.GetComponent<PathCreator>();
            restMass -= newPlanet.GetComponent<PlanetObject>().myMass;
            myPlanetSystem.myPlanets.Add(newPlanet);
            }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            {
             CreateSystem(maxSystemMass);
            }
    }

    private void GetRandomClass()
    {
        System.Random random = new System.Random();
        var values = Enum.GetValues(typeof(massClassEnum));
        var randomMassClass = (massClassEnum)values.GetValue(random.Next(values.Length));
        massClass = randomMassClass;
    }

    private GameObject GetRandomOrbit(List<GameObject> myorbits)
    {
        return myorbits[UnityEngine.Random.Range(0, myorbits.Count)];
    }
    private GameObject GetRandomPlanet(List<GameObject> myPlanets)
    {
        return myPlanets[UnityEngine.Random.Range(0, myPlanets.Count)];
    }


}
