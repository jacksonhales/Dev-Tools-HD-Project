using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Controllers;
using WebApplication.Models;

namespace Tests
{
    public class User_Tests
    {
        Project testProject = new Project();
        /*ProjectsController testController = new ProjectsController();*/
        User testUser = new User();

        [SetUp]
        public void Setup()
        {
            testProject = new Project();

            testProject.User = testUser;
            testUser.Projects.Add(testProject);
        }

        [Test]
        public void User_Can_Be_Instantiated()
        {
            testUser = new User();

            testUser.StudentName = "Fred";

            Assert.That(testUser.StudentName, Is.EqualTo("Fred"));
        }
    }
}
