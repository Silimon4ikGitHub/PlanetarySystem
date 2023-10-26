using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercurian : PlanetObject
{
    [SerializeField] private double maxMass = 0.1;
    [SerializeField] private double minMass = 0.00001;
    [SerializeField] private double maxRadius = 0.7;
    [SerializeField] private double minRadius = 0.03;
    private void Awake()
    {
        myMass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, myMass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
    }
}
