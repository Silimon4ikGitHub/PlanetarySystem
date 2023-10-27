using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terran : PlanetaryObject
{
    [SerializeField] private double maxMass = 2;
    [SerializeField] private double minMass = 0.5;
    [SerializeField] private double maxRadius = 1.9;
    [SerializeField] private double minRadius = 0.8;
    private void Awake()
    {
        Mass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, Mass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
        massClass.Equals(massClassEnum.Terran);
        myMass = Mass;
    }
}
