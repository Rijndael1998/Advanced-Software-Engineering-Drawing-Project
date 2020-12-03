namespace Advanced_Software_Engineering.Verbs.Flow {

    public interface IVerbChunk : IVerb {

        void AddVerb(IVerb verb);

        void ExecuteVerb();

        string GetDescription();
    }
}