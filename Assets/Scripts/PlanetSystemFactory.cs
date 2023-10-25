using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystemFactory : MonoBehaviour
{
    [SerializeField] private float maxMass;
    [SerializeField] private float restMass;
    [SerializeField] private List<PlanetObject> planets = new List<PlanetObject>();


    private void CreateSystem()
    {
            while (restMass < 0)
            {
                //random 0.00001 - 5
                //planets.Add(new PlanetObject(random));
                planets.Add(new PlanetObject(100));
                //restMass -= random
            }
    }
}
