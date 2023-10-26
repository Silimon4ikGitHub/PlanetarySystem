using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superterran : PlanetObject
{
    [SerializeField] private double maxMass = 10;
    [SerializeField] private double minMass = 2;
    [SerializeField] private double maxRadius = 3.3;
    [SerializeField] private double minRadius = 1.3;
    private void Awake()
    {
        myMass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, myMass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
    }
}
