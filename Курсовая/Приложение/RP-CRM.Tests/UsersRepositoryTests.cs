using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RP_CRM.Data;
using Xunit;

namespace RP_CRM.Tests
{
    public class UsersRepositoryTests
    {
        private readonly GenericRepository<User> _usersRepositoryUnderTest;
        private readonly List<User> _stubStorage;
        private readonly DbSet<User> _stubSet;
        
        public UsersRepositoryTests()
        {
            var dbSetMock = new Mock<DbSet<User>>();

            dbSetMock.Setup(dbSet => dbSet.Add(It.IsAny<User>()))
                .Callback((User user) => _stubStorage.Add(user));
            dbSetMock.Setup(dbSet => dbSet.Remove(It.IsAny<User>()))
                .Callback((User user) => _stubStorage.Remove(user));
            dbSetMock.Setup(dbSet => dbSet.Add(It.IsAny<User>()))
                .Callback((User user) => _stubStorage.Add(user));

            var dbContextMock = new Mock<DatabaseContext>();

            dbContextMock.SetupProperty<DbSet<User>>(dbContext => dbContext.Users, dbSetMock.Object);
            
            _usersRepositoryUnderTest = new GenericRepository<User>(dbContextMock.Object);
        }

        [Fact]
        public void UserShouldBeCorrectAddedToStorageWhenThereIsNoSuchUsers()
        {
            //arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Fake User",
                Login = "Fake Login",
                Password = "Fake Password"
            };
            //act
            _usersRepositoryUnderTest.AddOrUpdate(user);
            //assert
            _stubStorage
                .Should()
                .Contain(x => x.Id == user.Id &&
                    x.Name == user.Name &&
                    x.Login == user.Login &&
                    x.Password == user.Password);
        }
    }
}