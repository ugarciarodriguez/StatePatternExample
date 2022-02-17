namespace StatePattern
{
    public class MainEntity : StateResolver<MainEntity>
    {
        public MainEntity()
        {
            AddPropertyState<CaseContext>(x => x.IsPersonReadonly, y => y.IsWhq && y.IsHostBranch);
            AddPropertyState<CaseContext>(x => x.IsCorporationVisible, y => y.IsLocal);
        }
        
        protected override MainEntity Entity => this;

        public bool IsPersonReadonly { get; set; }

        public bool IsCorporationVisible { get; set; }

        public void OnInitialized(CaseContext context)
        {
            ApplyStates(context);
        }
    }
}
