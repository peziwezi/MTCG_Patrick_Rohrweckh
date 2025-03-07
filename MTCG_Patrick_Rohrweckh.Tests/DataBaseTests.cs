using MTCG_Patrick_Rohrweckh.Businesslogic;
using MTCG_Patrick_Rohrweckh.Datalogic.DataHandler;
using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using MTCG_Patrick_Rohrweckh.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Tests
{
    public class DataBaseTests
    {
        public DataHandler dataHandler { get; set; }
        [SetUp]
        public void Setup()
        {
            string database = "Host=localhost;Username=postgres;Password=password;Database=testdb";
            dataHandler = new DataHandler(database);
        }
        [Test]
        public void TestUserCreation()
        {
            DataUser user = new DataUser("Max", "123", 100, 20);
            dataHandler.userHandler.CreateUser(user);
            DataUser test = dataHandler.userHandler.RetrieveUser("Max");
            Assert.That(Equals(test.Username, user.Username));
            Assert.That(Equals(test.Password, user.Password));
            Assert.That(Equals(test.ELO, user.ELO));
            Assert.That(Equals(test.Coins, user.Coins));
            dataHandler.userHandler.DeleteUser(test);
        }
        [Test]
        public void TestUserUpdate()
        {
            DataUser user = new DataUser("Max", "123", 100, 20);
            dataHandler.userHandler.CreateUser(user);
            user.ELO = 80;
            dataHandler.userHandler.UpdateUser(user);
            DataUser test = dataHandler.userHandler.RetrieveUser("Max");
            Assert.That(Equals(test.Username, user.Username));
            Assert.That(Equals(test.Password, user.Password));
            Assert.That(Equals(test.ELO, user.ELO));
            Assert.That(Equals(test.Coins, user.Coins));
            dataHandler.userHandler.DeleteUser(test);
        }
        [Test]
        public void TestPackageCreation()
        {
            int? id = dataHandler.packageHandler.CreatePackage("Available");
            DataPackage test = dataHandler.packageHandler.RetrievePackage(id);
            Assert.That(Equals(test.Status, "Available"));
            dataHandler.packageHandler.DeletePackage(test);
        }
        [Test]
        public void TestPackageUpdate()
        {
            int? id = dataHandler.packageHandler.CreatePackage("Available");
            DataPackage package = dataHandler.packageHandler.RetrievePackage(id);
            package.Status = "Sold";
            dataHandler.packageHandler.UpdatePackage(package);
            DataPackage test = dataHandler.packageHandler.RetrievePackage(id);
            Assert.That(Equals(test.Status, "Sold"));
            dataHandler.packageHandler.DeletePackage(test);
        }
        [Test]
        public void TestCardCreation()
        {
            int? id = dataHandler.packageHandler.CreatePackage("Available");
            DataPackage package = dataHandler.packageHandler.RetrievePackage(id);
            DataCard user = new DataCard("Test", "Goblin", 10, id);
            dataHandler.cardHandler.CreateCard(user);
            DataCard test = dataHandler.cardHandler.RetrieveCardbyId("Test");
            Assert.That(Equals(test.Id, user.Id));
            Assert.That(Equals(test.Name, user.Name));
            Assert.That(Equals(test.Damage, user.Damage));
            Assert.That(Equals(test.Packid, user.Packid));
            dataHandler.cardHandler.DeleteCard(test);
            dataHandler.packageHandler.DeletePackage(package);
        }
        [Test]
        public void TestStackCreation()
        {
            int? id = dataHandler.packageHandler.CreatePackage("Available");
            DataPackage package = dataHandler.packageHandler.RetrievePackage(id);
            DataCard card = new DataCard("Test", "Goblin", 10, id);
            dataHandler.cardHandler.CreateCard(card);
            DataUser user = new DataUser("Max", "123", 100, 20);
            dataHandler.userHandler.CreateUser(user);
            DataUser testUser = dataHandler.userHandler.RetrieveUser("Max");
            DataCard testCard = dataHandler.cardHandler.RetrieveCardbyId("Test");
            DataStack stack = new DataStack(testUser.Id, testCard.Id, "Stack");
            dataHandler.stackHandler.CreateStack(stack);
            DataStack testStack = dataHandler.stackHandler.RetrieveStack(testUser.Id, testCard.Id);
            Assert.That(Equals(testStack.UserId, testUser.Id));
            Assert.That(Equals(testStack.CardId, testCard.Id));
            Assert.That(Equals(testStack.StackType, "Stack"));
            dataHandler.stackHandler.DeleteStack(testStack);
            dataHandler.userHandler.DeleteUser(testUser);
            dataHandler.cardHandler.DeleteCard(testCard);
            dataHandler.packageHandler.DeletePackage(package);
        }
        [Test]
        public void TestStackUpdate()
        {
            int? id = dataHandler.packageHandler.CreatePackage("Available");
            DataPackage package = dataHandler.packageHandler.RetrievePackage(id);
            DataCard card = new DataCard("Test", "Goblin", 10, id);
            dataHandler.cardHandler.CreateCard(card);
            DataUser user = new DataUser("Max", "123", 100, 20);
            dataHandler.userHandler.CreateUser(user);
            DataUser testUser = dataHandler.userHandler.RetrieveUser("Max");
            DataCard testCard = dataHandler.cardHandler.RetrieveCardbyId("Test");
            DataStack stack = new DataStack(testUser.Id, testCard.Id, "Stack");
            dataHandler.stackHandler.CreateStack(stack);
            DataStack testStack = dataHandler.stackHandler.RetrieveStack(testUser.Id, testCard.Id);
            testStack.StackType = "Deck";
            dataHandler.stackHandler.UpdateStack(testStack);
            testStack = dataHandler.stackHandler.RetrieveStack(testUser.Id, testCard.Id);
            Assert.That(Equals(testStack.UserId, testUser.Id));
            Assert.That(Equals(testStack.CardId, testCard.Id));
            Assert.That(Equals(testStack.StackType, "Deck"));
            dataHandler.stackHandler.DeleteStack(testStack);
            dataHandler.userHandler.DeleteUser(testUser);
            dataHandler.cardHandler.DeleteCard(testCard);
            dataHandler.packageHandler.DeletePackage(package);
        }
    } 
}
