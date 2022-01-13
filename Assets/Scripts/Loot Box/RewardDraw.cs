using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardDraw : MonoBehaviour
{
    class Draw {
        public string name;
        public int amount;

        public Draw(string name, int amount) {
            this.name = name;
            this.amount = amount;
        }
    }
    private List<KeyValuePair<Draw, float>> rewards;
    // Start is called before the first frame update
    void Start()
    {
        rewards = new List<KeyValuePair<Draw, float>>() {
            new KeyValuePair<Draw, float>(new Draw("KebabBoost", 1), 0.30f), //30%
            new KeyValuePair<Draw, float>(new Draw("KebabBoost", 2), 0.15f), //15%
            new KeyValuePair<Draw, float>(new Draw("KebabBoost", 3), 0.05f), //5%

            new KeyValuePair<Draw, float>(new Draw("InsuranceBoost", 1), 0.15f), //15%
            new KeyValuePair<Draw, float>(new Draw("InsuranceBoost", 2), 0.05f), //5%
            new KeyValuePair<Draw, float>(new Draw("InsuranceBoost", 3), 0.05f), //5%

            new KeyValuePair<Draw, float>(new Draw("DeadlineBoost", 1), 0.08f), //8%
            new KeyValuePair<Draw, float>(new Draw("DeadlineBoost", 2), 0.05f), //5%
            new KeyValuePair<Draw, float>(new Draw("DeadlineBoost", 3), 0.02f), //2%

            new KeyValuePair<Draw, float>(new Draw("skin1", 1), 0.03f), //3%
            new KeyValuePair<Draw, float>(new Draw("skin2", 1), 0.025f), //2.5%
            new KeyValuePair<Draw, float>(new Draw("skin3", 1), 0.02f), //2%
            new KeyValuePair<Draw, float>(new Draw("skin4", 1), 0.015f), //5%1.
            new KeyValuePair<Draw, float>(new Draw("skin5", 1), 0.01f), //1%
        };
    }

    public KeyValuePair<string, int> draw() {
        Draw reward = drawReward();
        return new KeyValuePair<string, int>(reward.name, reward.amount);
    }

    private Draw drawReward() {
        float value = Random.Range(0.0f, 1.0f);
        float sum = 0.0f;
        foreach (var r in rewards) {
            sum += r.Value;
            if (value < sum)
            {
                return r.Key;
            }
        }     
        return null;
    }
}
