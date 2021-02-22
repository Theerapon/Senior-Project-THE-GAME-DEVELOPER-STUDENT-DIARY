using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO testing_HardSkill_Template;
    private HardSkill_SO testing_HardSkill_Current;
    // Start is called before the first frame update
    void Start()
    {
        if (testing_HardSkill_Template != null)
        {
            testing_HardSkill_Current = Instantiate(testing_HardSkill_Template);
        }
    }

}
