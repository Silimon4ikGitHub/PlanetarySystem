using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;

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
        ShuffleArray(ref MyOrbits);
        if (restMass > 0)
        {
            for (int i = 0; i < MyOrbits.Length; i++)
                if (restMass > 0)
                {
                    GameObject randomPlanet = GetRandom(myFactory.MassClasses);
                    var newPlanet = Instantiate(randomPlanet, MyOrbits[i].transform, true);
                    newPlanet.GetComponent<PlanetaryObject>().Orbit = MyOrbits[i].GetComponent<PathCreator>();

                    if (newPlanet.GetComponent<PlanetaryObject>().Orbit != null)
                    {
                        restMass -= newPlanet.GetComponent<IPlanetaryObject>().Mass;
                        MyPlanets.Add(newPlanet);
                    }
                    else
                        Destroy(newPlanet);
                }
        }
    }

    private void ShuffleArray(ref Transform[] array)
    {
        System.Random rand = new System.Random();
        
        for (int i = array.Length - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);

            Transform tmp = array[j];
            array[j] = array[i];
            array[i] = tmp;
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
