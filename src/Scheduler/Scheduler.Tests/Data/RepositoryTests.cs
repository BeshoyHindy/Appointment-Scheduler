using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Scheduler.Domain.Models;
using Scheduler.Infra.Data.Context;
using Scheduler.Infra.Data.Repository;
using Xunit;

namespace Scheduler.Tests.Data
{
    public class RepositoryTests
    {
        [Fact]
        public void AddItem_Test()
        {
            var dbSetMock = new Mock<DbSet<Appointment>>();
            var dbContextMock = new Mock<AppointmentDataContext>();
            dbContextMock.Setup(s => s.Set<Appointment>()).Returns(dbSetMock.Object);
            var appointment = new Appointment(Guid.NewGuid(), "test name", "mail@test.com", "123456", DateTime.Now,
                DateTime.Now.AddMinutes(5), DateTime.Now, "notes here ");
            var repository = new AppointmentRepository(dbContextMock.Object);
            repository.Add(appointment);

            dbSetMock.Verify(m => m.Add(It.Is<Appointment>(y => y == appointment)));
            dbContextMock.Verify(m => m.SaveChanges(), Times.Never());

        }

        [Fact]
        public void Get_TestClassObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var testObject = new Appointment(new Guid("D4E0CEEB-92F5-434D-85C8-C955AF938C7D"), "test name", "mail@test.com", "123456", DateTime.Now,
                DateTime.Now.AddMinutes(5), DateTime.Now, "notes here ");


            var dbSetMock = new Mock<DbSet<Appointment>>();
            var dbContextMock = new Mock<AppointmentDataContext>();

            dbContextMock.Setup(s => s.Set<Appointment>()).Returns(dbSetMock.Object);
            //dbSetMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(testObject);

            // Act
            var repository = new AppointmentRepository(dbContextMock.Object);
            var obj = repository.GetById(new Guid("D4E0CEEB-92F5-434D-85C8-C955AF938C7D")).Result;

            // Assert
            dbContextMock.Verify(x => x.Set<Appointment>());
        }
    }
}
