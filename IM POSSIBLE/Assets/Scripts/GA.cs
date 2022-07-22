using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA : MonoBehaviour
{
    public TargetMover[] population;
    float mutationChance, crossoverChance;
    GameManager manager;

    public GA(TargetMover[] pop, float mc, float cc, GameManager man)
    {
        population = pop;
        mutationChance = mc;
        crossoverChance = cc;
        manager = man;
    }

    TargetBehaviour mutate(TargetBehaviour profile)
    {
        bool isTimes = Random.value >= 0.5; //generates random boolean
        if (isTimes)
        {
            int mutationPoint = Random.Range(0, profile.times.Length);
            //change times
            profile.times[mutationPoint] = Random.Range(1f, 2f);
        }else
        {
            int mutationPoint = Random.Range(0, profile.positions.Length);
            //change position
            profile.positions[mutationPoint] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f,1f));
            //choosing a random position using x,y,z axis 
        }
        return profile;
    }

    TargetBehaviour crossover (TargetBehaviour profile1, TargetBehaviour profile2)
    {


        // crossover positions
        int crossoverPointPos = Random.Range(0, profile1.positions.Length);
        Vector3[] newPositions = new Vector3[profile1.positions.Length];
        for (int i = 0; i < profile1.positions.Length; i++)
        {
            if (i < crossoverPointPos)
            {
                newPositions[i] = profile1.positions[i];
            } else
            {
                newPositions[i] = profile2.positions[i];
            }
        }

        // crossover times
        int crossoverPointTim = Random.Range(0, profile1.times.Length);
        float[] newTimes = new float[profile1.times.Length];
        for (int i = 0; i < profile1.times.Length; i++)
        {
            if (i < crossoverPointTim)
            {
                newTimes[i] = profile1.times[i];
            }
            else
            {
                newTimes[i] = profile2.times[i];
            }
        }
        return new TargetBehaviour(newPositions, newTimes);
    }

    public void createNewPopulation()
    {
        TargetMover[] newPop = new TargetMover[population.Length];
        TargetMover[] allAlive = System.Array.FindAll(population, c => !c.dead);
        for (int i = 0; i < newPop.Length; i++)
        {
            TargetMover currentMember;
            // crossover
            int cross1 = Random.Range(0, allAlive.Length);
            int cross2 = Random.Range(0, allAlive.Length);
            int mutations = allAlive[cross1].mutations > allAlive[cross2].mutations ? allAlive[cross1].mutations : allAlive[cross2].mutations;
            if (Random.value < crossoverChance)
            {
                currentMember = new TargetMover(crossover(allAlive[cross1].behaviour, allAlive[cross2].behaviour), manager,1);
            } else
            {
                currentMember = allAlive[cross1];
            }
            // mutate
            if (Random.value < mutationChance)
            {
                currentMember = new TargetMover(mutate(currentMember.behaviour), manager, mutations+1);
                print(currentMember.mutations);
            }
            newPop[i] = currentMember;
        }
        population = newPop;
    }
}
