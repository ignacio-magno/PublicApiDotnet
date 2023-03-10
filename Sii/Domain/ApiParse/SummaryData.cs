namespace Sii.Domain.ApiParse;

internal class SummaryData
{
    public IEnumerable<Resume>? Data { get; set; }

    public async Task ForEachResumeAsync(Func<Resume, Task> setFacturasVenta)
    {
        if (Data == null)
            return;

        var tasks = new List<Task>();
        foreach (var resume in Data)
        {
            tasks.Add(setFacturasVenta(resume));
        }

        await Task.WhenAll(tasks);
    }
}