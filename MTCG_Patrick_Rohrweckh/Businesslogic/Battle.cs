using MTCG_Patrick_Rohrweckh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Businesslogic
{
    public enum Result
    {   
        Card1,
        Card2,
        Draw
    }
    public class Battle
    {
        public Battle()
        {

        }
        public Card Fight(Card card1, Card card2)
        {
            Card winner = new MonsterCard("0", "Draw", 0);
            Result calculatedWinner = CalculateDamage(card1, card2);
            if(calculatedWinner == Result.Card1)
            {
                winner = card1;
            }
            else if(calculatedWinner == Result.Card2)
            {
                winner = card2;
            }
            return winner;
        }
        public Result CalculateDamage(Card card1, Card card2)
        {
            Result winner;
            float damage1 = card1.Damage;
            float damage2 = card2.Damage;
            if(!(card1.CardType == CardType.monster && card2.CardType == CardType.monster))
            {
                if (card1.CardType == CardType.monster)
                {
                    MonsterCard card1m = (MonsterCard)card1;
                    if(card1m.MonsterType == Monster.Knight && card2.ElementType == Element.water)
                    {
                        return Result.Card2;
                    }
                    else if(card1m.MonsterType == Monster.Kraken)
                    {
                        damage2 = 0;
                    }
                    else
                    {
                        if(card1m.ElementType == Element.water && card2.ElementType == Element.fire)
                        {
                            damage1 *= 2;
                            damage2 /= 2;
                        }
                        else if( card1m.ElementType == Element.fire && card2.ElementType == Element.normal)
                        {
                            damage1 *= 2;
                            damage2 /= 2;
                        }
                        else if (card1m.ElementType == Element.normal && card2.ElementType == Element.water)
                        {
                            damage1 *= 2;
                            damage2 /= 2;
                        }
                        else if (card1m.ElementType == Element.fire && card2.ElementType == Element.water)
                        {
                            damage1 /= 2;
                            damage2 *= 2;
                        }
                        else if (card1m.ElementType == Element.normal && card2.ElementType == Element.fire)
                        {
                            damage1 /= 2;
                            damage2 *= 2;
                        }
                        else if (card1m.ElementType == Element.water && card2.ElementType == Element.normal)
                        {
                            damage1 /= 2;
                            damage2 *= 2;
                        }
                    }
                }
                else if (card2.CardType == CardType.monster)
                {
                    MonsterCard card2m = (MonsterCard)card2;
                    if (card2m.MonsterType == Monster.Knight && card1.ElementType == Element.water)
                    {
                        return Result.Card1;
                    }
                    else if (card2m.MonsterType == Monster.Kraken)
                    {
                        damage1 = 0;
                    }
                    else
                    {
                        if (card1.ElementType == Element.water && card2m.ElementType == Element.fire)
                        {
                            damage1 *= 2;
                            damage2 /= 2;
                        }
                        else if (card1.ElementType == Element.fire && card2m.ElementType == Element.normal)
                        {
                            damage1 *= 2;
                            damage2 /= 2;
                        }
                        else if (card1.ElementType == Element.normal && card2m.ElementType == Element.water)
                        {
                            damage1 *= 2;
                            damage2 /= 2;
                        }
                        else if (card1.ElementType == Element.fire && card2m.ElementType == Element.water)
                        {
                            damage1 /= 2;
                            damage2 *= 2;
                        }
                        else if (card1.ElementType == Element.normal && card2m.ElementType == Element.fire)
                        {
                            damage1 /= 2;
                            damage2 *= 2;
                        }
                        else if (card1.ElementType == Element.water && card2m.ElementType == Element.normal)
                        {
                            damage1 /= 2;
                            damage2 *= 2;
                        }
                    }
                }
            }
            else
            {
                MonsterCard card1m = (MonsterCard)card1;
                MonsterCard card2m = (MonsterCard)card2;
                if (card1m.MonsterType == Monster.Goblin && card2m.MonsterType == Monster.Dragon)
                {
                    damage1 = 0;
                }
                else if (card1m.MonsterType == Monster.Wizzard && card2m.MonsterType == Monster.Ork)
                {
                    damage2 = 0;
                }
                else if ((card1m.MonsterType == Monster.Elf && card1m.ElementType == Element.fire) && card2m.MonsterType == Monster.Dragon)
                {
                    damage2 = 0;
                }
                else if (card1m.MonsterType == Monster.Dragon && card2m.MonsterType == Monster.Goblin)
                {
                    damage2 = 0;
                }
                else if (card1m.MonsterType == Monster.Ork && card2m.MonsterType == Monster.Wizzard)
                {
                    damage1 = 0;
                }
                else if (card1m.MonsterType == Monster.Dragon && (card2m.MonsterType == Monster.Elf && card2m.ElementType == Element.fire))
                {
                    damage1 = 0;
                }

            }
            if (damage1 > damage2) 
            {
                winner = Result.Card1;
            }
            else if(damage1 < damage2)
            {
                winner = Result.Card2;
            }
            else
            {
                winner = Result.Draw;
            }
            return winner;
        }
    }
}
