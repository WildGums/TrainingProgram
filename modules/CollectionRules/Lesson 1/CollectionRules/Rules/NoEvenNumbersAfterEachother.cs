namespace CollectionRules.Rules
{
    using CollectionRules.Validation;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NoEvenNumbersAfterEachother : TrialRuleBase<int>
    {
        private readonly Func<int, int, bool> _validationFunc;

        public NoEvenNumbersAfterEachother(Func<int, int, bool> validationFunc)
        {
            _validationFunc = validationFunc;
        }

        public override async Task<List<ITrialValidationError<int>>> ValidateAsync(List<int> items)
        {
            var validationResults = new List<ITrialValidationError<int>>();

            for (var i = 1; i < items.Count; i++)
            {
                var lastValue = items[i - 1];
                var currentValue = items[i];

                if (!_validationFunc(lastValue, currentValue))
                {
                    validationResults.Add(new TrialValidationError<int>(i, $"Item '{i}' has the same even value '{currentValue}' as the previous item '{lastValue}'", currentValue));
                }
            }

            return validationResults;
        }
    }
}
