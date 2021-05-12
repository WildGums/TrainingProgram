namespace CollectionRules
{
    using Catel.Collections;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static VerifyNUnit.Verifier;

    [TestFixture]
    public class CollectionFacts
    {
        [TestCase(8, 8, 1)]
        [TestCase(16, 8, 2)]
        [TestCase(24, 8, 3)]
        [TestCase(32, 8, 4)]
        [TestCase(40, 8, 5)]
        [TestCase(16, 16, 1)]
        [TestCase(32, 16, 2)]
        public async Task EveryOptionShouldShowEquallyForNumberOfItems(int totalItems, int totalOptions, int expectedOccurrencesPerOption)
        {
            var sessionMap = new Dictionary<int, List<int>>();

            var collectionGenerator = new CollectionGenerator();

            // Run for several sessions
            for (var i = 0; i < 10; i++)
            {
                var collection = await collectionGenerator.GenerateNumbersAsync(i, totalItems, totalOptions);

                var dictionary = new Dictionary<int, int>();

                for (var j = 0; j < collection.Count; j++)
                {
                    var item = collection[j];

                    if (!dictionary.ContainsKey(item))
                    {
                        dictionary[item] = 0;
                    }

                    dictionary[item]++;
                }

                Assert.AreEqual(totalOptions, dictionary.Count, $"Iteration {i}");

                foreach (var key in dictionary.Keys)
                {
                    Assert.AreEqual(expectedOccurrencesPerOption, dictionary[key], $"Item: '{key}' | Iteration {i}");
                }

                sessionMap[i] = new List<int>(collection);
            }

            // Check we did not generate equal sessions
            for (var i = 0; i < sessionMap.Count; i++)
            {
                var session = sessionMap.ElementAt(i);
                var sessionValues = session.Value;

                for (var j = 0; j < sessionMap.Count; j++)
                {
                    if (j == i)
                    {
                        // Don't compare ourselves
                        continue;
                    }

                    var otherSession = sessionMap.ElementAt(j);
                    var otherSessionValues = otherSession.Value;

                    Assert.IsFalse(CollectionHelper.IsEqualTo(sessionValues, otherSessionValues), $"Session '{session.Key}' generated exact same results as '{otherSession.Key}'");
                }
            }

            await Verify(sessionMap);
        }
    }
}