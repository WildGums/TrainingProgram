namespace CollectionRules.Validation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class TrialRuleBase<TTrial> : ITrialRule<TTrial>
    {
        public abstract Task<List<ITrialValidationError<TTrial>>> ValidateAsync(List<TTrial> trials);
    }
}
