using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just a simple timer that has its Value tracked
public class Timer
{
    Register value;
    float maxTime;
    public void Reset()
    {
        value.reset();
    }
    public void Update()
    {
        if (maxTime <= value.value)
        {
            return;
        }
        else
        {
            value.setValue(Time.deltaTime);
        }

    }



    public class Builder
    {
        Timer obj;

        public Builder()
        {
            obj = new Timer();
        }


    }
}
