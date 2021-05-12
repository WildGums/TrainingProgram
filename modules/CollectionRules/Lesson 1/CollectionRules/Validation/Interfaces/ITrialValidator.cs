namespace CollectionRules.Validation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrialValidator<TTrial>
    {
        void AddRule(ITrialRule<TTrial> rule);

        Task<List<ITrialValidationResult<TTrial>>> ValidateAsync(List<TTrial> trials);
    }
}
