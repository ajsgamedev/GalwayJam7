using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
		public AudioSource jump;
		public AudioSource slide;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		public float h = 0.5f;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

            }

        }


        private void FixedUpdate()
        {
            // Read the inputs.
			bool crouch = CrossPlatformInputManager.GetButton("slide");
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
			m_Character.Move(h, crouch, m_Jump);
			if (m_Jump == true)
			{
				jump.Play ();
			}
			if (crouch == true)
			{
				slide.Play ();
			}
            m_Jump = false;
        }
    }
}
