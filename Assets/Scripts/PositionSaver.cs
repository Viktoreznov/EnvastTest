using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PositionSaver : MonoBehaviour
{
    public Vector3 initialPosition;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        initialPosition = transform.position;
        transform.SetAsFirstSibling();
    }


    public void reset(){
        transform.position = initialPosition;
    }
}
