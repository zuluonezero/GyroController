using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedCoding.Observer
{
    public class ToggleTurbo : MonoBehaviour
    {

        public bool _isTurboOn;
        private Vector3 _initialPosition;
        private float _shakeMagnitude = 0.8f;

        void OnEnable()
        {
            _initialPosition = gameObject.transform.localPosition;
        }

        public void TurboSwitch()
        {
            _isTurboOn = ! _isTurboOn;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isTurboOn)
            {
                gameObject.transform.localPosition = _initialPosition + (Random.insideUnitSphere * _shakeMagnitude);
                Time.timeScale = 3f;
            }
            else
            {
                //gameObject.transform.localPosition = _initialPosition;
                Time.timeScale = 1f;
            }
        }
    }

}
