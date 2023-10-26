using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;
using Unity.VisualScripting;

public class PlanetaryObject : MonoBehaviour
{
    [SerializeField] public PathCreator orbit;
    [SerializeField] public double myMass;
    [SerializeField] protected double myRadius;
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    [SerializeField] protected double minScale = 0.5f;
    [SerializeField] protected double maxScale = 2.0f;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(orbit != null)
        {
            distance += speed * Time.deltaTime;
            transform.position = orbit.path.GetPointAtDistance(distance);
        }

    }

    public double GetRandomMass(double lowerBound, double upperBound)
    {
        System.Random random = new System.Random();
        var rDouble = random.NextDouble();
        var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
        return (rRangeDouble);
    }

    protected double Interpolate(double Xmin, double Xmax, double Ymin, double Ymax, double Xvalue)
    {
        return Ymin + (Xvalue - Xmin) / (Xmax - Xmin) * (Ymax - Ymin);
    }

    protected void ChangeScaleByRadius(double radius)
    {
            float radiusF = (float)radius;
            transform.localScale = new Vector3(radiusF, radiusF, radiusF);
    }

}
