using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimationController : AnimationController
{
    const string RIFLE_AIMING_IDLE = "RifleAimingIdle";
    const string RIFLE_RUN = "RifleRun";

    public void PlayRifleAimingIdleAnimation()
    {
        ChangeAnimationState(RIFLE_AIMING_IDLE);
    }

    public void PlayRifleRunAnimation()
    {
        ChangeAnimationState(RIFLE_RUN);
    }


}
