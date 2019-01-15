using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseNodesMini : MonoBehaviour
{
    public Spells spell;
    public bool activeTrigger = false;
    public string[] sphereSequence;
    public int sphereSequenceSize;
    public SphereGrid sGrid;
    public Activator1 activator;

    
    void Start()
    {
        sphereSequence = new string[sphereSequenceSize];
        ClearNodes();
    }

    void Update()
    {
        if (activator.active && activeTrigger == false)
        {
            activeTrigger = true;
        }
        if (!activator.active && activeTrigger == true)
        {
            activeTrigger = false;
            ParseSequence();
            ClearNodes();
        }
    }
    
    void ClearNodes()
    {
        for (int i = 0; i < sphereSequenceSize; i++)
        {
            sphereSequence[i] = null;
        }
    }

    int CmdLen()
    {
        int i = 0;
        
        while (i < sphereSequenceSize && sphereSequence[i] != null)
        {
           // Debug.Log(i + ": " + sphereSequence[i]);
            i++;
        }

        return i;
    }


  
    void Action3()
    {

        // Straight shot, back to front
        if (sphereSequence[0] == "back" && sphereSequence[1] == "mid" && sphereSequence[2] == "front")
        {
            spell.Cast("Ice");
        }
        // Curve shots
        else if (sphereSequence[0] == "back" && sphereSequence[1] == "left" && sphereSequence[2] == "front")
        {
            spell.Cast("Fire");
        }
        else if (sphereSequence[0] == "back" && sphereSequence[1] == "right" && sphereSequence[2] == "front")
        {
            spell.Cast("Fire");
        }
        else if (sphereSequence[0] == "back" && sphereSequence[1] == "up" && sphereSequence[2] == "front")
        {
            spell.Cast("Fire");
        }
        else if (sphereSequence[0] == "back" && sphereSequence[1] == "down" && sphereSequence[2] == "front")
        {
            spell.Cast("Fire");
        }
        // Down to up
        else if (sphereSequence[0] == "down" && sphereSequence[1] == "mid" && sphereSequence[2] == "up")
        {
            spell.Cast("Light");
        }
        // Up to down
        else if (sphereSequence[0] == "up" && sphereSequence[1] == "mid" && sphereSequence[2] == "down")
        {
            spell.Cast("Light");
        }
    }

    void Action4()
    {
        // Circle clockwise, starting from back 
        if (sphereSequence[0] == "back" && sphereSequence[1] == "left" && sphereSequence[2] == "front" && sphereSequence[3] == "right")
        {
            spell.Cast("Heal");
        }
        // Circle counterclockwise, starting from back 
        if (sphereSequence[0] == "back" && sphereSequence[1] == "right" && sphereSequence[2] == "front" && sphereSequence[3] == "left")
        {
            spell.Cast("Heal");
        }
    }

    void Action7()
    {
        if (sphereSequence[0] == "left" && sphereSequence[1] == "up" && sphereSequence[2] == "right" && sphereSequence[3] == "down" && sphereSequence[4] == "back" && sphereSequence[5] == "mid" && sphereSequence[6] == "front")
        {
            Debug.Log("Ultimate punch!!");
        }

    }

    void ParseSequence()
    {
        int len = CmdLen();

      ///Debug.Log("cmdlen: " + len);
        
        if (len >= 3)
        {
            switch (len)
            {
                case 3:
                    Action3();
                    break;
                case 4:
                    Action4();
                    break;
                case 7:
                    Action7();
                    break;
            }
        }
    }

    public void PushSphere(string id)
    {
        for (int i = 0; i < sphereSequenceSize; i++)
        {
            if (sphereSequence[i] == null)
            {
                sphereSequence[i] = id;
                break;
            }
        }
    }
}
