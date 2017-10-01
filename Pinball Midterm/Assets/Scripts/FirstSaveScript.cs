using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSaveScript : MonoBehaviour {

    private void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }

}
