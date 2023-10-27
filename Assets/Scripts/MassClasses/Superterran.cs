using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superterran : PlanetaryObject
{
    [SerializeField] private double maxMass = 10;
    [SerializeField] private double minMass = 2;
    [SerializeField] private double maxRadius = 3.3;
    [SerializeField] private double minRadius = 1.3;
    private void Awake()
    {
        Mass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, Mass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
        massClass.Equals(massClassEnum.Superterran);
        myMass = Mass;
    }
}
