using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Controllers;
using WebApplication.Models;

namespace Tests
{
    public class Project_Tests
    {
        Project testProject = new Project();
        /*ProjectsController testController = new ProjectsController();*/
        User testUser = new User();

        [SetUp]
        public void Setup()
        {
            testProject = new Project();
            testUser = new User();

            testUser.StudentName = "Fred";

            testProject.User = testUser;
            testUser.Projects.Add(testProject);
        }

        [Test]
        public void Project_Returns_Users()
        {
            List<User> users = testProject.GetUsers;
            Assert.That(users.First().StudentName, Is.EqualTo("Fred"));
        }
    }
}