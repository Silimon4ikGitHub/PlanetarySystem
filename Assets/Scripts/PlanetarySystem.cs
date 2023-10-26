using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour
{
    [SerializeField] public double mySystemMass;
    [SerializeField] private double restMass;
    [SerializeField] private PlanetarySystemFactory myFactory;
    [SerializeField] public Transform[] myOrbits;
    [SerializeField] public Transform myStar;
    [SerializeField] public List<GameObject> myPlanets = new List<GameObject>();

    private void Awake()
    {
        myFactory = FindObjectOfType<PlanetarySystemFactory>();
        myStar = gameObject.GetComponentInChildren<Transform>();
        myOrbits = myStar.GetComponentsInChildren<Transform>();
        mySystemMass = myFactory.maxSystemMass;

        restMass = mySystemMass;
        while (restMass > 0)
        {
            Transform randomOrbit = GetRandom(myOrbits);
            GameObject randomPlanet = GetRandom(myFactory.massClasses);
            
            var newPlanet = Instantiate(randomPlanet, randomOrbit.transform, true);

            newPlanet.GetComponent<PlanetaryObject>().orbit = randomOrbit.GetComponent<PathCreator>();

            if (newPlanet.GetComponent<PlanetaryObject>().orbit != null)
            {
                restMass -= newPlanet.GetComponent<PlanetaryObject>().myMass;
                myPlanets.Add(newPlanet);
            }
            else
                Destroy(newPlanet);

        }
    }

    private GameObject GetRandom(List<GameObject> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    private Transform GetRandom(Transform[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

}
