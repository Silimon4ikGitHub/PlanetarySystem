using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subterran : PlanetaryObject
{
    [SerializeField] private double maxMass = 0.5;
    [SerializeField] private double minMass = 0.1;
    [SerializeField] private double maxRadius = 1.2;
    [SerializeField] private double minRadius = 0.5;
    private void Awake()
    {
        Mass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, Mass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
        massClass.Equals(massClassEnum.Subterran);
        myMass = Mass;
    } 
}
