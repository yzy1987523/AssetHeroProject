using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianRandom : MonoBehaviour
{
    public int seed = 61829450;
    double sum = 0;
    long r = 0;
  
    void Update()
    {
        if (Time.frameCount % 7 == 0)
        {
            //       seed = 61829450;  
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                long holdseed = seed;
                seed ^= seed << 13;
                seed ^= seed >> 17;
                seed ^= seed << 5;
                r = holdseed + seed;
                sum += (double)r * (1.0 / 0x7FFFFFFFFFFFFFFF);
            }
            print(sum); //returns [-3.0, 3.0] at (66.7%, 95.8%, 100%)  
        }
    }

}
