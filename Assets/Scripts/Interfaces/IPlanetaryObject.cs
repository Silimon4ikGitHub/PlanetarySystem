using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlanetaryObject
{
    double Mass { get; set; }
    void Move(float speed);
}
