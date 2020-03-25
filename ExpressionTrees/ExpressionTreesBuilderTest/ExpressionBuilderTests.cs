using System;
using System.Linq;
using System.Linq.Expressions;
using ExpressionTreesBuilder;
using ExpressionTreesBuilderTest.Helpers;
using NUnit.Framework;

namespace ExpressionTreesBuilderTest
{
    public class ExpressionBuilderTests
    {
        private const string ExpectedElementName = "search name";
        private const int ExpectedElementCount = 11;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AndAlso_AddCondition_ReturnsCorrectCount()
        {
            // arrange
            var expectedElement = TestModel.GetNew(ExpectedElementName, ExpectedElementCount);

            var collection = TestModel
                .GetCollection(5, expectedElement)
                .AsQueryable();

            Expression<Func<TestModel, bool>> leftExpression = a => a.Name == ExpectedElementName;
            Expression<Func<TestModel, bool>> rightExpression = a => a.Count == ExpectedElementCount;

            // act
            var expression = leftExpression.AndAlso(rightExpression);
            var result = collection.Where(expression);

            // assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AndAlso_AddCondition_ReturnsCorrectElement()
        {
            // arrange
            var expectedElement = TestModel.GetNew(ExpectedElementName, ExpectedElementCount);

            var collection = TestModel
                .GetCollection(5, expectedElement)
                .AsQueryable();

            Expression<Func<TestModel, bool>> leftExpression = a => a.Name == ExpectedElementName;
            Expression<Func<TestModel, bool>> rightExpression = a => a.Count == ExpectedElementCount;

            // act
            var expression = leftExpression.AndAlso(rightExpression);
            var result = collection.Where(expression).First();

            // assert
            Assert.AreEqual(result.Count, ExpectedElementCount);
        }

        [Test]
        public void Or_AddCondition_ReturnsCorrectCount()
        {
            // arrange
            var firstElement = TestModel.GetNew(ExpectedElementName);
            var secondElement = TestModel.GetNew(ExpectedElementCount);

            var collection = TestModel
                .GetCollection(5, firstElement, secondElement)
                .AsQueryable();

            Expression<Func<TestModel, bool>> leftExpression = a => a.Name == ExpectedElementName;
            Expression<Func<TestModel, bool>> rightExpression = a => a.Count == ExpectedElementCount;

            // act
            var expression = leftExpression.Or(rightExpression);
            var result = collection.Where(expression);

            // assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void Or_AddCondition_ReturnsCorrectElements()
        {
            // arrange
            var firstElement = TestModel.GetNew(ExpectedElementName);
            var secondElement = TestModel.GetNew(ExpectedElementCount);

            var collection = TestModel
                .GetCollection(5, firstElement, secondElement)
                .AsQueryable();

            Expression<Func<TestModel, bool>> leftExpression = a => a.Name == ExpectedElementName;
            Expression<Func<TestModel, bool>> rightExpression = a => a.Count == ExpectedElementCount;

            // act
            var expression = leftExpression.Or(rightExpression);
            var result = collection.Where(expression).ToList();

            // assert
            Assert.Contains(firstElement, result);
            Assert.Contains(secondElement, result);
        }
    }
}