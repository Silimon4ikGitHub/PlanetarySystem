using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercurian : PlanetaryObject
{
    [SerializeField] private double maxMass = 0.1;
    [SerializeField] private double minMass = 0.00001;
    [SerializeField] private double maxRadius = 0.7;
    [SerializeField] private double minRadius = 0.03;
    private void Awake()
    {
        Mass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, Mass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
        massClass.Equals(massClassEnum.Mercurian);
    }
}
