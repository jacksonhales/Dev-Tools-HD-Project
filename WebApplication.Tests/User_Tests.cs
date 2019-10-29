using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Controllers;
using WebApplication.Models;

namespace Tests
{
    public class User_Tests
    {
        // new testing project
        Project testProject = new Project();
        // new user to add to testing project
        User testUser = new User();
        
        // setting up the unit test
        [SetUp]
        public void Setup()
        {
            // create a new project object
            testProject = new Project();

            // create a new user to add to the project
            testProject.User = testUser;
            // add user to testing project
            testUser.Projects.Add(testProject);
        }

        // the unit test
        [Test]
        public void User_Can_Be_Instantiated()
        {
            // create a new user object
            testUser = new User();
            // set the name of the user to equal Fred
            testUser.StudentName = "Fred";

            // assert that the user's name field matches the string 'Fred'
            Assert.That(testUser.StudentName, Is.EqualTo("Fred"));
        }
    }
}
