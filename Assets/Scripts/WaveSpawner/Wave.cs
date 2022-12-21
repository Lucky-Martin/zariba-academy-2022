using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public int enemyCount;
}
