using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow2 : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.8f;
        public float lookAheadMoveThreshold = 0.4f;
        public int xRotation = 50;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;
        private float initial_y;
        private float yRotation;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
            initial_y = transform.position.y - target.transform.position.y;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);


            if (Input.GetAxis("Mouse ScrollWheel") > 0) { if (initial_y >= 3.5f) { initial_y -= 0.6f; m_OffsetZ += 0.5f; } }

            if (Input.GetAxis("Mouse ScrollWheel") < 0) { if (initial_y <= 10f) { initial_y += 0.6f; m_OffsetZ -= 0.5f; } }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                yRotation += Input.GetAxis("Horizontal");
                transform.eulerAngles = new Vector3(xRotation, yRotation -= 90, 0); transform.position = new Vector3(5, 0, 0); 
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                yRotation -= Input.GetAxis("Horizontal");
                transform.eulerAngles = new Vector3(xRotation, yRotation += 90, 0); transform.position = new Vector3(5, 0, 0);
            }


            newPos.y = initial_y + target.transform.position.y;

            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }
    }
}
