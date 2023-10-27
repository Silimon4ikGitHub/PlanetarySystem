using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    public double MyMass { get; set; }
    public PathCreator Orbit;
    
    [SerializeField] protected double myRadius;
    [SerializeField] protected double minScale = 0.5f;
    [SerializeField] protected double maxScale = 2.0f;
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    void Update()
    {
        Move();
    }
    public double GetRandomMass(double lowerBound, double upperBound)
    {
        System.Random random = new System.Random();
        var rDouble = random.NextDouble();
        var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
        return (rRangeDouble);
    }

    private void Move()
    {
        if(Orbit != null)
        {
            distance += speed * Time.deltaTime;
            transform.position = Orbit.path.GetPointAtDistance(distance);
        }

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
