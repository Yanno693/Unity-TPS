public static class MyEnum
{
    public enum AlertLevel { Normal, Invectigation, Search, Fight};
    /* 
     * Alert : Define the alert level of an NPC
     * - Normal : Normal situation for the NPC
     * - Investigation : If the NPC notice something weird, it will investigate. If his doubts are confirmed, he will get to Search or Fight depending if there's an other Humanoid or not, or goes back to Normal if there's nothing
     * - Search : When the NPC knows there's an enemy but no target (target lost for example)
     * - Fight : When the NPC has a identified target and knows where it is. If all target are taken care of, go back to Normal.
     */
}
