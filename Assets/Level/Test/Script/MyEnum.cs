public static class MyEnum
{
    public enum AlertLevel { Normal, Investigation, Search, Fight};
    /* 
     * Alert : Define the alert level of an NPC
     * - Normal : Normal situation for the NPC
     * - Investigation : If the NPC notice something weird, it will investigate. If his doubts are confirmed, he will get to Search or Fight depending if there's an other Humanoid or not, or goes back to Normal if there's nothing (Example: A guard noticing an enemy will switch to Fight level, but a guard finding a corpse will switch to Search level)
     * - Search : When the NPC knows there's an enemy but no target (target lost for example)
     * - Fight : When the NPC has a identified target and knows where it is. If all target are taken care of, go back to Normal.
     */

    public enum Hand { Left, Right, None};
    /* 
     * Hand : For Humanoids, design on of both Humanoid hands
     * - Left : The left hand of the humanoid
     * - Right : The right hand of the humanoid
     * - Node : If none of the hands are choses
     */

     public enum PlayerCameraMode { Roaming, Fight}
     /*
        PlayerCameraMode : Define How the camera of the player will act depending on if the player is roaming of fighting
        - Roaming : The camera shakes a little bit (noise) and follows the player when he turn
        - Fighting : The camera doesn't shake and stay turns only with when the Mouse/Joystick is moved
      */
}
