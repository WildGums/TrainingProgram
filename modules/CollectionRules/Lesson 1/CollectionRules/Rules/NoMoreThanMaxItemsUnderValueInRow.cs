namespace CollectionRules.Rules
{
    using CollectionRules.Validation;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NoMoreThanMaxItemsUnderValueInRow : TrialRuleBase<int>
    {
        public NoMoreThanMaxItemsUnderValueInRow()
        {
            MaximumValue = 4;
            MaximumOccurrances = 3;
        }

        public int MaximumValue { get; set; }

        public int MaximumOccurrances { get; set; }

        public override async Task<List<ITrialValidationError<int>>> ValidateAsync(List<int> items)
        {
            var validationResults = new List<ITrialValidationError<int>>();

            var underNumberCount = 0;

            for (var j = 0; j < items.Count; j++)
            {
                var itemValue = items[j];
                if (itemValue < underNumberCount)
                {
                    underNumberCount++;
                }
                else
                {
                    underNumberCount = 0;
                }

                if (underNumberCount > MaximumOccurrances)
                {
                    validationResults.Add(new TrialValidationError<int>(j, $"Found '{underNumberCount}' items in a row where maximum allowed is '{MaximumValue}'", itemValue));
                }
            }

            return validationResults;
        }
    }
}
