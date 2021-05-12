namespace CollectionRules.Validation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TrialValidator<TTrial> : ITrialValidator<TTrial>
    {
        private readonly List<ITrialRule<TTrial>> _rules = new List<ITrialRule<TTrial>>();

        public TrialValidator()
        {

        }

        public void AddRule(ITrialRule<TTrial> rule)
        {
            _rules.Add(rule);
        }

        public async Task<List<ITrialValidationResult<TTrial>>> ValidateAsync(List<TTrial> trials)
        {
            var validationResults = new List<ITrialValidationResult<TTrial>>();

            foreach (var rule in _rules)
            {
                var ruleResults = await rule.ValidateAsync(trials);
                if (ruleResults.Count > 0)
                {
                    validationResults.AddRange(ruleResults);
                }
            }

            return validationResults;
        }
    }
}
