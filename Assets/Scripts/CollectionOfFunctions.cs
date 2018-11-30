using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfFunctions : MonoBehaviour
{

    // all functions are stored here
    public static GraphFunction[] functions =
    {
        SineFunction,
        CosineFunction,
        Sine2DFunction,
        MultiSineFunction,
        MultiSine2DFunction
    };

    public static string[] TemplateFunctionFormula =
    {
        "f(x, t) = sin(pi(x+t))", 
        "f(x, t) = cos(pi(x+t))",
        "f(x, z, t) = (sin(pi(x+t)) + sin(pi(z+t)))/2",
        "f(x, t) = (sin(pi(x+t)) + sin(2pi(x+t))/2) * 2/3",
        "f(x, z, t) = (4(sin(pi(x+z+t/2))) + sin(pi(x+t)) + sin(2pi(z+2t))) / 5.5"
    };

    private static float pi = Mathf.PI;

    // simple sine function
    private static Vector3 SineFunction(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.z = z;
        return p;
    }

    // simple cosine function
    private static Vector3 CosineFunction(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Cos(pi * (x + t));
        p.z = z;
        return p;
    }

    // 2D sine function
    private static Vector3 Sine2DFunction(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(pi * (z + t));
        p.y *= 0.5f;
        p.z = z;
        return p;
    }

    // multiple sine function 
    private static Vector3 MultiSineFunction(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
        p.y *= 2f / 3f;
        p.z = z;
        return p;
    }

    // multiple sine2d function
    private static Vector3 MultiSine2DFunction(float x, float z, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = 4 * Mathf.Sin(pi * (x + z + t * 0.5f));
        p.y += Mathf.Sin(pi * (x + t));
        p.y += Mathf.Sin(2f * pi * (z + 2f * t)) * 0.5f;
        p.y *= 1 / 5.5f;
        p.z = z;
        return p;
    }

    //// ripple function
    //private static Vector3 RippleFunction(float x, float z, float t)
    //{
    //    Vector3 p;
    //    p.x = x;
    //    float dist = Mathf.Sqrt(x * x + z * z);
    //    p.y = Mathf.Sin(pi * (4.0f * dist - t));
    //    p.y /= 1.0f + 10 * dist;
    //    p.z = z;
    //    return p;
    //}

    //// cylinder function
    //private static Vector3 Cylinder(float u, float v, float t)
    //{
    //    Vector3 p;
    //    //float radius = 1.0f + Mathf.Sin(6f * pi * u) * 0.2f; // star shape
    //    //float radius = 1.0f + Mathf.Sin(2f * pi * v + t) * 0.2f; // sine wave cup
    //    float radius = 0.8f + Mathf.Sin(pi * (6.0f * u + 2.0f * v + t)) * 0.2f; // use both u and v
    //    p.x = radius * Mathf.Sin(pi * u);
    //    p.y = v;
    //    p.z = radius * Mathf.Cos(pi * u);
    //    return p;
    //}

    //// sphere fundtion
    //private static Vector3 Sphere(float u, float v, float t)
    //{
    //    Vector3 p;
    //    float radius = 0.8f + Mathf.Sin(pi * (6.0f * u + t)) * 0.1f;
    //    radius += Mathf.Sin(pi * (4.0f * v + t)) * 0.1f;
    //    float s = radius * Mathf.Cos(pi * 0.5f * v);
    //    p.x = s * Mathf.Sin(pi * u);
    //    p.y = radius * Mathf.Sin(pi * v * 0.5f);
    //    p.z = s * Mathf.Cos(pi * u);
    //    return p;
    //}

    //// torus function
    //private static Vector3 Torus(float u, float v, float t)
    //{
    //    Vector3 p;
    //    float r1 = 0.65f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
    //    float r2 = 0.2f + Mathf.Sin(pi * (4f * v + t)) * 0.05f;
    //    float s = r2 * Mathf.Cos(pi * v) + r1;
    //    p.x = s * Mathf.Sin(pi * u);
    //    p.y = r2 * Mathf.Sin(pi * v);
    //    p.z = s * Mathf.Cos(pi * u);
    //    return p;
    //}
}