using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    public double MySystemMass;
    public Transform[] MyOrbits;
    public Transform MyStar;
    public List<GameObject> MyPlanets = new List<GameObject>();

    [SerializeField] private double restMass;
    [SerializeField] private PlanetarySystemFactory myFactory;


    private void Awake()
    {
        myFactory = FindObjectOfType<PlanetarySystemFactory>();
        MyStar = gameObject.GetComponentInChildren<Transform>();
        MyOrbits = MyStar.GetComponentsInChildren<Transform>();
        MySystemMass = myFactory.MaxSystemMass;

        restMass = MySystemMass;

        CreatePlanets();
    }
    private void CreatePlanets()
    {
        while (restMass > 0)
        {
            Transform randomOrbit = GetRandom(MyOrbits);
            GameObject randomPlanet = GetRandom(myFactory.MassClasses);

            var newPlanet = Instantiate(randomPlanet, randomOrbit.transform, true);

            newPlanet.GetComponent<PlanetaryObject>().Orbit = randomOrbit.GetComponent<PathCreator>();

            if (newPlanet.GetComponent<PlanetaryObject>().Orbit != null)
            {
                restMass -= newPlanet.GetComponent<IPlanetaryObject>().MyMass;
                MyPlanets.Add(newPlanet);
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
