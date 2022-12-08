using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ustawienie obiektu w pozycji (0, 0, 0)
        // transform.position = new Vector3(2.0f, 1.0f, 2.0f);
    }

    private float movedTotal = 0f;
    private float unitsMoved = 1f;
    public float howManyBlocks = 1f;
    public int course = 1;
    

    private bool invert = false;

    // Update is called once per frame
    void Update()
    {
        if (movedTotal < howManyBlocks)
        {
            unitsMoved = 1f * Time.deltaTime;
            if ((movedTotal += unitsMoved) > howManyBlocks)
            {
                unitsMoved = howManyBlocks - movedTotal;
            }

            if (invert)
            {
                unitsMoved *= -1;
            }
            switch (course) 
            {
                case 1:
                    transform.Translate( 0f,unitsMoved, 0f);
                    break;
                case 2:
                    transform.Translate( 0f,-unitsMoved, 0f);
                    break;
                case 3:
                    transform.Translate(unitsMoved, 0f, 0f);
                    break;
                case 4:
                    transform.Translate(-unitsMoved, 0f, 0f);
                    break; 
                case 5:
                    transform.Translate( 0f,0f, unitsMoved);
                    break;
                case 6:
                    transform.Translate( 0f,0f, -unitsMoved);
                    break;
                
            }
        }
        else
        {
            movedTotal = 0f;
            invert = !invert;
        }
    }
}