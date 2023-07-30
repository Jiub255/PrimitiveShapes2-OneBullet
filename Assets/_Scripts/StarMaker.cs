using System;
using System.Collections.Generic;
using UnityEngine;

public class StarMaker : MonoBehaviour
{
    [SerializeField]
    private int _starCount = 100;
    [SerializeField]
    private Vector2 _sizeRange = new Vector2(0.05f, 0.2f);
    [SerializeField]
    private GameObject _starPrefab;
    [SerializeField]
    private float _radius = 10f;
    [SerializeField]
    private float _mean;
    [SerializeField]
    private float _stdDev = 1f;

/*    [SerializeField]
    private Material _white;
    [SerializeField]
    private Material _red;
    [SerializeField]
    private Material _yellow;
    [SerializeField]
    private Material _green;
    [SerializeField]
    private Material _blue;
    [SerializeField]
    private Material _purple;
    [SerializeField]
    private Material _orange;*/
    [SerializeField]
    private MaterialChance[] _materialChances;

    [Serializable]
    private class MaterialChance
    {
        public Material Material;
        public int CumulativeOdds;
    }

    private void Start()
    {
        MakeStars();
    }

    private void MakeStars()
    {
        for (int i = 0; i < _starCount; i++)
        {
            GameObject star = Instantiate(_starPrefab, GetRandomSpherePosition(GetGaussianRandoms()), Quaternion.identity, transform);

            // Color star based on weighted odds from MaterialChance array. 
            star.GetComponent<Renderer>().material = GetRandomMaterial();

            // Randomly scale star within range. 
            star.transform.localScale = Vector3.one * GetRandomSize();
        }
    }

    private float GetRandomSize()
    {
        return UnityEngine.Random.Range(_sizeRange.x, _sizeRange.y);
    }

    private Material GetRandomMaterial()
    {
        int totalOdds = 0;
        foreach (MaterialChance materialChance in _materialChances)
        {
            totalOdds += materialChance.CumulativeOdds;
        }

        int random = UnityEngine.Random.Range(0, totalOdds) + 1;

        int cumulativeOdds = 0;
        foreach (MaterialChance materialChance in _materialChances)
        {
            cumulativeOdds += materialChance.CumulativeOdds;
            if (random <= cumulativeOdds)
            {
                return materialChance.Material;
            }
        }

        Debug.LogWarning("StarMaker.GetRandomMaterial returned null, something is wrong. ");
        return null;
    }

    private Vector3 GetRandomSpherePosition(float[] gaussians)
    {
        float normalizer = 0;
        foreach (float gaussian in gaussians)
        {
            normalizer += gaussian * gaussian;
        }
        normalizer = Mathf.Sqrt(normalizer);

        // Try again if all three are zero (highly unlikely, but still). 
        if (normalizer == 0)
        {
            MakeStars();
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                gaussians[i] /= normalizer;
                gaussians[i] *= _radius;
            }
        }

        return new Vector3(gaussians[0], gaussians[1], gaussians[2]);
    }

    private float[] GetGaussianRandoms()
    {
        float[] gaussians = new float[3];
        for (int i = 0; i < 3; i++)
        {
            gaussians[i] = GetGaussianRandom();
        }

        return gaussians;
    }

    private float GetGaussianRandom()
    {
        // Reuse this if you are generating many.
        System.Random rand = new(); 

        // Create random floats in (0,1]. 
        float u1 = 1f - (float)rand.NextDouble(); 
        float u2 = 1f - (float)rand.NextDouble();
        
        // Random normal in (0,1).
        float randStdNormal = 
            Mathf.Sqrt(-2f * Mathf.Log(u1)) *
            Mathf.Sin(2f * Mathf.PI * u2); 

        // Random normal in (mean,stdDev^2). 
        float randNormal = _mean + _stdDev * randStdNormal; 

        return randNormal;
    }
}