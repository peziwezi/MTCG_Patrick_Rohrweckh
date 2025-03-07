using MTCG_Patrick_Rohrweckh.Businesslogic;
using MTCG_Patrick_Rohrweckh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Tests
{
    public class BattleTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void PlayerOneWins()
        {
            List<Card> card1 = [new MonsterCard("1", "FireGoblin", 20), new SpellCard("2", "FireSpell", 20), new MonsterCard("1", "WaterGoblin", 40), new SpellCard("5", "RegularSpell", 20)];
            List<Card> card2 = [new MonsterCard("1", "WaterGoblin", 10), new SpellCard("2", "WaterSpell", 10), new MonsterCard("1", "FireElf", 20), new SpellCard("5", "RegularSpell", 10)];
            Battle battle = new Battle(new Deck(card1), new Deck(card2));
            battle.Duel();
            Assert.That(battle.ProclaimWinner, Is.EqualTo( "Player1"));

            //Arrange

        }
        [Test]
        public void PlayerTwoWins()
        {
            List<Card> card1 = [new MonsterCard("1", "FireGoblin", 20), new SpellCard("2", "FireSpell", 20), new MonsterCard("1", "WaterGoblin", 20), new SpellCard("5", "RegularSpell", 20)];
            List<Card> card2 = [new MonsterCard("1", "Dragon", 30), new SpellCard("2", "WaterSpell", 30), new MonsterCard("1", "FireElf", 40), new SpellCard("5", "FireSpell", 20)];
            Battle battle = new Battle(new Deck(card1), new Deck(card2));
            battle.Duel();
            Assert.That(battle.ProclaimWinner, Is.EqualTo("Player2"));

            //Arrange

        }
        [Test]
        public void PlayersDraw()
        {
            List<Card> card1 = [new MonsterCard("1", "WaterGoblin", 10), new SpellCard("2", "WaterSpell", 10), new MonsterCard("1", "WaterElf", 20), new SpellCard("5", "WaterSpell", 10)];
            List<Card> card2 = [new MonsterCard("1", "WaterGoblin", 10), new SpellCard("2", "WaterSpell", 10), new MonsterCard("1", "WaterElf", 20), new SpellCard("5", "WaterSpell", 10)];
            Battle battle = new Battle(new Deck(card1), new Deck(card2));
            battle.Duel();
            Assert.That(battle.ProclaimWinner, Is.EqualTo("Draw"));

            //Arrange

        }
    }
}
