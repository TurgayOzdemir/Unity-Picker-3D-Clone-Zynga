using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    [SerializeField] private GameObject[] characterCube;
    [SerializeField] private CharacterSpec[] characterSpec;

    private bool _characterSelection=true;
    
    void Update()
    {
        if (_characterSelection)
        {
            foreach (var character in characterCube)
            {
                character.GetComponent<MeshRenderer>().material = characterSpec[0].ObjectMaterial;
            }

            gameObject.transform.localScale = new Vector3(characterSpec[0].Size, characterSpec[0].Size, characterSpec[0].Size);
        }
        else
        {
            foreach (var character in characterCube)
            {
                character.GetComponent<MeshRenderer>().material = characterSpec[1].ObjectMaterial;
            }

            gameObject.transform.localScale = new Vector3(characterSpec[1].Size, characterSpec[1].Size, characterSpec[1].Size);
        }


    }

    public void setCharacterSelection(bool newValue)
    {
        _characterSelection = newValue;
    }


}
