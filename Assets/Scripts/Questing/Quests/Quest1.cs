using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest1 : Quest
{
    public void Awake()
    {
        QuestInWhatScene = 1;
        QuestName = "Get the CHIKENZ";
        Description = "You need to get the CHIKENZ, ";
        GoldReward = 20;
        Goals.Add(new CollectGoal(this, "QuestChicken", "Collect chicken", false, 0, 5));
        Goals.Add(new AreaGoal(this, "LocationArea", "Stand in front of the door", false, 0, 1));
        Goals.ForEach(g => g.Init());
    }

    protected override void GiveReward()
    {
        base.GiveReward();
        Debug.Log("Quest1 Completed");
        GameManager.NextQuest();
    }
}