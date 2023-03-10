using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Fish
//Inherits from base class "Fish" INHERITANCE
{
    [SerializeField] private AudioSource tagNoise;
    protected override void AdditionalOnTagged()
    {
        //adding virtual method for override-able additional effects on projectile hit. POLYMORPHISM
        //Do extra stuff for the Shark
        tagNoise.Play();
        Debug.Log("I say, we seem to have tagged a Shark!");
    }
}
