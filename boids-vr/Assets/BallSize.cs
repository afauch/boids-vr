using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BallSize : MonoBehaviour {

    float _baseScale;
    float _squeezedScale;
    public float _squeezeFactor = 0.4f;

	// Use this for initialization
	void Start () {

        _baseScale = this.gameObject.transform.lossyScale.x;
        _squeezedScale = _squeezeFactor * _baseScale;
        VRTK.VRTK_SDKManager.instance.scriptAliasRightController.GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += OnTriggerAxisChanged;


	}

    private void OnTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

        float lerpedScale = Mathf.Lerp(_baseScale, _squeezedScale, e.buttonPressure);
        this.gameObject.transform.SetGlobalScale(new Vector3(lerpedScale, lerpedScale, lerpedScale));

    }
}

