// See https://aka.ms/new-console-template for more information
using StatePattern;

Console.WriteLine("Application state working");


/// <summary>
///  Async call to server
/// </summary>
CaseContext caseContext = new () { IsLocal = true, IsWhq = false, IsHostBranch = false };

MainEntity mainEntity = new();

mainEntity.OnInitialized(caseContext);

Console.WriteLine(mainEntity.IsPersonReadonly);
Console.WriteLine(mainEntity.IsCorporationVisible);


