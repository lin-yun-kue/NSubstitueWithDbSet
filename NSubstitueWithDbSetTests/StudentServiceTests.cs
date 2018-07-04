using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NSubstitueWithDbSet.Tests
{
    [TestClass()]
    public class StudentServiceTests
    {
        [TestMethod()]
        public void GetStudenTest()
        {
            var mockDbSet = Substitute.For<DbSet<Student>, IQueryable<Student>>();
            var mockEntity = Substitute.For<DevEntities>();

            var students = new List<Student>()
            {
                new Student{ ID = 1, Name = "Kyle"},
                new Student{ ID = 2, Name = "Zeal"}
            };

            var queryStudent = students.AsQueryable();

            mockDbSet.AsQueryable().Provider.Returns(queryStudent.Provider);
            mockDbSet.AsQueryable().Expression.Returns(queryStudent.Expression);
            mockDbSet.AsQueryable().ElementType.Returns(queryStudent.ElementType);
            mockDbSet.AsQueryable().GetEnumerator().Returns(queryStudent.GetEnumerator());

            mockEntity.Student = mockDbSet;

            var studentService = new StudentService(mockEntity);

            studentService.GetStuden();
        }
    }
}