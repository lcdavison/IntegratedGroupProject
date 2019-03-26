using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    [SerializeField]
    private Building building_data;

    public Building GetData()
    {
        return building_data;
    }
}
