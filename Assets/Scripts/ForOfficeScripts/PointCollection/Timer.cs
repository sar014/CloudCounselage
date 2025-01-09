using UnityEngine;

public class Timer
{
   public float GetRandomInterval(float min,float max)
   {
        return UnityEngine.Random.Range(min,max);
   }
}
