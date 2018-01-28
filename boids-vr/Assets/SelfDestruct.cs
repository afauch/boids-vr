using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public float _lifeTime;
    public bool _destroy;

	void Start() {

        SetDestroy(_destroy);
	}

    public void SetDestroy(bool destroy)
    {
        if (destroy)
        {
            Destroy(this.gameObject, _lifeTime);
        }

    }

}
