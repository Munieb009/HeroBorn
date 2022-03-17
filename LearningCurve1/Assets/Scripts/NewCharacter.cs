using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacter : Character // New Character is a Character
{
    private string name;

    public NewCharacter()
    {
        this.name = "Robot";
    }

    public NewCharacter(string name)
    {
        this.name = name;
    }
    // Method Overloading --> in the same class, same name of the methods but different number / type of paramters
    public void printData()
    {
        Debug.Log("This name of the character is " + name);
    }
    public void printData(string name)
    {
        Debug.Log("This name of the character is " + name);
    }

    // Method Overriding --> different class (Parent/ Child classes)
    // Polymorphism --> Many forms --> one method is acting differently in every class
    //

    public override void PrintStatInfo()
    {
        Debug.Log("This name of the character is " + name);

    }
}
