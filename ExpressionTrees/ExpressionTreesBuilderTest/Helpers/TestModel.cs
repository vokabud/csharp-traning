using System;
using System.Collections.Generic;

namespace ExpressionTreesBuilderTest.Helpers
{
    class TestModel
    {
        public static TestModel GetNew()
            => new TestModel(
                Guid.NewGuid().ToString(),
                new Random().Next(),
                Guid.NewGuid());

        public static TestModel GetNew(
            string name,
            int count)
            => new TestModel(
                name,
                count,
                Guid.NewGuid());

        public static TestModel GetNew(
            string name) 
            => new TestModel(
                name,
                new Random().Next(),
                Guid.NewGuid());

        public static TestModel GetNew(
            int count)
            => new TestModel(
                Guid.NewGuid().ToString(),
                count,
                Guid.NewGuid());

        public static IEnumerable<TestModel> GetCollection(
            int count, params TestModel[] tasks)
        {
            var result = new List<TestModel>();

            for (var i = 0; i < tasks.Length; i++)
            {
                result.Add(tasks[i]);
            }

            for (var i = 0; i < count; i++)
            {
                result.Add(TestModel.GetNew());
            }

            return result;
        }

        public TestModel(
            string name, 
            int count, 
            Guid id)
        {
            Name = name;
            Count = count;
            Id = id;
        }

        public string Name { get; }

        public int Count { get; }

        public Guid Id { get;  }
    }
}
