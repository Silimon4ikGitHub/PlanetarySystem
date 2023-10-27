using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jovian : PlanetaryObject
{
    [SerializeField] private double maxMass = 5000;
    [SerializeField] private double minMass = 50;
    [SerializeField] private double maxRadius = 27;
    [SerializeField] private double minRadius = 3.5;
    private void Awake()
    {
        MyMass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, MyMass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
    }
}
