/**
 * @file       : AudioTypes.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {
    /* Audio enums */
    public enum AudioState {
        ENABLED,
        MUTED,
    }

    public enum AudioMood {
        INTENSE, 
        CALM, 
    }

    /* Audio data structs */
    public struct audioData {
        double volume;
        double intensity;
        double pitch; 
        double timbre; 
    }

    public class AudioTypes {

    }
}
