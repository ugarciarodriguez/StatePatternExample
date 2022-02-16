// See https://aka.ms/new-console-template for more information
using StatePattern;

Console.WriteLine("Application state working");

CaseContext caseContext = new () { IsLocal = true, IsWhq = false };

MainEntity mainEntity = new();

new StateResolver<MainEntity>()
    .AddPropertyState(x => x.IsPersonReadonly, caseContext.IsWhq)
    .AddPropertyState(x => x.IsCorporationVisible, caseContext.IsLocal)
    .ApplyStates(mainEntity);


Console.WriteLine(mainEntity.IsPersonReadonly);
Console.WriteLine(mainEntity.IsCorporationVisible);


