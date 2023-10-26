using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neptunian : PlanetaryObject
{
    [SerializeField] private double maxMass = 50;
    [SerializeField] private double minMass = 10;
    [SerializeField] private double maxRadius = 5.7;
    [SerializeField] private double minRadius = 2.1;
    private void Awake()
    {
        myMass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, myMass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
    }
}
