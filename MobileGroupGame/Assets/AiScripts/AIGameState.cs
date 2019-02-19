﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class AIGameState
{
    public static List<AIGameState> AllStates = new List<AIGameState>();
    public static float TimePased;
    public AIGameState ParentState;
    public List<AIGameState> ChildsStatus = new List<AIGameState>();
    public int Index;
    public HeroBehaviourScript PlayerHero;
    public List<CardBehaviourScript> PlayerTableCards;
    public HeroBehaviourScript AIHero;
    public List<CardBehaviourScript> AIHandCards;
    public List<CardBehaviourScript> AITableCards;

    public int maxMana;
    public int PlayerMana;
    public int AIMana;

    public BoardBehaviourScript.Turn turn;

    public float State_Score = 0;
    float AI_Table_Score = 0;
    float Player_Table_Score = 0;
    float AI_Hand_Score = 0;
    float Player_Health_Score = 0;
    float AI_Health_Score = 0;

    float Attackweight = 1;
    float Healthweight = 1;
    float Manaweight = 0.1f;
    float HeroHealthweight = 0.1f;

    public struct Action
    {
        public string Card1;
        public string Card2;
        public string Hero;
        public int OpCode;
    }
    public Queue<Action> Actions = new Queue<Action>();

    #region Constructors 
    public AIGameState() { }
    public AIGameState(
        List<CardBehaviourScript> PlayerTable,
        List<CardBehaviourScript> AIHand,
        List<CardBehaviourScript> AITable,
        HeroBehaviourScript _PlayerHero,
        HeroBehaviourScript _AIHero,
        int _MaxMana,
        int _PlayerMana,
        int _AIMana,
        BoardBehaviourScript.Turn _Turn,
        AIGameState Parent
        )
    {
        ParentState = Parent;
        if (ParentState == null)
        {
            Index = 0;
        }
        else
        {
            Index = ParentState.Index + 1;
            Actions = new Queue<Action>(ParentState.Actions);
        }
        PlayerTableCards = CardListCopier.DeepCopy(PlayerTable);
        PlayerHero = _PlayerHero.Clone() as HeroBehaviourScript;

        AIHandCards = CardListCopier.DeepCopy(AIHand);
        AITableCards = CardListCopier.DeepCopy(AITable);
        AIHero = _AIHero.Clone() as HeroBehaviourScript;
        maxMana = _MaxMana;
        PlayerMana = _PlayerMana;
        AIMana = _AIMana;
        turn = _Turn;
        Calculate_State_Score();
        AllStates.Add(this);
    }
    public AIGameState(
         List<GameObject> PlayerTable,
         List<GameObject> AIHand,
         List<GameObject> AITable,
         HeroBehaviourScript _PlayerHero,
         HeroBehaviourScript _AIHero,
         int _MaxMana,
         int _PlayerMana,
         int _AIMana,
         BoardBehaviourScript.Turn _Turn,
         AIGameState Parent
        )
    {
        ParentState = Parent;
        if (ParentState == null)
        {
            Index = 0;
        }
        else
        {
            Index = ParentState.Index + 1;
            Actions = new Queue<Action>(ParentState.Actions);
        }

        List<CardBehaviourScript> _tempPlayerTable = new List<CardBehaviourScript>();
        foreach (var item in PlayerTable) _tempPlayerTable.Add(item.GetComponent<CardBehaviourScript>());
        PlayerTableCards = CardListCopier.DeepCopy(_tempPlayerTable);

        PlayerHero = _PlayerHero.Clone() as HeroBehaviourScript;


        List<CardBehaviourScript> _tempAIHand = new List<CardBehaviourScript>();
        foreach (var item in AIHand) _tempAIHand.Add(item.GetComponent<CardBehaviourScript>());
        AIHandCards = CardListCopier.DeepCopy(_tempAIHand);

        List<CardBehaviourScript> _tempAITable = new List<CardBehaviourScript>();
        foreach (var item in AITable) _tempAITable.Add(item.GetComponent<CardBehaviourScript>());
        AITableCards = CardListCopier.DeepCopy(_tempAITable);

        AIHero = _AIHero.Clone() as HeroBehaviourScript;
        maxMana = _MaxMana;
        PlayerMana = _PlayerMana;
        AIMana = _AIMana;
        turn = _Turn;
        Calculate_State_Score();
        AllStates.Add(this);
    }
    #endregion
    float Calculate_State_Score()
    {
        State_Score = 0;
        AI_Table_Score = 0;
        Player_Table_Score = 0;
        AI_Hand_Score = 0;
        Player_Health_Score = 0;
        AI_Health_Score = 0;

        foreach (CardBehaviourScript Card in AITableCards)
        {
            AI_Table_Score += Card._Attack * Attackweight + Card.health * Healthweight;
            if (Card.cardtype == CardBehaviourScript.CardType.Magic && PlayerTableCards.Count > 0)
            {
                AI_Table_Score += 2;
            }
        }


        foreach (CardBehaviourScript Card in PlayerTableCards)
        {
            Player_Table_Score -= Card._Attack * Attackweight + Card.health * Healthweight;
        }

        foreach (CardBehaviourScript Card in AIHandCards)
        {
            AI_Hand_Score += Card.mana * Manaweight;
        }


        if (PlayerHero.health <= 0) Player_Table_Score = float.MaxValue;
        else
            Player_Health_Score -= PlayerHero.health * HeroHealthweight;



        if (AIHero.health <= 0) AI_Health_Score = float.MinValue;
        else
            AI_Health_Score += AIHero.health * HeroHealthweight;

        State_Score = AI_Table_Score + Player_Table_Score + AI_Hand_Score + Player_Health_Score + AI_Health_Score;
        return State_Score;
    }
    public void GetAllPlacingAction()
    {
        if (turn == BoardBehaviourScript.Turn.AITurn)
        {
            if (AIHandCards.Count == 0)
            {
            }
            else
            {
                List<List<CardBehaviourScript>> temp = ProducePlacing(AIHandCards, AIMana);
                for (int i = 0; i < temp.Count; i++)
                {
                    AIGameState State = new AIGameState(PlayerTableCards, AIHandCards, AITableCards, PlayerHero, AIHero, maxMana, PlayerMana, AIMana, turn, this);
                    for (int j = 0; j < temp[i].Count; j++)
                    {

                        State.PlaceCard(temp[i][j]);

                    }
                    State.Calculate_State_Score();
                    ChildsStatus.Add(State);
                }
            }
        }
    }
    public void GetAllAttackingActions(int AILEVEL)
    {
        _GetAllAttackingActions();
        _GetAllAttackingHeroActions();
        TimePased += Time.deltaTime;
        if (Index + 1 < AILEVEL)
        {
            foreach (var item in ChildsStatus)
            {
                item.GetAllAttackingActions(AILEVEL);
            }


        }
        else
        {
            TimePased = 0;
        }
    }
    void _GetAllAttackingActions()
    {
        if (turn == BoardBehaviourScript.Turn.AITurn)
        {
            List<List<CardBehaviourScript>> temp = ProduceAllAttackCombinations(AITableCards);
            foreach (var PlayerCard in PlayerTableCards)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    AIGameState State = new AIGameState(PlayerTableCards, AIHandCards, AITableCards, PlayerHero, AIHero, maxMana, PlayerMana, AIMana, turn, this);
                    for (int j = 0; j < temp[i].Count; j++)
                    {
                        if (temp[i][j].canPlay)
                        {
                            if (temp[i][j].cardtype == CardBehaviourScript.CardType.Monster)
                            {
                                State.CardAttackCard(temp[i][j], PlayerCard);
                            }
                            else if (temp[i][j].cardtype == CardBehaviourScript.CardType.Magic)
                            {
                                if (temp[i][j].cardeffect == CardBehaviourScript.CardEffect.ToSpecific)
                                {
                                    State.CardMagicCard(temp[i][j], PlayerCard);
                                }
                            }
                        }


                    }
                    State.Calculate_State_Score();
                    ChildsStatus.Add(State);
                }
            }

        }
    }
    void _GetAllAttackingHeroActions()
    {
        List<List<CardBehaviourScript>> temp = ProduceAllAttackCombinations(AITableCards);
        for (int i = 0; i < temp.Count; i++)
        {
            AIGameState State = new AIGameState(PlayerTableCards, AIHandCards, AITableCards, PlayerHero, AIHero, maxMana, PlayerMana, AIMana, turn, this);
            for (int j = 0; j < temp[i].Count; j++)
            {
                if (temp[i][j].canPlay)
                    State.CardAttackHero(temp[i][j], PlayerHero);

            }
            State.Calculate_State_Score();
            ChildsStatus.Add(State);
        }
    }
    private void CardMagicCard(CardBehaviourScript _attacker, CardBehaviourScript _target)
    {
        CardBehaviourScript attacker = AITableCards.Find(item => item._name == _attacker._name);
        CardBehaviourScript target = PlayerTableCards.Find(item => item._name == _target._name);
        {
            Action a;
            a.Card1 = attacker._name;
            a.Card2 = target._name;
            a.Hero = "";
            a.OpCode = 3;
            Actions.Enqueue(a);
            attacker.AddToMonster(attacker, target, false, delegate
            {
                attacker.Destroy(attacker);
            });
        }
    }

    public void CardAttackCard(CardBehaviourScript _attacker, CardBehaviourScript _target)
    {
        CardBehaviourScript attacker = AITableCards.Find(item => item._name == _attacker._name);
        CardBehaviourScript target = PlayerTableCards.Find(item => item._name == _target._name);
        {
            Action a;
            a.Card1 = attacker._name;
            a.Card2 = target._name;
            a.Hero = "";
            a.OpCode = 1;
            Actions.Enqueue(a);
            attacker.AttackCard(attacker, target, false, delegate
            {
                attacker.canPlay = false;
            });
        }

    }
    public void CardAttackHero(CardBehaviourScript _attacker, HeroBehaviourScript _target)
    {
        CardBehaviourScript attacker = AITableCards.Find(item => item._name == _attacker._name);
        Action a;
        a.Card1 = attacker._name;
        a.Card2 = "";
        a.Hero = _target._name;
        a.OpCode = 2;
        Actions.Enqueue(a);
        attacker.AttackHero(attacker, PlayerHero, false, delegate
        {
            attacker.canPlay = false;
        });

    }
    public void PlaceCard(CardBehaviourScript temp)
    {
        CardBehaviourScript card = AIHandCards.Find(item => item._name == temp._name);
        if (card.team == CardBehaviourScript.Team.AI && AIMana - card.mana >= 0 && AITableCards.Count < 10)
        {
            AIHandCards.Remove(card);
            AITableCards.Add(card);
            Action a;
            a.Card1 = card._name;
            a.Card2 = "";
            a.Hero = "";
            a.OpCode = 0;
            Actions.Enqueue(a);
            card.SetCardStatus(CardBehaviourScript.CardStatus.OnTable);
            if (card.cardtype == CardBehaviourScript.CardType.Magic)
            {
                card.canPlay = true;
                if (card.cardeffect == CardBehaviourScript.CardEffect.ToAll)
                {
                    card.AddToAll(card, false, delegate { card.Destroy(card); });
                }
                else if (card.cardeffect == CardBehaviourScript.CardEffect.ToEnemies)
                {
                    card.AddToEnemies(card, PlayerTableCards, false, delegate { card.Destroy(card); });
                }
            }

            AIMana -= card.mana;
        }
    }
    public List<List<CardBehaviourScript>> ProducePlacing(List<CardBehaviourScript> allValues, int maxmana)
    {
        List<List<CardBehaviourScript>> collection = new List<List<CardBehaviourScript>>();
        for (int counter = 0; counter < (1 << allValues.Count); ++counter)
        {
            List<CardBehaviourScript> combination = new List<CardBehaviourScript>();
            for (int i = 0; i < allValues.Count; ++i)
            {
                if ((counter & (1 << i)) == 0)
                    combination.Add(allValues[i]);
            }

            collection.Add(combination);
        }
        return collection;
    }
    public List<List<CardBehaviourScript>> ProduceAllAttackCombinations(List<CardBehaviourScript> allValues)
    {
        List<List<CardBehaviourScript>> collection = new List<List<CardBehaviourScript>>();
        for (int counter = 0; counter < (1 << allValues.Count); ++counter)
        {
            List<CardBehaviourScript> combination = new List<CardBehaviourScript>();
            for (int i = 0; i < allValues.Count; ++i)
            {
                if ((counter & (1 << i)) == 0)
                    combination.Add(allValues[i]);
            }
            collection.Add(combination);
        }
        return collection;
    }
}
public static class CardListCopier
{
    public static List<CardBehaviourScript> DeepCopy(List<CardBehaviourScript> objectToCopy)
    {
        List<CardBehaviourScript> temp = new List<CardBehaviourScript>();
        foreach (CardBehaviourScript Card in objectToCopy)
        {
            temp.Add(Card.Clone() as CardBehaviourScript);
        }

        return temp;
    }

}

