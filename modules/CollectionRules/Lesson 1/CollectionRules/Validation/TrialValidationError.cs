namespace CollectionRules.Validation
{
    public class TrialValidationError<TTrial> : ITrialValidationError<TTrial>
    {
        public TrialValidationError(int index, string message, TTrial trial)
        {
            Index = index;
            Message = message;
            Trial = trial;
        }

        public int Index { get; private set; }

        public string Message { get; private set; }

        public TTrial Trial { get; private set; }

        public override string ToString()
        {
            return $"[{Index}] {Message}";
        }
    }
}
