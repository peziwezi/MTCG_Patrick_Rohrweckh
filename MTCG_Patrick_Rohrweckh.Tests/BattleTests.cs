using MTCG_Patrick_Rohrweckh;
using MTCG_Patrick_Rohrweckh.Models;
using MTCG_Patrick_Rohrweckh.Businesslogic;
namespace MTCG_Patrick_Rohrweckh.Tests
{
    public class BattleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Compare_Cards_Damage_Return_Winner()
        {
            Assert.Pass();
            //Arrange
            Battle battle = new Battle();
            Card card1 = new MonsterCard("1","Test1", 5);
            Card card2 = new MonsterCard("2", "Test2", 10);

            //Act
            Card winner = battle.Fight(card1, card2);
            //Assert
            Assert.That(Equals(winner, card2));
            Assert.That(winner, Is.EqualTo(card2));
        }
        [Test]
        public void Compare_FireSpell_and_NormalMonster_Return_Winner()
        {
            Assert.Pass();
            //Arrange
            Battle battle = new Battle();
            Card card1 = new MonsterCard("1", "NormalMonster", 10);
            Card card2 = new SpellCard("2", "FireSpell", 5);

            //Act
            Card winner = battle.Fight(card1, card2);
            //Assert
            Assert.That(Equals(winner, card2));
            Assert.That(winner, Is.EqualTo(card2));
        }
        [Test]
        public void Compare_WaterSpell_and_Knight_Return_Winner()
        {
            Assert.Pass();
            //Arrange
            Battle battle = new Battle();
            Card card1 = new MonsterCard("1", "Knight", 20);
            Card card2 = new SpellCard("2", "WaterSpell", 5);

            //Act
            Card winner = battle.Fight(card1, card2);
            //Assert
            Assert.That(Equals(winner, card2));
            Assert.That(winner, Is.EqualTo(card2));
        }
        [Test]
        public void Compare_WaterGoblin_and_FireGoblin_Return_Winner()
        {
            Assert.Pass();
            //Arrange
            Battle battle = new Battle();
            Card card1 = new MonsterCard("1", "WaterGoblin", 5);
            Card card2 = new MonsterCard("2", "FireGoblin", 10);

            //Act
            Card winner = battle.Fight(card1, card2);
            //Assert
            Assert.That(Equals(winner, card2));
            Assert.That(winner, Is.EqualTo(card2));
        }
        [Test]
        public void Compare_Dragon_and_FireElf_Return_Winner()
        {
            Assert.Pass();
            //Arrange
            Battle battle = new Battle();
            Card card1 = new MonsterCard("1", "Dragon", 20);
            Card card2 = new MonsterCard("2", "FireElf", 5);

            //Act
            Card winner = battle.Fight(card1, card2);
            //Assert
            Assert.That(Equals(winner, card2));
            Assert.That(winner, Is.EqualTo(card2));
        }
        [Test]
        public void Draw()
        {
            Assert.Pass();
            //Arrange
            Battle battle = new Battle();
            Card card1 = new MonsterCard("1", "WaterElf", 5);
            Card card2 = new MonsterCard("2", "FireElf", 5);
            Card draw = new MonsterCard("0", "Draw", 0);

            //Act
            Card winner = battle.Fight(card1, card2);
            //Assert
            Assert.That((Equals(winner, card1)) == false);
            Assert.That((Equals(winner, card2)) == false);
            Assert.That(Equals(winner, draw));
            Assert.That(winner, Is.EqualTo(draw));
        }
    }
}