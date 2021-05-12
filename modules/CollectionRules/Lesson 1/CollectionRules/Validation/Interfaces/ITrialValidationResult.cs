namespace CollectionRules.Validation
{
    public interface ITrialValidationResult<TTrial>
    {
        int Index { get; }

        string Message { get; }

        TTrial Trial { get; }
    }
}
