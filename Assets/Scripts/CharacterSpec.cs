using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Character", menuName = "New/Character Traits")]
public class CharacterSpec : ScriptableObject
{
    public Material ObjectMaterial;
    public float Size;
}
