using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidian : PlanetaryObject
{
    [SerializeField] private double maxMass = 0.00001;
    [SerializeField] private double minMass = 0;
    [SerializeField] private double maxRadius = 0.003;
    [SerializeField] private double minRadius = 0;
    private void Awake()
    {
        Mass = GetRandomMass(minMass, maxMass);
        myRadius = Interpolate(minMass, maxMass, minRadius, maxRadius, Mass);
        ChangeScaleByRadius(Interpolate(minRadius, maxRadius, minScale, maxScale, myRadius));
        massClass.Equals(massClassEnum.Asteroidian);
        myMass = Mass;
    }
}
