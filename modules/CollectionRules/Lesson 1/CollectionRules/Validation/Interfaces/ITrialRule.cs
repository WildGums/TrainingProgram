namespace CollectionRules.Validation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrialRule<TTrial>
    {
        Task<List<ITrialValidationError<TTrial>>> ValidateAsync(List<TTrial> trials);
    }
}
