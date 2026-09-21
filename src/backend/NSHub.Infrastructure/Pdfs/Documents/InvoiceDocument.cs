using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace PlanetHub.Infrastructure.Pdfs.Documents;

public class InvoiceDocument : IDocument
{
    private readonly Invoice _invoice;

    public InvoiceDocument(Invoice invoice)
    {
        _invoice = invoice;
    }

    public DocumentMetadata GetMetadata() => new DocumentMetadata
    {
        Title = $"Invoice {_invoice.Id}"
    };

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(40);

            page.Header().Text($"Invoice {_invoice.Id}")
                .FontSize(20).Bold();

            page.Content().Column(col =>
            {
                col.Item().Text($"Date: {_invoice.Date:dd/MM/yyyy}");
                col.Item().Text($"Customer: {_invoice.CustomerName}");

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(3);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(1);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Description").Bold();
                        header.Cell().Text("Qty").Bold();
                        header.Cell().Text("Price").Bold();
                        header.Cell().Text("Total").Bold();
                    });

                    foreach (var line in _invoice.Lines)
                    {
                        table.Cell().Text(line.Description);
                        table.Cell().Text(line.Quantity.ToString());
                        table.Cell().Text($"{line.UnitPrice:C}");
                        table.Cell().Text($"{line.Total:C}");
                    }
                });

                col.Item().PaddingTop(20).AlignRight().Text(
                    $"TOTAL: {_invoice.Lines.Sum(x => x.Total):C}"
                ).FontSize(16).Bold();
            });

            page.Footer().AlignCenter().Text("Generated with QuestPDF");
        });
    }
}
