namespace CollectionRules.Validation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ITrialValidatorExtensions
    {
        public static async Task<bool> IsValidAsync<TTrial>(this ITrialValidator<TTrial> trialValidator, List<TTrial> trials)
        {
            var results = await trialValidator.ValidateAsync(trials);
            return !results.Any();
        }

        public static async Task<bool> IsValidForSpecificIndexesAsync<TTrial>(this ITrialValidator<TTrial> trialValidator, List<TTrial> trials, params int[] indexes)
        {
            var results = await ValidateIndexesAsync(trialValidator, trials, indexes);
            return !results.Any();
        }

        public static async Task<List<ITrialValidationResult<TTrial>>> ValidateIndexesAsync<TTrial>(this ITrialValidator<TTrial> trialValidator, List<TTrial> trials, params int[] indexes)
        {
            var validationResults = await trialValidator.ValidateAsync(trials);

            var finalValidationResults = new List<ITrialValidationResult<TTrial>>();

            foreach (var validationResult in validationResults)
            {
                if (indexes.Contains(validationResult.Index))
                {
                    finalValidationResults.Add(validationResult);
                }
            }

            return finalValidationResults;
        }
    }
}
