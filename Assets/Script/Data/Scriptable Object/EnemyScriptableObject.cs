using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] String enemyID;

    public String EnemyID => enemyID;
}