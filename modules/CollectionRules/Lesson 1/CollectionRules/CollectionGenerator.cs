namespace CollectionRules
{
    using CollectionRules.Rules;
    using CollectionRules.Validation;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class CollectionGenerator
    {
        public async Task<List<int>> GenerateNumbersAsync(int randomizationSeed, int totalItems, int totalOptions)
        {
            // We are trying to reach an even spread
            var availableItems = totalOptions;
            var availableOptions = new List<int>();
            var occurancePerOption = Math.DivRem(totalItems, availableItems, out var remainder);
            if (remainder != 0)
            {
                throw new NotSupportedException($"Number of trials ('{totalItems}') is not dividable by available items ('{availableItems}'). Not all items will be shown equally");
            }

            for (var availableItem = 0; availableItem < availableItems; availableItem++)
            {
                for (var i = 0; i < occurancePerOption; i++)
                {
                    availableOptions.Add(availableItem);
                }
            }

            var validator = new TrialValidator<int>();

            validator.AddRule(new NoEvenNumbersAfterEachother((option1, option2) =>
            {
                if ((option1 % 2 == 0) && (option2 % 2 == 0))
                {
                    return false;
                }

                return true;
            }));

            validator.AddRule(new NoMoreThanMaxItemsUnderValueInRow
            {
                MaximumValue = availableItems / 2
            });

            // Sometimes we can't find a good set, in that case we need to use a different randomizing algorithm
            for (var randomizerIndex = 0; randomizerIndex < 1000; randomizerIndex += 10)
            {
                var randomizer = new Random(randomizationSeed + randomizerIndex);
                var existingIndexes = new List<int>();

                // Generate "random" list of items
                for (var i = 1; i <= totalItems; i++)
                {
                    while (true)
                    {
                        var newIndex = randomizer.Next(0, totalItems);
                        if (!existingIndexes.Contains(newIndex))
                        {
                            existingIndexes.Add(newIndex);
                            break;
                        }
                    }
                }

                var optimizedIndexes = new List<int>(existingIndexes);

                //=========================================================================================
                // NOTE: Implementation goes here
                await OptimizeCollection_First(validator, availableOptions, optimizedIndexes);
                //=========================================================================================

                var finalValues = new List<int>(totalItems);

                foreach (var index in optimizedIndexes)
                {
                    finalValues.Add(availableOptions[index]);
                }

                if (await validator.IsValidAsync(finalValues))
                {
                    return finalValues;
                }
            }

            throw new NotSupportedException("Collection could not be solved");
        }
    }
}
