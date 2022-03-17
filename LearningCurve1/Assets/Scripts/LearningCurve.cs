using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NewCharacter First_character = new NewCharacter("Robot");
        First_character.PrintStatInfo();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
