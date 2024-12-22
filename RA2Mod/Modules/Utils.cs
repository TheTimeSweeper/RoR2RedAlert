using RoR2;
using UnityEngine;

namespace RA2Mod.Modules
{
    public class Utils
    {
        public static void Knockup(GameObject gameObject, float force, bool resetVelocity = true, bool disableAirControl = true)
        {
            PhysForceInfo physInfo = new PhysForceInfo()
            {
                massIsOne = true,
                disableAirControlUntilCollision = disableAirControl,
                ignoreGroundStick = true,
                force = Vector3.up * force,
            };

            if (gameObject.TryGetComponent(out CharacterMotor motor))
            {
                Knockup(motor, physInfo, resetVelocity);
            }
            if (gameObject.TryGetComponent(out RigidbodyMotor rigidMotor))
            {
                Knockup(rigidMotor, physInfo, resetVelocity);
            }
        }

        public static void Knockup(CharacterBody body, float force, bool resetVelocity = true, bool disableAirControl = true)
        {
            PhysForceInfo physInfo = new PhysForceInfo()
            {
                massIsOne = true,
                disableAirControlUntilCollision = disableAirControl,
                ignoreGroundStick = true,
                force = Vector3.up * force,
            };

            if (body.characterMotor)
            {
                Knockup(body.characterMotor, physInfo, resetVelocity);
            }
            if (body.TryGetComponent(out RigidbodyMotor rigidMotor))
            {
                Knockup(rigidMotor, physInfo, resetVelocity);
            }
        }

        public static void Knockup(CharacterMotor motor, PhysForceInfo physInfo, bool resetVelocity)
        {
            if (!motor.isGrounded)
            {
                physInfo.disableAirControlUntilCollision = false;
            }
            if (resetVelocity)
            {
                motor.velocity = Vector3.zero;
            }
            motor.ApplyForceImpulse(physInfo);
        }

        public static void Knockup(RigidbodyMotor rigidMotor, PhysForceInfo physInfo, bool resetVelocity)
        {
            physInfo.disableAirControlUntilCollision = false;

            if (resetVelocity)
            {
                rigidMotor.rigid.velocity = Vector3.zero;
            }
            rigidMotor.ApplyForceImpulse(physInfo);
        }
    }
}