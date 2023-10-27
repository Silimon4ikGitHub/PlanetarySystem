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
        Mass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, Mass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
        massClass.Equals(massClassEnum.Jovian);
        myMass = Mass;
    }
}
